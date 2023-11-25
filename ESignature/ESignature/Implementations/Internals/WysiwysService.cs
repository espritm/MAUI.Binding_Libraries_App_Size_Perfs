using System;
using System.ComponentModel;
using System.Xml.Linq;
using ESignature.Interfaces;
using ESignature.EventArguments.Internals;
using ESignature.Interfaces;
using ESignature.Interfaces.Internals;

namespace ESignature.Implementations.Internals
{
    internal class WysiwysService : IWysiwysService
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


        public enum Decision
        {
            [Description("accept")]
            Accept,
            [Description("refuse")]
            Refuse
        }

        private readonly ISenseService SenseService;
        readonly ILogerService LogerService;
        private readonly string WysiwysLicense;
        private bool isInit = false;
        private IWysiwysController WysiwysController;  //Platform specific
        IESignatureGeolocationProvider ESignatureGeolocationProvider;
        IESignatureUserDisplayProvider ESignatureUserDisplayProvider;
        IContract openedContract;
        ISignaturePdfViewer pdfViwer;

        public WysiwysService(ISenseService senseService, ILogerService logerService, String wysiwysLicense)
        {
            SenseService = senseService;
            WysiwysLicense = wysiwysLicense;
            WysiwysController = new WysiwysController();
            LogerService = logerService;

            WysiwysController.DocumentPreparedEventHandler += (s, a) => { DocumentPreparedEventHandler?.Invoke(this, new DocumentPreparedEventArgs(a.DocumentDigest, a.Reason, openedContract)); };
            WysiwysController.ProcessDidFinishEventHandler += (s, a) => { ProcessDidFinishEventHandler?.Invoke(this, new ProcessDidFinishEventArgs(a.Reason, a.Document, openedContract)); };
            WysiwysController.ProcessDidFailWithErrorEventHandler += (s, a) => { ProcessDidFailWithErrorEventHandler?.Invoke(this, a); };
            WysiwysController.MissingRequiredFormFieldEventHandler += (s, a) => { /*should never happen. If happen, technical error, ebanking team should be prompted*/ };
            WysiwysController.SignatureFormFieldRequiresManualFillingEventHandler += (s, a) => { /*should never happen. If happen, technical error, ebanking team should be prompted*/ };
            WysiwysController.SignatureRequiresPositioningEventHandler += (s, a) => { /*should never happen. If happen, technical error, ebanking team should be prompted*/ };
            WysiwysController.SelectSignatureFormFieldEventHandler += (s, a) => { };
            WysiwysController.ConfirmationRequiredEventHandler += (s, a) => { ConfirmationRequiredEventHandler?.Invoke(this, a); };
            WysiwysController.WillPrepareDocumentEventHandler += (s, a) => { WillPrepareDocumentEventHandler?.Invoke(this, a); };
            WysiwysController.DidSelectSignatureFormFieldEventHandler += (s, a) => { };

            WysiwysController.DocumentDidLoadEventHandler += (s, a) => { DocumentDidLoadEventHandler?.Invoke(this, a); };
            WysiwysController.DidPageChangedEventHandler += (s, a) => { DidPageChangedEventHandler?.Invoke(this, a); };
        }

        public async Task<ISignaturePdfViewer> Initialize(IESignatureGeolocationProvider eSignatureGeolocationProvider, IESignatureUserDisplayProvider eSignatureUserDisplayProvider)
        {
            if (isInit)
                return pdfViwer;

            try
            {
                ESignatureGeolocationProvider = eSignatureGeolocationProvider;
                ESignatureUserDisplayProvider = eSignatureUserDisplayProvider;

                string senseUserLogin = await SenseService.GetSenseUserLogin();

                string wysiwysStorageKey = await SenseService.GetSenseUserPassword();

                WysiwysController.InitSDK(senseUserLogin, wysiwysStorageKey, WysiwysLicense);

                isInit = true;

                await ResetView();
            }
            catch (Exception e)
            {
                LogerService.LogError(e);
            }

            return pdfViwer;
        }

        public async Task<ISignaturePdfViewer> ResetView()
        {
            pdfViwer = await WysiwysController.InitView();

            return pdfViwer;
        }

