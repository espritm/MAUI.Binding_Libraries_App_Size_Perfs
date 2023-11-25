//
//  WYSSignatureAttributes.h
//  sense-smartcontract-sdk-wysiwys-ios
//
//  Created by Mark on 16.10.20.
//  Copyright © 2020 sysmosoft. All rights reserved.
//

/**
 * Configuration to give when that will be used to set signature details
*/
@interface WYSSignatureAttributes : NSObject

/**
 * Sets the name attribute of the signature field.
 *
 * The name is not directly visible in the document, but may be displayed in the
 * signature details of some PDF Viewer.
 *
 * Default: The username configured with the username given with WYSPdfViewerConfiguration.username
 */
@property (nonatomic) NSString *signatureName;
/**
 * Sets the reason attribute of the signature field.
 *
 * Default: `accepted` or `refused`, depending the user's decision
 *
 */
@property (nonatomic) NSString *signatureReason;
/**
 * Sets the location attribute of the signature field.
 *
 * Default: null
*/
@property (nonatomic) NSString *signatureLocation;

/**
 * Sets the estimated size of the digital signature.
 *
 * This is the length reserved for the signature container in the PDF document
 * before digitally signing it. A big estimated size will possibly make the
 * signed document bigger than necessary, but a too small one will cause the
 * signing process to fail
 *
 * Default: 32k
 *
 */
@property (nonatomic, assign) int estimatedSignatureSize;

@end
