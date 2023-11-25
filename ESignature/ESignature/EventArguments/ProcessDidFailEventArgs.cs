using System;
using ESignature.Interfaces;
using ESignature.Interfaces;

namespace ESignature.EventArguments
{
    public class ProcessDidFailEventArgs : EventArgs, IProcessDidFailEventArgs
    {
        public string Error { get; }

        public ProcessDidFailEventArgs(string error)
        {
            Error = error;
        }
    }
}

