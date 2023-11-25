using System;
using Foundation;
using ESignature.Interfaces.Internals;
using SmartContract_xcframework_to_DOTNET;
using ESignature.Interfaces;

namespace ESignature.Implementations.Internals
{
    internal class SessionService : ISessionService
    {
        internal SessionService()
        {
        }

        public void Logout()
        {
            SSCSessionService.LogOut();
        }

        public async Task<Boolean> EnrollApplication(String userLogin, String password, String activationCode)
        {
            SSCEnrollmentInfo enrollmentInfo = new SSCEnrollmentInfo();
            enrollmentInfo.Username = userLogin;
            enrollmentInfo.Password = password;
            enrollmentInfo.Code = activationCode;

            TaskCompletionSource<Boolean> completion = new TaskCompletionSource<Boolean>(); 
            SSCSessionService.EnrollApplicationWithInfo(enrollmentInfo, (error) =>
            {
                if (error == null)
                    completion.SetResult(true);
                else
                    completion.SetResult(false);
            });

            return await completion.Task;
        }

        public async Task<Boolean> CreateApplicationSession(String userLogin, String password)
        {
            TaskCompletionSource<Boolean> completion = new TaskCompletionSource<Boolean>();
            SSCSessionService.CreateApplicationSessionWithUsername(userLogin, password, (error) =>
            {
                if (error == null)
                    completion.SetResult(true);
                else
                    completion.SetResult(false);
            });

            return await completion.Task;
        }

        public String GetUserLogged()
        {
            return SSCSessionService.UserLogged;
        }

        public Dictionary<String, String> GetConfigProperties()
        {
            NSDictionary keyValuePairs = SSCSessionService.ConfigProperties;

            Dictionary<String, String> res = new Dictionary<String, String>();

            if (keyValuePairs != null)
                foreach (var k in keyValuePairs)
                    res.Add(k.Key.Description, k.Value.Description);

            return res;
        }

        public List<String> GetAlreadyEnrolledUsers()
        {
            List<String> res = new List<string>();

            NSObject[] enrolledUsersLogin = SSCSessionService.GetAlreadyEnrolledUsers();

            for (int i = 0; i < enrolledUsersLogin?.Length; i++)
            {
                NSString userLogin = enrolledUsersLogin[i] as NSString;
                res.Add(userLogin.Description);
            }

            return res;
        }
    }
}

