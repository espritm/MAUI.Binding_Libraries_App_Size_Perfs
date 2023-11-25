using System;
using ESignature.Interfaces;

namespace ESignature.Interfaces.Internals
{
    internal interface IWysiwysService
    {
        event EventHandler<IDocumentPreparedEventArgs> DocumentPreparedEventHandler;
        event EventHandler<IProcessDidFinishEventArgs> ProcessDidFinishEventHandler;
        event EventHandler<IProcessDidFailWithErrorEventArgs> ProcessDidFailWithErrorEventHandler;
        event EventHandler SignatureFormFieldRequiresManualFillingEventHandler;
        event EventHandler SignatureRequiresPositioningEventHandler;
        event EventHandler SelectSignatureFormFieldEventHandler;
        event EventHandler ConfirmationRequiredEventHandler;
        event EventHandler WillPrepareDocumentEventHandler;
        event EventHandler DidSelectSignatureFormFieldEventHandler;
        event EventHandler DocumentDidLoadEventHandler;
        event EventHandler<IDidPageChangedEventArgs> DidPageChangedEventHandler;

        Task<ISignaturePdfViewer> Initialize(IESignatureGeolocationProvider eSignatureGeolocationProvider, IESignatureUserDisplayProvider eSignatureUserDisplayProvider);
        Task<ISignaturePdfViewer> ResetView();
        Page GetSignatureSettingsPage();
        bool HasSignatures();
        void AcceptDocument();
        void RefuseDocument();
        void ConfirmSignature();
        void EmbedSignature(String contractID, Stream signature);
        void DisposeDocument(String contractID);
        void SetPageIndex(int pageIndex);
        int GetPageIndex();
        int GetPageCount();
        Task<ISignaturePdfViewer> OpenDocumentForSignature(IContract contract, ESignatureReason reason);
        //TODO : OpenDocumentForSignature should return a model object that contains the view, and the methods  SetPageIndex, GetPageIndex, GetPageCount, and all other that are linked to the actual document opened
    }
}

