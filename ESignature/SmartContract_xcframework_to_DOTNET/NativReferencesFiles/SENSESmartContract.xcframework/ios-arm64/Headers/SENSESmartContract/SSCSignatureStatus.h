//
//  SSCSignatureStatus.h
//  sense-smartcontract-sdk-ios
//
//  Created by Mark Vincent on 04.02.20.
//  Copyright © 2020 Sysmosoft. All rights reserved.
//

#import <Foundation/Foundation.h>

/**
 * The model representing a signature status when requesting remote signature
 */
@interface SSCSignatureStatus : NSObject

/**
 * CANCEL: The user has canceled the signature request.
 * ERROR: An error occurred.
 * PENDING: The user must be authenticated.
 * SUCCESS: The digest has been successfully signed.
 * TIMEOUT: The signature request has timed out.
*/
typedef enum statusTypes{
    CANCEL, ERROR, PENDING, SUCCESS, TIMEOUT
} Status;

/**
 * NOT_ALLOWED: The user is not allowed to request the signature.
 * SERVICE_FAILURE: The service is not available at this moment.
 * UNRECOVERABLE_FAILURE: An unrecoverable error occurred, the contract has been moved to an error state and cannot be retrieved anymore.
*/
typedef enum errorTypes{
    NOT_ALLOWED, SERVICE_FAILURE, UNRECOVERABLE_FAILURE
} StatusError;

/**
 * The id of the request bound to this signature status
*/
@property (nonatomic, strong, readonly) NSString *requestId;

/**
 * The status of the request
 */
@property (nonatomic, assign, readonly) Status status;

/**
 * The signature as a PKSC7 returned by the remote signature service
 * Always Null when signature is requested using API
 * [SSCSmartContractService#requestSignaturesForContract: withDocumentDigests: completion:].
 * In that case, signatures are can be retrieved using [SSCSignatureStatus signatures] API.
 */
@property (nonatomic, strong, readonly) NSData *signature;

/**
 * The DER-encoded signatures of the digests, mapped by their identifiers.
 *
 * Not null and not empty when [SignatureStatus status] is equals to Status.SUCCESS.
 *
 * Always Null when single digest signature is requested using API
 * [SSCSmartContractService#requestSignatureForContract: withDocumentDigest: completion:]
 * In that case, signature are can be retrieved using [SSCSignatureStatus signature] API.
 */
@property (nonatomic, strong, readonly) NSDictionary<NSString*,NSData*> *signatures;

/**
 * If the signature is pending, a declaration of will (consent) may be required. Consent is delivered back to the
 * application as an URL as most of the use cases require to display a web page
 */
@property (nonatomic, strong, readonly) NSString *authenticationUrl;

/**
 * Represents the cause of the error.
 */
@property (nonatomic, assign, readonly) StatusError error;

/**
 * If the status is equals to ERROR, errorInfo may gives more details.
 */
@property (nonatomic, assign, readonly) NSString* errorInfo;

- (instancetype)initWithContract:(SSCContract *)contract;

@end
