using System;
using ESignature.Interfaces;
using ESignature.Interfaces.Internals;
using ESignature.Model;
using CH.Sysmosoft.Sense.Smartcontract.Sdk;
using CH.Sysmosoft.Sense.Smartcontract.Sdk.Model;
using static Java.Security.Cert.CertPathValidatorException;
using System.Diagnostics.Contracts;

namespace ESignature.Implementations.Internals
{
    internal class SmartContractService : ISmartContractService
    {
        public SmartContractService()
        {
        }

        public async Task<Stream> GetContractPayload(string contractID)
        {
            TaskCompletionSource<Stream> completion = new TaskCompletionSource<Stream>();

            await Task.Run(() =>
            {
                try
                {
                    byte[] payload = SmartContract.SessionService.Services.SmartContractService.GetPayload(contractID);

                    if (payload != null)
                        completion.SetResult(new MemoryStream(payload));
                    else
                        completion.SetResult(null);
                }
                catch (Exception e)
                {
                    completion.SetResult(null);
                }
            });

            return await completion.Task;
        }

        public async Task<IList<ESignature.Model.Contract>> GetPendingContracts()
        {
            TaskCompletionSource<List<ESignature.Model.Contract>> completion = new TaskCompletionSource<List<ESignature.Model.Contract>>();

            await Task.Run(() =>
            {
                try
                {
                    IList<CH.Sysmosoft.Sense.Smartcontract.Sdk.Model.Contract> contracts = SmartContract.SessionService.Services.SmartContractService.PendingContracts;

                    if (contracts != null)
                    {
                        List<ESignature.Model.Contract> result = new List<ESignature.Model.Contract>();

                        foreach (var c in contracts)
                            result.Add(ContractHelper.FromSDKContract(c));

                        completion.SetResult(result);
                    }
                    else
                        completion.SetResult(null);
                }
                catch (Exception e)
                {
                    completion.SetResult(null);
                }
            });

            return await completion.Task;
        }

        public async Task<Stream> RequestSignature(string contractID, Stream documentDigest)
        {
            TaskCompletionSource<Stream> completion = new TaskCompletionSource<Stream>();

            MemoryStream memoryStream = new MemoryStream();
            await documentDigest.CopyToAsync(memoryStream);
            byte[] documentDigestPayload = memoryStream.ToArray();

            await Task.Run(() =>
            {
                try
                {
                    SignatureStatus signatureStatus = SmartContract.SessionService.Services.SmartContractService.RequestSignature(contractID, documentDigestPayload);

                    if (signatureStatus != null && signatureStatus.GetStatus() == SignatureStatus.Status.Success)
                    {
                        Stream result = new MemoryStream(signatureStatus.GetSignature());
                        completion.SetResult(result);
                    }
                    else
                        completion.SetResult(null);
                }
                catch (Exception e)
                {
                    completion.SetResult(null);
                }
            });

            return await completion.Task;
        }

        public async Task<bool> SendResponse(string sReason, Stream document, string contractID)
        {
            TaskCompletionSource<bool> completion = new TaskCompletionSource<bool>();

            MemoryStream memoryStream = new MemoryStream();
            await document.CopyToAsync(memoryStream);
            byte[] documentPayload = memoryStream.ToArray();

            await Task.Run(() =>
            {
                try
                {
                    ContractResponse contractResponse = SmartContract.SessionService.Services.SmartContractService.SendResponse(contractID, documentPayload, sReason, true);

                    if (contractResponse == null)
                        completion.SetResult(false);
                    else
                        completion.SetResult(true);
                }
                catch (Exception e)
                {
                    completion.SetResult(false);
                }
            });

            return await completion.Task;
        }
    }
}