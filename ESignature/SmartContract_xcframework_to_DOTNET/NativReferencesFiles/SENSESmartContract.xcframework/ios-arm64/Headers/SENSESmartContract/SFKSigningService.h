//
//  SFKSigningService.h
//  sense-sdk-ios-framework
//
//  Created by jcaillet on 10.02.20.
//  Copyright © 2020 Sysmosoft. All rights reserved.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface SFKSigningService : NSObject

/**
 * Generates an EC-P256 key pair that will be securely stored in the secure enclave.
 *
 * @param alias The alias of the key pair.
 * @param error If the user is not logged in Sense.
 *              Or The device does not support key pair generation in the secure enclave.
 *
 * @return The public key of the key pair.
 */
+ (SecKeyRef)generateKeyPairWithAlias:(NSString *)alias error:(NSError *__autoreleasing *)error;

/**
 * Retrieves the public key for a given alias.
 *
 * @param alias The alias of the key pair.
 * @param error If the user is not logged in Sense.
 *              Or if the key pair does not exist or cannot be loaded from the secure enclave.
 *
 * @return The public key of the key pair.
 */
+ (SecKeyRef)publicKeyWithAlias:(NSString *)alias error:(NSError *__autoreleasing *)error;

/**
 * Signs the data provided using the private key of the given alias.
 *
 * @param data The raw data to be signed.
 * @param alias The alias of the key pair.
 * @param error If the user is not logged in Sense.
 *              Or if the key pair does not exist or cannot be loaded from the secure enclave.
 *              Or if an error occured while signing the data.
 *
 * @return The signed data.
 */
+ (NSData *)signData:(NSData *)data alias:(NSString *)alias error:(NSError *__autoreleasing *)error;

/**
 * Deletes the KeyPair of the given alias.
 *
 * @param alias The alias of the key pair.
 * @param error If the user is not logged in Sense.
 *              Or if the key pair does not exist in the secure enclave.
 */
+ (void)deleteKeyPairWithAlias:(NSString *)alias error:(NSError *__autoreleasing *)error;

/**
 * Verifies if a key pair exists for the given alias in the secure enclave.
 *
 * @param alias The alias of the key pair.
 * @param error If the user is not logged in Sense.
 * @return YES if a key pair is present in the secure enclave for the given alias, NO otherwise.
 */
+ (BOOL)existsWithAlias:(NSString *)alias error:(NSError *__autoreleasing *)error;

+ (void)clearAliasesForUsername:(NSString *)username;

@end

NS_ASSUME_NONNULL_END
