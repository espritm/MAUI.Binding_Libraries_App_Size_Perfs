using System;
using CH.Sysmosoft.Sense.Smartcontract.Sdk.Wysiwys;

namespace ESignature.Platforms.Android.Callbacks
{
    public class SignaturePickedListenerCallback : Java.Lang.Object, ISignaturePickedListener
    {
        public Action SignaturePicked { get; set; }

        public SignaturePickedListenerCallback()
        {
        }

        public void OnSignaturePicked()
        {
            SignaturePicked?.Invoke();
        }
    }
}

