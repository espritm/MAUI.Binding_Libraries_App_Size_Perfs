using System;
using System.ComponentModel;
using ESignature.Implementations;

namespace ESignature.Interfaces
{
	public interface IESignatureServices
    {
        Task<ISignaturePdfViewer> Initialize(String userLogin, string secServUrl, string senseLicense, String wysiwysLicense, ISettings settingsService, IESignatureActivationCodeProvider activationCodeProvider, ILogerService logerService, IESignatureGeolocationProvider eSignatureGeolocationProvider, IESignatureUserDisplayProvider eSignatureUserDisplayProvider);

        Task<String> GetSenseUserLogin();

        Task<String> GetSenseUserPassword();

        Task<Boolean> EnrollUserIfNotEnrolled();

        Task<Boolean> EnrollOrOpenSession();

        void LogOut();

        Task<Boolean> SendResponse(String sReason, Stream document, IContract contract);

        Task<Stream> RequestSignature(IContract contract, Stream documentDigest);

        Task<Stream> GetContractPayload(IContract contract);

        Task<List<IContract>> GetPendingContracts();

        bool HaveHandwrittenSignature();

        ISignaturesSettingsPage GetSignatureSettingsPage();

        Task<ISignaturePdfViewer> OpenDocumentForSignature(IContract contract, ESignatureReason reason);

        void StartSignatureProcessForOpenedDocument(ESignatureReason reason);

        void ConfirmSignature();

        void SetPageIndex(int pageIndex);
        int GetPageCount();
        Task<ISignaturePdfViewer> ResetView();
        void DisposeDocument(String contractID);

        event EventHandler<ISignatureRequestedForPreparedDocumentEventArgs> SignatureRequestedForPreparedDocumentEventHandler;
        event EventHandler DocumentSignedSuccessfullyEventHandler;
        event EventHandler<IProcessDidFailEventArgs> ProcessDidFailWithErrorEventHandler;
        event EventHandler ConfirmationRequiredEventHandler;
        event EventHandler WillPrepareDocumentEventHandler;
        event EventHandler DocumentDidLoadEventHandler;
        event EventHandler<IDidPageChangedEventArgs> DidPageChangedEventHandler;
    }

    public interface IDidPageChangedEventArgs
    {
        int PageIndex { get; }
    }
    public interface IProcessDidFailEventArgs
    {
        string Error { get; }
    }
    public interface ISignatureRequestedForPreparedDocumentEventArgs
    {
        Stream SignatureDigest { get; }
    }

    public enum ESignatureReason
    {
        [Description("Accept")]
        Accept,

        [Description("Reject")]
        Reject
    }
}

