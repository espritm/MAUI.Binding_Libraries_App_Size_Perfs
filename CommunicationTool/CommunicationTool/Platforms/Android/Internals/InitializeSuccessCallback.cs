using System;
using Com.Unblu.Sdk.Core.Callback;
using Com.Unblu.Sdk.Core.Visitor;

namespace CommunicationTool.Unblu.Platforms.Android.Internals
{
    public class InitializeSuccessCallback : Java.Lang.Object, IInitializeSuccessCallback
    {
        public Action<IUnbluVisitorClient> OnSuccessAction { get; set; }

        public InitializeSuccessCallback(Action<IUnbluVisitorClient> onSuccessAction)
        {
            OnSuccessAction = onSuccessAction;
        }

        public void OnSuccess(Java.Lang.Object instance)
        {
            IUnbluVisitorClient unbluInstance = null;

            try
            {
                unbluInstance = instance as IUnbluVisitorClient;
            }
            catch (Exception e)
            {
                //...
            }

            OnSuccessAction?.Invoke(unbluInstance);
        }
    }
}