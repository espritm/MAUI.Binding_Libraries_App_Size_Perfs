using System;
using ESignature.Interfaces;

namespace ESignature.Interfaces.Internals
{
    internal interface IWysiwysController
    {
        event EventHandler<IDocumentPreparedEventArgs> DocumentPreparedEventHandler;
        event EventHandler<IProcessDidFinishEventArgs> ProcessDidFinishEventHandler;
        event EventHandler<IProcessDidFailWithErrorEventArgs> ProcessDidFailWithErrorEventHandler;
        event EventHandler MissingRequiredFormFieldEventHandler;
        event EventHandler SignatureFormFieldRequiresManualFillingEventHandler;
        event EventHandler SignatureRequiresPositioningEventHandler;
        event EventHandler SelectSignatureFormFieldEventHandler;
        event EventHandler ConfirmationRequiredEventHandler;
        event EventHandler WillPrepareDocumentEventHandler;
        event EventHandler DidSelectSignatureFormFieldEventHandler;
        event EventHandler DocumentDidLoadEventHandler;
        event EventHandler<IDidPageChangedEventArgs> DidPageChangedEventHandler;

        void InitSDK(string senseUserLogin, string wysiwysStorageKey, string wysiwysLicense);
        Task<ISignaturePdfViewer> InitView();
        bool HasSignatures();
        SignatureSettingsPage GetSignatureSettingsPage();
        void AcceptDocument();
        void RefuseDocument();
        void ConfirmSignature();
        void EmbedSignature(String contractID, Stream signature);
        void DisposeDocument(String contractID);
        void SetPageIndex(int pageIndex);
        int GetPageIndex();
        int GetPageCount();
        Task<ISignaturePdfViewer> OpenDocument(Stream documentDigest, String contractID, string userDisplayName, string geolocation, string signatureDescription, string signatureReason, string dateTimePattern, ESignatureReason reason);
    }

    internal interface IDocumentPreparedEventArgs
    {
        IContract Contract { get; }
        Stream DocumentDigest { get; }
        string Reason { get; }
    }
    internal interface IProcessDidFinishEventArgs
    {
        IContract Contract { get; }
        string Reason { get; }
        Stream Document { get; }
    }
    internal interface IProcessDidFailWithErrorEventArgs
    {
        string Error { get; }
    }
}

