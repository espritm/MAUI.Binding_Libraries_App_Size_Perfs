using System;
using ESignature.Interfaces;
using ESignature.Interfaces;

namespace ESignature
{
    public class SignaturePdfViewer : View, ISignaturePdfViewer
    {
        public SignaturePdfViewer()
        {
        }

        public void ClearParentView()
        {
            try
            {
                SignaturePdfViewerHandler handler = this.Handler as SignaturePdfViewerHandler;

                if (handler != null)
                    handler.ClearParentView();
            }
            catch(Exception e)
            {
                string error = e.Message;
            }
        }
    }
}

