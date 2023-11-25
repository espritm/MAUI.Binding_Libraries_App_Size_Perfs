using System;
using Foundation;
using SmartContract_xcframework_to_DOTNET;
using ESignature.Interfaces.Internals;
using ESignature.Model;
using ObjCRuntime;

//[assembly: LinkWith("SENSESmartContract.framework\\SENSESmartContract", SmartLink = true, ForceLoad = true)]
namespace ESignature.Implementations.Internals
{
    internal class SmartContractService : ISmartContractService
    {
        private SSCSmartContractService nativeSmartContractService; 
        private List<SSCContract> lsContracts = new List<SSCContract>();

        public SmartContractService()
        {
            NSError er = new NSError(new NSString("domaion"), 404);
            nativeSmartContractService = new SSCSmartContractService();

            String s = null;
            if (er != null)
                s = er.DebugDescription.ToString();
        }

        SSCContract FindContractAndThrowIfNotFound(String contractID)
        {
            if (String.IsNullOrWhiteSpace(contractID))
                throw new Exception("Contract not found for ID null or whitespace");

            SSCContract contract = lsContracts.Find(c => c.Identifier.Equals(contractID));

            if (contract == null)
                throw new Exception($"Contract not found for ID {contractID}");

            return contract;
        }

        public async Task<Stream> GetContractPayload(String contractID)
        {
            SSCContract contract = FindContractAndThrowIfNotFound(contractID);

            TaskCompletionSource<Stream> completion = new TaskCompletionSource<Stream>();
            nativeSmartContractService.GetPayloadForContract(contract, (error) => {
                if (error == null)
                {
                    //Update the local list of contracts with the new instance with the payload.
                    lsContracts.RemoveAll(c => c.Identifier.Equals(contract.Identifier));
                    lsContracts.Add(contract);

                    NSData payload = contract.Payload;
                    completion.SetResult(new MemoryStream(payload?.ToArray()));
                }
                else
                { 
                    completion.SetResult(null);
                    throw new Exception($"Failed to GetPayloadForContract {contractID} : {error.LocalizedDescription} ");
                }
            });

            return await completion.Task;
        }

        public async Task<IList<Contract>> GetPendingContracts()
        {
            TaskCompletionSource<IList<Contract>> completion = new TaskCompletionSource<IList<Contract>>();
            nativeSmartContractService.GetPendingContractsCompletion((contracts, error) => {
                if (error == null)
                {
                    if (contracts == null)
                        throw new Exception($"Error while getting contracts : error is null and contracts is null ");

                    List<Contract> result = new List<Contract>();

                    for (int i = 0; i < contracts.Length; i++)
                    {
                        SSCContract sscContract = contracts[i];
                        Contract contract = ContractHelper.FromSSCContract(sscContract);
                        result.Add(contract);
                    }

                    lsContracts.Clear();
                    lsContracts.AddRange(contracts);

                    completion.SetResult(result);
                }
                else
                {
                    completion.SetResult(null);
                    throw new Exception($"Error while getting contracts : {error.LocalizedDescription} ");
                }
            });

            return await completion.Task;
        }

        public async Task<Stream> RequestSignature(String contractID, Stream documentDigest)
        {
            SSCContract contract = FindContractAndThrowIfNotFound(contractID);

            TaskCompletionSource<Stream> completion = new TaskCompletionSource<Stream>();
            nativeSmartContractService.RequestSignatureForContract(contract, NSData.FromStream(documentDigest), (response, error) => {
                if (response == null)
                    completion.SetResult(null);
                else
                {
                    switch (response.Status)
                    {
                        case Status.Success:
                            NSData signature = response.Signature;
                            completion.SetResult(new MemoryStream(signature?.ToArray()));
                            break;

                        case Status.Pending:
                            completion.SetResult(null);
                            break;

                        case Status.Error:
                            //Erreur
                            completion.SetResult(null);
                            break;

                        default:
                            // Invalid status (Cancel or Timeout)
                            completion.SetResult(null);
                            break;
                    }
                }
            });

            return await completion.Task;
        }

        public async Task<Boolean> SendResponse(string sReason, Stream document, String contractID)
        {
            SSCContract contract = FindContractAndThrowIfNotFound(contractID);

            SSCContractSending contractSending = new SSCContractSending(sReason, contract);
            contractSending.Data = NSData.FromStream(document);
            contractSending.Attached = true; 

            TaskCompletionSource<Boolean> completion = new TaskCompletionSource<Boolean>();
            nativeSmartContractService.SendResponse(contractSending, (response, error) => {
                if (error == null)
                    completion.SetResult(true);
                else
                {
                    completion.SetResult(false);
                    throw new Exception($"Failed to Send Contract Response for ID {contractID} : {error.LocalizedDescription} ");
                }
            });

            return await completion.Task;
        }
    }
}

