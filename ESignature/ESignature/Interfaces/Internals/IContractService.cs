using System;
using ESignature.Model;

namespace ESignature.Interfaces.Internals
{
    /// <summary>
    /// The service to get the contracts and their content, or to send the response for a signed contract.
    /// </summary>
    internal interface IContractService
    {
        /// <summary>
        /// Send the response for a contract.
        /// </summary>
        /// <param name="sReason">The response value (accepted or refused).</param>
        /// <param name="document">The data attached with the response. For instance with a PDF contract, the contract payload with the signature.</param>
        /// <param name="contract">The contract linked to the sending response.</param>
        /// <returns></returns>
        Task<Boolean> SendResponse(String sReason, Stream document, Contract contract);

        /// <summary>
        /// Request a remote signature for the given document digest.
        /// </summary>
        /// <param name="contract">The contract from which the digest has been calculated.</param>
        /// <param name="documentDigest">The document digest to be processed for signature.</param>
        /// <returns>A stream whith the PKSC7 (if status is SUCCESS), else null.</returns>
        Task<Stream> RequestSignature(Contract contract, Stream documentDigest);

        /// <summary>
        /// Retrieve the payload of the contract.
        /// </summary>
        /// <param name="contract">The contract which you want to retrieve the payload.</param>
        /// <returns>The contract payload as a Stream, null if an error occured.</returns>
        Task<Stream> GetContractPayload(Contract contract);

        /// <summary>
        /// Retrieve the pending contracts for logged in user.
        /// </summary>
        /// <returns>The contracts list.</returns>
        Task<List<Contract>> GetPendingContracts();
    }
}

