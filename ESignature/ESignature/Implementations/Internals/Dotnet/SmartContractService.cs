using System;
using ESignature.Interfaces.Internals;
using ESignature.Model;

namespace ESignature.Implementations.Internals
{
#if ANDROID || IOS || MACCATALYST
#else
    internal class SmartContractService : ISmartContractService
    {
        public Task<Stream> GetContractPayload(string contractID)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Contract>> GetPendingContracts()
        {
            throw new NotImplementedException();
        }

        public Task<Stream> RequestSignature(string contractID, Stream documentDigest)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendResponse(string sReason, Stream document, string contractID)
        {
            throw new NotImplementedException();
        }
    }
#endif
}

