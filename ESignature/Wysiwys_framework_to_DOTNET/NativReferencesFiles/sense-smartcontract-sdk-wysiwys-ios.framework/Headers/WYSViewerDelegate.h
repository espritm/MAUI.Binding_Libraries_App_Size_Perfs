//
//  WYSViewerConfiguration.h
//  sense-smartcontract-sdk-wysiwys-ios
//
//  Created by Mark on 06.07.20.
//  Copyright © 2020 sysmosoft. All rights reserved.
//

/**
 * Delegate to handle document events
 */
@protocol WYSViewerDelegate <NSObject>

@optional
/**
 * Called after a document has opened and displayed.
 */
-(void)documentDidLoad;

/**
 * Called when user scrolled to a new page.
 *
 * @param pageIndex Page index of new page.
 */
-(void) didPageChanged:(int) pageIndex;

@end
