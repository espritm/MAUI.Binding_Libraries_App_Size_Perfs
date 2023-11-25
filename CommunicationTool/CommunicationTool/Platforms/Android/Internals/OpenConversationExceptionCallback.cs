using Com.Unblu.Sdk.Core.Callback;
using Com.Unblu.Sdk.Core.Errortype;

namespace CommunicationTool.Unblu.Platforms.Android.Internals
{
    public class OpenConversationExceptionCallback: Java.Lang.Object, IOpenConversationExceptionCallback
    {
        public Action OnNotInitializedAction { get; set; }
        public Action<string> OnFailedToOpenAction { get; set; }

        public OpenConversationExceptionCallback(Action onNotInitializedAction, Action<string> onFailedToOpenAction)
        {
            OnNotInitializedAction = onNotInitializedAction;
            OnFailedToOpenAction = onFailedToOpenAction;
        }

        public void OnNotInitialized()
        {
            OnNotInitializedAction?.Invoke();
        }

        public void OnFailedToOpen(OpenConversationErrorType errorType, string details)
        {
            OnFailedToOpenAction?.Invoke($"{errorType.Name} - {details}");
        }
    }
}

