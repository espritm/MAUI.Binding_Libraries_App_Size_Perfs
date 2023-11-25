using Foundation;
using ObjCRuntime;
using UIKit;
//using sense-smartcontract-sdk-wysiwys-ios;

namespace Wysiwys_framework_to_DOTNET
{
	// @interface WYSHighlightedFieldAppearance : NSObject
	[BaseType (typeof(NSObject))]
	interface WYSHighlightedFieldAppearance
	{
		// @property (nonatomic) UIColor * highlightBackgroundColor;
		[Export ("highlightBackgroundColor", ArgumentSemantic.Assign)]
		UIColor HighlightBackgroundColor { get; set; }

		// @property (nonatomic) NSString * signatureHighlightText;
		[Export ("signatureHighlightText")]
		string SignatureHighlightText { get; set; }

		// @property (nonatomic) UIFont * signatureHighlightFont;
		[Export ("signatureHighlightFont", ArgumentSemantic.Assign)]
		UIFont SignatureHighlightFont { get; set; }
	}

	// @protocol WYSViewerDelegate <NSObject>
	[BaseType (typeof(NSObject))]
    [Protocol]
    interface WYSViewerDelegate
	{
		// @optional -(void)documentDidLoad;
		[Export ("documentDidLoad")]
		void DocumentDidLoad ();

		// @optional -(void)didPageChanged:(int)pageIndex;
		[Export ("didPageChanged:")]
		void DidPageChanged (int pageIndex);
	}

	// @protocol WYSSignatureProcessDelegate <NSObject>
	[BaseType (typeof(NSObject))]
    [Protocol]
    interface WYSSignatureProcessDelegate 
	{
		// @required -(void)missingRequiredFormField;
		[Abstract]
		[Export ("missingRequiredFormField")]
		void MissingRequiredFormField ();

		// @required -(void)signatureFormFieldRequiresManualFilling;
		[Abstract]
		[Export ("signatureFormFieldRequiresManualFilling")]
		void SignatureFormFieldRequiresManualFilling ();

		// @required -(void)signatureRequiresPositioning;
		[Abstract]
		[Export ("signatureRequiresPositioning")]
		void SignatureRequiresPositioning ();

		// @required -(void)selectSignatureFormField;
		[Abstract]
		[Export ("selectSignatureFormField")]
		void SelectSignatureFormField ();

		// @required -(void)documentPreparedForSignature:(NSData * _Nonnull)documentDigest withReason:(NSString * _Nonnull)reason;
		[Abstract]
		[Export ("documentPreparedForSignature:withReason:")]
		void DocumentPreparedForSignature (NSData documentDigest, string reason);

		// @required -(void)confirmationRequired;
		[Abstract]
		[Export ("confirmationRequired")]
		void ConfirmationRequired ();

		// @required -(void)processDidFinishWithReason:(NSString * _Nonnull)reason andDocument:(NSData * _Nonnull)document;
		[Abstract]
		[Export ("processDidFinishWithReason:andDocument:")]
		void ProcessDidFinishWithReason (string reason, NSData document);

		// @required -(void)processDidFailWithError:(NSError * _Nonnull)error;
		[Abstract]
		[Export ("processDidFailWithError:")]
		void ProcessDidFailWithError (NSError error);

		// @optional -(void)willPrepareDocument;
		[Export ("willPrepareDocument")]
		void WillPrepareDocument ();

		// @optional -(void)didSelectSignatureFormField;
		[Export ("didSelectSignatureFormField")]
		void DidSelectSignatureFormField ();
	}

	// @protocol WYSSignatureStore <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[BaseType (typeof(NSObject))]
    [Protocol]
    interface WYSSignatureStore
	{
		// @required -(void)addSignature:(UIImage * _Nonnull)signature capturedWithMode:(WYSSignatureMode)mode;
		[Abstract]
		[Export ("addSignature:capturedWithMode:")]
		void AddSignature (UIImage signature, WYSSignatureMode mode);

