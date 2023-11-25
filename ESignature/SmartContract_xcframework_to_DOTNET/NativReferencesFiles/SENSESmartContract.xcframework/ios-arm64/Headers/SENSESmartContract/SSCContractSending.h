//
//  SSCContractSending.h
//  sense-smartcontract-sdk-ios
//
//  Created by Marc-Henri on 22.07.19.
//  Copyright © 2019 Marc-Henri Primault. All rights reserved.
//

#import "SSCContract.h"

NS_ASSUME_NONNULL_BEGIN

/**
 * Class to represent an sending response for a contract.
 */
@interface SSCContractSending : NSObject

/**
 * The identifier for the sending response.
 */
@property (nonatomic, strong, readonly) NSString *identifier;

/**
 * The response value
 */
@property (nonatomic, strong, readonly) NSString *response;

/**
 * The data attached with the response.
 *
 * The default value is the contact's payload.
 */
@property (nonatomic, strong, nullable) NSData *data;

/**
 * The data should be attached with the sending response.
 */
@property (nonatomic, assign) BOOL attached;

/**
 * The initializer for a sending response
 *
 * @param response The response value
 * @param contract The contract linked to the sending response
 *
 * @warning May return nil if the name or the contract are not set.
 */
- (instancetype)initWithResponse:(NSString *)response forContract:(SSCContract *)contract;

@end

NS_ASSUME_NONNULL_END
