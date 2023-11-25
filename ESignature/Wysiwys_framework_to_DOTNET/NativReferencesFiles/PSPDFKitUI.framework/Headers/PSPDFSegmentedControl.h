//
//  Copyright © 2012-2021 PSPDFKit GmbH. All rights reserved.
//
//  THIS SOURCE CODE AND ANY ACCOMPANYING DOCUMENTATION ARE PROTECTED BY INTERNATIONAL COPYRIGHT LAW
//  AND MAY NOT BE RESOLD OR REDISTRIBUTED. USAGE IS BOUND TO THE PSPDFKIT LICENSE AGREEMENT.
//  UNAUTHORIZED REPRODUCTION OR DISTRIBUTION IS SUBJECT TO CIVIL AND CRIMINAL PENALTIES.
//  This notice may not be removed from this file.
//

#import <PSPDFKit/PSPDFEnvironment.h>

/// Add support to replace images as the selection changes.
PSPDF_DEPRECATED_IOS(10.3, "Please consider creating your own segmented control subclass.")
PSPDF_CLASS_SWIFT(SegmentedControl)
@interface PSPDFSegmentedControl : UISegmentedControl

/// Extends the hit testing area, if a negative inset is set.
@property (nonatomic) UIEdgeInsets hitTestEdgeInsets;

@end
