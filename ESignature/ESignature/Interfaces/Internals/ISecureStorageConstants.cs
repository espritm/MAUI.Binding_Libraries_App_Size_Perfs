using System;
namespace ESignature.Interfaces.Internals
{
    /// <summary>
    /// Providing platform specific constants for the secure storage keys.
    /// </summary>
    internal interface ISecureStorageConstants
    {
        String SenseLogin { get; }
        String SensePassword { get; }
    }
}

