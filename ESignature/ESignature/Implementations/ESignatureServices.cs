using System;
using System.Collections.Generic;
using ESignature.Interfaces;
using ESignature.EventArguments;
using ESignature.Implementations.Internals;
using ESignature.Interfaces.Internals;
using ESignature.Model;

namespace ESignature.Implementations
{
    public class ESignatureServices : IESignatureServices
    {
        public event EventHandler<ISignatureRequestedForPreparedDocumentEventArgs> SignatureRequestedForPreparedDocumentEventHandler;
        public event EventHandler DocumentSignedSuccessfullyEventHandler;
        public event EventHandler<IProcessDidFailEventArgs> ProcessDidFailWithErrorEventHandler;
        public event EventHandler ConfirmationRequiredEventHandler;
        public event EventHandler WillPrepareDocumentEventHandler;
        public event EventHandler DocumentDidLoadEventHandler;
        public event EventHandler<IDidPageChangedEventArgs> DidPageChangedEventHandler;

        IContractService contractService;
        ISenseService senseService;
        IWysiwysService wysiwysService;

        internal ESignatureServices()
        {
        }

        public async Task<ISignaturePdfViewer> Initialize(String userLogin, string secServUrl, string senseLicense, String wysiwysLicense, ISettings settingsService, IESignatureActivationCodeProvider activationCodeProvider, ILogerService logerService, IESignatureGeolocationProvider eSignatureGeolocationProvider, IESignatureUserDisplayProvider eSignatureUserDisplayProvider)
        {
            senseService = new SenseService(logerService);
            await senseService.Init(userLogin, secServUrl, senseLicense, settingsService, activationCodeProvider); 

            contractService = new ContractService(logerService);

            wysiwysService = new WysiwysService(senseService, logerService, wysiwysLicense);
            ISignaturePdfViewer res = await wysiwysService.Initialize(eSignatureGeolocationProvider, eSignatureUserDisplayProvider);

            wysiwysService.DocumentPreparedEventHandler += ESignatureServices_DocumentPrepared;
            wysiwysService.ProcessDidFinishEventHandler += ESignatureServices_ProcessDidFinish;
            wysiwysService.ProcessDidFailWithErrorEventHandler += ESignatureServices_ProcessDidFailWithError;
            wysiwysService.ConfirmationRequiredEventHandler += ESignatureServices_ConfirmationRequired;
            wysiwysService.WillPrepareDocumentEventHandler += ESignatureServices_WillPrepareDocument;
            wysiwysService.DocumentDidLoadEventHandler += ESignatureService_DocumentDidLoad;
            wysiwysService.DidPageChangedEventHandler += ESignatureService_DidPageChanged;

            return res;
        }

        public async Task<ISignaturePdfViewer> ResetView()
        {
            return await wysiwysService?.ResetView();
        }

        public void DisposeDocument(string contractID)
        {
            wysiwysService?.DisposeDocument(contractID);
        }

        public async Task<bool> EnrollOrOpenSession()
        {
            return await senseService.EnrollOrOpenSession();
        }

        public async Task<bool> EnrollUserIfNotEnrolled()
        {
            return await senseService.EnrollUserIfNotEnrolled();
        }

        public async Task<string> GetSenseUserLogin()
        {
            return await senseService.GetSenseUserLogin();
        }

        public async Task<string> GetSenseUserPassword()
        {
            return await senseService.GetSenseUserPassword();
        }

        public void LogOut()
        {
            senseService.LogOut();
        }

        public async Task<Stream> GetContractPayload(IContract contract)
        {
            return await contractService.GetContractPayload(contract as Contract);
        }

        public async Task<List<IContract>> GetPendingContracts()
        {
            List<Contract> contracts = await contractService.GetPendingContracts();

            List<IContract> lsRes = new List<IContract>();
            lsRes.AddRange(contracts);

            return lsRes;
        }

        public async Task<Stream> RequestSignature(IContract contract, Stream documentDigest)
        {
            return await contractService.RequestSignature(contract as Contract, documentDigest);
        }