		// @required -(BOOL)removeSignature:(NSString * _Nonnull)identifier;
		[Abstract]
		[Export ("removeSignature:")]
		bool RemoveSignature (string identifier);

		// @required -(NSDictionary<NSString *,UIImage *> *)signatures;
		[Abstract]
		[Export ("signatures")]
		NSDictionary<NSString, UIImage> Signatures { get; }
	}

	// @interface WYSPdfViewerConfiguration : NSObject
	[BaseType (typeof(NSObject))]
	interface WYSPdfViewerConfiguration
	{
		// @property (nonatomic) NSString * _Nonnull username;
		[Export ("username")]
		string Username { get; set; }

		// @property (nonatomic) NSString * _Nonnull license;
		[Export ("license")]
		string License { get; set; }

		// @property (nonatomic) NSData * _Nonnull storageKey;
		[Export ("storageKey", ArgumentSemantic.Assign)]
		NSData StorageKey { get; set; }

		// @property (nonatomic) id<WYSSignatureStore> signatureStore;
		[Export ("signatureStore", ArgumentSemantic.Assign)]
		WYSSignatureStore SignatureStore { get; set; }
	}

	// @interface WYSSignatureAppearance : NSObject
	[BaseType (typeof(NSObject))]
	interface WYSSignatureAppearance
	{
		// @property (nonatomic) NSString * signerName;
		[Export ("signerName")]
		string SignerName { get; set; }

		// @property (assign, nonatomic) BOOL invisibleSignature;
		[Export ("invisibleSignature")]
		bool InvisibleSignature { get; set; }

		// @property (assign, nonatomic) BOOL handwrittenSignatureEnabled;
		[Export ("handwrittenSignatureEnabled")]
		bool HandwrittenSignatureEnabled { get; set; }

		// @property (nonatomic) UIFont * signerNameFont;
		[Export ("signerNameFont", ArgumentSemantic.Assign)]
		UIFont SignerNameFont { get; set; }

		// @property (nonatomic) NSString * dateTimePattern;
		[Export ("dateTimePattern")]
		string DateTimePattern { get; set; }

		// @property (nonatomic) UIFont * dateFont;
		[Export ("dateFont", ArgumentSemantic.Assign)]
		UIFont DateFont { get; set; }

		// @property (nonatomic) NSString * signatureDescription;
		[Export ("signatureDescription")]
		string SignatureDescription { get; set; }

		// @property (nonatomic) UIFont * signatureDescriptionFont;
		[Export ("signatureDescriptionFont", ArgumentSemantic.Assign)]
		UIFont SignatureDescriptionFont { get; set; }

		// @property (nonatomic) UIImage * signatureGraphic;
		[Export ("signatureGraphic", ArgumentSemantic.Assign)]
		UIImage SignatureGraphic { get; set; }
	}

	// @interface WYSWatermarkAppearance : NSObject
	[BaseType (typeof(NSObject))]
	interface WYSWatermarkAppearance
	{
		// @property (nonatomic) NSString * title;
		[Export ("title")]
		string Title { get; set; }

		// @property (nonatomic) NSString * dateTimePattern;
		[Export ("dateTimePattern")]
		string DateTimePattern { get; set; }

		// @property (nonatomic) UIFont * titleFont;
		[Export ("titleFont", ArgumentSemantic.Assign)]
		UIFont TitleFont { get; set; }

		// @property (nonatomic) UIFont * dateFont;
		[Export ("dateFont", ArgumentSemantic.Assign)]
		UIFont DateFont { get; set; }

		// @property (assign, nonatomic) int rotation;
		[Export ("rotation")]
		int Rotation { get; set; }
	}

	// @interface WYSSignatureAttributes : NSObject
	[BaseType (typeof(NSObject))]
	interface WYSSignatureAttributes
	{
		// @property (nonatomic) NSString * signatureName;
		[Export ("signatureName")]
		string SignatureName { get; set; }

		// @property (nonatomic) NSString * signatureReason;
		[Export ("signatureReason")]
		string SignatureReason { get; set; }

