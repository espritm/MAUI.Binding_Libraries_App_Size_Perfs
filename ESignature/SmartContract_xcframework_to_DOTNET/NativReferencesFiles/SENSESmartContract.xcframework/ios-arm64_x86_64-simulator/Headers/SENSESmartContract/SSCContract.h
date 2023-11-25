//
//  SSCContract.h
//  sense-smartcontract-sdk-ios
//
//  Created by Marc-Henri Primault on 22.01.18.
//  Copyright © 2018 Sysmosoft. All rights reserved.
//

/**
 * The model representing a contract
 */
@interface SSCContract : NSObject

/**
 * The identifier of the contract
 */
@property (nonatomic, strong, readonly) NSString *identifier;

/**
 * The type of the contract
 */
@property (nonatomic, strong, readonly) NSString *type;

/**
 * The state of the contract
 */
@property (nonatomic, strong, readonly) NSString *state;

/**
 * The date of the contract
 */
@property (nonatomic, strong, readonly) NSDate *date;

/**
 * The metadata of the contract
 */
@property (nonatomic, strong, readonly) NSDictionary *metadata;

/**
 * The payload of the contract.
 * When signing a contract, only the payload is signed.
 */
@property (nonatomic, strong, readonly) NSData *payload;

@end
