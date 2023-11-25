using Com.Unblu.Sdk.Core.Configuration;
using Com.Unblu.Sdk.Core.Internal.Utils;

namespace CommunicationTool.Unblu.Platforms.Android.Internals
{
    public class DownloadHandler : Java.Lang.Object, IUnbluDownloadHandler
    {
        public void OnDownloadStart(IApplicationStateProvider applicationStateProvider, string requestedUrl, string userAgent, string contentDisposition, string mimeType, long contentLength, string cookies)
        {
            throw new NotImplementedException();
        }
    }
}