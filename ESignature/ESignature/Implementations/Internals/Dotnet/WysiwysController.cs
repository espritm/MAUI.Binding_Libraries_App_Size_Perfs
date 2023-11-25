using System;
using ESignature.Interfaces;
using ESignature.Interfaces;
using ESignature.Interfaces.Internals;

namespace ESignature.Implementations.Internals
{
#if ANDROID || IOS || MACCATALYST
#else
    public class WysiwysController : IWysiwysController
    {
        public WysiwysController()
        {
        }

        public event EventHandler MissingRequiredFormFieldEventHandler;
        public event EventHandler SignatureFormFieldRequiresManualFillingEventHandler;
        public event EventHandler SignatureRequiresPositioningEventHandler;
        public event EventHandler SelectSignatureFormFieldEventHandler;
        public event EventHandler ConfirmationRequiredEventHandler;
        public event EventHandler WillPrepareDocumentEventHandler;
        public event EventHandler DidSelectSignatureFormFieldEventHandler;
        public event EventHandler DocumentDidLoadEventHandler;
        public event EventHandler<IDidPageChangedEventArgs> DidPageChangedEventHandler;

        event EventHandler<IDocumentPreparedEventArgs> IWysiwysController.DocumentPreparedEventHandler
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event EventHandler<IProcessDidFinishEventArgs> IWysiwysController.ProcessDidFinishEventHandler
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event EventHandler<IProcessDidFailWithErrorEventArgs> IWysiwysController.ProcessDidFailWithErrorEventHandler
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public void AcceptDocument()
        {
            throw new NotImplementedException();
        }

        public SignatureSettingsPage GetSignatureSettingsPage()
        {
            throw new NotImplementedException();
        }

        public bool HasSignatures()
        {
            throw new NotImplementedException();
        }

        public void InitSDK(string senseUserLogin, string wysiwysStorageKey, string wysiwysLicense)
        {
            throw new NotImplementedException();
        }

        public Task<ISignaturePdfViewer> OpenDocument(Stream documentDigest, string contractID, string userDisplayName, string geolocation, string signatureDescription, string signatureReason, string dateTimePattern, ESignatureReason reason)
        {
            throw new NotImplementedException();
        }

        public void RefuseDocument()
        {
            throw new NotImplementedException();
        }

        public void ConfirmSignature()
        {
            throw new NotImplementedException();
        }

        public void EmbedSignature(string contractID, Stream signature)
        {
            throw new NotImplementedException();
        }

        public void DisposeDocument(string contractID)
        {
            throw new NotImplementedException();
        }

        public void SetPageIndex(int pageIndex)
        {
            throw new NotImplementedException();
        }

        public int GetPageIndex()
        {
            throw new NotImplementedException();
        }

        public int GetPageCount()
        {
            throw new NotImplementedException();
        }

        public Task<ISignaturePdfViewer> InitView()
        {
            return null;
        }
    }
#endif
}

