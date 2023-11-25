using Com.Unblu.Sdk.Core.Callback;
using Com.Unblu.Sdk.Core.Errortype;

namespace CommunicationTool.Unblu.Platforms.Android.Internals
{
    public class OpenConversationOverviewExceptionCallback : Java.Lang.Object, IOpenConversationOverviewExceptionCallback
    {
        public Action OnNotInitializedAction { get; set; }
        public Action<string> OnFailedToOpenAction { get; set; }

        public OpenConversationOverviewExceptionCallback(Action onNotInitializedAction, Action<string> onFailedToOpenAction)
        {
            OnNotInitializedAction = onNotInitializedAction;
            OnFailedToOpenAction = onFailedToOpenAction;
        }

        public void OnNotInitialized()
        {
            OnNotInitializedAction?.Invoke();
        }

        public void OnFailedToOpenOverview(OpenConversationOverviewErrorType errorType, string details)
        {
            OnFailedToOpenAction?.Invoke($"{errorType.Name} - {details}");
        }
    }
}

