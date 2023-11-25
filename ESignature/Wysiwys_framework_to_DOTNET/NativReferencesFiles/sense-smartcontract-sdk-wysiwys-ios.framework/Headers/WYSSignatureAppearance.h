//
//  WYSSignatureAppearance.h
//  sense-smartcontract-sdk-wysiwys-ios
//
//  Created by Mark on 26.06.20.
//  Copyright © 2020 sysmosoft. All rights reserved.
//

/**
 * Model to setup the signature appreance
 */
@interface WYSSignatureAppearance : NSObject

/**
 * Set the signer name that is used to generate the signature.
 *
 * Not required when SignatureAppearance#isHandwrittenSignatureEnabled is enabled.
 *
 */
@property (nonatomic) NSString *signerName;

/**
 * Enable invisble signature if no visual signature is required
 *
 * When enabled, the document will be signed without any visible signature. Only the
 * digital signature will by applied.
 *
 * Default : false
 */
@property (nonatomic, assign) BOOL invisibleSignature;

/**
 * Enable handwritten signature.
 *
 * When enabled, user will have to draw or pick a signature when requested. If
 * disabled, a signature is automatically generated using signerName
 * text and SignatureAppearance#signerNameFont font.
 *
 * Default : false
 */
@property (nonatomic, assign) BOOL handwrittenSignatureEnabled;

/**
 * Set the font to be used to render the signer name.
 *
 * Default : [UIFont boldSystemFontOfSize:48]
 *
 */
@property (nonatomic)UIFont *signerNameFont;
/**
 * Set a custom date time pattern that will be used to format the signature date.
 *
 * If not provided, the default pattern `yyyy-MM-dd HH:mm` is used.
 */
@property (nonatomic) NSString *dateTimePattern;
/**
 * Set the font to be used to render the signature date.
 *
 * Default : [UIFont systemFontOfSize:28]
 */
@property (nonatomic)UIFont *dateFont;
/**
 * Set a short description that will be shown in the signature field.
 *
 * Description is optional
 */
@property (nonatomic) NSString *signatureDescription;
/**
 * Set the type face to be used to render the signatureDescription.
 *
 * Default : [UIFont boldSystemFontOfSize:28]
 *
 */
@property (nonatomic)UIFont *signatureDescriptionFont;

/**
 * Set the signature graphic that will be displayed at the bottom of the
 * signature.
 *
 * The graphic is displayed as is, without image adjustments or resizing. The
 * graphic's width must be consistent with the font sizes defined. For default
 * font sizes, the preferred width of the graphic might be 512 px.
 *
 * Default : nil
*/
@property (nonatomic)UIImage* signatureGraphic;

@end

