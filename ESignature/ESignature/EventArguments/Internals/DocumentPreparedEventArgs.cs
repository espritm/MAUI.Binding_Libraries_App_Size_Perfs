using System;
using ESignature.Interfaces;
using ESignature.Interfaces.Internals;

namespace ESignature.EventArguments.Internals
{
    internal class DocumentPreparedEventArgs : EventArgs, IDocumentPreparedEventArgs
    {
        public Stream DocumentDigest { get; }

        public string Reason { get; }

        public IContract Contract { get; }

        public DocumentPreparedEventArgs(Stream documentDigest, string reason, IContract contract)
        {
            DocumentDigest = documentDigest;
            Reason = reason;
            Contract = contract;
        }
    }
}

