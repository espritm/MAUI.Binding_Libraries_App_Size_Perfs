using System;
using System.ComponentModel;
using Foundation;
using ESignature.Interfaces;
using ESignature.EventArguments.Internals;
using ESignature.Interfaces;
using ESignature.Interfaces.Internals;
using UIKit;
using Wysiwys_framework_to_DOTNET;
using SmartContract_xcframework_to_DOTNET;
using ESignature.EventArguments;

namespace ESignature.Implementations.Internals
{
    internal class WysiwysController : IWysiwysController
    {
        public event EventHandler<IDocumentPreparedEventArgs> DocumentPreparedEventHandler;
        public event EventHandler<IProcessDidFinishEventArgs> ProcessDidFinishEventHandler;
        public event EventHandler<IProcessDidFailWithErrorEventArgs> ProcessDidFailWithErrorEventHandler;
        public event EventHandler MissingRequiredFormFieldEventHandler;
        public event EventHandler SignatureFormFieldRequiresManualFillingEventHandler;
        public event EventHandler SignatureRequiresPositioningEventHandler;
        public event EventHandler SelectSignatureFormFieldEventHandler;
        public event EventHandler ConfirmationRequiredEventHandler;
        public event EventHandler WillPrepareDocumentEventHandler;
        public event EventHandler DidSelectSignatureFormFieldEventHandler;
        public event EventHandler DocumentDidLoadEventHandler;
        public event EventHandler<IDidPageChangedEventArgs> DidPageChangedEventHandler;

        WYSIWYSController WysiwysNativeController;
        WYSSignatureConfiguration WysiwysSignatureConfiguration;
        WYSViewerConfiguration WysiwysViewerConfiguration;
        UIView nativePdfViewerView;
        SignaturePdfViewer mauiPdfViewerView;

        public WysiwysController()
        {
        }

        public void InitSDK(string senseUserLogin, string wysiwysStorageKey, string wysiwysLicense)
        {
            WYSPdfViewerConfiguration config = new WYSPdfViewerConfiguration();

            config.Username = senseUserLogin;

            //64 characters !!
            config.StorageKey = NSData.FromString(wysiwysStorageKey);

            config.License = wysiwysLicense;

            this.WysiwysNativeController = new WYSIWYSController(config); //Crash the app if user login, logout, and login again...	
                                                                            //at <unknown> <0xffffffff>
                                                                            //at ApiDefinitions.Messaging: NativeHandle_objc_msgSend_NativeHandle < 0x001cd >
                                                                            //at Wysiwys_framework_to_DOTNET.WYSIWYSController:.ctor < 0x00392 >
        }

        public bool HasSignatures()
        {
            bool bRes = WYSIWYSController.HasSignatureStored();

            return bRes;
        }

        public SignatureSettingsPage GetSignatureSettingsPage(/*MauiContext mauiContext*/)
        {
            UITableViewController nativeController = WYSIWYSController.OpenSignatureSettings();

            SignatureSettingsPageHandler mauiHandler = new SignatureSettingsPageHandler();
            mauiHandler.SetNativeSignatureSettingsUITableViewController(nativeController);
            //mauiHandler.SetMauiContext(mauiContext);

            SignatureSettingsPage mauiPage = new SignatureSettingsPage();
            //mauiPage.Handler = mauiHandler;
            mauiPage.NativeViewController = nativeController;

            return mauiPage;
        }

        private void InitViewerConfig()
        {
            //Init viewer config
            WysiwysViewerConfiguration = new WYSViewerConfiguration();
            WysiwysViewerConfiguration.ContinuousScrolling = true;
            WysiwysViewerConfiguration.VerticalScrolling = true;

            //Register Viewer delegates
            WYSViewerDelegate viewerDelegate = new WYSViewerDelegate();
            viewerDelegate.DocumentDidLoadEventHandler += (s, a) => { DocumentDidLoad(); };
            viewerDelegate.DidPageChangedEventHandler += (s, a) => { DidPageChanged(a.PageIndex); };
            WysiwysViewerConfiguration.WeakViewerDelegate = viewerDelegate;
        }