		// @property (nonatomic) NSString * signatureLocation;
		[Export ("signatureLocation")]
		string SignatureLocation { get; set; }

		// @property (assign, nonatomic) int estimatedSignatureSize;
		[Export ("estimatedSignatureSize")]
		int EstimatedSignatureSize { get; set; }
	}

	// @interface WYSSignatureConfiguration : NSObject
	[BaseType (typeof(NSObject))]
	interface WYSSignatureConfiguration
	{
		[Wrap ("WeakSignatureProcessDelegate")]
		WYSSignatureProcessDelegate SignatureProcessDelegate { get; set; }

		// @property (nonatomic) id<WYSSignatureProcessDelegate> _Nonnull signatureProcessDelegate;
		[NullAllowed, Export ("signatureProcessDelegate", ArgumentSemantic.Assign)]
		NSObject WeakSignatureProcessDelegate { get; set; }

		// @property (nonatomic) WYSSignatureAppearance * _Nonnull signatureAppearance;
		[Export ("signatureAppearance", ArgumentSemantic.Assign)]
		WYSSignatureAppearance SignatureAppearance { get; set; }

		// @property (nonatomic) WYSWatermarkAppearance * _Nonnull watermarkAppearance;
		[Export ("watermarkAppearance", ArgumentSemantic.Assign)]
		WYSWatermarkAppearance WatermarkAppearance { get; set; }

		// @property (nonatomic) WYSSignatureAttributes * _Nonnull signatureAttributes;
		[Export ("signatureAttributes", ArgumentSemantic.Assign)]
		WYSSignatureAttributes SignatureAttributes { get; set; }

		// @property (nonatomic) WYSHighlightedFieldAppearance * _Nonnull highlightedFieldAppearance;
		[Export ("highlightedFieldAppearance", ArgumentSemantic.Assign)]
		WYSHighlightedFieldAppearance HighlightedFieldAppearance { get; set; }
	}

	// @interface WYSViewerConfiguration : NSObject
	[BaseType (typeof(NSObject))]
	interface WYSViewerConfiguration
	{
		[Wrap ("WeakViewerDelegate")]
		WYSViewerDelegate ViewerDelegate { get; set; }

		// @property (nonatomic) id<WYSViewerDelegate> _Nonnull viewerDelegate;
		[NullAllowed, Export ("viewerDelegate", ArgumentSemantic.Assign)]
		NSObject WeakViewerDelegate { get; set; }

		// @property (assign, nonatomic) BOOL continuousScrolling;
		[Export ("continuousScrolling")]
		bool ContinuousScrolling { get; set; }

		// @property (assign, nonatomic) BOOL verticalScrolling;
		[Export ("verticalScrolling")]
		bool VerticalScrolling { get; set; }

		// @property (nonatomic) UIColor * _Nonnull backgroundColor;
		[Export ("backgroundColor", ArgumentSemantic.Assign)]
		UIColor BackgroundColor { get; set; }
	}

	// @interface WYSSignatureInfo : NSObject
	[BaseType (typeof(NSObject))]
	interface WYSSignatureInfo
	{
		// @property (nonatomic) NSData * documentDigest;
		[Export ("documentDigest", ArgumentSemantic.Assign)]
		NSData DocumentDigest { get; set; }

		// @property (nonatomic) NSString * reason;
		[Export ("reason")]
		string Reason { get; set; }
	}

	// @interface WYSIWYSController : NSObject
	[BaseType (typeof(NSObject))]
	interface WYSIWYSController
	{
		// -(instancetype _Nonnull)initWithConfiguration:(WYSPdfViewerConfiguration * _Nonnull)configuration;
		[Export ("initWithConfiguration:")]
		NativeHandle Constructor (WYSPdfViewerConfiguration configuration);

		// -(BOOL)storeDocument:(NSData * _Nonnull)pdf documentID:(NSString * _Nonnull)documentId;
		[Export ("storeDocument:documentID:")]
		bool StoreDocument (NSData pdf, string documentId);

