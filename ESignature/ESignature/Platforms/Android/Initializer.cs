using System;
using Java.Net;
using System.Collections.Generic;
using ESignature.Interfaces.Internals;
using Java.Util;
using CH.Sysmosoft.Sense.Smartcontract.Sdk;

namespace ESignature.Implementations.Internals
{
    internal class Initializer : IInitializer
    {
        public Initializer()
        {

        }

        public async Task<bool> Initialize(string secServUrl, string senseLicense)
        {
            try
            {
                if (SmartContract.IsInitialized)
                    return true;

                Properties configuration = new Properties();
                configuration.SetProperty("sec-server-url", secServUrl);
                configuration.SetProperty("identification-only", "true");

                if (!string.IsNullOrWhiteSpace(senseLicense))
                    configuration.SetProperty("sense-license", senseLicense);

                CH.Sysmosoft.Sense.Smartcontract.Sdk.Api.ISessionService sessionService = SmartContract.Initialize(/*Android.App.Application.Context*/Platform.CurrentActivity, configuration);



                
                /*sessionService.EnrollApplication("euat09", "7mfit{cN{8YjiV?L".ToCharArray(), "HJUL".ToCharArray(), new Platforms.Android.Callbacks.SessionEstablishmentListenerCallback
                {
                    LoginSuccessful = (services) =>
                    {
                        string s = "Success";
                        //completion.SetResult(true);
                    },
                    LoginFailed = (throwable) =>
                    {
                        string s = "failed";
                        //completion.SetResult(false);
                    },
                    ApplicationUpToDate = () =>
                    {

                    },
                    UpdateAvailable = (s) =>
                    {

                    }
                });
                */


                return true;
            }
            catch (Exception e)
            {
                if (e.Message.Equals("SmartContract SDK already initialized"))
                    return true;

                return false;
            }
        }
    }
}

