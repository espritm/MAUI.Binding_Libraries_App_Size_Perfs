using System;
namespace ESignature.Interfaces
{
	public interface IESignatureActivationCodeProvider
    {
        Task<String> GetESignatureActivationCode();
    }
}

