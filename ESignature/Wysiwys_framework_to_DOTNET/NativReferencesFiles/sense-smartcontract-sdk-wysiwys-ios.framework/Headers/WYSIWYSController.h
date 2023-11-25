//
//  WYSIWYSController.h
//  sense-smartcontract-sdk-wysiwys-ios
//
//  Created by Mark on 03.03.20.
//  Copyright © 2020 Sysmosoft. All rights reserved.
//

#import "WYSViewerDelegate.h"
#import "WYSSignatureProcessDelegate.h"
#import "WYSPdfViewerConfiguration.h"
#import "WYSSignatureConfiguration.h"
#import "WYSViewerConfiguration.h"
#import "WYSSignatureInfo.h"

NS_ASSUME_NONNULL_BEGIN

/**
 * Main controller to interact with the WYSIWYS reader
 */
@interface WYSIWYSController : NSObject

/**
 * Initializes the PDF Viewer with the given configuration. This method must be called before opening a document.
 *
 * @param configuration the PDF Viewer configuration
 */
- (instancetype)initWithConfiguration:(nonnull WYSPdfViewerConfiguration*) configuration;

/**
 * Store document for further processing. This will securely store the document until dispose is called.
 * The stored document can be processed through the viewer with repoen or UI less with acceptAndPrepare
 * or refuseAndPrepare.
 *
 * @param pdf the data of the document
 * @param documentId the identifier of the document
*/
- (BOOL)storeDocument:(nonnull NSData *)pdf documentID:(nonnull NSString*) documentId;

/**
 * Opens a new document from an byte array. The document will be loaded from the given
 * byte array and securely stored in its internal storage using the given ID as identifier.
 * The method return nil in case of error.
 *
 * @param pdf the data of the document
 * @param documentId the identifier of the document
 * @param viewerConfiguration the viewer configuration
 * @param signatureConfiguration the signature configuration
 * @param error not nil if an error happen when opening the document.
 */
- (UIView*)openDocument:(nonnull NSData *)pdf documentID:(nonnull NSString*) documentId viewerConfiguration:(nonnull WYSViewerConfiguration*) viewerConfiguration signatureConfiguration:(nonnull WYSSignatureConfiguration*) signatureConfiguration error:(NSError **)error;

/**
 * Reopens the existing document represented by the given ID. This method is equals to
 * reopenDocument:documentId:inState:viewerConfiguration:viewerConfiguration:signatureConfiguration:error: with state WYSDocumentStateStored
 * The method return nil in case of error.
 *
 * @param documentId the identifier of the document
 * @param viewerConfiguration the viewer configuration
 * @param signatureConfiguration the signature configuration
 * @param error not nil if an error happen when opening the document or if the state given is WYSDocumentStateNotExist or WYSDocumentStateSigned.
 */
- (UIView*)reopenDocument:(nonnull NSString*) documentId viewerConfiguration:(nonnull WYSViewerConfiguration*) viewerConfiguration signatureConfiguration:(nonnull WYSSignatureConfiguration*) signatureConfiguration error:(NSError **)error;

/**
 * Reopens an existing document represented by the given ID in the given state.
 * The method return nil in case of error.
 *
 * @param documentId the identifier of the document
 * @param state the state of the document that we want to reopen (only WYSDocumentStateStored and WYSDocumentStatePrepared)
 * @param viewerConfiguration the viewer configuration
 * @param signatureConfiguration the signature configuration
 * @param error not nil if an error happen when opening the document or if the state given is WYSDocumentStateNotExist or WYSDocumentStateSigned.
 */
- (UIView*)reopenDocument:(nonnull NSString*) documentId inState:(WYSDocumentState)state viewerConfiguration:(nonnull WYSViewerConfiguration*) viewerConfiguration signatureConfiguration:(nonnull WYSSignatureConfiguration*) signatureConfiguration error:(NSError **)error;

