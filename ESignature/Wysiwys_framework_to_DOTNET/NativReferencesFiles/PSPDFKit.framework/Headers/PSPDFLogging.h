//
//  Copyright © 2011-2021 PSPDFKit GmbH. All rights reserved.
//
//  THIS SOURCE CODE AND ANY ACCOMPANYING DOCUMENTATION ARE PROTECTED BY INTERNATIONAL COPYRIGHT LAW
//  AND MAY NOT BE RESOLD OR REDISTRIBUTED. USAGE IS BOUND TO THE PSPDFKIT LICENSE AGREEMENT.
//  UNAUTHORIZED REPRODUCTION OR DISTRIBUTION IS SUBJECT TO CIVIL AND CRIMINAL PENALTIES.
//  This notice may not be removed from this file.
//

#pragma once

#if !defined(PSPDF_STATIC_BUILD)
#import <PSPDFKit/PSPDFEnvironment.h>
#else
#import "PSPDFEnvironment.h"
#endif

/// To fetch log messages, you can use either:
/// - Xcode's console
/// - Apple's Console.app
/// - or the 'log' terminal utility.
///
/// PSPDFKit uses `os_log` under the hood to send log messages and categories to the OS.
/// An additional filter is used for performance reasons, as `os_log` is wrapped
/// to support external log handlers, and therefore logging has an impact on performance.
///
/// The Debug and Info log levels have to be enabled separately in the Console app's in Action menu.
///
/// Terminal: Debug requires separate activation to work streamed.
/// log stream --level debug --predicate 'subsystem == "com.pspdfkit.sdk"' --style compact
/// To enable all levels: sudo log config --mode "level:debug" --subsystem com.pspdfkit.sdk
/// See also: https://www.iosdev.recipes/simulator/os_log/
///
/// When using Simulator, prefix Terminal log with xcrun simctrl:
/// xcrun simctl spawn booted log stream --level debug --style syslog --color none --predicate 'subsystem contains "com.pspdfkit.sdk"'
///
/// If the suggestion above doesn't work (e.g. “Error from getpwuid_r: 0 (Undefined error: 0)”),
/// we recommend using Console.app for reading log messages.
///
/// On iOS, debug messages are re-classified from DEBUG to INFO level, in order to work around
/// FB9028830 (os_log Debug streaming does not work on iOS Simulator).
/// This bug does not impact Mac Catalyst, so no reclassification is necessary there.
/// See also: https://stackoverflow.com/questions/57509909/swift-oslog-os-log-not-showing-up-in-console-app
typedef NS_OPTIONS(NSUInteger, PSPDFLogLevelMask) {
    /// Log nothing.
    PSPDFLogLevelMaskNothing = 0,

    /// Logs critical issues, that can break or limit the functionality of the framework.
    /// Should never be disabled.
    PSPDFLogLevelMaskCritical = 1 << 0,

    /// Logs errors. Should never be disabled.
    PSPDFLogLevelMaskError = 1 << 1,

    /// Logs issues that are not errors or critical, but log-worthy.
    PSPDFLogLevelMaskWarning = 1 << 2,

    /// Logs important operations.
    PSPDFLogLevelMaskInfo = 1 << 3,

    /// Will log almost everything and slow down the application flow.
    PSPDFLogLevelMaskDebug = 1 << 4,

    /// Might log security related details like signature points.
    /// Never enable this in release builds unless they are solely for testing.
    PSPDFLogLevelMaskVerbose = 1 << 5,

    /// Enables all logging categories.
    PSPDFLogLevelMaskAll = UINT_MAX,
} PSPDF_ENUM_SWIFT(LogLevelMask);
