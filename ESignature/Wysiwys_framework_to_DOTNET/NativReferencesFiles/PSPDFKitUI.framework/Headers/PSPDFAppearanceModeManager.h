//
//  Copyright © 2016-2021 PSPDFKit GmbH. All rights reserved.
//
//  THIS SOURCE CODE AND ANY ACCOMPANYING DOCUMENTATION ARE PROTECTED BY INTERNATIONAL COPYRIGHT LAW
//  AND MAY NOT BE RESOLD OR REDISTRIBUTED. USAGE IS BOUND TO THE PSPDFKIT LICENSE AGREEMENT.
//  UNAUTHORIZED REPRODUCTION OR DISTRIBUTION IS SUBJECT TO CIVIL AND CRIMINAL PENALTIES.
//  This notice may not be removed from this file.
//

#import <PSPDFKit/PSPDFEnvironment.h>
#import <PSPDFKit/PSPDFOverridable.h>

@class PSPDFAppearanceModeManager, PSPDFConfigurationBuilder, PSPDFRenderOptions;

typedef NS_OPTIONS(NSUInteger, PSPDFAppearanceMode) {
    /// Normal application appearance and page rendering, as configured by the host app.
    PSPDFAppearanceModeDefault = 0,
    /// Renders the PDF content with a sepia tone.
    PSPDFAppearanceModeSepia = 1 << 0,
    /// Inverts the PDF page content and applies color correction.
    PSPDFAppearanceModeNight = 1 << 1,
    /// All options.
    PSPDFAppearanceModeAll = PSPDFAppearanceModeDefault | PSPDFAppearanceModeSepia | PSPDFAppearanceModeNight
} NS_SWIFT_NAME(PDFAppearanceMode);

NS_ASSUME_NONNULL_BEGIN

/// Notification sent out after `appearanceMode` is changed.
PSPDF_EXPORT NSNotificationName const PSPDFAppearanceModeChangedNotification;

/// Notification `userInfo` dictionary key. Holds a `BOOL` `NSNumber` which is `true`
/// when an animated mode change was requested.
PSPDF_EXPORT NSString *const PSPDFAppearanceModeChangedAnimatedKey PSPDF_DEPRECATED_IOS(10.5, "This is irrelevant on iOS 13 and later. Appearance mode change is never animated.");

PSPDF_PROTOCOL_SWIFT(AppearanceModeManagerDelegate)
@protocol PSPDFAppearanceModeManagerDelegate<NSObject>

@optional

/// Provides the document render options for the specified mode.
///
/// @param manager A reference to the invoking appearance mode manager.
/// @param mode The mode that is about to be applied.
///
/// @note Overrides the default behavior, if implemented.
- (PSPDFRenderOptions *)appearanceManager:(PSPDFAppearanceModeManager *)manager renderOptionsForMode:(PSPDFAppearanceMode)mode;

/// Update any UIAppearance changes for the selected mode.
///
/// On iOS 13 and later this can be done using `overrideUserInterfaceStyle`
/// available on `UIViewController` or a `UIView`.
///
/// @param manager A reference to the invoking appearance mode manager.
/// @param mode The mode that is about to be applied.
- (void)appearanceManager:(PSPDFAppearanceModeManager *)manager applyAppearanceSettingsForMode:(PSPDFAppearanceMode)mode PSPDF_DEPRECATED_IOS(10.5, "Appearance mode changes only affect page rendering and should no longer be used for UI customization.");

/// Update `builder` with any settings specific to the provided `mode`.
///
/// @param manager A reference to the invoking appearance mode manager.
/// @param builder The controller configuration that can be updated.
/// @param mode The mode that is about to be applied.
- (void)appearanceManager:(PSPDFAppearanceModeManager *)manager updateConfiguration:(PSPDFConfigurationBuilder *)builder forMode:(PSPDFAppearanceMode)mode PSPDF_DEPRECATED_IOS(10.5, "Appearance mode changes only affect page rendering and should no longer be used for UI customization.");

@end

/// Coordinates appearance mode changes.
///
/// This class will only update the PDF page rendering style.
/// Any UI appearance changes should be instead handled by the host application via the
/// delegate methods this class offers.
PSPDF_CLASS_SWIFT(PDFAppearanceModeManager)
@interface PSPDFAppearanceModeManager : NSObject<PSPDFOverridable>

/// The currently selected appearance mode. Defaults to `PSPDFAppearanceModeDefault`.
@property (nonatomic) PSPDFAppearanceMode appearanceMode;

/// Sets the appearance mode.
///
/// @param appearanceMode The new mode to apply.
/// @param animated Fades any theme changes if set to `true`. This parameter is not relevant on iOS 13 and later.
- (void)setAppearanceMode:(PSPDFAppearanceMode)appearanceMode animated:(BOOL)animated PSPDF_DEPRECATED_IOS(10.5, "The animated parameter is not relevant on iOS 13 and later. Use the variable `appearanceMode` instead.");

/// The appearance delegate. Can be used to customize the default behaviors for each mode.
@property (nonatomic, weak) id<PSPDFAppearanceModeManagerDelegate> delegate;

@end

NS_ASSUME_NONNULL_END
