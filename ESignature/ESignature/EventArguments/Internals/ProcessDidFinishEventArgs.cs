using System;
using ESignature.Interfaces;
using ESignature.Interfaces.Internals;

namespace ESignature.EventArguments.Internals
{
    internal class ProcessDidFinishEventArgs : EventArgs, IProcessDidFinishEventArgs
    {
        public string Reason { get; }

        public Stream Document { get; }

        public IContract Contract { get; }

        public ProcessDidFinishEventArgs(string reason, Stream document, IContract contract)
        {
            Reason = reason;
            Document = document;
            Contract = contract;
        }
    }
}

