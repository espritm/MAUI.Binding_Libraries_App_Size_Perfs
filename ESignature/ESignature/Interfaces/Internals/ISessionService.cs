using System;

namespace ESignature.Interfaces.Internals
{
    /// <summary>
    /// Sysmosoft equivalent SSCSessionService for iOS and SessionService for Android
    /// </summary>
    internal interface ISessionService
    {
        void Logout();

        Task<Boolean> EnrollApplication(String userLogin, String password, String activationCode);

        Task<Boolean> CreateApplicationSession(String userLogin, String password);

        String GetUserLogged();

        Dictionary<String, String> GetConfigProperties();

        List<String> GetAlreadyEnrolledUsers();
    }
}
