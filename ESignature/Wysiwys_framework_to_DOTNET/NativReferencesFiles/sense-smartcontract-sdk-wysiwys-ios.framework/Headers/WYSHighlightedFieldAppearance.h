//
//  WYSHighlightedFieldAppearance.h
//  sense-smartcontract-sdk-wysiwys-ios
//
//  Created by Mark on 25.10.21.
//  Copyright © 2021 sysmosoft. All rights reserved.
//

/**
* Model to setup the field appreance when highlighted
*/
@interface WYSHighlightedFieldAppearance : NSObject

/**
 * In electronic signature mode, set the highlight color used when a user need to tap on a field.
 *
 * Default : #FFED99
 */
@property (nonatomic) UIColor *highlightBackgroundColor;

/**
 * In electronic signature mode, set the signature text to invite the user to touch the field to place its signature.
 *
 * Default : nil
 */
@property (nonatomic) NSString *signatureHighlightText;

/**
 * In electronic signature mode, set the font to be used to render the signatureText.
 *
 * Default : [UIFont systemFontOfSize:28]
 *
 */
@property (nonatomic)UIFont *signatureHighlightFont;

@end
