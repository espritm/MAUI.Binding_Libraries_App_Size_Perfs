using System;
using Microsoft.Maui.Handlers;
using UIKit;

namespace CommunicationTool.Views
{
    public partial class ComToolViewHandler : ViewHandler<ComToolView, UIView>
    {
        UIView nativeUnbluUIView = new UIView();

        public void SetUnbluNativeView(UIView view)
        {
            nativeUnbluUIView = view;
        }

        protected override UIView CreatePlatformView()
        {
            return nativeUnbluUIView;
        }

        protected override void ConnectHandler(UIView platformView)
        {
            base.ConnectHandler(platformView);

            //Set unblu view Frame : x, y = 0, 0 and width and height according to the screen size
            platformView.Frame = new CoreGraphics.CGRect(0, 0, unbluViewWidth, unbluViewHeight);
        }

        protected override void DisconnectHandler(UIView platformView)
        {
            platformView.Dispose();
            base.DisconnectHandler(platformView);
        }
    }
}

