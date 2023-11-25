//
//  SSCSessionService.h
//  sense-smartcontract-sdk-ios
//
//  Created by Marc-Henri Primault on 31.01.18.
//  Copyright © 2018 Marc-Henri Primault. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SSCBlocks.h"
#import "SSCEnrollmentInfo.h"

NS_ASSUME_NONNULL_BEGIN

/**
 * Class to manage the user session.
 *
 * To create a session, a user must be enrolled.
 */
@interface SSCSessionService : NSObject

/**
 *  Enroll a user and create the session
 *
 *  @param info       The info for the enrollment.
 *  @param errorBlock The block will be called (on the main thread) at the end of the enrollment phase.
 *                    If there is no error returned, then  the enrollment passed and the user is enrolled.
 *                    You can check it by using the method userLogged or alreadyEnrolledUsers
 */
//+ (void)enrollApplicationWithInfo:(SSCEnrollmentInfo *)info errorBlock:(void(^)(NSError *))errorBlock;
+ (void)enrollApplicationWithInfo:(SSCEnrollmentInfo *)info errorBlock:(SSCErrorBlock)errorBlock;

/**
 *  Create a user server side, enroll it and create the session
 *
 *  @param info       The info for the enrollment. Token must be set.
 *  @param errorBlock The block will be called (on the main thread) at the end of the enrollment phase.
 *                    If there is no error returned, then  the enrollment passed and the user is enrolled.
 *                    You can check it by using the method userLogged or alreadyEnrolledUsers
 */
//+ (void)enrollApplicationWithInfoAndToken:(SSCEnrollmentInfo *)info errorBlock:(void(^)(NSError *))errorBlock;
+ (void)enrollApplicationWithInfoAndToken:(SSCEnrollmentInfo *)info errorBlock:(SSCErrorBlock)errorBlock;

/**
 *  Create a session for the user on the server
 *
 *  This is the method called for a log in.
 *
 *  @param username   Username of the user to authenticate
 *  @param password   Password of the user to authenticate
 *  @param errorBlock The block will be called (on the main thread) at the end of the login phase.
 *                    If there is no error returned, then the login passed. You can check it by using the method userLogged.
 */
+ (void)createApplicationSessionWithUsername:(NSString *)username password:(NSString *)password errorBlock:(SSCErrorBlock)errorBlock;

/**
 *  Log out the current logged user.
 */
+ (void)logOut;

/**
 *  Returns the username who is logged in. If the user is loggged in a specific domain, the domain is included with @.
 *
 *  @return The username or an empty string if no one is logged.
 */
+ (NSString *)userLogged;

/**
 *  Returns the list of users already enrolled in SENSE on this device.
 *
 *  @return A list of string of the username already enrolled. The list is sorted by the time of the last time the user logged in successfully.
 *          The first object is the last one who logged in.
 */
+ (NSArray *)alreadyEnrolledUsers;

/**
 *  Disenroll the user enrolled on the device.
 */
+ (void)disenrollUser:(NSString *)username;

/**
 *  Returns the configuration for the app. The properties are configured server-side and retrieved during session establishment.
 *
 *  @return A dictionary containing the configuration's keys with values. If no properties are configured, an empty dictionary is returned.
 */
+ (NSDictionary *)getConfigProperties;

NS_ASSUME_NONNULL_END

@end
