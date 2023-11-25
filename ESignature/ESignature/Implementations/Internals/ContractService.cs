using System;
using ESignature.Interfaces;
using ESignature.Interfaces.Internals;
using ESignature.Model;

namespace ESignature.Implementations.Internals
{
    public class ContractService : IContractService
    {
        private ILogerService logerService;
        private ISmartContractService smartContractService;// = new SmartContractService(); //Platform specific

        public ContractService(ILogerService logerService)
        {
            this.logerService = logerService;
        }

        private void Initialize()
        {
            if (smartContractService == null)
                smartContractService = new SmartContractService(); //Sense user should be loged in to not throw.
        }

        public async Task<Stream> GetContractPayload(Contract contract)
        {
            Initialize();
            Stream payload = null;

            try
            {
                payload = await smartContractService.GetContractPayload(contract.Identifier);

                if (payload == null)
                    logerService?.LogEvent("SmartContractService did fail while downloading contract payload...", LogEventType.Public);
                else
                    logerService?.LogEvent("SmartContractService did download contract payload successfully !", LogEventType.Public);
            }
            catch (Exception e)
            {
                logerService.LogEvent(e.Message, LogEventType.Public);
            }

            return payload;
        }

        public async Task<List<Contract>> GetPendingContracts()
        {
            Initialize();
            List<Contract> lsContracts = new List<Contract>();

            try
            {
                IList<Contract> pendingContracts = await smartContractService.GetPendingContracts();

                if (pendingContracts == null)
                    logerService?.LogEvent("SmartContractService did fail while getting pending contracts...", LogEventType.Public);
                else
                {
                    logerService?.LogEvent("SmartContractService did get pending contracts successfully !", LogEventType.Public);
                    lsContracts.AddRange(pendingContracts);
                }
            }
            catch (Exception e)
            {
                logerService.LogEvent(e.Message, LogEventType.Public);
            }

            return lsContracts;
        }

        public async Task<Stream> RequestSignature(Contract contract, Stream documentDigest)
        {
            Initialize();
            Stream payload = null;

            try
            {
                payload = await smartContractService.RequestSignature(contract.Identifier, documentDigest);

                if (payload == null)
                    logerService?.LogEvent("SmartContractService did fail while requesting signature...", LogEventType.Public);
                else
                    logerService?.LogEvent("SmartContractService did request signature successfully !", LogEventType.Public);
            }
            catch (Exception e)
            {
                logerService.LogEvent(e.Message, LogEventType.Public);
            }

            return payload;
        }

        public async Task<Boolean> SendResponse(string sReason, Stream document, Contract contract)
        {
            Initialize();
            Boolean succeed = false;

            try
            {
                succeed = await smartContractService.SendResponse(sReason, document, contract?.Identifier);

                if (succeed)
                    logerService?.LogEvent("SmartContractService did send response successfully !", LogEventType.Public);
                else
                    logerService?.LogEvent("SmartContractService did fail while sending response...", LogEventType.Public);
            }
            catch (Exception e)
            {
                logerService.LogEvent(e.Message, LogEventType.Public);
            }

            return succeed;
        }
    }
}

