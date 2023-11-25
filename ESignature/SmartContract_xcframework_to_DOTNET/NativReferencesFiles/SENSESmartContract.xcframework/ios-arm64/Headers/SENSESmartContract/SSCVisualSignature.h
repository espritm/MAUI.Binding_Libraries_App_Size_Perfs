//
//  SSCVisualSignature.h
//  sense-smartcontract-sdk-ios
//
//  Created by Mark on 25.11.21.
//  Copyright © 2021 Marc-Henri Primault. All rights reserved.
//

typedef NS_ENUM(NSInteger, SSCSignatureType) {
    SSCSignatureTypeText = 0,
    SSCSignatureTypeDraw,
    SSCSignatureTypeImage
};

/**
 * The model representing a visual signature
 */
@interface SSCVisualSignature : NSObject

/**
 * The identifier of the signature
 */
@property (nonatomic, strong) NSString *identifier;

/**
 * Date when the signature has been created
 */
@property (nonatomic, strong) NSDate *createdAt;

/**
 * Data representing the visual signature
 */
@property (nonatomic, strong) NSData *data;

/**
 * Visual signature type
 */
@property (assign) SSCSignatureType type;

@end
