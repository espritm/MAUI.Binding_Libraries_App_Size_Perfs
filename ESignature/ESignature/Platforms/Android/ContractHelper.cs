using System;
namespace ESignature.Implementations.Internals
{
    public static class ContractHelper
    {
        public static ESignature.Model.Contract FromSDKContract(CH.Sysmosoft.Sense.Smartcontract.Sdk.Model.Contract contract)
        {
            ESignature.Model.Contract result = new ESignature.Model.Contract();

            result.Identifier = contract.Id;

            result.Type = contract.Type;

            result.State = contract.State;

            result.Date = DateTimeOffset.FromUnixTimeMilliseconds(contract.Date).LocalDateTime; 

            result.Metadata = new Dictionary<String, String>();
            if (contract.MetaData != null)
                foreach (var k in contract.MetaData)
                    result.Metadata.Add(k.Key, k.Value); 

            if (contract.GetPayload() != null)
                result.Payload = new MemoryStream(contract.GetPayload());

            return result;
        }
    }
}

