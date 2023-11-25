using System;
using ESignature.Interfaces.Internals;

namespace ESignature.EventArguments.Internals
{
    internal class ProcessDidFailWithErrorEventArgs : EventArgs, IProcessDidFailWithErrorEventArgs
    {
        public string Error { get; }

        public ProcessDidFailWithErrorEventArgs(string error)
        {
            Error = error;
        }
    }
}

