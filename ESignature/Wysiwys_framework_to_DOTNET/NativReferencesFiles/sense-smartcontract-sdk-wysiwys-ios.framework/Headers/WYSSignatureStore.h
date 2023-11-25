//
//  WYSSignatureStore.h
//  sense-smartcontract-sdk-wysiwys-ios
//
//  Created by Mark on 17.11.21.
//  Copyright © 2021 sysmosoft. All rights reserved.
//

#import "WYSEnums.h"

/**
 * Protocol to provides an external signature store
 */
@protocol WYSSignatureStore <NSObject>

@required
/**
 * Called when the user has added a signature
 *
 * @param signature The image reprezenting the visual signature.
 * @param mode The mode used to capture the signature
 */
- (void)addSignature:(nonnull UIImage *)signature capturedWithMode:(WYSSignatureMode)mode;

/**
 * Called when the user has deleted a signature
 * @param identifier The id of the signature to delete
 */
- (BOOL)removeSignature:(nonnull NSString *)identifier;

/**
 * Called when the signature list is displayed
 */
- (NSDictionary<NSString*, UIImage*> *)signatures;

@end
