using System;
using Foundation;
using UIKit;

namespace UnbluProxy_FatFramework_to_DOTNET
{
	// @interface UnbluProxy : NSObject
	[BaseType (typeof(NSObject))]
	interface UnbluProxy
	{
		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull NOTIFICATION_NAME_UNREAD_MESSAGE_COUNT_CHANGED;
		[Static]
		[Export ("NOTIFICATION_NAME_UNREAD_MESSAGE_COUNT_CHANGED")]
		string NOTIFICATION_NAME_UNREAD_MESSAGE_COUNT_CHANGED { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull NOTIFICATION_NAME_DID_INITIALIZE;
		[Static]
		[Export ("NOTIFICATION_NAME_DID_INITIALIZE")]
		string NOTIFICATION_NAME_DID_INITIALIZE { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull NOTIFICATION_NAME_DID_DEINITIALIZE;
		[Static]
		[Export ("NOTIFICATION_NAME_DID_DEINITIALIZE")]
		string NOTIFICATION_NAME_DID_DEINITIALIZE { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull NOTIFICATION_NAME_UI_IS_READY;
		[Static]
		[Export ("NOTIFICATION_NAME_UI_IS_READY")]
		string NOTIFICATION_NAME_UI_IS_READY { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull NOTIFICATION_NAME_DID_PRELOAD_UI;
		[Static]
		[Export ("NOTIFICATION_NAME_DID_PRELOAD_UI")]
		string NOTIFICATION_NAME_DID_PRELOAD_UI { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull NOTIFICATION_NAME_DID_TRANSITION_UI_WITH_TRANSITION;
		[Static]
		[Export ("NOTIFICATION_NAME_DID_TRANSITION_UI_WITH_TRANSITION")]
		string NOTIFICATION_NAME_DID_TRANSITION_UI_WITH_TRANSITION { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull NOTIFICATION_NAME_DID_UPDATE_PERSON_INFO;
		[Static]
		[Export ("NOTIFICATION_NAME_DID_UPDATE_PERSON_INFO")]
		string NOTIFICATION_NAME_DID_UPDATE_PERSON_INFO { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull NOTIFICATION_NAME_DID_CHANGE_OPEN_CONVERSATION;
		[Static]
		[Export ("NOTIFICATION_NAME_DID_CHANGE_OPEN_CONVERSATION")]
		string NOTIFICATION_NAME_DID_CHANGE_OPEN_CONVERSATION { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull NOTIFICATION_NAME_DID_REQUEST_HIDE_UI;
		[Static]
		[Export ("NOTIFICATION_NAME_DID_REQUEST_HIDE_UI")]
		string NOTIFICATION_NAME_DID_REQUEST_HIDE_UI { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull NOTIFICATION_NAME_DID_REQUEST_SHOW_UI;
		[Static]
		[Export ("NOTIFICATION_NAME_DID_REQUEST_SHOW_UI")]
		string NOTIFICATION_NAME_DID_REQUEST_SHOW_UI { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull NOTIFICATION_NAME_DID_TOGGLE_CALL_UI;
		[Static]
		[Export ("NOTIFICATION_NAME_DID_TOGGLE_CALL_UI")]
		string NOTIFICATION_NAME_DID_TOGGLE_CALL_UI { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull NOTIFICATION_NAME_DID_RECEIVED_ERROR;
		[Static]
		[Export ("NOTIFICATION_NAME_DID_RECEIVED_ERROR")]
		string NOTIFICATION_NAME_DID_RECEIVED_ERROR { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull NOTIFICATION_NAME_DID_START_COBROWSING;
		[Static]
		[Export ("NOTIFICATION_NAME_DID_START_COBROWSING")]
		string NOTIFICATION_NAME_DID_START_COBROWSING { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull NOTIFICATION_NAME_DID_STOP_COBROWSING;
		[Static]
		[Export ("NOTIFICATION_NAME_DID_STOP_COBROWSING")]
		string NOTIFICATION_NAME_DID_STOP_COBROWSING { get; }

		// -(BOOL)configureApiWithCookiesInString:(NSDictionary<NSString *,NSString *> * _Nonnull)cookiesInString unbluUrlServer:(NSString * _Nonnull)unbluUrlServer unbluApiKey:(NSString * _Nonnull)unbluApiKey enableUnbluDebugOutput:(BOOL)enableUnbluDebugOutput __attribute__((warn_unused_result("")));
		[Export ("configureApiWithCookiesInString:unbluUrlServer:unbluApiKey:enableUnbluDebugOutput:")]
		bool ConfigureApiWithCookiesInString (NSDictionary<NSString, NSString> cookiesInString, string unbluUrlServer, string unbluApiKey, bool enableUnbluDebugOutput);

		// -(void)startWithCompletion:(void (^ _Nonnull)(BOOL, NSString * _Nonnull))completion;
		[Export ("startWithCompletion:")]
		void StartWithCompletion (Action<bool, NSString> completion);

		// -(UIView * _Nullable)getView __attribute__((warn_unused_result("")));
		[NullAllowed, Export ("getView")]
        UIView GetView();// { get; }

        // -(int32_t)getUnreadMessageCount __attribute__((warn_unused_result("")));
        [Export ("getUnreadMessageCount")]
        int UnreadMessageCount { get; }

        // -(void)openConversationOverviewWithCompletion:(void (^ _Nonnull)(BOOL, NSString * _Nonnull))completion;
        [Export ("openConversationOverviewWithCompletion:")]
		void OpenConversationOverviewWithCompletion (Action<bool, NSString> completion);

		// -(void)openConversation:(NSString * _Nonnull)conversationId completion:(void (^ _Nonnull)(BOOL, NSString * _Nonnull))completion;
		[Export ("openConversation:completion:")]
		void OpenConversation (string conversationId, Action<bool, NSString> completion);

		// -(void)startAudioCall:(NSString * _Nonnull)conversationId completion:(void (^ _Nonnull)(BOOL, NSString * _Nonnull))completion;
		[Export ("startAudioCall:completion:")]
		void StartAudioCall (string conversationId, Action<bool, NSString> completion);

		// -(void)startVideoCall:(NSString * _Nonnull)conversationId completion:(void (^ _Nonnull)(BOOL, NSString * _Nonnull))completion;
		[Export ("startVideoCall:completion:")]
		void StartVideoCall (string conversationId, Action<bool, NSString> completion);

		// -(void)isInitializedWithCompletion:(void (^ _Nonnull)(BOOL))completion;
		[Export ("isInitializedWithCompletion:")]
		void IsInitializedWithCompletion (Action<bool> completion);

		// -(void)stopWithCompletion:(void (^ _Nonnull)(BOOL, NSString * _Nonnull))completion;
		[Export ("stopWithCompletion:")]
		void StopWithCompletion (Action<bool, NSString> completion);
	}
}
