//
//  WYSViewerConfiguration.h
//  sense-smartcontract-sdk-wysiwys-ios
//
//  Created by Mark on 06.07.20.
//  Copyright © 2020 sysmosoft. All rights reserved.
//

#import "WYSViewerDelegate.h"

NS_ASSUME_NONNULL_BEGIN

/**
 * Model to setup the behavior of the document viewer
 */
@interface WYSViewerConfiguration : NSObject

/**
 * Sets the delegate that will receive all events related to the document.
 *
 */
@property (nonatomic, nonnull) id<WYSViewerDelegate> viewerDelegate;
/**
 * Sets whether the scrolling mode is continuous or page per page.
 *
 * Default : false (page per page scrolling)
 *
 */
@property (nonatomic, assign) BOOL continuousScrolling;
/**
 * Sets whether the orientation scrolling mode is horizontal or vertical.
 *
 * Default : false (horizontal scrolling)
 *
 */
@property (nonatomic, assign) BOOL verticalScrolling;
/**
 * Sets background color behind the page view.
 *
 * Default : [UIColor colorWithWhite:0.9 alpha:1.0]
 *
 */
@property (nonatomic, nonnull) UIColor* backgroundColor;

@end

NS_ASSUME_NONNULL_END
