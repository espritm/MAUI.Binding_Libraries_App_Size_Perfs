using Com.Unblu.Sdk.Core.Callback;

namespace CommunicationTool.Unblu.Platforms.Android.Internals
{
    public class DeinitializeExceptionCallback : Java.Lang.Object, IDeinitializeExceptionCallback
    {
        public Action<string> OnDeinitFailedAction { get; set; }

        public DeinitializeExceptionCallback(Action<string> onDeinitFailedAction)
        {
            OnDeinitFailedAction = onDeinitFailedAction;
        }

        public void OnDeinitFailed(string details)
        {
            OnDeinitFailedAction?.Invoke(details);
        }
    }
}

