using System;
using Com.Unblu.Sdk.Core.Callback;
using Com.Unblu.Sdk.Core.Errortype;

namespace CommunicationTool.Unblu.Platforms.Android.Internals
{
    public class InitializeExceptionCallback : Java.Lang.Object, IInitializeExceptionCallback
    {
        public Action OnConfigureNotCalledAction { get; set; }
        public Action OnInErrorStateAction { get; set; }
        public Action<string> OnInitFailedAction { get; set; }

        public InitializeExceptionCallback(Action onConfigureNotCalledAction, Action onInErrorStateAction, Action<string> onInitFailedAction)
        {
            OnConfigureNotCalledAction = onConfigureNotCalledAction;
            OnInErrorStateAction = onInErrorStateAction;
            OnInitFailedAction = onInitFailedAction;
        }

        public void OnConfigureNotCalled()
        {
            OnConfigureNotCalledAction?.Invoke();
        }

        public void OnInErrorState()
        {
            OnInErrorStateAction?.Invoke();
        }

        public void OnInitFailed(UnbluClientErrorType errorType, string details)
        {
            OnInitFailedAction?.Invoke($"{errorType.Name} - {details}");
        }
    }
}

