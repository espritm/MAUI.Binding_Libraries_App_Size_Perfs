using System;
using System.Net;
using ESignature.Model;
using SmartContract_xcframework_to_DOTNET;

namespace ESignature.Implementations.Internals
{
    public static class ContractHelper
    {
        public static Contract FromSSCContract(SSCContract contract)
        {
            Contract result = new Contract();

            result.Identifier = contract.Identifier;

            result.Type = contract.Type;

            result.State = contract.State;

            result.Date = (DateTime)contract.Date;

            result.Metadata = new Dictionary<String, String>();
            if (contract.Metadata != null)
                foreach (var k in contract.Metadata)
                    result.Metadata.Add(k.Key.Description, k.Value.Description); //TODO Verify

            if (contract.Payload != null)
                result.Payload = new MemoryStream(contract.Payload.ToArray());

            return result;
        }
    }
}