        private void InitSignatureConfig(string userDisplayName, string geolocation, string signatureDescription, string signatureReason, string dateTimePattern)
        {
            //Init signature config
            WysiwysSignatureConfiguration = new WYSSignatureConfiguration();
            WysiwysSignatureConfiguration.SignatureAppearance.SignerName = userDisplayName;
            WysiwysSignatureConfiguration.SignatureAppearance.SignerNameFont = UIFont.FromName("helvetica", 48);
            WysiwysSignatureConfiguration.SignatureAppearance.HandwrittenSignatureEnabled = true;
            WysiwysSignatureConfiguration.SignatureAppearance.SignatureDescription = signatureDescription;
            WysiwysSignatureConfiguration.SignatureAppearance.SignatureDescriptionFont = UIFont.FromName("Helvetica-Bold", 28);
            WysiwysSignatureConfiguration.SignatureAppearance.DateFont = UIFont.FromName("helvetica", 28);
            WysiwysSignatureConfiguration.SignatureAppearance.DateTimePattern = dateTimePattern;

            //Init signature attribute reason "signed by xxx"
            if (!string.IsNullOrWhiteSpace(signatureReason))
                WysiwysSignatureConfiguration.SignatureAttributes.SignatureReason = signatureReason;

            //Init signature attribute geolocation
            if (!string.IsNullOrWhiteSpace(geolocation))
                WysiwysSignatureConfiguration.SignatureAttributes.SignatureLocation = geolocation;

            //Register signature config delegates
            WYSSignatureProcessDelegate signatureProcessDelegate = new WYSSignatureProcessDelegate();
            signatureProcessDelegate.DocumentPreparedEventHandler += (s, a) => { DocumentPreparedForSignature(a.DocumentDigest, a.Reason); };
            signatureProcessDelegate.ProcessDidFinishEventHandler += (s, a) => { ProcessDidFinishWithReason(a.Reason, a.Document); };
            signatureProcessDelegate.ProcessDidFailWithErrorEventHandler += (s, a) => { ProcessDidFailWithError(a.Error); };
            signatureProcessDelegate.MissingRequiredFormFieldEventHandler += (s, a) => { MissingRequiredFormField(); };
            signatureProcessDelegate.SignatureFormFieldRequiresManualFillingEventHandler += (s, a) => { SignatureFormFieldRequiresManualFilling(); };
            signatureProcessDelegate.SignatureRequiresPositioningEventHandler += (s, a) => { SignatureRequiresPositioning(); };
            signatureProcessDelegate.SelectSignatureFormFieldEventHandler += (s, a) => { SelectSignatureFormField(); };
            signatureProcessDelegate.ConfirmationRequiredEventHandler += (s, a) => { ConfirmationRequired(); };
            signatureProcessDelegate.WillPrepareDocumentEventHandler += (s, a) => { WillPrepareDocument(); };
            signatureProcessDelegate.DidSelectSignatureFormFieldEventHandler += (s, a) => { DidSelectSignatureFormField(); };
            WysiwysSignatureConfiguration.WeakSignatureProcessDelegate = signatureProcessDelegate;
        }

        public async Task<ISignaturePdfViewer> OpenDocument(Stream documentDigest, String contractID, string userDisplayName, string geolocation, string signatureDescription, string signatureReason, string dateTimePattern, ESignatureReason reason)
        {
            //set WysiwysViewerConfiguration
            InitViewerConfig();

            //Set WysiwysSignatureConfiguration
            InitSignatureConfig(userDisplayName, geolocation, signatureDescription, signatureReason, dateTimePattern);

            NSError nsError;

            nativePdfViewerView = WysiwysNativeController.OpenDocument(NSData.FromStream(documentDigest), contractID, WysiwysViewerConfiguration, WysiwysSignatureConfiguration, out nsError);

            if (nsError != null) 
            {
                ProcessDidFailWithError(nsError.LocalizedDescription);
                return null;
            }
            else if (nativePdfViewerView == null)
            {
                ProcessDidFailWithError("WysiwysNativeController.OpenDocument returned null instead of a UIView.");
                return null;
            }

            SignaturePdfViewerHandler mauiHandler = new SignaturePdfViewerHandler();
            mauiHandler.SetNativeView(nativePdfViewerView);

            mauiPdfViewerView = new SignaturePdfViewer();
            mauiPdfViewerView.Handler = mauiHandler;

            return mauiPdfViewerView;
        }

