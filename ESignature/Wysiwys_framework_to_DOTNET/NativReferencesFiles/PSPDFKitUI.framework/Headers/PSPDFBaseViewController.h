//
//  Copyright © 2012-2021 PSPDFKit GmbH. All rights reserved.
//
//  THIS SOURCE CODE AND ANY ACCOMPANYING DOCUMENTATION ARE PROTECTED BY INTERNATIONAL COPYRIGHT LAW
//  AND MAY NOT BE RESOLD OR REDISTRIBUTED. USAGE IS BOUND TO THE PSPDFKIT LICENSE AGREEMENT.
//  UNAUTHORIZED REPRODUCTION OR DISTRIBUTION IS SUBJECT TO CIVIL AND CRIMINAL PENALTIES.
//  This notice may not be removed from this file.
//

#import <PSPDFKit/PSPDFEnvironment.h>

NS_ASSUME_NONNULL_BEGIN

PSPDF_CLASS_SWIFT(PDFBaseViewController)
@interface PSPDFBaseViewController : UIViewController
@end

/// The methods in this category provide entry points so that you can override or supplement this class' behavior.
///
/// @warning These methods are not meant to be called directly from your code. Subclassing hooks can change without prior deprecation. If you're using them, please double check that they are still available after a PSPDFKit update.
@interface PSPDFBaseViewController (SubclassingHooks)

/// Called when the font system base size is changed.
- (void)contentSizeDidChange NS_REQUIRES_SUPER;

@end

@interface PSPDFBaseViewController (SubclassingWarnings)

// PSPDFKit overrides all kind of event hooks for UIViewController.
// You should always call super on those, even if you're just using UIViewController.

- (void)viewWillAppear:(BOOL)animated NS_REQUIRES_SUPER;
- (void)viewDidAppear:(BOOL)animated NS_REQUIRES_SUPER;
- (void)viewWillDisappear:(BOOL)animated NS_REQUIRES_SUPER;
- (void)viewDidDisappear:(BOOL)animated NS_REQUIRES_SUPER;
- (void)viewWillLayoutSubviews NS_REQUIRES_SUPER;
- (void)viewDidLayoutSubviews NS_REQUIRES_SUPER;

- (void)didReceiveMemoryWarning NS_REQUIRES_SUPER;

@end

/// Checks that the `requested` interface orientation is supported by both view controller and application.
///
/// @note This function is deprecated. Please implement your own orientation handling.
///
/// @param requested The requested preferred interface orientation.
/// @param supported Value from view controller's `supportedInterfaceOrientations`.
/// @param window Window which hosts the view controller.
///
/// @return Requested orientation if it's supported by both view controller and application, otherwise falls back to current orientation.
PSPDF_EXPORT UIInterfaceOrientation PSPDFSafePreferredInterfaceOrientation(UIInterfaceOrientation requested, UIInterfaceOrientationMask supported, UIWindow * _Nullable window) PSPDF_DEPRECATED_IOS(10.1, "Please implement your own orientation handling.");

NS_ASSUME_NONNULL_END
