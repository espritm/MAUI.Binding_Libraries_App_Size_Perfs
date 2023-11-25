using System;
namespace ESignature.Interfaces.Internals
{
    /// <summary>
    /// Sysmosoft equivalent SSCInitializer for iOS and SmartContract.initialize(...) for Android
    /// </summary>
    internal interface IInitializer
    {
        Task<Boolean> Initialize(string secServUrl, string senseLicense);
    }
}

