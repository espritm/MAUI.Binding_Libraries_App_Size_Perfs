using System;
using ESignature.Interfaces.Internals;
using ESignature.Interfaces;
using ESignature.Interfaces;
using ESignature.Implementations;

namespace ESignature.Interfaces.Internals
{
    /// <summary>
    /// The service that manage authentication and communication between the app and the sysmosoft server.
    /// </summary>
    internal interface ISenseService
    {
        /// <summary>
        /// Have to be called once before all, typically once the user is logged in.
        /// </summary>
        /// <param name="userLogin">The loggedin username, usualy the one used to authenticate in the app.</param>
        /// <param name="secServUrl">The sec serv url.</param>
        /// <param name="senseLicense">The sense license.</param>
        /// <param name="settingsService">Used to store login and password in secure storage.</param>
        /// <param name="activationCodeProvider">Used to get an activation code for sysmosoft from webservices for instance.</param>
        /// <returns></returns>
        Task Init(String userLogin, string secServUrl, string senseLicense, ISettings settingsService, IESignatureActivationCodeProvider activationCodeProvider);

        /// <summary>
        /// The login stored in the secure storage.
        /// Empty string if it does not exists in the secure storage.
        /// </summary>
        Task<String> GetSenseUserLogin();

        /// <summary>
        /// The password stored in the secure storage.
		/// If it does not exists in the secure storage, create a random 64 bit string and store it in the secure storage.
        /// </summary>
        Task<String> GetSenseUserPassword();

        /// <summary>
        /// Verify the server reachability, enroll the user if it is not enrolled yet, retrieve the dynamic server configurations. 
        /// </summary>
        /// <returns>True if the user has been enrolled successfully.</returns>
        Task<Boolean> EnrollUserIfNotEnrolled();

        /// <summary>
        /// Verify the server reachability, enroll the user if it is not enrolled yet, open a session, retrieve the dynamic server configurations. 
        /// </summary>
        /// <returns>True if the user has been enrolled successfully.</returns>
        Task<Boolean> EnrollOrOpenSession();

        /// <summary>
        /// Logout.
        /// </summary>
        void LogOut();
    }
}