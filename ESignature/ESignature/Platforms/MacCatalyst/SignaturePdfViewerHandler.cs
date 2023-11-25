using System;
using Microsoft.Maui.Handlers;
using UIKit;

namespace ESignature
{
    public partial class SignaturePdfViewerHandler : ViewHandler<SignaturePdfViewer, UIView>
    {
        protected override UIView CreatePlatformView()
        {
            //throw new NotImplementedException();
            return new UIView();
        }

        public void ClearParentView()
        {
            //Nothing to do for now...
        }
    }
}

