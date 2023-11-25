using System;
namespace ESignature.Interfaces
{
	public interface IContract
    {
        String Identifier { get; }

        String Type { get; }

        String State { get; }

        DateTime Date { get; }

        Dictionary<String, String> Metadata { get; }

        Stream Payload { get; set; }
    }
}

