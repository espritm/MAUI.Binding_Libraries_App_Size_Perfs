//
//  WYSEnums.h
//  sense-smartcontract-sdk-wysiwys-ios
//
//  Created by Mark on 03.03.20.
//  Copyright © 2020 Sysmosoft. All rights reserved.
//

/**
 * Document states:
 *
 * - WYSDocumentStateNotExist: The document has never been store or has been deleted.
 * - WYSDocumentStateStored: The document has been stored. Modifed document that has been saved are alos in this state.
 * - WYSDocumentStatePrepared: The document has been prepared and wiating to be signed.
 * - WYSDocumentStateSigned: The document has been signed
 */
typedef NS_ENUM(NSInteger, WYSDocumentState) {
    WYSDocumentStateNotExist = 0,
    WYSDocumentStateStored,
    WYSDocumentStatePrepared,
    WYSDocumentStateSigned
};

/**
 * Visual signature mode
 *
 * - WYSVisualSignatureTypeDraw: Visual signature drawn manually.
 * - WYSVisualSignatureTypeImage: Visual signature from uploaded image.
 */
typedef NS_ENUM(NSInteger, WYSSignatureMode) {
    WYSVisualSignatureModeDraw = 0,
    WYSVisualSignatureModeImage
};

/**
 * :nodoc:
 */
typedef NS_ENUM(NSInteger, WYSResponseType) {
    WYSResponseTypeAccepted = 0,
    WYSResponseTypeRefused
};

/**
 * :nodoc:
 */
typedef NS_ENUM(NSInteger, WYSPDFSignatureControllerType) {
    WYSPDFSignatureControllerTypeDefault,
    WYSPDFSignatureControllerTypeManage,
    WYSPDFSignatureControllerTypeSelect
};

/**
 * :nodoc:
 */
typedef NS_ENUM(NSInteger, WYSPDFControllerState) {
    WYSPDFControllerStateInitialized,
    WYSPDFControllerStateReadOnly,
    WYSPDFControllerStateWillPrepare,
    WYSPDFControllerStateIsPreparing,
    WYSPDFControllerStateConfirmationRequired
};
