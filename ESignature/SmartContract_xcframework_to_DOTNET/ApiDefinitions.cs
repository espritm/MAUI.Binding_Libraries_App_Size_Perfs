using System;
using Foundation;
using ObjCRuntime;

namespace SmartContract_xcframework_to_DOTNET
{
	// @protocol SFKSecureStorageProtocol <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	[BaseType (typeof(NSObject))]
	interface SFKSecureStorageProtocol
	{
		// @required -(BOOL)itemExistsAtPath:(NSString *)path;
		[Abstract]
		[Export ("itemExistsAtPath:")]
		bool ItemExistsAtPath (string path);

		// @required -(BOOL)fileExistsAtPath:(NSString *)path isDirectory:(BOOL *)isDirectory;
		[Abstract]
		[Export ("fileExistsAtPath:isDirectory:")]
		unsafe bool FileExistsAtPath (string path, bool isDirectory);

		// @required -(NSDictionary *)attributesOfItemAtPath:(NSString *)path error:(NSError **)error;
		[Abstract]
		[Export ("attributesOfItemAtPath:error:")]
		NSDictionary AttributesOfItemAtPath (string path, out NSError error);

		// @required -(BOOL)createItemAtPath:(NSString *)path contents:(NSData *)contents;
		[Abstract]
		[Export ("createItemAtPath:contents:")]
		bool CreateItemAtPath (string path, NSData contents);

		// @required -(NSData *)contentsAtPath:(NSString *)path;
		[Abstract]
		[Export ("contentsAtPath:")]
		NSData ContentsAtPath (string path);

		// @required -(NSArray *)contentsOfDirectoryAtPath:(NSString *)path error:(NSError **)error;
		[Abstract]
		[Export ("contentsOfDirectoryAtPath:error:")]
		NSObject[] ContentsOfDirectoryAtPath (string path, out NSError error);

		// @required -(NSArray *)subpathsOfDirectoryAtPath:(NSString *)path error:(NSError **)error;
		[Abstract]
		[Export ("subpathsOfDirectoryAtPath:error:")]
		NSObject[] SubpathsOfDirectoryAtPath (string path, out NSError error);

		// @required -(BOOL)copyItemAtPath:(NSString *)srcPath toPath:(NSString *)dstPath error:(NSError **)error;
		[Abstract]
		[Export ("copyItemAtPath:toPath:error:")]
		bool CopyItemAtPath (string srcPath, string dstPath, out NSError error);

		// @required -(BOOL)moveItemAtPath:(NSString *)srcPath toPath:(NSString *)dstPath error:(NSError **)error;
		[Abstract]
		[Export ("moveItemAtPath:toPath:error:")]
		bool MoveItemAtPath (string srcPath, string dstPath, out NSError error);

		// @required -(BOOL)removeItemAtPath:(NSString *)path error:(NSError **)error;
		[Abstract]
		[Export ("removeItemAtPath:error:")]
		bool RemoveItemAtPath (string path, out NSError error);

		// @required -(BOOL)createDirectoryAtPath:(NSString *)path withIntermediateDirectories:(BOOL)createIntermediates attributes:(NSDictionary *)attributes error:(NSError **)error;
		[Abstract]
		[Export ("createDirectoryAtPath:withIntermediateDirectories:attributes:error:")]
		bool CreateDirectoryAtPath (string path, bool createIntermediates, NSDictionary attributes, out NSError error);
	}

	// @interface SFKSecureStorage : NSObject
	[BaseType (typeof(NSObject))]
	interface SFKSecureStorage
	{
		// +(BOOL)isAvailable;
		[Static]
		[Export ("isAvailable")]
		bool IsAvailable { get; }

		// +(id<SFKSecureStorageProtocol>)secureStorageWithError:(NSError **)error;
		[Static]
		[Export ("secureStorageWithError:")]
		SFKSecureStorageProtocol SecureStorageWithError (out NSError error);

		// +(id<SFKSecureStorageProtocol>)secureStorageWithPath:(NSString *)path error:(NSError **)error;
		[Static]
		[Export ("secureStorageWithPath:error:")]
		SFKSecureStorageProtocol SecureStorageWithPath (string path, out NSError error);

		// +(BOOL)removeSecureStorageWithError:(NSError **)error;
		[Static]
		[Export ("removeSecureStorageWithError:")]
		bool RemoveSecureStorageWithError (out NSError error);

		// +(BOOL)removeSecureStorageAtPath:(NSString *)path error:(NSError **)error;
		[Static]
		[Export ("removeSecureStorageAtPath:error:")]
		bool RemoveSecureStorageAtPath (string path, out NSError error);

		// +(id<SFKSecureStorageProtocol>)secureStorage __attribute__((deprecated("first deprecated in SENSE 3.16 - instead use secureStorageWithError:")));
		[Static]
		[Export ("secureStorage")]
		SFKSecureStorageProtocol SecureStorage { get; }

		// +(id<SFKSecureStorageProtocol>)secureStorageWithKey:(NSData *)key withRootPath:(NSString *)path error:(NSError **)error __attribute__((deprecated("first deprecated in SENSE 3.16 - instead use secureStorageWithPath:error: and migrate your data to use the SENSE provided key")));
		[Static]
		[Export ("secureStorageWithKey:withRootPath:error:")]
		SFKSecureStorageProtocol SecureStorageWithKey (NSData key, string path, out NSError error);

		// +(id<SFKSecureStorageProtocol>)secureStorageWithKey:(NSData *)key withRootPath:(NSString *)path __attribute__((deprecated("first deprecated in SENSE 3.16 - instead use secureStorageWithPath:error: and migrate your data to use the SENSE provided key")));
		[Static]
		[Export ("secureStorageWithKey:withRootPath:")]
		SFKSecureStorageProtocol SecureStorageWithKey (NSData key, string path);
    }

    // @interface SFKSigningService : NSObject
    [BaseType(typeof(NSObject))]
    interface SFKSigningService
    {
        // +(SecKeyRef _Nonnull)generateKeyPairWithAlias:(NSString * _Nonnull)alias error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export("generateKeyPairWithAlias:error:")]
        unsafe IntPtr GenerateKeyPairWithAlias(string alias, [NullAllowed] out NSError error);

        // +(SecKeyRef _Nonnull)publicKeyWithAlias:(NSString * _Nonnull)alias error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export("publicKeyWithAlias:error:")]
        unsafe IntPtr PublicKeyWithAlias(string alias, [NullAllowed] out NSError error);

        // +(NSData * _Nonnull)signData:(NSData * _Nonnull)data alias:(NSString * _Nonnull)alias error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export("signData:alias:error:")]
        NSData SignData(NSData data, string alias, [NullAllowed] out NSError error);

