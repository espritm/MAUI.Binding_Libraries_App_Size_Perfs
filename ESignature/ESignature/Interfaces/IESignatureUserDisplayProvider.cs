using System;
namespace ESignature.Interfaces
{
	public interface IESignatureUserDisplayProvider
    {
        Task<string> GetESignatureUserDisplayNameForPDF();
    }
}

