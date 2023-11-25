//
//  WYSSignatureConfiguration.h
//  sense-smartcontract-sdk-wysiwys-ios
//
//  Created by Mark on 11.03.20.
//  Copyright © 2020 Sysmosoft. All rights reserved.
//
#import "WYSSignatureProcessDelegate.h"
#import "WYSSignatureAppearance.h"
#import "WYSWatermarkAppearance.h"
#import "WYSSignatureAttributes.h"
#import "WYSHighlightedFieldAppearance.h"

/**
 * Configuration to give when initilizing the WYSIWYS reader
 */
@interface WYSSignatureConfiguration : NSObject

/**
 * Delegate that will receive all events related emitted by the PDF Viewer.
 *
 */
@property (nonatomic, nonnull) id<WYSSignatureProcessDelegate> signatureProcessDelegate;

@property (nonatomic, nonnull) WYSSignatureAppearance *signatureAppearance;
@property (nonatomic, nonnull) WYSWatermarkAppearance *watermarkAppearance;
@property (nonatomic, nonnull) WYSSignatureAttributes *signatureAttributes;
@property (nonatomic, nonnull) WYSHighlightedFieldAppearance *highlightedFieldAppearance;

@end