        // +(void)deleteKeyPairWithAlias:(NSString * _Nonnull)alias error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export("deleteKeyPairWithAlias:error:")]
        void DeleteKeyPairWithAlias(string alias, [NullAllowed] out NSError error);

        // +(BOOL)existsWithAlias:(NSString * _Nonnull)alias error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export("existsWithAlias:error:")]
        bool ExistsWithAlias(string alias, [NullAllowed] out NSError error);

        // +(void)clearAliasesForUsername:(NSString * _Nonnull)username;
        [Static]
        [Export("clearAliasesForUsername:")]
        void ClearAliasesForUsername(string username);
    }

    // @interface SSCJSONRPCService : NSObject
    [BaseType (typeof(NSObject))]
	interface SSCJSONRPCService
	{
		// -(id)initWithApplicationRef:(NSString *)appRef;
		[Export ("initWithApplicationRef:")]
		NativeHandle Constructor (string appRef);

		// -(void)requestWithService:(NSString *)service method:(NSString *)method completion:(void (^)(id, NSError *))completion;
		[Export ("requestWithService:method:completion:")]
		void RequestWithService (string service, string method, Action<NSObject, NSError> completion);

		// -(void)requestWithService:(NSString *)service method:(NSString *)method params:(NSArray *)params completion:(void (^)(id, NSError *))completion;
		[Export ("requestWithService:method:params:completion:")]
		void RequestWithService (string service, string method, NSObject[] @params, Action<NSObject, NSError> completion);
	}

	// @interface SSCContract : NSObject
	[BaseType (typeof(NSObject))]
	interface SSCContract
	{
		// @property (readonly, nonatomic, strong) NSString * identifier;
		[Export ("identifier", ArgumentSemantic.Strong)]
		string Identifier { get; }

		// @property (readonly, nonatomic, strong) NSString * type;
		[Export ("type", ArgumentSemantic.Strong)]
		string Type { get; }

		// @property (readonly, nonatomic, strong) NSString * state;
		[Export ("state", ArgumentSemantic.Strong)]
		string State { get; }

		// @property (readonly, nonatomic, strong) NSDate * date;
		[Export ("date", ArgumentSemantic.Strong)]
		NSDate Date { get; }

		// @property (readonly, nonatomic, strong) NSDictionary * metadata;
		[Export ("metadata", ArgumentSemantic.Strong)]
		NSDictionary Metadata { get; }

		// @property (readonly, nonatomic, strong) NSData * payload;
		[Export ("payload", ArgumentSemantic.Strong)]
		NSData Payload { get; }
	}

	// @interface SSCContractResponse : NSObject
	[BaseType (typeof(NSObject))]
	interface SSCContractResponse
	{
		// @property (readonly, nonatomic, strong) NSString * contractId;
		[Export ("contractId", ArgumentSemantic.Strong)]
		string ContractId { get; }

		// @property (readonly, nonatomic, strong) NSString * username;
		[Export ("username", ArgumentSemantic.Strong)]
		string Username { get; }

		// @property (readonly, nonatomic, strong) NSString * domainName;
		[Export ("domainName", ArgumentSemantic.Strong)]
		string DomainName { get; }

		// @property (readonly, nonatomic, strong) NSString * response;
		[Export ("response", ArgumentSemantic.Strong)]
		string Response { get; }

		// @property (readonly, nonatomic, strong) NSDate * date;
		[Export ("date", ArgumentSemantic.Strong)]
		NSDate Date { get; }

		// @property (readonly, nonatomic, strong) NSDictionary * context;
		[Export ("context", ArgumentSemantic.Strong)]
		NSDictionary Context { get; }

		// @property (readonly, nonatomic, strong) NSString * signature;
		[Export ("signature", ArgumentSemantic.Strong)]
		string Signature { get; }

		// @property (readonly, nonatomic, strong) NSData * data;
		[Export ("data", ArgumentSemantic.Strong)]
		NSData Data { get; }
	}

	// @interface SSCSignatureStatus : NSObject
	[BaseType (typeof(NSObject))]
	interface SSCSignatureStatus
	{
		// @property (readonly, nonatomic, strong) NSString * requestId;
		[Export ("requestId", ArgumentSemantic.Strong)]
		string RequestId { get; }

		// @property (readonly, assign, nonatomic) Status status;
		[Export ("status", ArgumentSemantic.Assign)]
		Status Status { get; }

		// @property (readonly, nonatomic, strong) NSData * signature;
		[Export ("signature", ArgumentSemantic.Strong)]
		NSData Signature { get; }

