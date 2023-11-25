//
//  SSCContractEvent.h
//  sense-smartcontract-sdk-ios
//
//  Created by Marc-Henri on 16.01.19.
//  Copyright © 2019 Marc-Henri Primault. All rights reserved.
//

#import "SSCContract.h"

/**
 * Class to represent an event for a contract.
 */
@interface SSCContractEvent : NSObject

/**
 * The identifier for the event
 */
@property (nonatomic, strong, readonly) NSString *identifier;

/**
 * The name of the event
 */
@property (nonatomic, strong, readonly) NSString *name;

/**
 * The data of the event.
 */
@property (nonatomic, strong) NSData *data;

/**
 * The extra of the event.
 */
@property (nonatomic, strong) NSDictionary<NSString *, NSString *> *extras;

/**
 * The initializer for an event
 *
 * @param name The name of the event
 * @param contract The contract linked to the event
 *
 * @warning May return nil if the name or the contract are not set.
 */
- (instancetype)initWithName:(NSString *)name forContract:(SSCContract *)contract;

@end
