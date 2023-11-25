using System;
using CH.Sysmosoft.Sense.Smartcontract.Sdk.Api;
using Java.Lang;

namespace ESignature.Platforms.Android.Callbacks
{
    public class SessionEstablishmentListenerCallback : Java.Lang.Object, ISessionEstablishmentListener
    {
        public Action ApplicationUpToDate { get; set; }
        public Action<Throwable> LoginFailed { get; set; }
        public Action<IServices> LoginSuccessful { get; set; }
        public Action<string> UpdateAvailable { get; set; }

        public SessionEstablishmentListenerCallback()
        {
        }

        public void OnApplicationUpToDate()
        {
            ApplicationUpToDate?.Invoke();
        }

        public void OnLoginFailed(Throwable throwable)
        {
            LoginFailed?.Invoke(throwable);
        }

        public void OnLoginSuccessful(IServices services)
        {
            LoginSuccessful?.Invoke(services);
        }

        public void OnUpdateAvailable(string p0)
        {
            UpdateAvailable?.Invoke(p0);
        }
    }
}

