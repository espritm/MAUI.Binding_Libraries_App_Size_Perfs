using System;
using Microsoft.Maui.Handlers;

namespace ESignature
{
    public partial class SignaturePdfViewerHandler : ViewHandler<SignaturePdfViewer, Android.Views.View>
    {
        Android.Views.View nativeView;

        public void SetNativeView(Android.Views.View view)
        {
            nativeView = view;
        }

        protected override Android.Views.View CreatePlatformView()
        {
            ClearParentView();

            return nativeView;
        }

        protected override void DisconnectHandler(Android.Views.View platformView)
        {
            platformView.Dispose();
            base.DisconnectHandler(platformView);
        }

        public void ClearParentView()
        {
            if (nativeView != null && nativeView.Parent != null)
                ((Android.Views.ViewGroup)nativeView.Parent).RemoveView(nativeView);
        }
    }
}