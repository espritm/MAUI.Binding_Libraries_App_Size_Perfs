//
//  WYSSignatureProcessDelegate.h
//  sense-smartcontract-sdk-wysiwys-ios
//
//  Created by Mark on 06.07.20.
//  Copyright © 2020 sysmosoft. All rights reserved.
//

/**
 * Delegate to handle signature process events
 */

@protocol WYSSignatureProcessDelegate <NSObject>

/**
 * Called when the document cannot be accepted because of empty form field(s)
 * marked as required.
 *
 * This method is called immediately after calling WYSIWYSController#acceptDocument.
 * Once the user has filled all the required fields, the document must be accepted again.
 */
- (void)missingRequiredFormField;

/**
 * Called only when doing electronic signature when we expect the user to touch the signature field
 * to apply its signature.
 */
- (void)signatureFormFieldRequiresManualFilling;

/**
 * Called when there is not signature field and the user must place manually its visual signature.
 *
 */
- (void)signatureRequiresPositioning;

/**
 * Called when multiple empty signature form fields are available.
 *
 * After receiving this event, the listener should prompt the user to click on the desired form field.
 */
- (void)selectSignatureFormField;

/**
 * Called when the document has been prepared. The document digest that must be signed is provided as parameter.
 *
 * The signature can be then embedded in the document using the method WYSIWYSController#embedSignature:(NSData*) pkcs7.
 *
 * @param documentDigest document digest to be signed
 * @param reason can accepted or refused
 */
- (void)documentPreparedForSignature:(nonnull NSData*) documentDigest withReason:(nonnull NSString*)reason;

/**
 * Called after #willPrepareDocument:(nonnull NSString*)reason if the document has been
 * visually modified during the preparation and requires the user to confirm the document.
 *
 * The PDF Viewer has been updated with the updated document. The method WYSIWYSController#confirmSignature should be called to terminate the
 * preparation of the document once the user has confirmed.
 */
- (void)confirmationRequired;

/**
 * Called when the signature has been embedded to the document.
 *
 *
 * @param reason `accepted` or `refused`
 * @param document the signed document
 */
- (void)processDidFinishWithReason:(nonnull NSString*)reason andDocument:(nonnull NSData*)document;

/**
 * Called when something went wrong during the process.
 *
 * @param error  the cause of the error
 */
- (void)processDidFailWithError:(nonnull NSError*) error;

@optional
/**
 * Called when the document is about to be prepared.
 */
- (void)willPrepareDocument;

/**
 * Called when the user has selected an empty signature form field.
 *
 */
- (void)didSelectSignatureFormField;

@end
