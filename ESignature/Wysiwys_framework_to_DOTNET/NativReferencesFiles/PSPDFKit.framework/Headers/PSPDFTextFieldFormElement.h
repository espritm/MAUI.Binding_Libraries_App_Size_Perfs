//
//  Copyright © 2013-2021 PSPDFKit GmbH. All rights reserved.
//
//  THIS SOURCE CODE AND ANY ACCOMPANYING DOCUMENTATION ARE PROTECTED BY INTERNATIONAL COPYRIGHT LAW
//  AND MAY NOT BE RESOLD OR REDISTRIBUTED. USAGE IS BOUND TO THE PSPDFKIT LICENSE AGREEMENT.
//  UNAUTHORIZED REPRODUCTION OR DISTRIBUTION IS SUBJECT TO CIVIL AND CRIMINAL PENALTIES.
//  This notice may not be removed from this file.
//

#import <PSPDFKit/PSPDFFormElement.h>

NS_ASSUME_NONNULL_BEGIN

@class PSPDFTextFormField;

/// Form field flags specific to text fields, matching bit positions in the PDF specification.
/// These values are not used in PSPDFKit API. Use the properties on `TextFormField` instead.
typedef NS_OPTIONS(NSUInteger, PSPDFTextFieldFlag) {
    PSPDFTextFieldFlagMultiline = 1 << (13 - 1),
    PSPDFTextFieldFlagPassword = 1 << (14 - 1),
    PSPDFTextFieldFlagFileSelect = 1 << (21 - 1),
    PSPDFTextFieldFlagDoNotSpellCheck = 1 << (23 - 1),
    PSPDFTextFieldFlagDoNotScroll = 1 << (24 - 1),
    PSPDFTextFieldFlagComb = 1 << (25 - 1),
    PSPDFTextFieldFlagRichText = 1 << (26 - 1),
} PSPDF_ENUM_SWIFT(TextFieldFormElement.TextFieldFlag) PSPDF_DEPRECATED(10.4, 5.4, "These values are not used. Use the properties on `TextFormField` instead.");

/// An input format for a text form field.
typedef NS_CLOSED_ENUM(NSUInteger, PSPDFTextInputFormat) {
    /// The text will not have any predefined format.
    PSPDFTextInputFormatNormal,
    /// The text will be formatted as a number.
    PSPDFTextInputFormatNumber,
    /// The text will be formatted as a date.
    PSPDFTextInputFormatDate,
    /// The text will be formatted as a time.
    PSPDFTextInputFormatTime,
} PSPDF_ENUM_SWIFT(TextFieldFormElement.TextInputFormat);

/// A form element in which a user can enter text.
PSPDF_CLASS_SWIFT(TextFieldFormElement)
@interface PSPDFTextFieldFormElement : PSPDFFormElement

/// If set, the field may contain multiple lines of text; if clear, the field’s text shall be restricted to a single line.
@property (atomic, getter=isMultiline, readonly) BOOL multiline;

/// If set, the field is intended for entering a secure password that should not be echoed visibly to the screen.
@property (atomic, getter=isPassword, readonly) BOOL password;

/// Returns the contents formatted based on rules set on the form field (including JavaScript).
@property (atomic, readonly, nullable) NSString *formattedContents;

/// The input format. Some forms are number/date/time specific.
@property (atomic, readonly) PSPDFTextInputFormat inputFormat;

/// This is equivalent to the `formField` property from the superclass but with the more specific type `TextFormField`.
@property (atomic, readonly, nullable) PSPDFTextFormField *textFormField;

@end

NS_ASSUME_NONNULL_END
