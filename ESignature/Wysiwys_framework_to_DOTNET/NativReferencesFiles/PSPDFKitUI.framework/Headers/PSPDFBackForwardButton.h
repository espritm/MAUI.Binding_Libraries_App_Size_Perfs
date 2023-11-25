//
//  Copyright © 2015-2021 PSPDFKit GmbH. All rights reserved.
//
//  THIS SOURCE CODE AND ANY ACCOMPANYING DOCUMENTATION ARE PROTECTED BY INTERNATIONAL COPYRIGHT LAW
//  AND MAY NOT BE RESOLD OR REDISTRIBUTED. USAGE IS BOUND TO THE PSPDFKIT LICENSE AGREEMENT.
//  UNAUTHORIZED REPRODUCTION OR DISTRIBUTION IS SUBJECT TO CIVIL AND CRIMINAL PENALTIES.
//  This notice may not be removed from this file.
//

#import <PSPDFKit/PSPDFOverridable.h>
#import <PSPDFKitUI/PSPDFStyleButton.h>

NS_ASSUME_NONNULL_BEGIN

/// Back and forward buttons, used for the action stack navigation.
PSPDF_CLASS_SWIFT(BackForwardButton)
@interface PSPDFBackForwardButton : PSPDFStyleButton<PSPDFOverridable>

/// Returns a button pre-configured for the back button style.
@property (class, nonatomic, readonly) PSPDFBackForwardButton *backButton;

/// Returns a button pre-configured for the forward button style.
@property (class, nonatomic, readonly) PSPDFBackForwardButton *forwardButton;

/// On iOS 13, PSPDFKit does not use this gesture recognizer and adding actions to it will not work.
@property (nonatomic, readonly) UILongPressGestureRecognizer *longPressRecognizer PSPDF_DEPRECATED_IOS(9.4, "On iOS 13, PSPDFKit does not use this gesture recognizer and adding actions to it will not work.");

@end

NS_ASSUME_NONNULL_END
