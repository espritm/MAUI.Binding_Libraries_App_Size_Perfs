using System;
using Microsoft.Maui.Handlers;

namespace CommunicationTool.Views
{
    public partial class ComToolViewHandler : ViewHandler<ComToolView, Android.Views.View>
    {
        Android.Views.View nativeUnbluView;

        public void SetUnbluNativeView(Android.Views.View view)
        {
            nativeUnbluView = view;
        }

        protected override Android.Views.View CreatePlatformView()
        {
            if (nativeUnbluView != null && nativeUnbluView.Parent != null)
                ((Android.Views.ViewGroup)nativeUnbluView.Parent).RemoveView(nativeUnbluView);

            return nativeUnbluView;
        }

        protected override void DisconnectHandler(Android.Views.View platformView)
        {
            platformView.Dispose();
            base.DisconnectHandler(platformView);
        }
    }
}

