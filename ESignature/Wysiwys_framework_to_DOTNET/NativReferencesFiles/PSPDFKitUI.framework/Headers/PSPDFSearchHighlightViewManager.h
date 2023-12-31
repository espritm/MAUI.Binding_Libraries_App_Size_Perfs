//
//  Copyright © 2014-2021 PSPDFKit GmbH. All rights reserved.
//
//  THIS SOURCE CODE AND ANY ACCOMPANYING DOCUMENTATION ARE PROTECTED BY INTERNATIONAL COPYRIGHT LAW
//  AND MAY NOT BE RESOLD OR REDISTRIBUTED. USAGE IS BOUND TO THE PSPDFKIT LICENSE AGREEMENT.
//  UNAUTHORIZED REPRODUCTION OR DISTRIBUTION IS SUBJECT TO CIVIL AND CRIMINAL PENALTIES.
//  This notice may not be removed from this file.
//

#import <PSPDFKit/PSPDFEnvironment.h>
#import <PSPDFKit/PSPDFOverridable.h>
#import <PSPDFKitUI/PSPDFPageView.h>

NS_ASSUME_NONNULL_BEGIN

@class PSPDFSearchResult;

/// The data source for the `PSPDFSearchHighlightViewManager` to coordinate animations and highlighting.
PSPDF_PROTOCOL_SWIFT(SearchHighlightViewManagerDataSource)
@protocol PSPDFSearchHighlightViewManagerDataSource<NSObject>

/// Control if we should add search highlight views at all.
@property (nonatomic, readonly) BOOL shouldHighlightSearchResults;

/// Returns an array of PSPDFPageView objects.
@property (nonatomic, readonly) NSArray<PSPDFPageView *> *visiblePageViews;

@end

/// Manages views added on `PDFPageView`.
PSPDF_CLASS_SWIFT(SearchHighlightViewManager)
@interface PSPDFSearchHighlightViewManager : NSObject<PSPDFOverridable>

PSPDF_EMPTY_INIT_UNAVAILABLE

/// Designated initializer.
- (instancetype)initWithDataSource:(id<PSPDFSearchHighlightViewManagerDataSource>)dataSource NS_DESIGNATED_INITIALIZER;

/// The data source for the search highlight manager.
@property (nonatomic, weak, readonly) id<PSPDFSearchHighlightViewManagerDataSource> dataSource;

/// Returns YES if there are search results displayed on a page view.
@property (nonatomic, readonly) BOOL hasVisibleSearchResults;

/// Hide search results.
///
/// @note `animated` is currently ignored.
- (void)clearHighlightedSearchResultsAnimated:(BOOL)animated;

/// Add search results.
- (void)addHighlightSearchResults:(NSArray<PSPDFSearchResult *> *)searchResults animated:(BOOL)animated;

/// Animate search results.
- (void)animateSearchHighlight:(PSPDFSearchResult *)searchResult;

@end

NS_ASSUME_NONNULL_END