/**
 * Shows a new document from an byte array.
 *
 * The APIs related to the signature cannot be used when documents are displayed
 * using this API.
 *
 * The document will be loaded from the given byte array and securely
 * stored in the storage. File will be automatically deleted when the viewer is deallocated.
 *
 * @param pdf the data of the document
 * @param viewerConfiguration the viewer configuration
 * @param error not nil if an error happen when displaying the document.
*/
- (UIView*)showDocument:(nonnull NSData *)pdf viewerConfiguration:(nonnull WYSViewerConfiguration*) viewerConfiguration error:(NSError **)error;

/**
 * Shows a  document in the state given
 *
 * The APIs related to the signature cannot be used when documents are displayed
 * using this API.
 *
 * The document will be loaded from the storage if available.
 *
 * @param documentId the identifier of the document
 * @param state the state of the document that we want to show (only WYSDocumentStateStored, WYSDocumentStatePrepared and WYSDocumentStateSigned)
 * @param viewerConfiguration the viewer configuration
 * @param error not nil if an error happen when displaying the document, if the document has never been prepared or if the state given is WYSDocumentStateNotExist.
*/
- (UIView*)showDocumentWithId:(nonnull NSString*) documentId inState:(WYSDocumentState)state viewerConfiguration:(nonnull WYSViewerConfiguration*) viewerConfiguration error:(NSError **)error;

/**
 * Verifies if a document identified by the given ID is in the given state
 *
 * @param documentId  the document ID
 * @param state the state to verify
 * @return true if the document is in the given state
*/
- (BOOL)isDocumentWithId:(nonnull NSString*)documentId inState:(WYSDocumentState)state;

/**
 * Retrieve the document version of the given state
 *
 * @param documentId the identifier of the document
 * @param state the state of the document that we want to retrieve
 * @param error not nil if an error happen when retrieving the document or if the document is not in the given state.
*/
- (NSData*)documentWithId:(nonnull NSString*)documentId inState:(WYSDocumentState)state error:(NSError **)error;

/**
 * Verifies if a document identified by the given ID has been already opened and modified.
 *
 * @param documentId  the document ID
 * @return true if the document is in progress
 */
- (BOOL)documentInProgress:(nonnull NSString*) documentId;

/**
 * Saves current state into the PDF. Document must be opened to use this method. NOTE : If you use swift, you can use the error-free version of this method to get the boolean return
 *
 * @param error not nil if an error happen when saving the document.
 * @return true if the document the document has been saved
 */
- (BOOL)saveDocument:(NSError **)error;


/**
 * Saves current state into the PDF. Document must be opened to use this method.
 *
 * @return true if the document the document has been saved
 */
- (BOOL)saveDocument;

/**
 * Disposes the document identified by the given ID.
 *
 * This method can be called when the document has been processed and will not
 * be reopened anymore (delete all data on the storage).
 * This method is equals to disposeDocument:documentId:inState: with state WYSDocumentStateStored
 *
 *
 * @param documentId  the document ID
 */
- (void)disposeDocument:(nonnull NSString*) documentId;

/**
 * Disposes the document identified by the given ID in the given state.
 * If the state WYSDocumentStateSigned is given, only the signed version of document is deleted
 * If the state WYSDocumentStatePreoared is given, the signed version and the preapred version of document are deleted
 * If the state WYSDocumentStateStored is given, any versions of document are deleted
 *
 * @param documentId  the document ID
 * @param state the state of the document that we want to dispose.
*/
- (void)disposeDocument:(nonnull NSString*) documentId inState:(WYSDocumentState)state;
/**
 * Starts the signature process for a document accepted by the user.
 *
 * The signature flow might differ depending the type and the content of the
 * document.
 *
 * a) If the document does not contain an empty signature form field, no preview
 * is displayed and the document digest in directly sent to the event
 * [WYSPdfViewerDelegate documentPreparedForSignature:withReason:]
 *
 * b) If the document contains a single empty signature form field, or if one
 * the empty signature form field name matches the user's username or
 * ff a sequence pattern 'smartcontract_sign_field_X' is found, the user
 * will be prompted to enter its signature.
 *
 * c) If the document contains multiple empty signature form fields, the user
 * will have to click on the desired field. The event
 * [WYSPdfViewerDelegate selectSignatureFormField] will be sent to
 * let the app prompting the user to perform the action. Once the field is
 * selected by the user, the event
 * [WYSPdfViewerDelegate didSelectSignatureFormField] will be
 * sent to notify the app and the user will be prompted to enter its signature.
 *
 * In case of scenario b) and c), the PDF will be visually modified while being
 * prepared to introduce the signature and will require a confirmation from the
 * user. The preview of the document is automatically displayed and the event
 * [WYSPdfViewerDelegate onConfirmationRequired] will be sent to the
 * listener. The SDK will wait until the method confirmSignature is
 * called. When a sequence pattern is found, the next field in the sequence is
 * selected to embed the signature.
 */
