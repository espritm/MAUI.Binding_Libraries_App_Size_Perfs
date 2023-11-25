//
//  SSCContractResponse.h
//  sense-smartcontract-sdk-ios
//
//  Created by Marc-Henri Primault on 23.01.18.
//  Copyright © 2018 Sysmosoft. All rights reserved.
//

/**
 * The model representing a response for a contract
 */
@interface SSCContractResponse : NSObject

/**
 * The identifier of the response
 */
@property (nonatomic, strong, readonly) NSString *contractId;

/**
 * The username of the user
 */
@property (nonatomic, strong, readonly) NSString *username;

/**
 * The domaine name of the user
 */
@property (nonatomic, strong, readonly) NSString *domainName;

/**
 * The response of the user
 */
@property (nonatomic, strong, readonly) NSString *response;

/**
 * The signing date of the contract
 */
@property (nonatomic, strong, readonly) NSDate *date;

/**
 * The signing context of the response
 */
@property (nonatomic, strong, readonly) NSDictionary *context;

/**
 * The signature of the response
 */
@property (nonatomic, strong, readonly) NSString *signature;

/**
 * The data of the response
 */
@property (nonatomic, strong, readonly) NSData *data;

@end
