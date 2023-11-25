using System;
using ESignature.Interfaces.Internals;

namespace ESignature.Implementations.Internals
{
#if ANDROID || IOS || MACCATALYST
#else
    internal class SessionService : ISessionService
    {
        public SessionService()
        {
        }

        public Task<bool> CreateApplicationSession(string userLogin, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EnrollApplication(string userLogin, string password, string activationCode)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAlreadyEnrolledUsers()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetConfigProperties()
        {
            throw new NotImplementedException();
        }

        public string GetUserLogged()
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
#endif
}

