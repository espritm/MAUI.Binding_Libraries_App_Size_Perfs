using ESignature.Interfaces;

namespace ESignature.EventArguments
{
    public class DidPageChangedEventArgs : EventArgs, IDidPageChangedEventArgs
    {
        public int PageIndex { get; }

        public DidPageChangedEventArgs(int pageIndex)
        {
            PageIndex = pageIndex;
        }
    }
}