        public Page GetSignatureSettingsPage()
        {
            try
            {
                return WysiwysController.GetSignatureSettingsPage();
            }
            catch (Exception e)
            {
                LogerService.LogError(e);
                return null;
            }
        }

        public bool HasSignatures()
        {
            try
            {
                return WysiwysController.HasSignatures();
            }
            catch (Exception e)
            {
                LogerService.LogError(e);
                return false;
            }
        }

        //EmbedSignature
        public void EmbedSignature(String contractID, Stream signature)
        {
            try
            {
                WysiwysController?.EmbedSignature(contractID, signature);
            }
            catch (Exception e)
            {
                LogerService.LogError(e);
            }
        }

        //SetPageIndex
        public void SetPageIndex(int pageIndex)
        {
            try
            {
                WysiwysController?.SetPageIndex(pageIndex);
            }
            catch (Exception e)
            {
                LogerService.LogError(e);
            }
        }

        //GetPageCount
        public int GetPageCount()
        {
            try
            {
                return WysiwysController?.GetPageCount() ?? -1;
            }
            catch (Exception e)
            {
                LogerService.LogError(e);
                return -1;
            }
        }

        //GetPageIndex
        public int GetPageIndex()
        {
            try
            {
                return WysiwysController?.GetPageIndex() ?? -1;
            }
            catch (Exception e)
            {
                LogerService.LogError(e);
                return -1;
            }
        }

        //RefuseDocument
        public void RefuseDocument()
        {
            try
            {
                WysiwysController?.RefuseDocument();
            }
            catch (Exception e)
            {
                LogerService.LogError(e);
            }
        }

        //AcceptDocument
        public void AcceptDocument()
        {
            try
            {
                WysiwysController?.AcceptDocument();
            }
            catch (Exception e)
            {
                LogerService.LogError(e);
            }
        }

        //ConfirmSignature
        public void ConfirmSignature()
        {
            try
            {
                WysiwysController?.ConfirmSignature();
            }
            catch (Exception e)
            {
                LogerService.LogError(e);
            }
        }

        //DisposeDocument
        public void DisposeDocument(String contractID)
        {
            try
            {
                openedContract = null;
                WysiwysController?.DisposeDocument(contractID);
            }
            catch (Exception e)
            {
                LogerService.LogError(e);
            }
        }

        public async Task<ISignaturePdfViewer> OpenDocumentForSignature(IContract contract, ESignatureReason reason)
        {
            try
            {
                if (contract == null)
                    ;//Throw : should call InitializeSignatureConfiguration first

                if (contract.Payload == null)
                    ;//throw : should get contract payload first.

                openedContract = contract;
                string userDisplayName = await ESignatureUserDisplayProvider?.GetESignatureUserDisplayNameForPDF(); ;
                string geolocation = await ESignatureGeolocationProvider?.GetESignatureGeolocationForPDF();
                string signatureDescription = $"Digitally signed by {userDisplayName}";
                string signatureReason = $"Signed by {userDisplayName}";
                string dateTimePattern = "dd.MM.yyyy";

                //See following events for the end of the process :
                //  DocumentPreparedEventHandler 
                //  ProcessDidFinishEventHandler 
                //  ProcessDidFailWithErrorEventHandler 
                //  MissingRequiredFormFieldEventHandler 
                //  SignatureFormFieldRequiresManualFillingEventHandler 
                //  SignatureRequiresPositioningEventHandler 
                //  WysiwysController.SelectSignatureFormFieldEventHandler 
                //  ConfirmationRequiredEventHandler 
                //  WillPrepareDocumentEventHandler 
                //  DidSelectSignatureFormFieldEventHandler 
                //  DocumentDidLoadEventHandler 
                //  DidPageChangedEventHandler 

                return await WysiwysController.OpenDocument(contract.Payload, contract.Identifier, userDisplayName, geolocation, signatureDescription, signatureReason, dateTimePattern, reason);
            }
            catch (Exception e)
            {
                LogerService.LogError(e);
                return null;
            }
        }
    }
}