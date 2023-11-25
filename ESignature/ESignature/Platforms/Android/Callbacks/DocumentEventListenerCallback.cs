using System;
using CH.Sysmosoft.Sense.Smartcontract.Sdk.Api;
using CH.Sysmosoft.Sense.Smartcontract.Sdk.Wysiwys;
using Java.Lang;

namespace ESignature.Platforms.Android.Callbacks
{
    public class DocumentEventListenerCallback : Java.Lang.Object, IDocumentEventListener
    {
        public Action DocumentLoaded { get; set; }
        public Action<Throwable> DocumentLoadFailed { get; set; }
        public Action<int> PageChanged { get; set; }

        public DocumentEventListenerCallback()
        {
        }

        public void OnDocumentLoaded()
        {
            DocumentLoaded?.Invoke();
        }

        public void OnDocumentLoadFailed(Throwable throwable)
        {
            DocumentLoadFailed?.Invoke(throwable);
        }

        public void OnPageChanged(int pageIndex)
        {
            PageChanged?.Invoke(pageIndex);
        }
    }
}

