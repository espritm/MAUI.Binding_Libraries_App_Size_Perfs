using SmartContract_xcframework_to_DOTNET;
using System;
using Foundation;
using ESignature.Interfaces.Internals;

namespace ESignature.Implementations.Internals
{
    internal class Initializer : IInitializer
    {
        public Initializer()
        {
        }

        public async Task<Boolean> Initialize(string secServUrl, string senseLicense)
        {
            //We use the sense-config.properties file because it is the normal behavior for the iOS SDK
            NSDictionary senseConfigs = SFKConfiguration.SenseConfiguration;
            String secServUrlFromSettings = senseConfigs?["sec-server-url"]?.Description;

            //The SENSE Smart Contract SDK has to be initialized prior using any provided service.
            SSCInitializer.Instance().SenseServerURL = new NSUrl(secServUrlFromSettings);

            TaskCompletionSource<Boolean> completion = new TaskCompletionSource<Boolean>();
            SSCInitializer.Instance().VerifyServerReachabilityCompletion((error) =>
            {
                if (error == null)
                    completion.SetResult(true);
                else
                    completion.SetResult(false);
            });

            return await completion.Task;
        }
    }
}

