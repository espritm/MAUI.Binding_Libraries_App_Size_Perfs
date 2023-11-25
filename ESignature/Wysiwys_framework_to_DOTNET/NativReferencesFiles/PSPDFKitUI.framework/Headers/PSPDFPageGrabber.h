//
//  Copyright © 2017-2021 PSPDFKit GmbH. All rights reserved.
//
//  THIS SOURCE CODE AND ANY ACCOMPANYING DOCUMENTATION ARE PROTECTED BY INTERNATIONAL COPYRIGHT LAW
//  AND MAY NOT BE RESOLD OR REDISTRIBUTED. USAGE IS BOUND TO THE PSPDFKIT LICENSE AGREEMENT.
//  UNAUTHORIZED REPRODUCTION OR DISTRIBUTION IS SUBJECT TO CIVIL AND CRIMINAL PENALTIES.
//  This notice may not be removed from this file.
//

#import <UIKit/UIKit.h>

NS_ASSUME_NONNULL_BEGIN

/// The page grabber view protocol can be implemented by `UIView` subclasses. It enables
/// an instance of `PSPDFPageGrabber` to communicate state changes to the view that
/// implements this protocol, if the view is used as the page grabber's `grabberView`.
PSPDF_PROTOCOL_SWIFT(PageGrabberView)
PSPDF_DEPRECATED_IOS(10.5, "Deprecated in PSPDFKit 10.5 for iOS because the scroll indicator from `UIScrollView` supports dragging on iOS 13 and later.")
@protocol PSPDFPageGrabberView<NSObject>
@optional

/// If implemented, this method is called to let you know when the grabber view is
/// touched.
///
/// @param collapsed YES if the user is touching the grabber. NO when the user is
/// currently not touching the grabber.
/// @param animated YES if the state change should be animated, NO otherwise.
- (void)setCollapsed:(BOOL)collapsed animated:(BOOL)animated;

@end

/// The page grabber is a view that provides an area on the screen where the user can
/// swipe their finger to quickly skim through the pages.
///
/// The page grabber itself is fully transparent, the knob the user can touch and drag
/// around is represented by its `grabberView` property.
PSPDF_CLASS_SWIFT(PageGrabber)
PSPDF_DEPRECATED_IOS(10.5, "Deprecated in PSPDFKit 10.5 for iOS because the scroll indicator from `UIScrollView` supports dragging on iOS 13 and later.")
@interface PSPDFPageGrabber : UIView

/// A custom view that should be used to visualize the grabber.
///
/// If you specify your own view here, its size is used to calculate the size of the
/// page grabber orthogonal to its moving direction. The direction of movement is always
/// of variable size and is set to fit the user interface view it is displayed in.
@property (nonatomic) UIView<PSPDFPageGrabberView> *grabberView;

/// The current sate. YES if the user is touching the page grabber, NO if not.
@property (nonatomic, readonly, getter=isGrabbing) BOOL grabbing;

@end

NS_ASSUME_NONNULL_END
