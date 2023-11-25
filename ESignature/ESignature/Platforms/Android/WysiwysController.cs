using System;
using CH.Sysmosoft.Sense.Smartcontract.Sdk.Wysiwys;
using CH.Sysmosoft.Sense.Smartcontract.Sdk.Wysiwys.Config;
using CH.Sysmosoft.Sense.Smartcontract.Sdk.Wysiwys.Provider;
using ESignature.Interfaces;
using ESignature.Interfaces.Internals;
using ESignature.Platforms.Android.Callbacks;
using static CH.Sysmosoft.Sense.Smartcontract.Sdk.Wysiwys.Config.PdfViewerConfiguration;
using ESignature.EventArguments;
using ESignature.EventArguments.Internals;
using Android.Widget;
using static Android.Views.ViewGroup;
using Android.Runtime;
using Android.Views;
using Android.Content;

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

        ISignatureProvider headlessSignatureProvider;
        bool isInit;
        ViewerConfiguration viewerConfiguration;
        SignatureConfiguration signatureConfiguration;
        PdfViewer nativePdfViewerView;
        SignaturePdfViewer mauiPdfViewerView;


        public WysiwysController()
        {
        }

        public void InitSDK(string senseUserLogin, string wysiwysStorageKey, string wysiwysLicense)
        {
            PdfViewerConfigurationBuilder builder = PdfViewerConfiguration.Builder();
            builder.Licence(wysiwysLicense);
            builder.StorageKey(System.Text.Encoding.UTF8.GetBytes(wysiwysStorageKey));
            builder.Username(senseUserLogin);

            PdfViewerConfiguration pdfViewerConfiguration = builder.Build();

            PdfViewer.Initialize(/*Android.App.Application.Context*/Platform.CurrentActivity, pdfViewerConfiguration);

            isInit = true;

            headlessSignatureProvider = HeadlessSignatureController.SignatureProvider;
        }

        public bool HasSignatures()
        {
            try
            {
                if (headlessSignatureProvider == null)
                    return false;

                IDictionary<Java.Lang.Long, Android.Graphics.Bitmap> signatures = headlessSignatureProvider.Signatures;

                if (signatures != null && signatures.Count >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //Does not return the view, but display the SDK Signature Page over the actual app page
        public SignatureSettingsPage GetSignatureSettingsPage()
        {
            PdfViewer.OpenSignatureSettings(Platform.CurrentActivity as AndroidX.Fragment.App.FragmentActivity, new SignaturePickedListenerCallback
            {
                SignaturePicked = () =>
                {
                    //Nothing to do
                }
            });

            return null;
        }

        public void AcceptDocument()
        {
            nativePdfViewerView?.AcceptDocument();
        }

        private void InitViewerConfig()
        {
            //Init viewer config
            viewerConfiguration = new ViewerConfiguration();
            viewerConfiguration.ContinuousScrolling = true;
            viewerConfiguration.VerticalScrolling = true;

            //Register Viewer delegates
            viewerConfiguration.DocumentEventListener = new DocumentEventListenerCallback
            {
                DocumentLoaded = () =>
                {
                    DocumentDidLoadEventHandler?.Invoke(this, new EventArgs());
                },
                DocumentLoadFailed = (throwable) =>
                {

                },
                PageChanged = (pageIndex) =>
                {
                    DidPageChangedEventHandler?.Invoke(this, new DidPageChangedEventArgs(pageIndex));
                }
            };
        }

        private void InitSignatureConfig(string userDisplayName, string geolocation, string signatureDescription, string signatureReason, string dateTimePattern, ESignatureReason reason)
        {
            //Init signature config
            signatureConfiguration = new SignatureConfiguration();

            //Signature appearance
            SignatureConfiguration.SignatureAppearance signatureAppearance = new SignatureConfiguration.SignatureAppearance();
            signatureAppearance.HandwrittenSignatureEnabled = true;
            signatureAppearance.DateTimePattern = dateTimePattern;
            signatureAppearance.SignatureDescription = signatureDescription;
            signatureAppearance.SignerName = userDisplayName;
            //signatureAppearance.DateTimeFontSize = 28;
            //signatureAppearance.SignatureDescriptionFontSize = 28;    //thoses are commented in old native app
            //signatureAppearance.SignerNameFontSize = 48;
            signatureConfiguration.SetSignatureAppearance(signatureAppearance);

            //signature watermark
            if (reason == ESignatureReason.Reject)
            {
                SignatureConfiguration.WatermarkAppearance watermarkAppearance = new SignatureConfiguration.WatermarkAppearance();
                watermarkAppearance.Title = "refused";
                signatureConfiguration.SetWatermarkAppearance(watermarkAppearance);
            }
            
            //signature attribute : reason "signed by xxx" : geolocation
            SignatureConfiguration.SignatureAttributes signatureAttributes = new SignatureConfiguration.SignatureAttributes();
            if (!string.IsNullOrWhiteSpace(signatureReason))
                signatureAttributes.SignatureReason = signatureReason;
            if (!string.IsNullOrWhiteSpace(geolocation))
                signatureAttributes.SignatureLocation = geolocation;
            signatureConfiguration.SetSignatureAttributes(signatureAttributes);

            //Register signature config delegates
            signatureConfiguration.SignatureEventListener = new SignatureEventListenerCallback
            {
                ConfirmationRequired = () =>
                {
                    ConfirmationRequiredEventHandler?.Invoke(this, new EventArgs());
                },
                DocumentPreparedForSignature = (documentDigest) =>
                {
                    DocumentPreparedEventHandler?.Invoke(this, new DocumentPreparedEventArgs(new MemoryStream(documentDigest), null, null));
                },
                MissingRequiredFormField = () =>
                {
                    MissingRequiredFormFieldEventHandler?.Invoke(this, new EventArgs());
                },
                PreparingDocument = () =>
                {
                    WillPrepareDocumentEventHandler?.Invoke(this, new EventArgs());
                },
                ProcessFailed = (throwable) =>
                {
                    ProcessDidFailWithErrorEventHandler?.Invoke(this, new ProcessDidFailWithErrorEventArgs(throwable.Message));
                },
                ProcessFinished = (reason, document) =>
                {
                    ProcessDidFinishEventHandler?.Invoke(this, new ProcessDidFinishEventArgs(reason, new MemoryStream(document), null));
                },
                SelectSignatureFormField = () =>
                {
                    SelectSignatureFormFieldEventHandler?.Invoke(this, new EventArgs());
                },
                SignatureFormFieldRequiresManualFilling = () =>
                {
                    SignatureFormFieldRequiresManualFillingEventHandler?.Invoke(this, new EventArgs());
                },
                SignatureFormFieldSelected = () =>
                {
                    DidSelectSignatureFormFieldEventHandler?.Invoke(this, new EventArgs());
                },
                SignatureRequiresPositioning = () =>
                {
                    SignatureRequiresPositioningEventHandler?.Invoke(this, new EventArgs());
                },
            };
        }

        public async Task<ISignaturePdfViewer> InitView()
        {
            LayoutInflater layoutInflater = (LayoutInflater)Platform.CurrentActivity.GetSystemService(Context.LayoutInflaterService);
            Android.Views.View v = layoutInflater.Inflate(ESignature.Resource.Layout.esignature_view_to_inflate, null);
            nativePdfViewerView = v as PdfViewer;

            SignaturePdfViewerHandler mauiHandler = new SignaturePdfViewerHandler();
            mauiHandler.SetNativeView(nativePdfViewerView);

            mauiPdfViewerView = new SignaturePdfViewer();
            mauiPdfViewerView.Handler = mauiHandler;

            return mauiPdfViewerView;
        }

        public async Task<ISignaturePdfViewer> OpenDocument(Stream documentDigest, string contractID, string userDisplayName, string geolocation, string signatureDescription, string signatureReason, string dateTimePattern, ESignatureReason reason)
        {
            //set WysiwysViewerConfiguration
            InitViewerConfig();

            //Set WysiwysSignatureConfiguration
            InitSignatureConfig(userDisplayName, geolocation, signatureDescription, signatureReason, dateTimePattern, reason);

            //Call the open document method from the sdk
            nativePdfViewerView.OpenDocument(Platform.CurrentActivity as AndroidX.AppCompat.App.AppCompatActivity, documentDigest, contractID, viewerConfiguration, signatureConfiguration);

            return mauiPdfViewerView;
        }

        public void RefuseDocument()
        {
            nativePdfViewerView?.RefuseDocument();
        }

        public void ConfirmSignature()
        {
            nativePdfViewerView?.ConfirmSignature();
        }

        public void EmbedSignature(string contractID, Stream signature)
        {
            MemoryStream memoryStream = new MemoryStream();
            signature.CopyTo(signature);

            nativePdfViewerView?.EmbedSignature(memoryStream.ToArray());
        }

        public void DisposeDocument(string contractID)
        {
            nativePdfViewerView?.Dispose();
        }

        public void SetPageIndex(int pageIndex)
        {
            nativePdfViewerView?.SetPageIndex(pageIndex, true);
        }

        public int GetPageIndex()
        {
            return nativePdfViewerView?.PageIndex ?? 0;
        }

        public int GetPageCount()
        {
            return nativePdfViewerView?.PageCount ?? 0;
        }
    }
}

