using System;
namespace ESignature.Interfaces
{
	public interface IESignatureGeolocationProvider
    {
        Task<string> GetESignatureGeolocationForPDF();
    }
}

