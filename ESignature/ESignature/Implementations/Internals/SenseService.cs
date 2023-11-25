using System;
using ESignature.Interfaces.Internals;
using ESignature.Interfaces;
using ESignature.Interfaces;

namespace ESignature.Implementations.Internals
{
    public class SenseService : ISenseService
    {
        private ILogerService logerService;
        private ISettings settingsService;
        private IESignatureActivationCodeProvider activationCodeProvider;
        private ISecureStorageConstants secureStorageConstants = new SecureStorageConstants(); //Platform specific
        private ISessionService sessionService = new SessionService(); //Platform specific
        private IInitializer iniatilizer = new Initializer(); //Platform specific
        private string secServUrl;
        private string senseLicense;

        internal SenseService(ILogerService logerService)
        {
            this.logerService = logerService;
        }

        public async Task Init(String userLogin, string secServUrl, string senseLicense, ISettings settingsService, IESignatureActivationCodeProvider activationCodeProvider)
        {
            this.settingsService = settingsService;
            this.activationCodeProvider = activationCodeProvider;
            this.secServUrl = secServUrl;
            this.senseLicense = senseLicense;

            await settingsService.SetSecure(secureStorageConstants.SenseLogin, userLogin);
        }

        public async Task<string> GetSenseUserLogin()
        {
            return await settingsService.GetSecure(secureStorageConstants.SenseLogin);
        }

        public async Task<string> GetSenseUserPassword()
        {
            String passwordStored = await settingsService.GetSecure(secureStorageConstants.SensePassword);

            if (String.IsNullOrWhiteSpace(passwordStored))
            {
                //Generate a random password for sense user. This will also be used for Wysiwys storage key.
                //Wysiwys storage key must be 64 bytes long for iOS and 16 bytes for Android
                int passwordLenght = 64;
#if ANDROID
                passwordLenght = 16;
#endif
                String letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";// _-.:,;!?&%{}";
                Random random = new Random();

                passwordStored = "";
                for (int i = 0; i < passwordLenght; i++)
                    passwordStored += letters[random.Next(0, letters.Length - 1)];

                await settingsService.SetSecure(secureStorageConstants.SensePassword, passwordStored);
            }

            return passwordStored;
        }

        public void LogOut()
        {
            sessionService.Logout();
        }

        public async Task<bool> EnrollOrOpenSession()
        {
            bool isUserLoggedin = false;
            bool isServerReachable = await VerifyServerReachability();

            if (isServerReachable)
            {
                if (IsUserEnrolled())
                    isUserLoggedin = await OpenUserSession();
                else
                    isUserLoggedin = await EnrollUser();
            }

            if (isUserLoggedin)
                ManageServerConfiguration();

            return isUserLoggedin;
        }

        public async Task<bool> EnrollUserIfNotEnrolled()
        {
            bool isUserEnrolled = false;
            bool isServerReachable = await VerifyServerReachability();

            if (isServerReachable)
                if (!IsUserEnrolled())
                    isUserEnrolled = await EnrollUser();

            if (isUserEnrolled)
                ManageServerConfiguration();

            return isUserEnrolled;
        }

        private async Task<bool> VerifyServerReachability()
        {
            bool isInitializedSuccessfully = await iniatilizer.Initialize(secServUrl, senseLicense);

            if (isInitializedSuccessfully)
                logerService?.LogEvent("Sysmo initialization successfull and server address verified !", LogEventType.Public);
            else
                logerService?.LogEvent("Error while initializing Sysmo or server address verification...", LogEventType.Public);

            return isInitializedSuccessfully;
        }

        private bool IsUserEnrolled()
        {
            List<String> enrolledUsers = sessionService.GetAlreadyEnrolledUsers();
            return enrolledUsers?.Count > 0;
        }

        private async Task<bool> EnrollUser()
        {
            String userLogin = await GetSenseUserLogin();
            String userPassword = await GetSenseUserPassword();
            String activationCode = await activationCodeProvider.GetESignatureActivationCode();

            bool userSuccessfullyEnrolled = await sessionService.EnrollApplication(userLogin, userPassword, activationCode);

            if (userSuccessfullyEnrolled)
                logerService?.LogEvent("Sysmo enrollment successfull !", LogEventType.Public);
            else
                logerService?.LogEvent("Error while enrolling user into Sysmo...", LogEventType.Public);

            return userSuccessfullyEnrolled;
        }

        private async Task<bool> OpenUserSession()
        {
            String userLogin = await GetSenseUserLogin();
            String userPassword = await GetSenseUserPassword();

            bool sessionSuccessfullyOpened = await sessionService.CreateApplicationSession(userLogin, userPassword);

            if (sessionSuccessfullyOpened)
                logerService?.LogEvent("Sysmo session creation successfull !", LogEventType.Public);
            else
                logerService?.LogEvent("Error while creating Sysmo session...", LogEventType.Public);

            return sessionSuccessfullyOpened;
        }

        //not used to prevent errors (crash if use wysiwys sdk without being loged in sense).
        private String GetSenseLogedInUserName()
        {
            return sessionService.GetUserLogged();
        }

        private void ManageServerConfiguration()
        {
            //Retrieve dynamic configurations from server after session establishment
            Dictionary<String, String> configs = sessionService.GetConfigProperties();

            //do nothing for the moment
        }
    }
}