        public async Task<bool> SendResponse(string sReason, Stream document, IContract contract)
        {
            return await contractService.SendResponse(sReason, document, contract as Contract);
        }

        public bool HaveHandwrittenSignature()
        {
            return wysiwysService.HasSignatures();
        }

        public ISignaturesSettingsPage GetSignatureSettingsPage()
        {
            return wysiwysService.GetSignatureSettingsPage() as ISignaturesSettingsPage;
        }

        public async Task<ISignaturePdfViewer> OpenDocumentForSignature(IContract contract, ESignatureReason reason)
        {
            //See related events for the signature process
            //  ESignatureServices_DocumentPrepared;
            //  ESignatureServices_ProcessDidFinish;
            //  ESignatureServices_ProcessDidFailWithError;
            //  ESignatureServices_ConfirmationRequired;
            //  ESignatureServices_WillPrepareDocument;
            //  ESignatureService_DocumentDidLoad;
            //  ESignatureService_DidPageChanged;

            return await wysiwysService.OpenDocumentForSignature(contract, reason);
        }

        public void StartSignatureProcessForOpenedDocument(ESignatureReason reason)
        {
            switch (reason)
            {
                case ESignatureReason.Accept:
                    wysiwysService.AcceptDocument();
                    break;

                case ESignatureReason.Reject:
                    wysiwysService.RefuseDocument();
                    break;

                default:
                    throw new NotImplementedException($"ESignatureServices.StartSignatureProcessForOpenedDocument.");
            }
        }

        public void ConfirmSignature()
        {
            wysiwysService.ConfirmSignature();
        }

        public void SetPageIndex(int pageIndex)
        {
            wysiwysService.SetPageIndex(pageIndex);
        }

        public int GetPageCount()
        {
            return wysiwysService.GetPageCount();
        }

        private async void ESignatureServices_DocumentPrepared(object sender, IDocumentPreparedEventArgs e)
        {
            Stream signatureDigest = await RequestSignature(e.Contract, e.DocumentDigest);

            if (signatureDigest == null)
                ProcessDidFailWithErrorEventHandler?.Invoke(this, new ProcessDidFailEventArgs("failed"));
            else
            {
                SignatureRequestedForPreparedDocumentEventHandler?.Invoke(this, new SignatureRequestedForPreparedDocumentEventArgs(signatureDigest));

                wysiwysService.EmbedSignature(e.Contract.Identifier, signatureDigest);
            }
        }

        private async void ESignatureServices_ProcessDidFinish(object sender, IProcessDidFinishEventArgs e)
        {
            bool success = await SendResponse(e.Reason, e.Document, e.Contract);

            if (success)
                //Success. Propagate with event DocumentSignedSuccessfully
                DocumentSignedSuccessfullyEventHandler?.Invoke(this, new EventArgs());
            else
                //Fail. Propagate with event ProcessDidFailWithError
                ProcessDidFailWithErrorEventHandler?.Invoke(this, new ProcessDidFailEventArgs("failed"));
        }

        private void ESignatureServices_ProcessDidFailWithError(object sender, IProcessDidFailWithErrorEventArgs e)
        {
            ProcessDidFailWithErrorEventHandler?.Invoke(this, new ProcessDidFailEventArgs(e.Error));
        }

        private void ESignatureServices_ConfirmationRequired(object sender, System.EventArgs e)
        {
            ConfirmationRequiredEventHandler?.Invoke(this, e);
        }

        private void ESignatureServices_WillPrepareDocument(object sender, System.EventArgs e)
        {
            WillPrepareDocumentEventHandler?.Invoke(this, e);
        }

        private void ESignatureService_DocumentDidLoad(object sender, System.EventArgs e)
        {
            DocumentDidLoadEventHandler?.Invoke(this, e);
        }

        private void ESignatureService_DidPageChanged(object sender, IDidPageChangedEventArgs e)
        {
            DidPageChangedEventHandler?.Invoke(this, new DidPageChangedEventArgs(e.PageIndex));
        }
    }
}
