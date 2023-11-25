//
//  Copyright © 2013-2021 PSPDFKit GmbH. All rights reserved.
//
//  THIS SOURCE CODE AND ANY ACCOMPANYING DOCUMENTATION ARE PROTECTED BY INTERNATIONAL COPYRIGHT LAW
//  AND MAY NOT BE RESOLD OR REDISTRIBUTED. USAGE IS BOUND TO THE PSPDFKIT LICENSE AGREEMENT.
//  UNAUTHORIZED REPRODUCTION OR DISTRIBUTION IS SUBJECT TO CIVIL AND CRIMINAL PENALTIES.
//  This notice may not be removed from this file.
//

#import <PSPDFKit/PSPDFAction.h>
#import <PSPDFKit/PSPDFDocument.h>
#import <PSPDFKit/PSPDFFormElement.h>

NS_ASSUME_NONNULL_BEGIN

/// Defines an action that contains JavaScript to be executed in the document context.
PSPDF_CLASS_SWIFT(JavaScriptAction)
@interface PSPDFJavaScriptAction : PSPDFAction

/// Designated initializer.
- (instancetype)initWithScript:(NSString *)script;

/// The javascript content.
@property (nonatomic, copy, readonly, nullable) NSString *script;

@end

NS_ASSUME_NONNULL_END