        public void AcceptDocument()
        {
            WysiwysNativeController?.AcceptDocument();
        }

        public void RefuseDocument()
        {
            WysiwysNativeController?.RefuseDocument();
        }

        public void ConfirmSignature()
        {
            WysiwysNativeController?.ConfirmSignature();
        }

        public void EmbedSignature(String contractID, Stream signature)
        {
            WysiwysNativeController?.EmbedSignature(contractID, WysiwysSignatureConfiguration, NSData.FromStream(signature));
        }

        public void DisposeDocument(String contractID)
        {
            WysiwysNativeController?.DisposeDocument(contractID);
        }

        public void SetPageIndex(int pageIndex)
        {
            WysiwysNativeController?.SetPageIndex(pageIndex, true);
        }

        public int GetPageIndex()
        {
            return WysiwysNativeController?.PageIndex ?? -1;
        }

        public int GetPageCount()
        {
            return WysiwysNativeController?.PageCount ?? -1;
        }


        #region Events Handlers for weak delegates
        public void DocumentDidLoad()
        {
            DocumentDidLoadEventHandler?.Invoke(this, new EventArgs());
        }

        public void DidPageChanged(int pageIndex)
        {
            DidPageChangedEventHandler?.Invoke(this, new DidPageChangedEventArgs(pageIndex));
        }

        public void DocumentPreparedForSignature(Stream documentDigest, string reason)
        {
            DocumentPreparedEventHandler?.Invoke(this, new DocumentPreparedEventArgs(documentDigest, reason, null));
        }

        public void ProcessDidFinishWithReason(string reason, Stream document)
        {
            ProcessDidFinishEventHandler?.Invoke(this, new ProcessDidFinishEventArgs(reason, document, null));
        }

        public void ProcessDidFailWithError(string error)
        {
            //Fail. Propagate with event ProcessDidFailWithError
            ProcessDidFailWithErrorEventHandler?.Invoke(this, new ProcessDidFailWithErrorEventArgs(error));
        }

        public void MissingRequiredFormField()
        {
            //should never happen. If happen, technical error, ebanking team should be prompted
            MissingRequiredFormFieldEventHandler?.Invoke(this, new EventArgs());
        }

        public void SignatureFormFieldRequiresManualFilling()
        {
            //should never happen. If happen, technical error, ebanking team should be prompted
            SignatureFormFieldRequiresManualFillingEventHandler?.Invoke(this, new EventArgs());
        }

        public void SignatureRequiresPositioning()
        {
            //should never happen. If happen, technical error, ebanking team should be prompted
            SignatureRequiresPositioningEventHandler?.Invoke(this, new EventArgs());
        }

        public void SelectSignatureFormField()
        {
            //didSelectSignatureFormField() //simulate first signature field selection
            SelectSignatureFormFieldEventHandler?.Invoke(this, new EventArgs());
        }

        public void ConfirmationRequired()
        {
            ConfirmationRequiredEventHandler?.Invoke(this, new EventArgs());
        }

        public void WillPrepareDocument()
        {
            WillPrepareDocumentEventHandler?.Invoke(this, new EventArgs());
        }

        public void DidSelectSignatureFormField()
        {
            DidSelectSignatureFormFieldEventHandler?.Invoke(this, new EventArgs());
        }

        public async Task<ISignaturePdfViewer> InitView()
        {
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                nativePdfViewerView = new UIView(new CoreGraphics.CGRect(0, 0, 5, 5));

                SignaturePdfViewerHandler mauiHandler = new SignaturePdfViewerHandler();
                mauiHandler.SetNativeView(nativePdfViewerView);

                mauiPdfViewerView = new SignaturePdfViewer();
                mauiPdfViewerView.Handler = mauiHandler;
            });

