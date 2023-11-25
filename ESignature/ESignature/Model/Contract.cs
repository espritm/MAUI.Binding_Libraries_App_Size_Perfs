using System;
using ESignature.Interfaces;

namespace ESignature.Model
{
    public class Contract : IContract
    {
        public Contract()
        {
        }

        public String Identifier { get; internal set; }

        public String Type { get; internal set; }

        public String State { get; internal set; }

        public DateTime Date { get; internal set; }

        public Dictionary<String, String> Metadata { get; internal set; }

        public Stream Payload { get; set; }
    }
}