		// -(UIView * _Nonnull)openDocument:(NSData * _Nonnull)pdf documentID:(NSString * _Nonnull)documentId viewerConfiguration:(WYSViewerConfiguration * _Nonnull)viewerConfiguration signatureConfiguration:(WYSSignatureConfiguration * _Nonnull)signatureConfiguration error:(NSError * _Nullable * _Nullable)error;
		[Export ("openDocument:documentID:viewerConfiguration:signatureConfiguration:error:")]
		UIView OpenDocument (NSData pdf, string documentId, WYSViewerConfiguration viewerConfiguration, WYSSignatureConfiguration signatureConfiguration, [NullAllowed] out NSError error);

		// -(UIView * _Nonnull)reopenDocument:(NSString * _Nonnull)documentId viewerConfiguration:(WYSViewerConfiguration * _Nonnull)viewerConfiguration signatureConfiguration:(WYSSignatureConfiguration * _Nonnull)signatureConfiguration error:(NSError * _Nullable * _Nullable)error;
		[Export ("reopenDocument:viewerConfiguration:signatureConfiguration:error:")]
		UIView ReopenDocument (string documentId, WYSViewerConfiguration viewerConfiguration, WYSSignatureConfiguration signatureConfiguration, [NullAllowed] out NSError error);

		// -(UIView * _Nonnull)reopenDocument:(NSString * _Nonnull)documentId inState:(WYSDocumentState)state viewerConfiguration:(WYSViewerConfiguration * _Nonnull)viewerConfiguration signatureConfiguration:(WYSSignatureConfiguration * _Nonnull)signatureConfiguration error:(NSError * _Nullable * _Nullable)error;
		[Export ("reopenDocument:inState:viewerConfiguration:signatureConfiguration:error:")]
		UIView ReopenDocument (string documentId, WYSDocumentState state, WYSViewerConfiguration viewerConfiguration, WYSSignatureConfiguration signatureConfiguration, [NullAllowed] out NSError error);

		// -(UIView * _Nonnull)showDocument:(NSData * _Nonnull)pdf viewerConfiguration:(WYSViewerConfiguration * _Nonnull)viewerConfiguration error:(NSError * _Nullable * _Nullable)error;
		[Export ("showDocument:viewerConfiguration:error:")]
		UIView ShowDocument (NSData pdf, WYSViewerConfiguration viewerConfiguration, [NullAllowed] out NSError error);

		// -(UIView * _Nonnull)showDocumentWithId:(NSString * _Nonnull)documentId inState:(WYSDocumentState)state viewerConfiguration:(WYSViewerConfiguration * _Nonnull)viewerConfiguration error:(NSError * _Nullable * _Nullable)error;
		[Export ("showDocumentWithId:inState:viewerConfiguration:error:")]
		UIView ShowDocumentWithId (string documentId, WYSDocumentState state, WYSViewerConfiguration viewerConfiguration, [NullAllowed] out NSError error);

		// -(BOOL)isDocumentWithId:(NSString * _Nonnull)documentId inState:(WYSDocumentState)state;
		[Export ("isDocumentWithId:inState:")]
		bool IsDocumentWithId (string documentId, WYSDocumentState state);

		// -(NSData * _Nonnull)documentWithId:(NSString * _Nonnull)documentId inState:(WYSDocumentState)state error:(NSError * _Nullable * _Nullable)error;
		[Export ("documentWithId:inState:error:")]
		NSData DocumentWithId (string documentId, WYSDocumentState state, [NullAllowed] out NSError error);

		// -(BOOL)documentInProgress:(NSString * _Nonnull)documentId;
		[Export ("documentInProgress:")]
		bool DocumentInProgress (string documentId);

		// -(BOOL)saveDocument:(NSError * _Nullable * _Nullable)error;
		[Export ("saveDocument:")]
		bool SaveDocument ([NullAllowed] out NSError error);

		// -(BOOL)saveDocument;
		[Export("saveDocument")]
		bool SaveDocument();

		// -(void)disposeDocument:(NSString * _Nonnull)documentId;
		[Export ("disposeDocument:")]
		void DisposeDocument (string documentId);