- (void)acceptDocument;
/**
 * Starts the signature process for a document refused by the user.
 *
 * A refused document does not allow the user to add its signature. A watermark
 * will be applied to each page of the resulting document. The label of the
 * watermark can be configured within the [WYSSignatureConfiguration setWatermarkTitle:].
 *
 * The event [WYSPdfViewerDelegate willPrepareDocument] will be sent
 * to the listener to notify the app the document is being prepared, followed by
 * the event [WYSPdfViewerDelegate documentPreparedForSignature:withReason:]
 *
 * As the PDF will be visually modified while being prepared, it will require a
 * confirmation from the user. The preview of the document is automatically
 * displayed and the event [WYSPdfViewerDelegate onConfirmationRequired] will be sent to the
 * listener. The SDK will wait until the method confirmSignature is
 * called.
 */
- (void)refuseDocument;

/**
 * Starts the signature process for a document accepted by the user without user interaction.
 *
 * The signature flow might differ depending the type and the content of the
 * document.
 *
 * a) If the document does not contain an empty signature form field, an invisible signature
 * field will be created and the document digest in directly sent to the event
 * [WYSPdfViewerDelegate documentPreparedForSignature:withReason:]
 *
 * b) If the document contains a single empty signature form field, or if one of
 * the empty signature form field name matches the user's username or
 * if a sequence pattern 'smartcontract_sign_field_X' is found, the signature
 * will be placed inside it.
 *
 * c) If the document contains multiple empty signature form fields, the first available
 * field will be used unless a sequence pattern 'smartcontract_sign_field_X' is found.
 *
 * In case of scenario b) and c), if [WYSSignatureAppearance handwrittenSignatureEnabled]
 * is set to YES, the first available signature will be used otherwise a signature is
 * automatically generated. When a sequence pattern is found, the next field in the sequence is
 * selected to embed the signature.
 *
 * @param documentId the identifier of the document
 * @param signatureConfiguration the signature configuration
 */
-(void)acceptAndPrepareDocument:(nonnull NSString*) documentId signatureConfiguration:(nonnull WYSSignatureConfiguration*) signatureConfiguration;

/**
 * Starts the signature process for a document refused by the user.
 *
 * A refused document does not allow the user to add its signature. A watermark
 * will be applied to each page of the resulting document. The label of the
 * watermark can be configured within the [WYSSignatureConfiguration setWatermarkTitle:].
 *
 * The event [WYSPdfViewerDelegate willPrepareDocument] will be sent
 * to the listener to notify the app the document is being prepared, followed by
 * the event [WYSPdfViewerDelegate documentPreparedForSignature:withReason:]
 *
 * No confirmation will be required is this mode. It is up to the application to ensure that the
 * user can see it before signature by using [WYSIWYSController showPreparedDocument]
 *
 * @param documentId the identifier of the document
 * @param signatureConfiguration the signature configuration
 */
-(void)refuseAndPrepareDocument:(nonnull NSString*) documentId signatureConfiguration:(nonnull WYSSignatureConfiguration*) signatureConfiguration;

/**
 * Cancels the preview.
 *
 * After calling this method, the viewer will restore the document, allowing the user to modify it.
 */
- (void)cancelPreview;

/**
 * Cancel the signature positionning.
 *
 * After calling this method, the viewer will restore the document, allowing the user to modify it.
*/
- (void)cancelSignaturePositioning;

