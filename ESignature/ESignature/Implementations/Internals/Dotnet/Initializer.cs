using System;
using ESignature.Interfaces.Internals;

namespace ESignature.Implementations.Internals
{
#if ANDROID || IOS || MACCATALYST
#else
    internal class Initializer : IInitializer
    {
        public Task<bool> Initialize(string secServUrl, string senseLicense)
        {
            throw new NotImplementedException();
        }
    }
#endif
}

