using System;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Handlers;
using UIKit;

namespace ESignature
{
    public partial class SignaturePdfViewerHandler : ViewHandler<SignaturePdfViewer, UIView>
    {
        UIView nativeUIView = new UIView();

        public void SetNativeView(UIView view)
        {
            nativeUIView = view;
        }

        protected override UIView CreatePlatformView()
        {
            return nativeUIView;
        }

        protected override void ConnectHandler(UIView platformView)
        {
            base.ConnectHandler(platformView);

            //Set native view Frame : x, y = 0, 0 and width and height according to the screen size
           // platformView.Frame = new CoreGraphics.CGRect(0, 0, unbluViewWidth, unbluViewHeight);
        }

        protected override void DisconnectHandler(UIView platformView)
        {
            platformView.Dispose();
            base.DisconnectHandler(platformView);
        }

        public void ClearParentView()
        {
            //Nothing to do for now...
        }
    }
}

