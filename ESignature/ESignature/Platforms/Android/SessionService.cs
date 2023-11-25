using System;
using CH.Sysmosoft.Sense.Smartcontract.Sdk;
using ESignature.Interfaces.Internals;
using ESignature.Platforms.Android.Callbacks;

namespace ESignature.Implementations.Internals
{
    internal class SessionService : ISessionService
    {
        public SessionService()
        {
        }

        public void Logout()
        {
            SmartContract.SessionService.CloseSession();
        }

        public async Task<bool> EnrollApplication(string userLogin, string password, string activationCode)
        {
            TaskCompletionSource<bool> completion = new TaskCompletionSource<bool>();

            SmartContract.SessionService.EnrollApplication(userLogin, password.ToCharArray(), activationCode.ToCharArray(), new SessionEstablishmentListenerCallback
            {
                LoginSuccessful = (services) =>
                {
                    completion.SetResult(true);
                },
                LoginFailed = (throwable) =>
                {
                    completion.SetResult(false);
                },
                ApplicationUpToDate = () =>
                {

                },
                UpdateAvailable = (s) =>
                {

                }
            });

            return await completion.Task;
        }

        public async Task<bool> CreateApplicationSession(string userLogin, string password)
        {
            TaskCompletionSource<bool> completion = new TaskCompletionSource<bool>();

            SmartContract.SessionService.OpenApplicationSession(userLogin, password.ToCharArray(), new SessionEstablishmentListenerCallback
            {
                LoginSuccessful = (services) =>
                {
                    completion.SetResult(true);
                },
                LoginFailed = (throwable) =>
                {
                    completion.SetResult(false);
                },
                ApplicationUpToDate = () =>
                {

                },
                UpdateAvailable = (s) =>
                {

                }
            });

            return await completion.Task;
        }

        public string GetUserLogged()
        {
            return SmartContract.SessionService.EnrolledUser;
        }

        public Dictionary<string, string> GetConfigProperties()
        {
            //todo if needed
            return new Dictionary<string, string>();
        }

        public List<string> GetAlreadyEnrolledUsers()
        {
            IList<string> res = SmartContract.SessionService.EnrolledUsers;

            if (res != null)
                return new List<string>(res);
            else
                return new List<string>();
        }
    }
}

