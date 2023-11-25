//
//  WYSSignatureConfiguration.h
//  sense-smartcontract-sdk-wysiwys-ios
//
//  Created by Mark on 09.03.20.
//  Copyright © 2020 Sysmosoft. All rights reserved.
//

#import "WYSSignatureStore.h"

/**
 * Configuration to give when initilizing the prcoessing of a document
 */
@interface WYSPdfViewerConfiguration : NSObject;

/**
 * The username designating the signer.
 *
 */
@property (nonatomic, nonnull) NSString *username;

/**
 * Set the licence of the SDK.
 *
 */
@property (nonatomic, nonnull) NSString *license;

/**
 * Set the storage key. The storage key is used to encrypt all the documents. The key must be exactly 64 bytes long.
 *
 */
@property (nonatomic, nonnull) NSData *storageKey;

/**
 * Set a custom implementation of the signature store. If not set, the default signature store using internal database would be used.
 *
 */
@property (nonatomic) id<WYSSignatureStore> signatureStore;

@end