		// -(void)disposeDocument:(NSString * _Nonnull)documentId inState:(WYSDocumentState)state;
		[Export ("disposeDocument:inState:")]
		void DisposeDocument (string documentId, WYSDocumentState state);

		// -(void)acceptDocument;
		[Export ("acceptDocument")]
		void AcceptDocument ();

		// -(void)refuseDocument;
		[Export ("refuseDocument")]
		void RefuseDocument ();

		// -(void)acceptAndPrepareDocument:(NSString * _Nonnull)documentId signatureConfiguration:(WYSSignatureConfiguration * _Nonnull)signatureConfiguration;
		[Export ("acceptAndPrepareDocument:signatureConfiguration:")]
		void AcceptAndPrepareDocument (string documentId, WYSSignatureConfiguration signatureConfiguration);

		// -(void)refuseAndPrepareDocument:(NSString * _Nonnull)documentId signatureConfiguration:(WYSSignatureConfiguration * _Nonnull)signatureConfiguration;
		[Export ("refuseAndPrepareDocument:signatureConfiguration:")]
		void RefuseAndPrepareDocument (string documentId, WYSSignatureConfiguration signatureConfiguration);

		// -(void)cancelPreview;
		[Export ("cancelPreview")]
		void CancelPreview ();

		// -(void)cancelSignaturePositioning;
		[Export ("cancelSignaturePositioning")]
		void CancelSignaturePositioning ();

		// -(void)signaturePositionned;
		[Export ("signaturePositionned")]
		void SignaturePositionned ();

		// -(void)confirmSignature;
		[Export ("confirmSignature")]
		void ConfirmSignature ();

		// -(void)embedSignature:(NSData * _Nonnull)signature;
		[Export ("embedSignature:")]
		void EmbedSignature (NSData signature);

		// -(void)embedSignature:(NSString * _Nonnull)documentId signatureConfiguration:(WYSSignatureConfiguration * _Nonnull)signatureConfiguration signature:(NSData * _Nonnull)signature;
		[Export ("embedSignature:signatureConfiguration:signature:")]
		void EmbedSignature (string documentId, WYSSignatureConfiguration signatureConfiguration, NSData signature);

		// -(void)showThumbnailView;
		[Export ("showThumbnailView")]
		void ShowThumbnailView ();

		// -(void)hideThumbnailView;
		[Export ("hideThumbnailView")]
		void HideThumbnailView ();

		// -(_Bool)thumbnailViewDisplayed;
		[Export("thumbnailViewDisplayed")]
		bool ThumbnailViewDisplayed();

		// +(UITableViewController * _Nonnull)openSignatureSettings;
		[Static]
		[Export("openSignatureSettings")]
		UITableViewController OpenSignatureSettings();

		// +(BOOL)hasSignatureStored;
		[Static]
		[Export("hasSignatureStored")]
		bool HasSignatureStored();

		// -(BOOL)documentCompletionRequired:(NSString * _Nonnull)documentId error:(NSError * _Nullable * _Nullable)error;
		[Export ("documentCompletionRequired:error:")]
		bool DocumentCompletionRequired (string documentId, [NullAllowed] out NSError error);

		// -(BOOL)documentCompletionRequired:(NSString * _Nonnull)documentId;
		[Export ("documentCompletionRequired:")]
		bool DocumentCompletionRequired (string documentId);

		// -(WYSSignatureInfo * _Nonnull)signatureInfoForDocumentWithId:(NSString * _Nonnull)documentId;
		[Export ("signatureInfoForDocumentWithId:")]
		WYSSignatureInfo SignatureInfoForDocumentWithId (string documentId);

		// -(int)pageCount;
		[Export ("pageCount")]
		int PageCount { get; }

		// -(int)pageIndex;
		[Export ("pageIndex")]
		int PageIndex { get; }

		// -(void)setPageIndex:(int)pageIndex animated:(BOOL)animated;
		[Export ("setPageIndex:animated:")]
		void SetPageIndex (int pageIndex, bool animated);
	}
}
