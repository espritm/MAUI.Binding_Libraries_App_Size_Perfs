//
//  SSCASN1.h
//  sense-smartcontract-sdk-ios
//
//  Created by Marc-Henri Primault on 18.01.18.
//  Copyright © 2018 Sysmosoft. All rights reserved.
//

#import "SSCASN1Constants.h"

@interface SSCASN1 : NSObject

+ (void)appendSequence:(NSData *)data into:(NSMutableData *)into;
+ (void)appendINTEGER:(NSData *)data into:(NSMutableData *)into;
+ (void)appendPrintableString:(NSString *)string into:(NSMutableData *)into;
+ (void)appendAttr0String:(NSString *)string into:(NSMutableData *)into;
+ (void)appendAttr4Data:(NSData *)data into:(NSMutableData *)into;
+ (void)appendSubjectItem:(NSData *)what value:(NSString *)value into:(NSMutableData *)into;
+ (void)appendUTF8String:(NSString *)string into:(NSMutableData *)into;
+ (void)appendOCTETString:(NSData *)data into:(NSMutableData *)into;
+ (void)appendBITSTRING:(NSData *)data into:(NSMutableData *)into;
+ (void)appendUTCTime:(NSDate *)date into:(NSMutableData *)into;
+ (void)appendDERLength:(size_t)length into:(NSMutableData *)into;
+ (void)enclose:(NSMutableData *)data by:(uint8_t)by;

@end
