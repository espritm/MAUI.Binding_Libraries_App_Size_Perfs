//
//  SSCInitializer.h
//  sense-smartcontract-sdk-ios
//
//  Created by Marc-Henri Primault on 31.01.18.
//  Copyright © 2018 Marc-Henri Primault. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SSCBlocks.h"

/**
 *  This class is used to initialize the framework. For the moment,
 *  the developer can only set the URL of the SENSE security server.
 */
@interface SSCInitializer : NSObject

/**
 * The SENSE security server URL
 *
 * @note If the senseServerURL property is not set, the instance use the value
 *       of `sec-server-url` key in the `sense-config.properties` file.
 */
@property (nonatomic, copy) NSURL *senseServerURL;

/**
 * The list of the non proxy hosts
 *
 * A non proxy host will not be handled by the SENSE HTTP proxy.
 * A non proxy host prefixed with a wildcard '*' character is supported.
 * Example: google.com, *.apple.com
 */
@property (nonatomic, copy) NSSet<NSString *> *nonProxyHosts;

/**
 *  Generate or retrieve the unique instance of SFKInitializer
 *
 *  @return The unique instance of SFKInitializer
 */
+ (instancetype)instance;

/**
 * Verifies that the SENSE server is well reachable.
 *
 * @param errorBlock An error is returned if the server is not reachable
 *                   otherwise return nil.
 */
- (void)verifyServerReachabilityCompletion:(SSCErrorBlock)errorBlock;

@end
