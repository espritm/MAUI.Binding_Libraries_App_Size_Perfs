//
//  SSCRemoteNotification.h
//  sense-smartcontract-sdk-ios
//
//  Created by Marc-Henri Primault on 01.02.18.
//  Copyright © 2018 Marc-Henri Primault. All rights reserved.
//

@interface SSCRemoteNotification : NSObject

/*
 *  Determine if the remote notification registration is available.
 *  This parameter is set in SENSE server under the security settings.
 *
 *  @return YES if the remote notification registration is available otherwise NO
 */
+ (BOOL)isAvailable;

/*
 *  Register the token provided by the Apple Push Notification(APN) service in SENSE server. NOTE : If you use swift, you can use the error-free version of this method to get the boolean return
 *
 *  @param token The APN token received for the application.
 *  @param error The error if the registration failed.
 *               You may specify nil for this parameter if you do not want the error information.
 *  @return YES if the registration successful otherwise NO
 */
+ (BOOL)registerRemoteNotificationToken:(NSData *)token error:(NSError **)error;


/*
 *  Register the token provided by the Apple Push Notification(APN) service in SENSE server.
 *
 *  @param token The APN token received for the application.
 *
 *  @return YES if the registration successful otherwise NO
 */
+ (BOOL)registerRemoteNotificationToken:(NSData *)token;

@end
