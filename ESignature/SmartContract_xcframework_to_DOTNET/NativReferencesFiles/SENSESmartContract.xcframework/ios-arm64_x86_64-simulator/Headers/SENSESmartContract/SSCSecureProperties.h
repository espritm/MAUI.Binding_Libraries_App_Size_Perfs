//
//  SSCSecureProperties.h
//  sense-smartcontract-sdk-ios
//
//  Created by Mark on 11.06.20.
//  Copyright © 2020 Marc-Henri Primault. All rights reserved.
//

@interface SSCSecureProperties : NSObject

+ (void)setPropertyWithAlias:(NSString*)alias andValue:(NSString*)value;
+ (NSString*)valueForAlias:(NSString*)alias;

@end
