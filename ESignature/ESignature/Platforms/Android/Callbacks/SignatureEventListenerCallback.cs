using System;
using CH.Sysmosoft.Sense.Smartcontract.Sdk.Wysiwys;
using Java.Lang;

namespace ESignature.Platforms.Android.Callbacks
{
    public class SignatureEventListenerCallback : Java.Lang.Object, ISignatureEventListener
    {
        public Action ConfirmationRequired { get; set; }
        public Action<byte[]> DocumentPreparedForSignature { get; set; }
        public Action MissingRequiredFormField { get; set; }
        public Action PreparingDocument { get; set; }
        public Action<Throwable> ProcessFailed { get; set; }
        public Action<string, byte[]> ProcessFinished { get; set; }
        public Action SelectSignatureFormField { get; set; }
        public Action SignatureFormFieldRequiresManualFilling { get; set; }
        public Action SignatureFormFieldSelected { get; set; }
        public Action SignatureRequiresPositioning { get; set; }

        public SignatureEventListenerCallback()
        {
        }

        public void OnConfirmationRequired()
        {
            ConfirmationRequired?.Invoke();
        }

        public void OnDocumentPreparedForSignature(byte[] documentDigest)
        {
            DocumentPreparedForSignature?.Invoke(documentDigest);
        }

        public void OnMissingRequiredFormField()
        {
            MissingRequiredFormField?.Invoke();
        }

        public void OnPreparingDocument()
        {
            PreparingDocument?.Invoke();
        }

        public void OnProcessFailed(Throwable throwable)
        {
            ProcessFailed?.Invoke(throwable);
        }

        public void OnProcessFinished(string reason, byte[] document)
        {
            ProcessFinished?.Invoke(reason, document);
        }

        public void OnSelectSignatureFormField()
        {
            SelectSignatureFormField?.Invoke();
        }

        public void OnSignatureFormFieldRequiresManualFilling()
        {
            SignatureFormFieldRequiresManualFilling?.Invoke();
        }

        public void OnSignatureFormFieldSelected()
        {
            SignatureFormFieldSelected?.Invoke();
        }

        public void OnSignatureRequiresPositioning()
        {
            SignatureRequiresPositioning?.Invoke();
        }
    }
}

