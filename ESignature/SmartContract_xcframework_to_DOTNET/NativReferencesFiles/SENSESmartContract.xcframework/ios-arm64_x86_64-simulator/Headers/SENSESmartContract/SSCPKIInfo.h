//
//  SSCPKIInfo.h
//  sense-smartcontract-sdk-ios
//
//  Created by Marc-Henri on 02.04.19.
//  Copyright © 2019 Marc-Henri Primault. All rights reserved.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

/**
 The information for the TLS client certificate enrollment.
 */
@interface SSCPKIInfo : NSObject

/// The EST server URL.
@property (nonatomic) NSURL *estServerURL;

/// The username.
@property (nonatomic) NSString *enrollUsername;

/// The password.
@property (nonatomic) NSString *enrollPassword;

@end

NS_ASSUME_NONNULL_END
