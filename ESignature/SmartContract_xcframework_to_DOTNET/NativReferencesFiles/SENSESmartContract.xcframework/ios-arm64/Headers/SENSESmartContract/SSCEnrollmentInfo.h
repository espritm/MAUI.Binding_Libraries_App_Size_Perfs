//
//  SSCEnrollmentInfo.h
//  sense-smartcontract-sdk-ios
//
//  Created by Marc-Henri on 02.04.19.
//  Copyright © 2019 Marc-Henri Primault. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SSCPKIInfo.h"

NS_ASSUME_NONNULL_BEGIN

/**
 Information to enroll a user.
 */
@interface SSCEnrollmentInfo : NSObject

/// The user's username.
@property (nonatomic) NSString *username;

/// The user's password
@property (nonatomic) NSString *password;

/// The user's enrollment code.
@property (nonatomic) NSString *code;

/// The user's token when sense is used with OIDC infrastructure
@property (nonatomic) NSString *token;

/// The information for the TLS client certificate enrollment.
@property (nonatomic, nullable) SSCPKIInfo *pkiInfo;

@end

NS_ASSUME_NONNULL_END
