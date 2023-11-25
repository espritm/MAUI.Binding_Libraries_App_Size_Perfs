//
//  Copyright © 2015-2021 PSPDFKit GmbH. All rights reserved.
//
//  THIS SOURCE CODE AND ANY ACCOMPANYING DOCUMENTATION ARE PROTECTED BY INTERNATIONAL COPYRIGHT LAW
//  AND MAY NOT BE RESOLD OR REDISTRIBUTED. USAGE IS BOUND TO THE PSPDFKIT LICENSE AGREEMENT.
//  UNAUTHORIZED REPRODUCTION OR DISTRIBUTION IS SUBJECT TO CIVIL AND CRIMINAL PENALTIES.
//  This notice may not be removed from this file.
//

#if !defined(PSPDF_STATIC_BUILD)
#import <PSPDFKit/PSPDFEnvironment.h>
#else
#import "PSPDFEnvironment.h"
#endif

NS_ASSUME_NONNULL_BEGIN

typedef NS_CLOSED_ENUM(NSUInteger, PSPDFReachability) {
    PSPDFReachabilityUnknown,
    PSPDFReachabilityUnreachable,
    PSPDFReachabilityWiFi,
    /// iOS only
    PSPDFReachabilityWWAN,
} PSPDF_ENUM_SWIFT(ReachabilityStatus);

NS_ASSUME_NONNULL_END
