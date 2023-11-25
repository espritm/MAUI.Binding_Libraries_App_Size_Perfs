using System;
using ESignature.Interfaces.Internals;

namespace ESignature.Implementations.Internals
{
#if ANDROID || IOS || MACCATALYST
#else
    internal class SecureStorageConstants : ISecureStorageConstants
    {
        public string SenseLogin => throw new NotImplementedException();

        public string SensePassword => throw new NotImplementedException();
    }
#endif
}