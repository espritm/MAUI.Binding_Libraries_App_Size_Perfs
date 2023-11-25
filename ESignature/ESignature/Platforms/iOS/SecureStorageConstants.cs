using System;
using ESignature.Interfaces.Internals;

namespace ESignature.Implementations.Internals
{
    internal class SecureStorageConstants : ISecureStorageConstants
    {
        public string SenseLogin => "eSignLogin"; //In the ios actual app is "login" 

        public string SensePassword => "eSignPassword"; //In the ios actual app is "eSignPassword"
    }
}

