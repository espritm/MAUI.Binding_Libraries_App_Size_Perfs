using System;
using Microsoft.Maui.Handlers;

namespace ESignature
{
    public partial class SignaturePdfViewerHandler
    {
#if ANDROID || IOS || MACCATALYST
        public static IPropertyMapper<SignaturePdfViewer, SignaturePdfViewerHandler> PropertyMapper = new PropertyMapper<SignaturePdfViewer, SignaturePdfViewerHandler>(ViewHandler.ViewMapper)
        {
        };


        public static CommandMapper<SignaturePdfViewer, SignaturePdfViewerHandler> CommandMapper = new CommandMapper<SignaturePdfViewer, SignaturePdfViewerHandler>(ViewCommandMapper)
        {
        };


        public SignaturePdfViewerHandler() : base(PropertyMapper, CommandMapper)
        {
        }
#else
        public SignaturePdfViewerHandler()
        {
        }

        public void ClearParentView()
        {
            //Nothing to do for now...
        }
#endif
    }
}

