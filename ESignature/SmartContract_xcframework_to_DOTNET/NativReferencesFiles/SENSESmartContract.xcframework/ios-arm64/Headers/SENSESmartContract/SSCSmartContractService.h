//
//  SSCContractService.h
//  sense-smartcontract-sdk-ios
//
//  Created by Marc-Henri Primault on 01.02.18.
//  Updated by Mark Vincent on 04.02.18
//  Copyright © 2018 Sysmosoft. All rights reserved.
//

#import "SSCBlocks.h"
#import "SSCContractSending.h"
#import "SSCContractEvent.h"

 NS_ASSUME_NONNULL_BEGIN

/**
 * Class to handle the contracts provided by the SENSE Smart Contract server.
 */
@interface SSCSmartContractService : NSObject

- (instancetype)initWithError:(NSError **)error;

/**
 * Retrieve the pending contracts for logged in user.
 *
 * @param completion Completion block with the contracts list
 *                   or an error in case of failure
 */
- (void)getPendingContractsCompletion:(SSCContractsBlock)completion;

/**
 * Retrieve the payload of the contract.
 *
 * @param contract The contract which you want to retrieve the payload
 * @param errorBlock Completion block which contains an error in case of failure
 */
- (void)getPayloadForContract:(SSCContract *)contract error:(SSCErrorBlock)errorBlock;

/**
 * Retrieve of contracts contained inside an envelope.
 *
 * @param envelope The contract envelope which you want to retrieve the payload
 * @param completion Completion block with the contracts list
 *                   or an error in case of failure
 */
- (void)getEnvelopeContracts:(SSCContract *)envelope completion:(SSCContractsBlock)completion;

/**
 * Send the response for a contract.
 *
 * @param sendingResponse The sending response
 * @param completion Completion block which contains the contract response sent to the server otherwise an error in case of failure.
 */
- (void)sendResponse:(SSCContractSending *)sendingResponse completion:(SSCContractResponseBlock)completion;

/**
* Request a remote signature for the given document digest
*
* @param contract the contract from which the digest has been calculated
* @param documentDigest the document digest to be processed for signature
* @param signatureStatusBlock Completion block which contains either a PKSC7 (if status is SUCCESS) or an authentication URL.
* If nothing is set, the status is set to a no success reason (TIMEOUT,CANCEL,ERROR). If an authentication URL is set, the requestId
* must be kept for further processing with signatureStatus
*/
- (void)requestSignatureForContract:(SSCContract *)contract withDocumentDigest:(NSData *)documentDigest completion:(SSCSignatureStatusBlock) signatureStatusBlock;

/**
* Requests remote signature for multiple digests at once.
*
* @param contract the contract of type envelop from which the digests of document inside have been calculated
* @param documentDigests the document digest list to be processed for signature
* @param signatureStatusBlock Completion block which contains either a PKSC7 list (if status is SUCCESS) or an authentication URL.
* If nothing is set, the status is set to a no success reason (TIMEOUT,CANCEL,ERROR). If an authentication URL is set, the requestId
* must be kept for further processing with signatureStatus
*/
- (void)requestSignaturesForContract:(SSCContract *)contract withDocumentDigests:(NSDictionary<NSString*,NSData*> *)documentDigests completion:(SSCSignatureStatusBlock) signatureStatusBlock;

/**
* Method to poll the signature status of a requestID.
*
* @param contract the contract from which we need the signature status
* @param requestId the requestID for the request we would like to know the status
* @param signatureStatusBlock Completion block which contains PKSC7 (or a list of PKSC7 in case of an envelope) (if status is SUCCESS), PENDING is the PKSC7 is not available yet or
* a no success reason (TIMEOUT,CANCEL,ERROR)
*/
- (void)signatureStatusForContract:(SSCContract *)contract withRequestId:(NSString*)requestId completion:(SSCSignatureStatusBlock) signatureStatusBlock;

/**
 * Send an event
 *
 * @param event the event to send
 * @param contractBlock Completion block which contains a contract only if expected or an error in case of failure.
 */
- (void)sendEvent:(SSCContractEvent *)event completion:(SSCContractBlock)contractBlock;

/**
 * Retrieves visual signature stored server-side.
 *
 * @param signatureTypes filter signatures by types. If nil, all signatures are retrieved (like giving:
 *
 * NSArray *types = [[NSArray alloc] initWithObjects:
 * @(SSCSignatureTypeText),
 * @(SSCSignatureTypeDraw),
 * @(SSCSignatureTypeImage), nil];
 *
 * ).
 * @param visualSignaturesBlock Completion block which contains a list of visual signatue or an error in case of failure.
 */
-(void)visualSignaturesOfTypes:(NSArray* _Nullable) signatureTypes completion:(SSCVisualSignaturesBlock) visualSignaturesBlock;

/**
 * Saves a visual signature server-side.
 *
 * @param visualSignature a signature object with only the type and data attributes set
 * @param visualSignatureBlock Completion block which contains the stored signature or an error in case of failure.
 */

-(void)saveVisualSignature:(SSCVisualSignature*) visualSignature completion:(SSCVisualSignatureBlock)visualSignatureBlock;

/**
 * Deletes a visual signature server-side.
 *
 * @param identifier  the signature id
 */
-(void)deleteSignature:(NSString*)identifier error:(SSCErrorBlock)errorBlock;

@end

NS_ASSUME_NONNULL_END