		// @property (readonly, nonatomic, strong) NSDictionary<NSString *,NSData *> * signatures;
		[Export ("signatures", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSData> Signatures { get; }

		// @property (readonly, nonatomic, strong) NSString * authenticationUrl;
		[Export ("authenticationUrl", ArgumentSemantic.Strong)]
		string AuthenticationUrl { get; }

		// @property (readonly, assign, nonatomic) StatusError error;
		[Export ("error", ArgumentSemantic.Assign)]
		StatusError Error { get; }

		// @property (readonly, assign, nonatomic) NSString * errorInfo;
		[Export ("errorInfo")]
		string ErrorInfo { get; }

		// -(instancetype)initWithContract:(SSCContract *)contract;
		[Export ("initWithContract:")]
		NativeHandle Constructor (SSCContract contract);
    }

    // @interface SFKConfiguration : NSObject
    [BaseType(typeof(NSObject))]
    interface SFKConfiguration
    {
        // +(NSDictionary *)senseConfiguration;
        [Static]
        [Export("senseConfiguration")]
        NSDictionary SenseConfiguration { get; }
    }

    // @interface SFKLogger : NSObject
    [BaseType(typeof(NSObject))]
    interface SFKLogger
    {
        // +(instancetype)instance;
        [Static]
        [Export("instance")]
        SFKLogger Instance();

        // -(void)log:(NSString *)message;
        [Export("log:")]
        void Log(string message);
    }

    // @interface SSCVisualSignature : NSObject
    [BaseType (typeof(NSObject))]
	interface SSCVisualSignature
	{
		// @property (nonatomic, strong) NSString * identifier;
		[Export ("identifier", ArgumentSemantic.Strong)]
		string Identifier { get; set; }

		// @property (nonatomic, strong) NSDate * createdAt;
		[Export ("createdAt", ArgumentSemantic.Strong)]
		NSDate CreatedAt { get; set; }

		// @property (nonatomic, strong) NSData * data;
		[Export ("data", ArgumentSemantic.Strong)]
		NSData Data { get; set; }

		// @property (assign) SSCSignatureType type;
		[Export ("type", ArgumentSemantic.Assign)]
		SSCSignatureType Type { get; set; }
	}

	// typedef void (^SSCContractsBlock)(NSArray<SSCContract *> *, NSError *);
	delegate void SSCContractsBlock (SSCContract[] arg0, NSError arg1);

	// typedef void (^SSCContractBlock)(SSCContract *, NSError *);
	delegate void SSCContractBlock (SSCContract arg0, NSError arg1);

	// typedef void (^SSCContractResponseBlock)(SSCContractResponse *, NSError *);
	delegate void SSCContractResponseBlock (SSCContractResponse arg0, NSError arg1);

	// typedef void (^SSCSignatureStatusBlock)(SSCSignatureStatus *, NSError *);
	delegate void SSCSignatureStatusBlock (SSCSignatureStatus arg0, NSError arg1);

	// typedef void (^SSCVisualSignaturesBlock)(NSArray<SSCVisualSignature *> *, NSError *);
	delegate void SSCVisualSignaturesBlock (SSCVisualSignature[] arg0, NSError arg1);

	// typedef void (^SSCVisualSignatureBlock)(SSCVisualSignature *, NSError *);
	delegate void SSCVisualSignatureBlock (SSCVisualSignature arg0, NSError arg1);

	// typedef void (^SSCErrorBlock)(NSError *);
	delegate void SSCErrorBlock (NSError arg0);

	// @interface SSCInitializer : NSObject
	[BaseType (typeof(NSObject))]
	interface SSCInitializer
	{
		// @property (copy, nonatomic) NSURL * senseServerURL;
		[Export ("senseServerURL", ArgumentSemantic.Copy)]
		NSUrl SenseServerURL { get; set; }

		// @property (copy, nonatomic) NSSet<NSString *> * nonProxyHosts;
		[Export ("nonProxyHosts", ArgumentSemantic.Copy)]
		NSSet<NSString> NonProxyHosts { get; set; }

		// +(instancetype)instance;
		[Static]
		[Export ("instance")]
		SSCInitializer Instance ();

		// -(void)verifyServerReachabilityCompletion:(SSCErrorBlock)errorBlock;
		[Export ("verifyServerReachabilityCompletion:")]
		void VerifyServerReachabilityCompletion (SSCErrorBlock errorBlock);
	}

	// @interface SSCPKIInfo : NSObject
	[BaseType (typeof(NSObject))]
	interface SSCPKIInfo
	{
		// @property (nonatomic) NSURL * _Nonnull estServerURL;
		[Export ("estServerURL", ArgumentSemantic.Assign)]
		NSUrl EstServerURL { get; set; }

		// @property (nonatomic) NSString * _Nonnull enrollUsername;
		[Export ("enrollUsername")]
		string EnrollUsername { get; set; }

		// @property (nonatomic) NSString * _Nonnull enrollPassword;
		[Export ("enrollPassword")]
		string EnrollPassword { get; set; }
	}

	// @interface SSCEnrollmentInfo : NSObject
	[BaseType (typeof(NSObject))]
	interface SSCEnrollmentInfo
	{
		// @property (nonatomic) NSString * _Nonnull username;
		[Export ("username")]
		string Username { get; set; }

		// @property (nonatomic) NSString * _Nonnull password;
		[Export ("password")]
		string Password { get; set; }

		// @property (nonatomic) NSString * _Nonnull code;
		[Export ("code")]
		string Code { get; set; }

		// @property (nonatomic) NSString * _Nonnull token;
		[Export ("token")]
		string Token { get; set; }

		// @property (nonatomic) SSCPKIInfo * _Nullable pkiInfo;
		[NullAllowed, Export ("pkiInfo", ArgumentSemantic.Assign)]
		SSCPKIInfo PkiInfo { get; set; }
	}

	// @interface SSCSessionService : NSObject
	[BaseType (typeof(NSObject))]
	interface SSCSessionService
	{
		// +(void)enrollApplicationWithInfo:(SSCEnrollmentInfo * _Nonnull)info errorBlock:(SSCErrorBlock _Nonnull)errorBlock;
		[Static]
		[Export ("enrollApplicationWithInfo:errorBlock:")]
		void EnrollApplicationWithInfo (SSCEnrollmentInfo info, SSCErrorBlock errorBlock);

		// +(void)enrollApplicationWithInfoAndToken:(SSCEnrollmentInfo * _Nonnull)info errorBlock:(SSCErrorBlock _Nonnull)errorBlock;
		[Static]
		[Export ("enrollApplicationWithInfoAndToken:errorBlock:")]
		void EnrollApplicationWithInfoAndToken (SSCEnrollmentInfo info, SSCErrorBlock errorBlock);

		// +(void)createApplicationSessionWithUsername:(NSString * _Nonnull)username password:(NSString * _Nonnull)password errorBlock:(SSCErrorBlock _Nonnull)errorBlock;
		[Static]
		[Export ("createApplicationSessionWithUsername:password:errorBlock:")]
		void CreateApplicationSessionWithUsername (string username, string password, SSCErrorBlock errorBlock);

		// +(void)logOut;
		[Static]
		[Export ("logOut")]
		void LogOut ();

		// +(NSString * _Nonnull)userLogged;
		[Static]
		[Export ("userLogged")]
		string UserLogged { get; }

		// +(NSArray * _Nonnull)alreadyEnrolledUsers;
		[Static]
		[Export("alreadyEnrolledUsers")]
		NSObject[] GetAlreadyEnrolledUsers();

		// +(void)disenrollUser:(NSString * _Nonnull)username;
		[Static]
		[Export ("disenrollUser:")]
		void DisenrollUser (string username);

		// +(NSDictionary * _Nonnull)getConfigProperties;
		[Static]
		[Export ("getConfigProperties")]
		NSDictionary ConfigProperties { get; }
	}

	[Static]
	partial interface Constants
	{
		// extern NSString *const SSC_ERROR_DOMAIN;
		[Field ("SSC_ERROR_DOMAIN", "__Internal")]
		NSString SSC_ERROR_DOMAIN { get; }

		// extern const NSInteger SSC_ERROR_CODE_USER_NOT_LOGGED;
		[Field ("SSC_ERROR_CODE_USER_NOT_LOGGED", "__Internal")]
		nint SSC_ERROR_CODE_USER_NOT_LOGGED { get; }

		// extern const NSInteger SSC_ERROR_CODE_ENROLLMENT_NOT_ALLOWED;
		[Field ("SSC_ERROR_CODE_ENROLLMENT_NOT_ALLOWED", "__Internal")]
		nint SSC_ERROR_CODE_ENROLLMENT_NOT_ALLOWED { get; }

		// extern const NSInteger SSC_ERROR_CODE_KEY_PAIR_GENERATION;
		[Field ("SSC_ERROR_CODE_KEY_PAIR_GENERATION", "__Internal")]
		nint SSC_ERROR_CODE_KEY_PAIR_GENERATION { get; }

		// extern const NSInteger SSC_ERROR_CODE_KEY_PAIR_UNKNOWN;
		[Field ("SSC_ERROR_CODE_KEY_PAIR_UNKNOWN", "__Internal")]
		nint SSC_ERROR_CODE_KEY_PAIR_UNKNOWN { get; }

		// extern const NSInteger SSC_ERROR_CODE_CERTIFICATE_CSR_REQUEST;
		[Field ("SSC_ERROR_CODE_CERTIFICATE_CSR_REQUEST", "__Internal")]
		nint SSC_ERROR_CODE_CERTIFICATE_CSR_REQUEST { get; }

		// extern const NSInteger SSC_ERROR_CODE_CERTIFICATE_GENERATION;
		[Field ("SSC_ERROR_CODE_CERTIFICATE_GENERATION", "__Internal")]
		nint SSC_ERROR_CODE_CERTIFICATE_GENERATION { get; }

		// extern const NSInteger SSC_ERROR_CODE_CERTIFICATE_TRUST;
		[Field ("SSC_ERROR_CODE_CERTIFICATE_TRUST", "__Internal")]
		nint SSC_ERROR_CODE_CERTIFICATE_TRUST { get; }

		// extern const NSInteger SSC_ERROR_CODE_CERTIFICATE_SAVE;
		[Field ("SSC_ERROR_CODE_CERTIFICATE_SAVE", "__Internal")]
		nint SSC_ERROR_CODE_CERTIFICATE_SAVE { get; }

		// extern NSString *const SSC_ERROR_DOMAIN_JSON_RPC;
		[Field ("SSC_ERROR_DOMAIN_JSON_RPC", "__Internal")]
		NSString SSC_ERROR_DOMAIN_JSON_RPC { get; }

		// extern const NSInteger SSC_ERROR_CODE_JSON_RPC_REQUEST_INVALID;
		[Field ("SSC_ERROR_CODE_JSON_RPC_REQUEST_INVALID", "__Internal")]
		nint SSC_ERROR_CODE_JSON_RPC_REQUEST_INVALID { get; }

		// extern const NSInteger SSC_ERROR_CODE_JSON_RPC_RESPONSE_VERSION_NOT_2_0;
		[Field ("SSC_ERROR_CODE_JSON_RPC_RESPONSE_VERSION_NOT_2_0", "__Internal")]
		nint SSC_ERROR_CODE_JSON_RPC_RESPONSE_VERSION_NOT_2_0 { get; }

		// extern const NSInteger SSC_ERROR_CODE_JSON_RPC_RESPONSE_FORMAT_INVALID;
		[Field ("SSC_ERROR_CODE_JSON_RPC_RESPONSE_FORMAT_INVALID", "__Internal")]
		nint SSC_ERROR_CODE_JSON_RPC_RESPONSE_FORMAT_INVALID { get; }

//------------
        // extern NSString *const SFK_ERROR_DOMAIN;
        [Field("SFK_ERROR_DOMAIN", "__Internal")]
        NSString SFK_ERROR_DOMAIN { get; }

        // extern const NSInteger SFK_ERROR_CODE_NSEXCEPTION;
        [Field("SFK_ERROR_CODE_NSEXCEPTION", "__Internal")]
        nint SFK_ERROR_CODE_NSEXCEPTION { get; }

        // extern const NSInteger SFK_ERROR_CODE_KEYCHAIN_ACCESS;
        [Field("SFK_ERROR_CODE_KEYCHAIN_ACCESS", "__Internal")]
        nint SFK_ERROR_CODE_KEYCHAIN_ACCESS { get; }

        // extern const NSInteger SFK_ERROR_CODE_KEYCHAIN_INTEGRITY;
        [Field("SFK_ERROR_CODE_KEYCHAIN_INTEGRITY", "__Internal")]
        nint SFK_ERROR_CODE_KEYCHAIN_INTEGRITY { get; }

        // extern const NSInteger SFK_ERROR_CODE_FRAMEWORK_NOT_INITIALIZED;
        [Field("SFK_ERROR_CODE_FRAMEWORK_NOT_INITIALIZED", "__Internal")]
        nint SFK_ERROR_CODE_FRAMEWORK_NOT_INITIALIZED { get; }

        // extern const NSInteger SFK_ERROR_CODE_DEVICE_JAILBROKEN;
        [Field("SFK_ERROR_CODE_DEVICE_JAILBROKEN", "__Internal")]
        nint SFK_ERROR_CODE_DEVICE_JAILBROKEN { get; }

        // extern const NSInteger SFK_ERROR_CODE_SESSION_KEY;
        [Field("SFK_ERROR_CODE_SESSION_KEY", "__Internal")]
        nint SFK_ERROR_CODE_SESSION_KEY { get; }

        // extern const NSInteger SFK_ERROR_CODE_MISSING_ENROLLMENT_INFO;
        [Field("SFK_ERROR_CODE_MISSING_ENROLLMENT_INFO", "__Internal")]
        nint SFK_ERROR_CODE_MISSING_ENROLLMENT_INFO { get; }

        // extern const NSInteger SFK_ERROR_CODE_IDENTIFICATION;
        [Field("SFK_ERROR_CODE_IDENTIFICATION", "__Internal")]
        nint SFK_ERROR_CODE_IDENTIFICATION { get; }

        // extern const NSInteger SFK_ERROR_CODE_AUTHENTICATION;
        [Field("SFK_ERROR_CODE_AUTHENTICATION", "__Internal")]
        nint SFK_ERROR_CODE_AUTHENTICATION { get; }

        // extern const NSInteger SFK_ERROR_CODE_ACCESS_DENIED;
        [Field("SFK_ERROR_CODE_ACCESS_DENIED", "__Internal")]
        nint SFK_ERROR_CODE_ACCESS_DENIED { get; }

        // extern const NSInteger SFK_ERROR_CODE_PASSWORD_EXPIRED;
        [Field("SFK_ERROR_CODE_PASSWORD_EXPIRED", "__Internal")]
        nint SFK_ERROR_CODE_PASSWORD_EXPIRED { get; }

        // extern const NSInteger SFK_ERROR_CODE_PASSWORD_CHANGE_REQUIRED;
        [Field("SFK_ERROR_CODE_PASSWORD_CHANGE_REQUIRED", "__Internal")]
        nint SFK_ERROR_CODE_PASSWORD_CHANGE_REQUIRED { get; }

        // extern const NSInteger SFK_ERROR_CODE_PASSWORD_POLICY_VIOLATED;
        [Field("SFK_ERROR_CODE_PASSWORD_POLICY_VIOLATED", "__Internal")]
        nint SFK_ERROR_CODE_PASSWORD_POLICY_VIOLATED { get; }

        // extern const NSInteger SFK_ERROR_CODE_APPLICATION_DISABLED;
        [Field("SFK_ERROR_CODE_APPLICATION_DISABLED", "__Internal")]
        nint SFK_ERROR_CODE_APPLICATION_DISABLED { get; }

        // extern const NSInteger SFK_ERROR_CODE_USER_NOT_ENROLLED;
        [Field("SFK_ERROR_CODE_USER_NOT_ENROLLED", "__Internal")]
        nint SFK_ERROR_CODE_USER_NOT_ENROLLED { get; }

        // extern const NSInteger SFK_ERROR_CODE_USER_ALREADY_ENROLLED;
        [Field("SFK_ERROR_CODE_USER_ALREADY_ENROLLED", "__Internal")]
        nint SFK_ERROR_CODE_USER_ALREADY_ENROLLED { get; }

        // extern const NSInteger SFK_ERROR_CODE_USER_DISENROLLED;
        [Field("SFK_ERROR_CODE_USER_DISENROLLED", "__Internal")]
        nint SFK_ERROR_CODE_USER_DISENROLLED { get; }

        // extern const NSInteger SFK_ERROR_CODE_ACCOUNT_LOCKED;
        [Field("SFK_ERROR_CODE_ACCOUNT_LOCKED", "__Internal")]
        nint SFK_ERROR_CODE_ACCOUNT_LOCKED { get; }

        // extern const NSInteger SFK_ERROR_CODE_ACCOUNT_ALREADY_LOCKED;
        [Field("SFK_ERROR_CODE_ACCOUNT_ALREADY_LOCKED", "__Internal")]
        nint SFK_ERROR_CODE_ACCOUNT_ALREADY_LOCKED { get; }

        // extern const NSInteger SFK_ERROR_CODE_PASSWORD_CHANGE_NOT_ALLOWED;
        [Field("SFK_ERROR_CODE_PASSWORD_CHANGE_NOT_ALLOWED", "__Internal")]
        nint SFK_ERROR_CODE_PASSWORD_CHANGE_NOT_ALLOWED { get; }

        // extern const NSInteger SFK_ERROR_CODE_CHANGE_PASSWORD_NOT_ALLOWED;
        [Field("SFK_ERROR_CODE_CHANGE_PASSWORD_NOT_ALLOWED", "__Internal")]
        nint SFK_ERROR_CODE_CHANGE_PASSWORD_NOT_ALLOWED { get; }

        // extern const NSInteger SFK_ERROR_CODE_PASSWORD_NOT_CHANGED;
        [Field("SFK_ERROR_CODE_PASSWORD_NOT_CHANGED", "__Internal")]
        nint SFK_ERROR_CODE_PASSWORD_NOT_CHANGED { get; }

        // extern const NSInteger SFK_ERROR_CODE_OFFLINE_NOT_ALLOWED;
        [Field("SFK_ERROR_CODE_OFFLINE_NOT_ALLOWED", "__Internal")]
        nint SFK_ERROR_CODE_OFFLINE_NOT_ALLOWED { get; }

        // extern const NSInteger SFK_ERROR_CODE_OFFLINE_CORRUPTED;
        [Field("SFK_ERROR_CODE_OFFLINE_CORRUPTED", "__Internal")]
        nint SFK_ERROR_CODE_OFFLINE_CORRUPTED { get; }

        // extern const NSInteger SFK_ERROR_CODE_DEVICE_LOCKED;
        [Field("SFK_ERROR_CODE_DEVICE_LOCKED", "__Internal")]
        nint SFK_ERROR_CODE_DEVICE_LOCKED { get; }

        // extern const NSInteger SFK_ERROR_CODE_DEVICE_NOT_COMPLIANT;
        [Field("SFK_ERROR_CODE_DEVICE_NOT_COMPLIANT", "__Internal")]
        nint SFK_ERROR_CODE_DEVICE_NOT_COMPLIANT { get; }

        // extern const NSInteger SFK_ERROR_CODE_SERVER_ERROR;
        [Field("SFK_ERROR_CODE_SERVER_ERROR", "__Internal")]
        nint SFK_ERROR_CODE_SERVER_ERROR { get; }

        // extern const NSInteger SFK_ERROR_CODE_NETWORK;
        [Field("SFK_ERROR_CODE_NETWORK", "__Internal")]
        nint SFK_ERROR_CODE_NETWORK { get; }

        // extern const NSInteger SFK_ERROR_CODE_SERVER_UNREACHABLE;
        [Field("SFK_ERROR_CODE_SERVER_UNREACHABLE", "__Internal")]
        nint SFK_ERROR_CODE_SERVER_UNREACHABLE { get; }

        // extern const NSInteger SFK_ERROR_CODE_NO_PROXY_URL_AVAILABLE;
        [Field("SFK_ERROR_CODE_NO_PROXY_URL_AVAILABLE", "__Internal")]
        nint SFK_ERROR_CODE_NO_PROXY_URL_AVAILABLE { get; }

        // extern const NSInteger SFK_ERROR_CODE_REPONSE_UNKNOW;
        [Field("SFK_ERROR_CODE_REPONSE_UNKNOW", "__Internal")]
        nint SFK_ERROR_CODE_REPONSE_UNKNOW { get; }

        // extern const NSInteger SFK_ERROR_CODE_XML_FORMAT;
        [Field("SFK_ERROR_CODE_XML_FORMAT", "__Internal")]
        nint SFK_ERROR_CODE_XML_FORMAT { get; }

        // extern const NSInteger SFK_ERROR_CODE_REQUEST_TIMEOUT;
        [Field("SFK_ERROR_CODE_REQUEST_TIMEOUT", "__Internal")]
        nint SFK_ERROR_CODE_REQUEST_TIMEOUT { get; }

        // extern const NSInteger SFK_ERROR_CODE_REQUEST_CANCELED;
        [Field("SFK_ERROR_CODE_REQUEST_CANCELED", "__Internal")]
        nint SFK_ERROR_CODE_REQUEST_CANCELED { get; }

        // extern const NSInteger SFK_ERROR_CODE_REQUEST_TLS_CLIENT_CERTIFICATE;
        [Field("SFK_ERROR_CODE_REQUEST_TLS_CLIENT_CERTIFICATE", "__Internal")]
        nint SFK_ERROR_CODE_REQUEST_TLS_CLIENT_CERTIFICATE { get; }

        // extern const NSInteger SFK_ERROR_CODE_OFFLINE_LOGIN_BLOCKED;
        [Field("SFK_ERROR_CODE_OFFLINE_LOGIN_BLOCKED", "__Internal")]
        nint SFK_ERROR_CODE_OFFLINE_LOGIN_BLOCKED { get; }

        // extern const NSInteger SFK_ERROR_CODE_MAX_ACCESS_TRY;
        [Field("SFK_ERROR_CODE_MAX_ACCESS_TRY", "__Internal")]
        nint SFK_ERROR_CODE_MAX_ACCESS_TRY { get; }

        // extern const NSInteger SFK_ERROR_CODE_LOCATION_REQUIRED;
        [Field("SFK_ERROR_CODE_LOCATION_REQUIRED", "__Internal")]
        nint SFK_ERROR_CODE_LOCATION_REQUIRED { get; }

        // extern const NSInteger SFK_ERROR_CODE_USER_SESSION_CLOSED;
        [Field("SFK_ERROR_CODE_USER_SESSION_CLOSED", "__Internal")]
        nint SFK_ERROR_CODE_USER_SESSION_CLOSED { get; }

        // extern const NSInteger SFK_ERROR_CODE_NOT_AVAILABLE_OFFLINE;
        [Field("SFK_ERROR_CODE_NOT_AVAILABLE_OFFLINE", "__Internal")]
        nint SFK_ERROR_CODE_NOT_AVAILABLE_OFFLINE { get; }

        // extern const NSInteger SFK_ERROR_CODE_SERVICE_NOT_ALLOWED;
        [Field("SFK_ERROR_CODE_SERVICE_NOT_ALLOWED", "__Internal")]
        nint SFK_ERROR_CODE_SERVICE_NOT_ALLOWED { get; }

        // extern const NSInteger SFK_ERROR_CODE_SIGNING_SERVICE_EMPTY_ALIAS;
        [Field("SFK_ERROR_CODE_SIGNING_SERVICE_EMPTY_ALIAS", "__Internal")]
        nint SFK_ERROR_CODE_SIGNING_SERVICE_EMPTY_ALIAS { get; }

        // extern const NSInteger SFK_ERROR_CODE_SIGNING_SERVICE_NO_SESSION;
        [Field("SFK_ERROR_CODE_SIGNING_SERVICE_NO_SESSION", "__Internal")]
        nint SFK_ERROR_CODE_SIGNING_SERVICE_NO_SESSION { get; }

        // extern const NSInteger SFK_ERROR_CODE_SIGNING_SERVICE_INVALID_SIGNATURE;
        [Field("SFK_ERROR_CODE_SIGNING_SERVICE_INVALID_SIGNATURE", "__Internal")]
        nint SFK_ERROR_CODE_SIGNING_SERVICE_INVALID_SIGNATURE { get; }

        // extern const NSInteger SFK_ERROR_CODE_SIGNING_SERVICE_KEYS_NOT_FOUND;
        [Field("SFK_ERROR_CODE_SIGNING_SERVICE_KEYS_NOT_FOUND", "__Internal")]
        nint SFK_ERROR_CODE_SIGNING_SERVICE_KEYS_NOT_FOUND { get; }

        // extern const NSInteger SFK_ERROR_CODE_SIGNING_SERVICE_KEYS_ALREADY_EXISTS;
        [Field("SFK_ERROR_CODE_SIGNING_SERVICE_KEYS_ALREADY_EXISTS", "__Internal")]
        nint SFK_ERROR_CODE_SIGNING_SERVICE_KEYS_ALREADY_EXISTS { get; }

        // extern const NSInteger SFK_ERROR_CODE_SIGNING_SERVICE_ENCLAVE_ACCESS_FAILED;
        [Field("SFK_ERROR_CODE_SIGNING_SERVICE_ENCLAVE_ACCESS_FAILED", "__Internal")]
        nint SFK_ERROR_CODE_SIGNING_SERVICE_ENCLAVE_ACCESS_FAILED { get; }

        // extern const NSInteger SFK_ERROR_CODE_SIGNING_SERVICE_UNEXPECTED_ERROR;
        [Field("SFK_ERROR_CODE_SIGNING_SERVICE_UNEXPECTED_ERROR", "__Internal")]
        nint SFK_ERROR_CODE_SIGNING_SERVICE_UNEXPECTED_ERROR { get; }

        // extern const NSInteger SFK_ERROR_CODE_STORAGE_INDEX_WRITTING;
        [Field("SFK_ERROR_CODE_STORAGE_INDEX_WRITTING", "__Internal")]
        nint SFK_ERROR_CODE_STORAGE_INDEX_WRITTING { get; }

        // extern const NSInteger SFK_ERROR_CODE_STORAGE_INDEX_READING;
        [Field("SFK_ERROR_CODE_STORAGE_INDEX_READING", "__Internal")]
        nint SFK_ERROR_CODE_STORAGE_INDEX_READING { get; }

        // extern const NSInteger SFK_ERROR_CODE_STORAGE_INDEX_CLOSED;
        [Field("SFK_ERROR_CODE_STORAGE_INDEX_CLOSED", "__Internal")]
        nint SFK_ERROR_CODE_STORAGE_INDEX_CLOSED { get; }

        // extern const NSInteger SFK_ERROR_CODE_STORAGE_COPY_ITEM;
        [Field("SFK_ERROR_CODE_STORAGE_COPY_ITEM", "__Internal")]
        nint SFK_ERROR_CODE_STORAGE_COPY_ITEM { get; }

        // extern const NSInteger SFK_ERROR_CODE_STORAGE_MOVE_ITEM;
        [Field("SFK_ERROR_CODE_STORAGE_MOVE_ITEM", "__Internal")]
        nint SFK_ERROR_CODE_STORAGE_MOVE_ITEM { get; }

        // extern const NSInteger SFK_ERROR_CODE_STORAGE_UNKNOW_ITEM;
        [Field("SFK_ERROR_CODE_STORAGE_UNKNOW_ITEM", "__Internal")]
        nint SFK_ERROR_CODE_STORAGE_UNKNOW_ITEM { get; }

        // extern const NSInteger SFK_ERROR_CODE_STORAGE_OVERWRITE_FILE;
        [Field("SFK_ERROR_CODE_STORAGE_OVERWRITE_FILE", "__Internal")]
        nint SFK_ERROR_CODE_STORAGE_OVERWRITE_FILE { get; }

        // extern const NSInteger SFK_ERROR_CODE_STORAGE_OVERWRITE_FOLDER;
        [Field("SFK_ERROR_CODE_STORAGE_OVERWRITE_FOLDER", "__Internal")]
        nint SFK_ERROR_CODE_STORAGE_OVERWRITE_FOLDER { get; }

        // extern const NSInteger SFK_ERROR_CODE_STORAGE_OVERWRITE_PATH;
        [Field("SFK_ERROR_CODE_STORAGE_OVERWRITE_PATH", "__Internal")]
        nint SFK_ERROR_CODE_STORAGE_OVERWRITE_PATH { get; }

        // extern const NSInteger SFK_ERROR_CODE_STORAGE_INTERNAL_PATH;
        [Field("SFK_ERROR_CODE_STORAGE_INTERNAL_PATH", "__Internal")]
        nint SFK_ERROR_CODE_STORAGE_INTERNAL_PATH { get; }

        // extern const NSInteger SFK_ERROR_CODE_STORAGE_REMOVE_FOLDER;
        [Field("SFK_ERROR_CODE_STORAGE_REMOVE_FOLDER", "__Internal")]
        nint SFK_ERROR_CODE_STORAGE_REMOVE_FOLDER { get; }

        // extern const NSInteger SFK_ERROR_CODE_STORAGE_INTERMEDIATE_FOLDER;
        [Field("SFK_ERROR_CODE_STORAGE_INTERMEDIATE_FOLDER", "__Internal")]
        nint SFK_ERROR_CODE_STORAGE_INTERMEDIATE_FOLDER { get; }

        // extern const NSInteger SFK_ERROR_CODE_STORAGE_IS_NOT_FOLDER;
        [Field("SFK_ERROR_CODE_STORAGE_IS_NOT_FOLDER", "__Internal")]
        nint SFK_ERROR_CODE_STORAGE_IS_NOT_FOLDER { get; }
    }

    // @interface SSCContractSending : NSObject
    [BaseType (typeof(NSObject))]
	interface SSCContractSending
	{
		// @property (readonly, nonatomic, strong) NSString * _Nonnull identifier;
		[Export ("identifier", ArgumentSemantic.Strong)]
		string Identifier { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull response;
		[Export ("response", ArgumentSemantic.Strong)]
		string Response { get; }

		// @property (nonatomic, strong) NSData * _Nullable data;
		[NullAllowed, Export ("data", ArgumentSemantic.Strong)]
		NSData Data { get; set; }

		// @property (assign, nonatomic) BOOL attached;
		[Export ("attached")]
		bool Attached { get; set; }

		// -(instancetype _Nonnull)initWithResponse:(NSString * _Nonnull)response forContract:(SSCContract * _Nonnull)contract;
		[Export ("initWithResponse:forContract:")]
		NativeHandle Constructor (string response, SSCContract contract);
	}

	// @interface SSCContractEvent : NSObject
	[BaseType (typeof(NSObject))]
	interface SSCContractEvent
	{
		// @property (readonly, nonatomic, strong) NSString * identifier;
		[Export ("identifier", ArgumentSemantic.Strong)]
		string Identifier { get; }

		// @property (readonly, nonatomic, strong) NSString * name;
		[Export ("name", ArgumentSemantic.Strong)]
		string Name { get; }

		// @property (nonatomic, strong) NSData * data;
		[Export ("data", ArgumentSemantic.Strong)]
		NSData Data { get; set; }

		// @property (nonatomic, strong) NSDictionary<NSString *,NSString *> * extras;
		[Export ("extras", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSString> Extras { get; set; }

		// -(instancetype)initWithName:(NSString *)name forContract:(SSCContract *)contract;
		[Export ("initWithName:forContract:")]
		NativeHandle Constructor (string name, SSCContract contract);
	}

	// @interface SSCSmartContractService : NSObject
	[BaseType (typeof(NSObject))]
	interface SSCSmartContractService
    {
        // -(instancetype _Nonnull)initWithError:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithError:")]
		NativeHandle Constructor ([NullAllowed] NSError error);

		// -(void)getPendingContractsCompletion:(SSCContractsBlock _Nonnull)completion;
		[Export ("getPendingContractsCompletion:")]
		void GetPendingContractsCompletion (SSCContractsBlock completion);

		// -(void)getPayloadForContract:(SSCContract * _Nonnull)contract error:(SSCErrorBlock _Nonnull)errorBlock;
		[Export ("getPayloadForContract:error:")]
		void GetPayloadForContract (SSCContract contract, SSCErrorBlock errorBlock);

		// -(void)getEnvelopeContracts:(SSCContract * _Nonnull)envelope completion:(SSCContractsBlock _Nonnull)completion;
		[Export ("getEnvelopeContracts:completion:")]
		void GetEnvelopeContracts (SSCContract envelope, SSCContractsBlock completion);

		// -(void)sendResponse:(SSCContractSending * _Nonnull)sendingResponse completion:(SSCContractResponseBlock _Nonnull)completion;
		[Export ("sendResponse:completion:")]
		void SendResponse (SSCContractSending sendingResponse, SSCContractResponseBlock completion);

		// -(void)requestSignatureForContract:(SSCContract * _Nonnull)contract withDocumentDigest:(NSData * _Nonnull)documentDigest completion:(SSCSignatureStatusBlock _Nonnull)signatureStatusBlock;
		[Export ("requestSignatureForContract:withDocumentDigest:completion:")]
		void RequestSignatureForContract (SSCContract contract, NSData documentDigest, SSCSignatureStatusBlock signatureStatusBlock);

		// -(void)requestSignaturesForContract:(SSCContract * _Nonnull)contract withDocumentDigests:(NSDictionary<NSString *,NSData *> * _Nonnull)documentDigests completion:(SSCSignatureStatusBlock _Nonnull)signatureStatusBlock;
		[Export ("requestSignaturesForContract:withDocumentDigests:completion:")]
		void RequestSignaturesForContract (SSCContract contract, NSDictionary<NSString, NSData> documentDigests, SSCSignatureStatusBlock signatureStatusBlock);

		// -(void)signatureStatusForContract:(SSCContract * _Nonnull)contract withRequestId:(NSString * _Nonnull)requestId completion:(SSCSignatureStatusBlock _Nonnull)signatureStatusBlock;
		[Export ("signatureStatusForContract:withRequestId:completion:")]
		void SignatureStatusForContract (SSCContract contract, string requestId, SSCSignatureStatusBlock signatureStatusBlock);

		// -(void)sendEvent:(SSCContractEvent * _Nonnull)event completion:(SSCContractBlock _Nonnull)contractBlock;
		[Export ("sendEvent:completion:")]
		void SendEvent (SSCContractEvent @event, SSCContractBlock contractBlock);

		// -(void)visualSignaturesOfTypes:(NSArray * _Nullable)signatureTypes completion:(SSCVisualSignaturesBlock _Nonnull)visualSignaturesBlock;
		[Export ("visualSignaturesOfTypes:completion:")]
		void VisualSignaturesOfTypes ([NullAllowed] NSObject[] signatureTypes, SSCVisualSignaturesBlock visualSignaturesBlock);

		// -(void)saveVisualSignature:(SSCVisualSignature * _Nonnull)visualSignature completion:(SSCVisualSignatureBlock _Nonnull)visualSignatureBlock;
		[Export ("saveVisualSignature:completion:")]
		void SaveVisualSignature (SSCVisualSignature visualSignature, SSCVisualSignatureBlock visualSignatureBlock);

		// -(void)deleteSignature:(NSString * _Nonnull)identifier error:(SSCErrorBlock _Nonnull)errorBlock;
		[Export ("deleteSignature:error:")]
		void DeleteSignature (string identifier, SSCErrorBlock errorBlock);
	}

	partial interface Constants
	{
		// extern NSString *const SSC_SESSION_WILL_TIMEOUT_NOTIFICATION;
		[Field ("SSC_SESSION_WILL_TIMEOUT_NOTIFICATION", "__Internal")]
		NSString SSC_SESSION_WILL_TIMEOUT_NOTIFICATION { get; }

		// extern NSString *const SSC_SESSION_TIMEOUT_NOTIFICATION;
		[Field ("SSC_SESSION_TIMEOUT_NOTIFICATION", "__Internal")]
		NSString SSC_SESSION_TIMEOUT_NOTIFICATION { get; }

		// extern NSString *const SSC_BACKGROUND_DISABLE_NOTIFICATION;
		[Field ("SSC_BACKGROUND_DISABLE_NOTIFICATION", "__Internal")]
		NSString SSC_BACKGROUND_DISABLE_NOTIFICATION { get; }

		// extern NSString *const SSC_UPDATE_AVAILABLE_NOTIFICATION;
		[Field ("SSC_UPDATE_AVAILABLE_NOTIFICATION", "__Internal")]
		NSString SSC_UPDATE_AVAILABLE_NOTIFICATION { get; }

		// extern NSString *const SSC_APPLICATION_UP_TO_DATE_NOTIFICATION;
		[Field ("SSC_APPLICATION_UP_TO_DATE_NOTIFICATION", "__Internal")]
		NSString SSC_APPLICATION_UP_TO_DATE_NOTIFICATION { get; }
	}

	// @interface SSCRemoteNotification : NSObject
	[BaseType (typeof(NSObject))]
	interface SSCRemoteNotification
	{
		// +(BOOL)isAvailable;
		[Static]
		[Export ("isAvailable")]
		bool IsAvailable { get; }

		// +(BOOL)registerRemoteNotificationToken:(NSData *)token error:(NSError **)error;
		[Static]
		[Export ("registerRemoteNotificationToken:error:")]
		bool RegisterRemoteNotificationToken (NSData token, out NSError error);

		// +(BOOL)registerRemoteNotificationToken:(NSData *)token;
		[Static]
		[Export ("registerRemoteNotificationToken:")]
		bool RegisterRemoteNotificationToken (NSData token);
	}

	// @interface SSCSecureProperties : NSObject
	[BaseType (typeof(NSObject))]
	interface SSCSecureProperties
	{
		// +(void)setPropertyWithAlias:(NSString *)alias andValue:(NSString *)value;
		[Static]
		[Export ("setPropertyWithAlias:andValue:")]
		void SetPropertyWithAlias (string alias, string value);

		// +(NSString *)valueForAlias:(NSString *)alias;
		[Static]
		[Export ("valueForAlias:")]
		string ValueForAlias (string alias);
	}

	// @interface SSCASN1 : NSObject
	[BaseType (typeof(NSObject))]
	interface SSCASN1
	{
		// +(void)appendSequence:(NSData *)data into:(NSMutableData *)into;
		[Static]
		[Export ("appendSequence:into:")]
		void AppendSequence (NSData data, NSMutableData into);

		// +(void)appendINTEGER:(NSData *)data into:(NSMutableData *)into;
		[Static]
		[Export ("appendINTEGER:into:")]
		void AppendINTEGER (NSData data, NSMutableData into);

		// +(void)appendPrintableString:(NSString *)string into:(NSMutableData *)into;
		[Static]
		[Export ("appendPrintableString:into:")]
		void AppendPrintableString (string @string, NSMutableData into);

		// +(void)appendAttr0String:(NSString *)string into:(NSMutableData *)into;
		[Static]
		[Export ("appendAttr0String:into:")]
		void AppendAttr0String (string @string, NSMutableData into);

		// +(void)appendAttr4Data:(NSData *)data into:(NSMutableData *)into;
		[Static]
		[Export ("appendAttr4Data:into:")]
		void AppendAttr4Data (NSData data, NSMutableData into);

		// +(void)appendSubjectItem:(NSData *)what value:(NSString *)value into:(NSMutableData *)into;
		[Static]
		[Export ("appendSubjectItem:value:into:")]
		void AppendSubjectItem (NSData what, string value, NSMutableData into);

		// +(void)appendUTF8String:(NSString *)string into:(NSMutableData *)into;
		[Static]
		[Export ("appendUTF8String:into:")]
		void AppendUTF8String (string @string, NSMutableData into);

		// +(void)appendOCTETString:(NSData *)data into:(NSMutableData *)into;
		[Static]
		[Export ("appendOCTETString:into:")]
		void AppendOCTETString (NSData data, NSMutableData into);

		// +(void)appendBITSTRING:(NSData *)data into:(NSMutableData *)into;
		[Static]
		[Export ("appendBITSTRING:into:")]
		void AppendBITSTRING (NSData data, NSMutableData into);

		// +(void)appendUTCTime:(NSDate *)date into:(NSMutableData *)into;
		[Static]
		[Export ("appendUTCTime:into:")]
		void AppendUTCTime (NSDate date, NSMutableData into);

		// +(void)appendDERLength:(size_t)length into:(NSMutableData *)into;
		[Static]
		[Export ("appendDERLength:into:")]
		void AppendDERLength (nuint length, NSMutableData into);

		// +(void)enclose:(NSMutableData *)data by:(uint8_t)by;
		[Static]
		[Export ("enclose:by:")]
		void Enclose (NSMutableData data, byte by);
	}
}
