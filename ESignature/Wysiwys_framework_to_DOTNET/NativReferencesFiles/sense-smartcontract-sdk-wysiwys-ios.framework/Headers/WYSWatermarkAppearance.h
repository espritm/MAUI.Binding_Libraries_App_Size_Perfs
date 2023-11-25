//
//  WYSWatermarkAppearance.h
//  sense-smartcontract-sdk-wysiwys-ios
//
//  Created by Mark on 26.06.20.
//  Copyright © 2020 sysmosoft. All rights reserved.
//

/**
 * Model to setup the watermark appreance at refusal
 */
@interface WYSWatermarkAppearance : NSObject

/**
 * Set a show title that will be displayed as watermark on refused document.
 *
 * If not provided,  `REFUSED` is used.
 */
@property (nonatomic)NSString *title;

/**
 * The custom date time pattern that will be used to format the date in the
 * watermark of refused document.
 *
 * If not provided, the default pattern `yyyy-MM-dd HH:mm:ss` is used.
 */
@property (nonatomic)NSString *dateTimePattern;

/**
 * Set the font to be used to render the watermark's title.
 *
 * Default : [UIFont systemFontOfSize:80]
 *
*/
@property (nonatomic)UIFont *titleFont;

/**
 * Set the font to be used to render the watermark's date.
 *
 * Default : [UIFont systemFontOfSize:25]
 *
*/
@property (nonatomic)UIFont *dateFont;

/**
 * The rotation in degrees of the watermark
 *
 * Default : 0
 *
*/
@property (nonatomic, assign) int rotation;
@end