/**
 * Tells the SDK that the signautre has been positionned.
*/
- (void)signaturePositionned;

/**
 * Confirms the signature of the document.
 *
 * This API must be called only after the event
 * [WYSPdfViewerDelegate onConfirmationRequired]  has been sent to the
 * listener.
 *
 * Once confirmed, the event [WYSPdfViewerDelegate documentPreparedForSignature:withReason:] will be sent to the listener.
 */
- (void)confirmSignature;
/**
 * Embeds the signature to the PDF
 *
 * The signature must be a valid PKCS#7 detached signature.
 *
 * @param signature PKCS#7 detached signature
 */
- (void)embedSignature:(NSData*) signature;

/**
 * Embeds the signature to a PDF document previously prepared.
 *
 * This method allows embedding a signature in a prepared PDF document without
 * the need to open the document again. It might be useful if the signature
 * generation takes time or if the signature is received when the viewer is
 * not displayed anymore.
 *
 * Once the signature is embedded in the document, the method
 * WYSSignatureProcessDelegate.processDidFinishWithReason:andDocument: is called
 * with the signed file.
 *
 * If no document was previously prepared, the method WYSSignatureProcessDelegate.processDidFailWithError: is called
 *
 * The SDK must be initialized prior using this method.
 *
 * @param documentId the document ID
 * @param signature PKCS#7 detached signature
 * @param signatureConfiguration to get the delegate to receive the result
 *
*/
- (void)embedSignature:(nonnull NSString*) documentId signatureConfiguration:(nonnull WYSSignatureConfiguration*) signatureConfiguration signature:(NSData*) signature;

/**
 * Shows the thumbnail view.
 *
 * The thumbnail view is a convenient way for the user to see all pages of its
 * document and open a specific page without the need to scroll all the pages.
 */
- (void) showThumbnailView;

/**
 * Hides the thumbnail view.
 */
- (void) hideThumbnailView;

/**
 * Verifies if the thumbnail view is currently displayed.
 *
 * @return true if the thumbnail view is currently displayed
 */
- (bool)thumbnailViewDisplayed;

/**
 * Opens the signature settings. This view allows the user to manage its visual signatures.
 * Returns nil if initWithConfiguration has not been called prior calling this method
 */
+ (UITableViewController*) openSignatureSettings;

/**
 * @return true if visual signature has been stored.
 */
+ (BOOL)hasSignatureStored;

/**
 * Checks if visual signature needs to be placed manually or if at least one form field is required.
 * The document must be stored to be able to use this methods. NOTE : If you use swift, you can use the error-free version of this method to get the boolean return
 *
 * @param error not nil if an error happen when checking the document.
 * @return true if visual signature needs to be placed manually or if at least one form field is required.
 */
- (BOOL)documentCompletionRequired:(nonnull NSString*) documentId error:(NSError **)error;


/**
 * Checks if visual signature needs to be placed manually or if at least one form field is required.
 * The document must be stored to be able to use this methods.
 *
 * @param documentId the document ID
 * @return true if visual signature needs to be placed manually or if at least one form field is required.
 */
- (BOOL)documentCompletionRequired:(nonnull NSString*) documentId;

/**
 * Retrieves the signature information of a prepared document
 *
 * @return the signature information or nil if the document is not in state WYSDocumentStatePrepared
*/
-(WYSSignatureInfo*)signatureInfoForDocumentWithId:(nonnull NSString*) documentId;

/**
 * Retrieves the total page count for the current document
 *
 * @return the page count
*/
-(int) pageCount;

/**
 * Retrieves the current page displayed
 *
 * @return the page index currently displayed
*/
-(int) pageIndex;

/**
 * Sets the page index to be displayed (0 is the fist page).
 * The method will throw an error if the page index is invalid.
 *
 * @param pageIndex the page index
 * @param animated YES if transitioning animation should be performed
 */
- (void)setPageIndex:(int)pageIndex animated:(BOOL)animated;

@end

NS_ASSUME_NONNULL_END
