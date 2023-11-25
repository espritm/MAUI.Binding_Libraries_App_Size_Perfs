using System;
using ESignature.Interfaces;
using ESignature.Interfaces;

namespace ESignature.EventArguments
{
    public class SignatureRequestedForPreparedDocumentEventArgs : EventArgs, ISignatureRequestedForPreparedDocumentEventArgs
    {
        public Stream SignatureDigest { get; }

        public SignatureRequestedForPreparedDocumentEventArgs(Stream signatureDigest)
        {
            SignatureDigest = signatureDigest;
        }
    }
}

