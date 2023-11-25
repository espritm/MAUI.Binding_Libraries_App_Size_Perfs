//
//  WYSSignatureInfo.h
//  sense-smartcontract-sdk-wysiwys-ios
//
//  Created by Mark on 14.01.21.
//  Copyright © 2021 sysmosoft. All rights reserved.
//

/**
 * Signature information for a prepared document
*/
@interface WYSSignatureInfo : NSObject

/**
 * Document digest of the prepared document
 */
@property (nonatomic) NSData *documentDigest;

/**
 * tells the reason of the prepared document which can be accepted or refused
 */
@property (nonatomic) NSString* reason;

@end