            return mauiPdfViewerView;
        }
        #endregion

        #region Classes to handle native weak delegates
        //Weak delegate for WYSViewerDelegate
        private class WYSViewerDelegate : NSObject
        {
            public event EventHandler DocumentDidLoadEventHandler;
            public event EventHandler<IDidPageChangedEventArgs> DidPageChangedEventHandler;

            [Export("documentDidLoad")]
            public void DocumentDidLoad()
            {
                DocumentDidLoadEventHandler?.Invoke(this, new EventArgs());
            }

            [Export("didPageChanged:")]
            public void DidPageChanged(int pageIndex)
            {
                DidPageChangedEventHandler?.Invoke(this, new DidPageChangedEventArgs(pageIndex));
            }
        }

        //Weak delegate for WYSSignatureProcessDelegate
        private class WYSSignatureProcessDelegate : NSObject
        {
            public event EventHandler<IDocumentPreparedEventArgs> DocumentPreparedEventHandler;
            public event EventHandler<IProcessDidFinishEventArgs> ProcessDidFinishEventHandler;
            public event EventHandler<IProcessDidFailWithErrorEventArgs> ProcessDidFailWithErrorEventHandler;
            public event EventHandler MissingRequiredFormFieldEventHandler;
            public event EventHandler SignatureFormFieldRequiresManualFillingEventHandler;
            public event EventHandler SignatureRequiresPositioningEventHandler;
            public event EventHandler SelectSignatureFormFieldEventHandler;
            public event EventHandler ConfirmationRequiredEventHandler;
            public event EventHandler WillPrepareDocumentEventHandler;
            public event EventHandler DidSelectSignatureFormFieldEventHandler;

            [Export("processDidFailWithError:")]
            public void ProcessDidFailWithError(NSError error)
            {
                //Fail. Propagate with event ProcessDidFailWithError
                ProcessDidFailWithErrorEventHandler?.Invoke(this, new ProcessDidFailWithErrorEventArgs(error.LocalizedDescription));
            }

            [Export("missingRequiredFormField")]
            public void MissingRequiredFormField()
            {
                //should never happen. If happen, technical error, ebanking team should be prompted
                MissingRequiredFormFieldEventHandler?.Invoke(this, new EventArgs());
            }

            [Export("signatureFormFieldRequiresManualFilling")]
            public void SignatureFormFieldRequiresManualFilling()
            {
                //should never happen. If happen, technical error, ebanking team should be prompted
                SignatureFormFieldRequiresManualFillingEventHandler?.Invoke(this, new EventArgs());
            }

            [Export("signatureRequiresPositioning")]
            public void SignatureRequiresPositioning()
            {
                //should never happen. If happen, technical error, ebanking team should be prompted
                SignatureRequiresPositioningEventHandler?.Invoke(this, new EventArgs());
            }

            [Export("selectSignatureFormField")]
            public void SelectSignatureFormField()
            {
                //didSelectSignatureFormField() //simulate first signature field selection
                SelectSignatureFormFieldEventHandler?.Invoke(this, new EventArgs());
            }

            [Export("confirmationRequired")]
            public void ConfirmationRequired()
            {
                ConfirmationRequiredEventHandler?.Invoke(this, new EventArgs());
            }

            [Export("willPrepareDocument")]
            public void WillPrepareDocument()
            {
                WillPrepareDocumentEventHandler?.Invoke(this, new EventArgs());
            }

            [Export("didSelectSignatureFormField")]
            public void DidSelectSignatureFormField()
            {
                DidSelectSignatureFormFieldEventHandler?.Invoke(this, new EventArgs());
            }

            [Export("documentPreparedForSignature:withReason:")]
            public void DocumentPreparedForSignature(NSData documentDigest, string reason)
            {
                DocumentPreparedEventHandler?.Invoke(this, new DocumentPreparedEventArgs(documentDigest.AsStream(), reason, null));
            }

            [Export("processDidFinishWithReason:andDocument:")]
            public void ProcessDidFinishWithReason(string reason, NSData document)
            {
                ProcessDidFinishEventHandler?.Invoke(this, new ProcessDidFinishEventArgs(reason, document.AsStream(), null));
            }
        }
        #endregion
    }
}