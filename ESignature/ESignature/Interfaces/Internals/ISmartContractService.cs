using System;
using ESignature.Model;

namespace ESignature.Interfaces.Internals
{
    /// <summary>
    /// Sysmosoft equivalent SSCSmartContractService for iOS and SmartContractService for Android
    /// </summary>
    internal interface ISmartContractService
    {
        Task<Boolean> SendResponse(String sReason, Stream document, String contractID);

        Task<Stream> RequestSignature(String contractID, Stream documentDigest);

        Task<Stream> GetContractPayload(String contractID);

        Task<IList<Contract>> GetPendingContracts();
    }
}