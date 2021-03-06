﻿using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using Accounts;
using CoreFoundation;
using CoreLocation;

namespace Facebook.CoreKit {
	interface AccessTokenDidChangeEventArgs {
		[Export ("FBSDKAccessTokenChangeNewKey")]
		AccessToken NewToken { get; }

		[Export ("FBSDKAccessTokenDidChangeUserID")]
		bool DidChangeUserIdToken { get; }

		[Export ("FBSDKAccessTokenChangeOldKey")]
		AccessToken OldToken { get; }

		[Export ("FBSDKAccessTokenDidExpire")]
		bool DidExpireKey { get; }
	}

	// @interface FBSDKAccessToken : NSObject <FBSDKCopying, NSSecureCoding>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAccessToken")]
	interface AccessToken : Copying, INSSecureCoding {

		// extern NSString *const FBSDKAccessTokenDidChangeNotification;
		[Notification (typeof (AccessTokenDidChangeEventArgs))]
		[Field ("FBSDKAccessTokenDidChangeNotification", "__Internal")]
		NSString DidChangeNotification { get; }

		[Field ("FBSDKAccessTokenChangeNewKey", "__Internal")]
		NSString NewTokenKey { get; }

		[Field ("FBSDKAccessTokenDidChangeUserID", "__Internal")]
		NSString UserIdKey { get; }

		[Field ("FBSDKAccessTokenChangeOldKey", "__Internal")]
		NSString OldTokenKey { get; }

		// FBSDK_EXTERN NSString *const FBSDKAccessTokenDidExpire;
		[Field ("FBSDKAccessTokenDidExpire", "__Internal")]
		NSString DidExpireKey { get; }

		// @property (readonly, copy, nonatomic) NSString * appID;
		[Export ("appID")]
		string AppID { get; }

		// @property (readonly, copy, nonatomic) NSSet * declinedPermissions;
		[Export ("declinedPermissions", ArgumentSemantic.Copy)]
		NSSet DeclinedPermissions { get; }

		// @property (readonly, copy, nonatomic) NSDate * expirationDate;
		[Export ("expirationDate", ArgumentSemantic.Copy)]
		NSDate ExpirationDate { get; }

		// @property (readonly, copy, nonatomic) NSSet * permissions;
		[Export ("permissions", ArgumentSemantic.Copy)]
		NSSet Permissions { get; }

		// @property (readonly, copy, nonatomic) NSDate * refreshDate;
		[Export ("refreshDate", ArgumentSemantic.Copy)]
		NSDate RefreshDate { get; }

		// @property (readonly, copy, nonatomic) NSString * tokenString;
		[Export ("tokenString", ArgumentSemantic.Copy)]
		string TokenString { get; }

		// @property (readonly, copy, nonatomic) NSString * userID;
		[Export ("userID", ArgumentSemantic.Copy)]
		string UserID { get; }

		// @property (readonly, assign, nonatomic, getter = isExpired) BOOL expired;
		[Export ("isExpired", ArgumentSemantic.Assign)]
		bool IsExpired { get; }

		// -(instancetype)initWithTokenString:(NSString *)tokenString permissions:(NSArray *)permissions declinedPermissions:(NSArray *)declinedPermissions appID:(NSString *)appID userID:(NSString *)userID expirationDate:(NSDate *)expirationDate refreshDate:(NSDate *)refreshDate __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithTokenString:permissions:declinedPermissions:appID:userID:expirationDate:refreshDate:")]
		IntPtr Constructor (string tokenString, [NullAllowed] string [] permissions, [NullAllowed] string [] declinedPermissions, string appID, string userID, [NullAllowed] NSDate expirationDate, [NullAllowed] NSDate refreshDate);

		// -(BOOL)hasGranted:(NSString *)permission;
		[Export ("hasGranted:")]
		bool HasGranted (string permission);

		// -(BOOL)isEqualToAccessToken:(FBSDKAccessToken *)token;
		[Export ("isEqualToAccessToken:")]
		bool IsEqualToAccessToken (AccessToken token);

		// +(FBSDKAccessToken *)currentAccessToken;
		// +(void)setCurrentAccessToken:(FBSDKAccessToken *)token;
		[Static]
		[Export ("currentAccessToken")]
		AccessToken CurrentAccessToken { get; set; }

		// + (BOOL)currentAccessTokenIsActive;
		[Static]
		[Export ("currentAccessTokenIsActive")]
		bool CurrentAccessTokenIsActive { get; }

		// + (void)refreshCurrentAccessToken:(FBSDKGraphRequestHandler)completionHandler;
		[Static]
		[Export ("refreshCurrentAccessToken:")]
		void RefreshCurrentAccessToken (GraphRequestHandler completionHandler);
	}

	// @interface FBSDKAppEvents : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAppEvents")]
	interface AppEvents {

		// extern NSString *const FBSDKAppEventsLoggingResultNotification;
		[Notification]
		[Field ("FBSDKAppEventsLoggingResultNotification", "__Internal")]
		NSString LoggingResultNotification { get; }

		// extern NSString *const FBSDKAppEventsOverrideAppIDBundleKey;
		[Field ("FBSDKAppEventsOverrideAppIDBundleKey", "__Internal")]
		NSString OverrideAppIdBundleKey { get; }

		// extern NSString *const FBSDKAppEventNameAchievedLevel;
		[Field ("FBSDKAppEventNameAchievedLevel", "__Internal")]
		NSString AchievedLevelEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameAddedPaymentInfo;
		[Field ("FBSDKAppEventNameAddedPaymentInfo", "__Internal")]
		NSString AddedPaymentInfoEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameAddedToCart;
		[Field ("FBSDKAppEventNameAddedToCart", "__Internal")]
		NSString AddedToCartEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameAddedToWishlist;
		[Field ("FBSDKAppEventNameAddedToWishlist", "__Internal")]
		NSString AddedToWishlistEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameCompletedRegistration;
		[Field ("FBSDKAppEventNameCompletedRegistration", "__Internal")]
		NSString CompletedRegistrationEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameCompletedTutorial;
		[Field ("FBSDKAppEventNameCompletedTutorial", "__Internal")]
		NSString CompletedTutorialEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameInitiatedCheckout;
		[Field ("FBSDKAppEventNameInitiatedCheckout", "__Internal")]
		NSString InitiatedCheckoutEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameRated;
		[Field ("FBSDKAppEventNameRated", "__Internal")]
		NSString RatedEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameSearched;
		[Field ("FBSDKAppEventNameSearched", "__Internal")]
		NSString SearchedEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameSpentCredits;
		[Field ("FBSDKAppEventNameSpentCredits", "__Internal")]
		NSString SpentCreditsEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameUnlockedAchievement;
		[Field ("FBSDKAppEventNameUnlockedAchievement", "__Internal")]
		NSString UnlockedAchievementEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameViewedContent;
		[Field ("FBSDKAppEventNameViewedContent", "__Internal")]
		NSString ViewedContentEventNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameContent;
		[Field ("FBSDKAppEventParameterNameContent", "__Internal")]
		NSString ContentParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameContentID;
		[Field ("FBSDKAppEventParameterNameContentID", "__Internal")]
		NSString ContentIdParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameContentType;
		[Field ("FBSDKAppEventParameterNameContentType", "__Internal")]
		NSString ContentTypeParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameCurrency;
		[Field ("FBSDKAppEventParameterNameCurrency", "__Internal")]
		NSString CurrencyParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameDescription;
		[Field ("FBSDKAppEventParameterNameDescription", "__Internal")]
		NSString DescriptionParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameLevel;
		[Field ("FBSDKAppEventParameterNameLevel", "__Internal")]
		NSString LevelParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameMaxRatingValue;
		[Field ("FBSDKAppEventParameterNameMaxRatingValue", "__Internal")]
		NSString MaxRatingValueParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameNumItems;
		[Field ("FBSDKAppEventParameterNameNumItems", "__Internal")]
		NSString NumItemsParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNamePaymentInfoAvailable;
		[Field ("FBSDKAppEventParameterNamePaymentInfoAvailable", "__Internal")]
		NSString PaymentInfoAvailableParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameRegistrationMethod;
		[Field ("FBSDKAppEventParameterNameRegistrationMethod", "__Internal")]
		NSString RegistrationMethodParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameSearchString;
		[Field ("FBSDKAppEventParameterNameSearchString", "__Internal")]
		NSString SearchStringParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameSuccess;
		[Field ("FBSDKAppEventParameterNameSuccess", "__Internal")]
		NSString SuccessParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterValueYes;
		[Field ("FBSDKAppEventParameterValueYes", "__Internal")]
		NSString YesParameterValueKey { get; }

		// extern NSString *const FBSDKAppEventParameterValueNo;
		[Field ("FBSDKAppEventParameterValueNo", "__Internal")]
		NSString NoParameterValueKey { get; }

		// +(void)logEvent:(NSString *)eventName;
		[Static]
		[Export ("logEvent:")]
		void LogEvent (string eventName);

		// +(void)logEvent:(NSString *)eventName valueToSum:(double)valueToSum;
		[Static]
		[Export ("logEvent:valueToSum:")]
		void LogEvent (string eventName, double valueToSum);

		// +(void)logEvent:(NSString *)eventName parameters:(NSDictionary *)parameters;
		[Static]
		[Export ("logEvent:parameters:")]
		void LogEvent (string eventName, NSDictionary parameters);

		// +(void)logEvent:(NSString *)eventName valueToSum:(double)valueToSum parameters:(NSDictionary *)parameters;
		[Static]
		[Export ("logEvent:valueToSum:parameters:")]
		void LogEvent (string eventName, double valueToSum, [NullAllowed] NSDictionary parameters);

		// +(void)logEvent:(NSString *)eventName valueToSum:(NSNumber *)valueToSum parameters:(NSDictionary *)parameters accessToken:(FBSDKAccessToken *)accessToken;
		[Static]
		[Export ("logEvent:valueToSum:parameters:accessToken:")]
		void LogEvent (string eventName, NSNumber valueToSum, [NullAllowed] NSDictionary parameters, [NullAllowed] AccessToken accessToken);

		// +(void)logPurchase:(double)purchaseAmount currency:(NSString *)currency;
		[Static]
		[Export ("logPurchase:currency:")]
		void LogPurchase (double purchaseAmount, string currency);

		// +(void)logPurchase:(double)purchaseAmount currency:(NSString *)currency parameters:(NSDictionary *)parameters;
		[Static]
		[Export ("logPurchase:currency:parameters:")]
		void LogPurchase (double purchaseAmount, string currency, [NullAllowed] NSDictionary parameters);

		// +(void)logPurchase:(double)purchaseAmount currency:(NSString *)currency parameters:(NSDictionary *)parameters accessToken:(FBSDKAccessToken *)accessToken;
		[Static]
		[Export ("logPurchase:currency:parameters:accessToken:")]
		void LogPurchase (double purchaseAmount, string currency, [NullAllowed] NSDictionary parameters, [NullAllowed] AccessToken accessToken);

		// + (void)logPushNotificationOpen:(NSDictionary *)payload;
		[Static]
		[Export ("logPushNotificationOpen:")]
		void LogPushNotificationOpen (NSDictionary payload);

		// + (void)logPushNotificationOpen:(NSDictionary *)payload action:(NSString *)action;
		[Static]
		[Export ("logPushNotificationOpen:action:")]
		void LogPushNotificationOpen (NSDictionary payload, string action);

		// +(void)activateApp;
		[Static]
		[Export ("activateApp")]
		void ActivateApp ();

		// + (void)setPushNotificationsDeviceToken:(NSData *)deviceToken;
		[Static]
		[Export ("setPushNotificationsDeviceToken:")]
		void SetPushNotificationsDeviceToken (NSData deviceToken);

		// +(FBSDKAppEventsFlushBehavior)flushBehavior;
		// +(void)setFlushBehavior:(FBSDKAppEventsFlushBehavior)flushBehavior;
		[Static]
		[Export ("flushBehavior")]
		AppEventsFlushBehavior FlushBehavior { get; set; }

		// +(NSString *)loggingOverrideAppID;
		// +(void)setLoggingOverrideAppID:(NSString *)appID;
		[Static]
		[Export ("loggingOverrideAppID")]
		string LoggingOverrideAppID { get; set; }

		// +(void)flush;
		[Static]
		[Export ("flush")]
		void Flush ();

		// +(FBSDKGraphRequest *)requestForCustomAudienceThirdPartyIDWithAccessToken:(FBSDKAccessToken *)accessToken;
		[Static]
		[Export ("requestForCustomAudienceThirdPartyIDWithAccessToken:")]
		GraphRequest RequestForCustomAudienceThirdPartyId (AccessToken accessToken);

		// +(void)setUserID:(NSString *)userID;
		// +(NSString *)userID;
		[Static]
		[Export ("userID")]
		[NullAllowed]
		string UserID { get; set; }

		// +(void)updateUserProperties:(NSDictionary *)properties handler:(FBSDKGraphRequestHandler)handler;
		[Static]
		[Export ("updateUserProperties:handler:")]
		void UpdateUserProperties (NSDictionary properties, [NullAllowed]GraphRequestHandler handler);
	}

	// @interface FBSDKApplicationDelegate : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKApplicationDelegate")]
	interface ApplicationDelegate {

		// +(instancetype)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		ApplicationDelegate SharedInstance { get; }

		// -(BOOL)application:(UIApplication *)application openURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication annotation:(id)annotation;
		[Export ("application:openURL:sourceApplication:annotation:")]
		bool OpenUrl ([NullAllowed] UIApplication application, [NullAllowed] NSUrl url, [NullAllowed] string sourceApplication, [NullAllowed] NSObject annotation);

		// -(BOOL)application:(UIApplication *)application openURL:(NSURL *)url options:(NSDictionary<UIApplicationOpenURLOptionsKey,id> *)options;
		[Export ("application:openURL:options:")]
		bool OpenUrl (UIApplication application, NSUrl url, NSDictionary options);

		[Obsolete ("This will be removed in future versions, please, use OpenUrl (UIApplication, NSUrl, NSDictionary) overload method instead.")]
		[Wrap ("OpenUrl (application, url, NSDictionary.FromObjectsAndKeys (options.Values, options.Keys, options.Keys.Length))")]
		bool OpenUrl (UIApplication application, NSUrl url, NSDictionary<NSString, NSObject> options);

		// -(BOOL)application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions;
		[Export ("application:didFinishLaunchingWithOptions:")]
		bool FinishedLaunching ([NullAllowed] UIApplication application, [NullAllowed] NSDictionary launchOptions);
	}

	// @interface FBSDKAppLinkResolver : NSObject<BFAppLinkResolving>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLinkResolver")]
	interface AppLinkResolver : AppLinkResolving {

		// - (BFTask *)appLinksFromURLsInBackground:(NSArray *)urls;
		[Export ("appLinksFromURLsInBackground:")]
		Task AppLinksInBackground (NSUrl [] urls);

		// + (instancetype)resolver;
		[Static]
		[Export ("resolver")]
		AppLinkResolver Resolver { get; }
	}

	// typedef void (^FBSDKDeferredAppLinkHandler)(NSURL *, NSError *);
	delegate void DeferredAppLinkHandler (NSUrl url, NSError error);
	// typedef void (^FBSDKDeferredAppInviteHandler)(NSURL *url);
	delegate void DeferredAppInviteHandler (NSUrl url);

	// @interface FBSDKAppLinkUtility : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLinkUtility")]
	interface AppLinkUtility {

		// +(void)fetchDeferredAppLink:(FBSDKDeferredAppLinkHandler)handler;
		[Static]
		[Async]
		[Export ("fetchDeferredAppLink:")]
		void FetchDeferredAppLink (DeferredAppLinkHandler handler);

		// + (BOOL)fetchDeferredAppInvite:(FBSDKDeferredAppInviteHandler)handler;
		[Static]
		[Export ("fetchDeferredAppInvite:")]
		[Obsolete ("This method is no longer available and will always return NO.")]
		bool FetchDeferredAppInvite (DeferredAppInviteHandler handler);

		// + (NSString*)appInvitePromotionCodeFromURL:(NSURL*)url;
		[Static]
		[Export ("appInvitePromotionCodeFromURL:")]
		string AppInvitePromotionCode (NSUrl url);
	}

	// @interface FBSDKButton : UIButton
	[BaseType (typeof (UIButton), Name = "FBSDKButton")]
	interface Button {

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);
	}

	[Static]
	interface Errors {

		// extern NSString *const FBSDKErrorDomain;
		[Field ("FBSDKErrorDomain", "__Internal")]
		NSString DomainKey { get; }

		// extern NSString *const FBSDKErrorArgumentCollectionKey;
		[Field ("FBSDKErrorArgumentCollectionKey", "__Internal")]
		NSString ArgumentCollectionKey { get; }

		// extern NSString *const FBSDKErrorArgumentNameKey;
		[Field ("FBSDKErrorArgumentNameKey", "__Internal")]
		NSString ArgumentNameKey { get; }

		// extern NSString *const FBSDKErrorArgumentValueKey;
		[Field ("FBSDKErrorArgumentValueKey", "__Internal")]
		NSString ArgumentValueKey { get; }

		// extern NSString *const FBSDKErrorDeveloperMessageKey;
		[Field ("FBSDKErrorDeveloperMessageKey", "__Internal")]
		NSString DeveloperMessageKey { get; }

		// extern NSString *const FBSDKErrorLocalizedDescriptionKey;
		[Field ("FBSDKErrorLocalizedDescriptionKey", "__Internal")]
		NSString LocalizedDescriptionKey { get; }

		// extern NSString *const FBSDKErrorLocalizedTitleKey;
		[Field ("FBSDKErrorLocalizedTitleKey", "__Internal")]
		NSString LocalizedTitleKey { get; }

		// extern NSString *const FBSDKGraphRequestErrorCategoryKey;
		[Field ("FBSDKGraphRequestErrorCategoryKey", "__Internal")]
		NSString CategoryKey { get; }

		// extern NSString *const FBSDKGraphRequestErrorGraphErrorCode;
		[Field ("FBSDKGraphRequestErrorGraphErrorCode", "__Internal")]
		NSString GraphErrorCode { get; }

		// extern NSString *const FBSDKGraphRequestErrorGraphErrorSubcode;
		[Field ("FBSDKGraphRequestErrorGraphErrorSubcode", "__Internal")]
		NSString GraphErrorSubcode { get; }

		// extern NSString *const FBSDKGraphRequestErrorHTTPStatusCodeKey;
		[Field ("FBSDKGraphRequestErrorHTTPStatusCodeKey", "__Internal")]
		NSString HttpStatusCodeKey { get; }

		// extern NSString *const FBSDKGraphRequestErrorParsedJSONResponseKey;
		[Field ("FBSDKGraphRequestErrorParsedJSONResponseKey", "__Internal")]
		NSString ParsedJSONResponseKey { get; }
	}

	// @protocol FBSDKErrorRecoveryAttempting <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKErrorRecoveryAttempting")]
	interface ErrorRecoveryAttempting {
		// @required -(void)attemptRecoveryFromError:(NSError *)error optionIndex:(NSUInteger)recoveryOptionIndex delegate:(id)delegate didRecoverSelector:(SEL)didRecoverSelector contextInfo:(void *)contextInfo;
		[Abstract]
		[Export ("attemptRecoveryFromError:optionIndex:delegate:didRecoverSelector:contextInfo:")]
		unsafe void AttemptRecovery (NSError error, nuint recoveryOptionIndex, NSObject aDelegate, Selector didRecoverSelector, NSObject contextInfo);
	}

	interface ICopying {

	}

	// @protocol FBSDKCopying <NSCopying, NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKCopying")]
	interface Copying : INSCopying {
		// @required -(id)copy;
		[New]
		[Abstract]
		[Export ("copy")]
		NSObject Copy ();
	}

	interface IGraphErrorRecoveryProcessorDelegate {

	}

	// @protocol FBSDKGraphErrorRecoveryProcessorDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKGraphErrorRecoveryProcessorDelegate")]
	interface GraphErrorRecoveryProcessorDelegate {

		// @required -(void)processorDidAttemptRecovery:(FBSDKGraphErrorRecoveryProcessor *)processor didRecover:(BOOL)didRecover error:(NSError *)error;
		[Abstract]
		[Export ("processorDidAttemptRecovery:didRecover:error:")]
		void DidAttemptRecovery (GraphErrorRecoveryProcessor processor, bool didRecover, NSError error);

		// @optional -(BOOL)processorWillProcessError:(FBSDKGraphErrorRecoveryProcessor *)processor error:(NSError *)error;
		[Export ("processorWillProcessError:error:")]
		bool WillProcessError (GraphErrorRecoveryProcessor processor, NSError error);
	}

	// @interface FBSDKGraphErrorRecoveryProcessor : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKGraphErrorRecoveryProcessor")]
	interface GraphErrorRecoveryProcessor {

		// @property (readonly, nonatomic, strong) id<FBSDKGraphErrorRecoveryProcessorDelegate> delegate;
		[Export ("delegate", ArgumentSemantic.Strong)]
		IGraphErrorRecoveryProcessorDelegate Delegate { get; }

		// -(BOOL)processError:(NSError *)error request:(FBSDKGraphRequest *)request delegate:(id<FBSDKGraphErrorRecoveryProcessorDelegate>)delegate;
		[Export ("processError:request:delegate:")]
		bool ProcessError (NSError error, GraphRequest request, [NullAllowed] IGraphErrorRecoveryProcessorDelegate aDelegate);

		// -(void)didPresentErrorWithRecovery:(BOOL)didRecover contextInfo:(void *)contextInfo;
		[Export ("didPresentErrorWithRecovery:contextInfo:")]
		unsafe void ErrorPresentedWithRecovery (bool didRecover, [NullAllowed] NSObject contextInfo);
	}

	// @interface FBSDKGraphRequest : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKGraphRequest")]
	interface GraphRequest {

		// -(instancetype)initWithGraphPath:(NSString *)graphPath parameters:(NSDictionary *)parameters;
		[Export ("initWithGraphPath:parameters:")]
		IntPtr Constructor (string graphPath, [NullAllowed] NSDictionary parameters);

		// -(instancetype)initWithGraphPath:(NSString *)graphPath parameters:(NSDictionary *)parameters HTTPMethod:(NSString *)HTTPMethod;
		[Export ("initWithGraphPath:parameters:HTTPMethod:")]
		IntPtr Constructor (string graphPath, [NullAllowed] NSDictionary parameters, [NullAllowed] string httpMethod);

		// -(instancetype)initWithGraphPath:(NSString *)graphPath parameters:(NSDictionary *)parameters tokenString:(NSString *)tokenString version:(NSString *)version HTTPMethod:(NSString *)HTTPMethod __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithGraphPath:parameters:tokenString:version:HTTPMethod:")]
		IntPtr Constructor (string graphPath, [NullAllowed] NSDictionary parameters, [NullAllowed] string tokenString, [NullAllowed] string version, [NullAllowed] string httpMethod);

		// @property (readonly, nonatomic, strong) NSMutableDictionary * parameters;
		[Export ("parameters", ArgumentSemantic.Strong)]
		NSMutableDictionary Parameters { get; }

		// @property (readonly, copy, nonatomic) NSString * tokenString;
		[Export ("tokenString", ArgumentSemantic.Copy)]
		string TokenString { get; }

		// @property (readonly, copy, nonatomic) NSString * graphPath;
		[Export ("graphPath", ArgumentSemantic.Copy)]
		string GraphPath { get; }

		// @property (readonly, copy, nonatomic) NSString * HTTPMethod;
		[Export ("HTTPMethod", ArgumentSemantic.Copy)]
		string HTTPMethod { get; }

		// @property (readonly, copy, nonatomic) NSString * version;
		[Export ("version", ArgumentSemantic.Copy)]
		string Version { get; }

		// -(void)setGraphErrorRecoveryDisabled:(BOOL)disable;
		[Export ("setGraphErrorRecoveryDisabled:")]
		void SetGraphErrorRecoveryDisabled (bool disable);

		// -(FBSDKGraphRequestConnection *)startWithCompletionHandler:(FBSDKGraphRequestHandler)handler;
		[Export ("startWithCompletionHandler:")]
		GraphRequestConnection Start (GraphRequestHandler handler);
	}

	// typedef void (^FBSDKGraphRequestHandler)(FBSDKGraphRequestConnection *id, NSError *);
	delegate void GraphRequestHandler (GraphRequestConnection connection, NSObject result, NSError error);

	interface IGraphRequestConnectionDelegate {

	}

	// @protocol FBSDKGraphRequestConnectionDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKGraphRequestConnectionDelegate")]
	interface GraphRequestConnectionDelegate {

		// @optional -(void)requestConnectionWillBeginLoading:(FBSDKGraphRequestConnection *)connection;
		[EventArgs ("GraphRequestConnectionWillBeginLoading")]
		[Export ("requestConnectionWillBeginLoading:")]
		void WillBeginLoading (GraphRequestConnection connection);

		// @optional -(void)requestConnectionDidFinishLoading:(FBSDKGraphRequestConnection *)connection;
		[EventArgs ("GraphRequestConnectionLoadingFinished")]
		[EventName ("LoadingFinished")]
		[Export ("requestConnectionDidFinishLoading:")]
		void DidFinishLoading (GraphRequestConnection connection);

		// @optional -(void)requestConnection:(FBSDKGraphRequestConnection *)connection didFailWithError:(NSError *)error;
		[EventArgs ("GraphRequestConnectionFailed")]
		[EventName ("Failed")]
		[Export ("requestConnection:didFailWithError:")]
		void DidFail (GraphRequestConnection connection, NSError error);

		// @optional -(void)requestConnection:(FBSDKGraphRequestConnection *)connection didSendBodyData:(NSInteger)bytesWritten totalBytesWritten:(NSInteger)totalBytesWritten totalBytesExpectedToWrite:(NSInteger)totalBytesExpectedToWrite;
		[EventArgs ("GraphRequestConnectionBodyDataSent")]
		[EventName ("BodyDataSent")]
		[Export ("requestConnection:didSendBodyData:totalBytesWritten:totalBytesExpectedToWrite:")]
		void DidSendBodyData (GraphRequestConnection connection, nint bytesWritten, nint totalBytesWritten, nint totalBytesExpectedToWrite);
	}

	// @interface FBSDKGraphRequestConnection : NSObject
	[BaseType (typeof (NSObject),
		Name = "FBSDKGraphRequestConnection",
		Delegates = new [] { "Delegate" },
		Events = new [] { typeof (GraphRequestConnectionDelegate) })]
	interface GraphRequestConnection {

		// extern NSString *const FBSDKNonJSONResponseProperty;
		[Field ("FBSDKNonJSONResponseProperty", "__Internal")]
		NSString NonJsonResponsePropertyKey { get; }

		// @property (assign, nonatomic) id<FBSDKGraphRequestConnectionDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IGraphRequestConnectionDelegate Delegate { get; set; }

		// @property (nonatomic) NSTimeInterval timeout;
		[Export ("timeout")]
		double Timeout { get; set; }

		// @property (readonly, retain, nonatomic) NSHTTPURLResponse * URLResponse;
		[Export ("URLResponse", ArgumentSemantic.Retain)]
		NSHttpUrlResponse UrlResponse { get; }

		// + (void)setDefaultConnectionTimeout:(NSTimeInterval)defaultConnectionTimeout;
		[Static]
		[Export ("setDefaultConnectionTimeout:")]
		void SetDefaultConnectionTimeout (double defaultConnectionTimeout);

		// -(void)addRequest:(FBSDKGraphRequest *)request completionHandler:(FBSDKGraphRequestHandler)handler;
		[Export ("addRequest:completionHandler:")]
		void AddRequest (GraphRequest request, [NullAllowed] GraphRequestHandler handler);

		// -(void)addRequest:(FBSDKGraphRequest *)request completionHandler:(FBSDKGraphRequestHandler)handler batchEntryName:(NSString *)name;
		[Export ("addRequest:completionHandler:batchEntryName:")]
		void AddRequest (GraphRequest request, [NullAllowed] GraphRequestHandler handler, string name);

		// -(void)addRequest:(FBSDKGraphRequest *)request completionHandler:(FBSDKGraphRequestHandler)handler batchParameters:(NSDictionary *)batchParameters;
		[Export ("addRequest:completionHandler:batchParameters:")]
		void AddRequest (GraphRequest request, [NullAllowed] GraphRequestHandler handler, [NullAllowed] NSDictionary batchParameters);

		// -(void)cancel;
		[Export ("cancel")]
		void Cancel ();

		// -(void)start;
		[Export ("start")]
		void Start ();

		// -(void)setDelegateQueue:(NSOperationQueue *)queue;
		[Export ("setDelegateQueue:")]
		void SetDelegateQueue (NSOperationQueue queue);

		// -(void)overrideVersionPartWith:(NSString *)version;
		[Export ("overrideVersionPartWith:")]
		void OverrideVersionPart (string version);
	}

	// @interface FBSDKGraphRequestDataAttachment : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKGraphRequestDataAttachment")]
	interface GraphRequestDataAttachment {
		// -(instancetype)initWithData:(NSData *)data filename:(NSString *)filename contentType:(NSString *)contentType __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithData:filename:contentType:")]
		IntPtr Constructor ([NullAllowed] NSData data, string filename, string contentType);

		// @property (readonly, copy, nonatomic) NSString * contentType;
		[Export ("contentType", ArgumentSemantic.Copy)]
		string ContentType { get; }

		// @property (readonly, nonatomic, strong) NSData * data;
		[Export ("data", ArgumentSemantic.Strong)]
		NSData Data { get; }

		// @property (readonly, copy, nonatomic) NSString * filename;
		[Export ("filename", ArgumentSemantic.Copy)]
		string Filename { get; }
	}

	// @protocol FBSDKMutableCopying <FBSDKCopying, NSMutableCopying>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKMutableCopying")]
	interface MutableCopying : Copying, INSMutableCopying {

		// @required -(id)mutableCopy;
		[New]
		[Abstract]
		[Export ("mutableCopy")]
		NSObject MutableCopy ();
	}

	interface ProfileDidChangeEventArgs {
		[Export ("FBSDKProfileChangeOldKey")]
		Profile OldProfile { get; }

		[Export ("FBSDKProfileChangeNewKey")]
		Profile NewProfile { get; }
	}

	// void(^)(FBSDKProfile *profile, NSError *error))completion
	delegate void ProfileLoadCurrentProfileHandler (Profile profile, NSError error);

	// @interface FBSDKProfile : NSObject <NSCopying, NSSecureCoding>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKProfile")]
	interface Profile : INSCopying, INSSecureCoding {

		// extern NSString *const FBSDKProfileDidChangeNotification;
		[Notification (typeof (ProfileDidChangeEventArgs))]
		[Field ("FBSDKProfileDidChangeNotification", "__Internal")]
		NSString DidChangeNotification { get; }

		[Field ("FBSDKProfileChangeOldKey", "__Internal")]
		NSString OldProfileKey { get; }

		[Field ("FBSDKProfileChangeNewKey", "__Internal")]
		NSString NewProfileKey { get; }

		// -(instancetype)initWithUserID:(NSString *)userID firstName:(NSString *)firstName middleName:(NSString *)middleName lastName:(NSString *)lastName name:(NSString *)name linkURL:(NSURL *)linkURL refreshDate:(NSDate *)refreshDate __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithUserID:firstName:middleName:lastName:name:linkURL:refreshDate:")]
		IntPtr Constructor (string userID, string firstName, string middleName, string lastName, string name, [NullAllowed] NSUrl linkUrl, [NullAllowed] NSDate refreshDate);

		// @property (readonly, nonatomic) NSString * userID;
		[Export ("userID")]
		string UserID { get; }

		// @property (readonly, nonatomic) NSString * firstName;
		[Export ("firstName")]
		string FirstName { get; }

		// @property (readonly, nonatomic) NSString * middleName;
		[Export ("middleName")]
		string MiddleName { get; }

		// @property (readonly, nonatomic) NSString * lastName;
		[Export ("lastName")]
		string LastName { get; }

		// @property (readonly, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) NSURL * linkURL;
		[Export ("linkURL")]
		NSUrl LinkUrl { get; }

		// @property (readonly, nonatomic) NSDate * refreshDate;
		[Export ("refreshDate")]
		NSDate RefreshDate { get; }

		// +(FBSDKProfile *)currentProfile;
		// +(void)setCurrentProfile:(FBSDKProfile *)profile;
		[Static]
		[Export ("currentProfile")]
		Profile CurrentProfile { get; set; }

		// +(void)enableUpdatesOnAccessTokenChange:(BOOL)enable;
		[Static]
		[Export ("enableUpdatesOnAccessTokenChange:")]
		void EnableUpdatesOnAccessTokenChange (bool enable);

		// + (void)loadCurrentProfileWithCompletion:(void(^)(FBSDKProfile *profile, NSError *error))completion;
		[Static]
		[Export ("loadCurrentProfileWithCompletion:")]
		void LoadCurrentProfile (ProfileLoadCurrentProfileHandler completion);

		// - (NSURL *)imageURLForPictureMode:(FBSDKProfilePictureMode)mode size:(CGSize)size;
		[Export ("imageURLForPictureMode:size:")]
		NSUrl ImageUrl (ProfilePictureMode mode, CGSize size);

		// -(NSString *)imagePathForPictureMode:(FBSDKProfilePictureMode)mode size:(CGSize)size;
		[Obsolete ("Use ImageUrl method instead")]
		[Export ("imagePathForPictureMode:size:")]
		string ImagePath (ProfilePictureMode mode, CGSize size);

		// -(BOOL)isEqualToProfile:(FBSDKProfile *)profile;
		[Export ("isEqualToProfile:")]
		bool IsEqualToProfile (Profile profile);
	}

	// @interface FBSDKProfilePictureView : UIView
	[BaseType (typeof (UIView), Name = "FBSDKProfilePictureView")]
	interface ProfilePictureView {
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (assign, nonatomic) FBSDKProfilePictureMode pictureMode;
		[Export ("pictureMode", ArgumentSemantic.Assign)]
		ProfilePictureMode PictureMode { get; set; }

		// @property (copy, nonatomic) NSString * profileID;
		[Export ("profileID", ArgumentSemantic.Copy)]
		string ProfileId { get; set; }

		// -(void)setNeedsImageUpdate;
		[Export ("setNeedsImageUpdate")]
		void SetNeedsImageUpdate ();
	}

	[Static]
	interface LoggingBehavior {

		// extern NSString *const FBSDKLoggingBehaviorAccessTokens;
		[Field ("FBSDKLoggingBehaviorAccessTokens", "__Internal")]
		NSString AccessTokensKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorPerformanceCharacteristics;
		[Field ("FBSDKLoggingBehaviorPerformanceCharacteristics", "__Internal")]
		NSString PerformanceCharacteristicsKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorAppEvents;
		[Field ("FBSDKLoggingBehaviorAppEvents", "__Internal")]
		NSString AppEventsKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorInformational;
		[Field ("FBSDKLoggingBehaviorInformational", "__Internal")]
		NSString InformationalKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorCacheErrors;
		[Field ("FBSDKLoggingBehaviorCacheErrors", "__Internal")]
		NSString CacheErrorsKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorUIControlErrors;
		[Field ("FBSDKLoggingBehaviorUIControlErrors", "__Internal")]
		NSString UIControlErrorsKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorGraphAPIDebugWarning;
		[Field ("FBSDKLoggingBehaviorGraphAPIDebugWarning", "__Internal")]
		NSString GraphAPIDebugWarningKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorGraphAPIDebugInfo;
		[Field ("FBSDKLoggingBehaviorGraphAPIDebugInfo", "__Internal")]
		NSString GraphAPIDebugInfoKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorNetworkRequests;
		[Field ("FBSDKLoggingBehaviorNetworkRequests", "__Internal")]
		NSString NetworkRequestsKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorDeveloperErrors;
		[Field ("FBSDKLoggingBehaviorDeveloperErrors", "__Internal")]
		NSString DeveloperErrorsKey { get; }
	}

	// @interface FBSDKSettings : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKSettings")]
	interface Settings {

		// +(NSString *)appID;
		// +(void)setAppID:(NSString *)appID;
		[Static]
		[Export ("appID")]
		string AppID { get; set; }

		// +(NSString *)appURLSchemeSuffix;
		// +(void)setAppURLSchemeSuffix:(NSString *)appURLSchemeSuffix;
		[Static]
		[Export ("appURLSchemeSuffix")]
		string AppUrlSchemeSuffix { get; set; }

		// +(NSString *)clientToken;
		// +(void)setClientToken:(NSString *)clientToken;
		[Static]
		[Export ("clientToken")]
		string ClientToken { get; set; }

		// +(void)setGraphErrorRecoveryDisabled:(BOOL)disableGraphErrorRecovery;
		[Static]
		[Export ("setGraphErrorRecoveryDisabled:")]
		void SetGraphErrorRecoveryDisabled (bool disableGraphErrorRecovery);

		// +(NSString *)displayName;
		// +(void)setDisplayName:(NSString *)displayName;
		[Static]
		[Export ("displayName")]
		string DisplayName { get; set; }

		// +(NSString *)facebookDomainPart;
		// +(void)setFacebookDomainPart:(NSString *)facebookDomainPart;
		[Static]
		[Export ("facebookDomainPart")]
		string FacebookDomainPart { get; set; }

		// +(CGFloat)JPEGCompressionQuality;
		// +(void)setJPEGCompressionQuality:(CGFloat)JPEGCompressionQuality;
		[Static]
		[Export ("JPEGCompressionQuality")]
		nfloat JpegCompressionQuality { get; set; }

		// + (NSNumber *)autoLogAppEventsEnabled;
		// + (void)setAutoLogAppEventsEnabled:(NSNumber*)AutoLogAppEventsEnabled;
		[Internal]
		[Static]
		[Export ("autoLogAppEventsEnabled")]
		NSNumber _AutoLogAppEventsEnabled { get; set; }

		// +(BOOL)limitEventAndDataUsage;
		// +(void)setLimitEventAndDataUsage:(BOOL)limitEventAndDataUsage;
		[Static]
		[Export ("limitEventAndDataUsage")]
		bool LimitEventAndDataUsage { get; set; }

		// +(NSString *)sdkVersion;
		[Static]
		[Export ("sdkVersion")]
		string SdkVersion { get; }

		// +(NSSet *)loggingBehavior;
		// +(void)setLoggingBehavior:(NSSet *)loggingBehavior;
		[Static]
		[Export ("loggingBehavior")]
		NSSet LoggingBehavior { get; set; }

		// +(void)enableLoggingBehavior:(NSString *)loggingBehavior;
		[Static]
		[Export ("enableLoggingBehavior:")]
		void EnableLoggingBehavior (string loggingBehavior);

		// +(void)disableLoggingBehavior:(NSString *)loggingBehavior;
		[Static]
		[Export ("disableLoggingBehavior:")]
		void DisableLoggingBehavior (string loggingBehavior);

		// +(NSString *)legacyUserDefaultTokenInformationKeyName;
		// +(void)setLegacyUserDefaultTokenInformationKeyName:(NSString *)tokenInformationKeyName;
		[Static]
		[Export ("legacyUserDefaultTokenInformationKeyName")]
		string LegacyUserDefaultTokenInformationKeyName { get; set; }

		// +(void)setGraphAPIVersion:(NSString *)version;
		// +(NSString *)graphAPIVersion;
		[Static]
		[Export ("graphAPIVersion")]
		string GraphAPIVersion { get; set; }
	}

	delegate void TestUsersManagerRetrieveTestAccountTokensHandler (AccessToken [] tokens, NSError error);
	delegate void TestUsersManagerRemoveTestAccountHandler (NSError error);

	// @interface FBSDKUtility : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKTestUsersManager")]
	interface TestUsersManager {

		// +(instancetype)sharedInstanceForAppID:(NSString *)appID appSecret:(NSString *)appSecret;
		[Static]
		[Export ("sharedInstanceForAppID:appSecret:")]
		TestUsersManager SharedInstance (string appID, string appSecret);

		// -(void)requestTestAccountTokensWithArraysOfPermissions:(NSArray *)arraysOfPermissions createIfNotFound:(BOOL)createIfNotFound completionHandler:(FBSDKTestUsersManagerRetrieveTestAccountTokensHandler)handler;
		[Export ("requestTestAccountTokensWithArraysOfPermissions:createIfNotFound:completionHandler:")]
		void RequestTestAccount (string [] arraysOfPermissions, bool createIfNotFound, TestUsersManagerRetrieveTestAccountTokensHandler handler);

		// -(void)addTestAccountWithPermissions:(NSSet *)permissions completionHandler:(FBSDKTestUsersManagerRetrieveTestAccountTokensHandler)handler;
		[Export ("addTestAccountWithPermissions:completionHandler:")]
		void AddTestAccount (NSSet permissions, TestUsersManagerRetrieveTestAccountTokensHandler handler);

		// -(void)removeTestAccount:(NSString *)userId completionHandler:(FBSDKTestUsersManagerRemoveTestAccountHandler)handler;
		[Export ("removeTestAccount:completionHandler:")]
		void RemoveTestAccount (string userId, TestUsersManagerRemoveTestAccountHandler handler);

		// -(void)makeFriendsWithFirst:(FBSDKAccessToken *)first second:(FBSDKAccessToken *)second callback:(void (^)(NSError *))callback;
		[Export ("makeFriendsWithFirst:second:callback:")]
		void MakeFriends (AccessToken first, AccessToken second, TestUsersManagerRemoveTestAccountHandler callback);
	}

	// @interface FBSDKUtility : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKUtility")]
	interface Utility {

		// +(NSDictionary *)dictionaryWithQueryString:(NSString *)queryString;
		[Static]
		[Export ("dictionaryWithQueryString:")]
		NSDictionary DictionaryWithQueryString (string queryString);

		// +(NSString *)queryStringWithDictionary:(NSDictionary *)dictionary error:(NSError **)errorRef;
		[Static]
		[Export ("queryStringWithDictionary:error:")]
		string QueryStringWithDictionary ([NullAllowed] NSDictionary dictionary, out NSError errorRef);

		// +(NSString *)URLDecode:(NSString *)value;
		[Static]
		[Export ("URLDecode:")]
		string UrlDecode (string value);

		// +(NSString *)URLEncode:(NSString *)value;
		[Static]
		[Export ("URLEncode:")]
		string UrlEncode (string value);

		// +(dispatch_source_t)startGCDTimerWithInterval:(double)interval block:(dispatch_block_t)block;
		[Internal]
		[Static]
		[Export ("startGCDTimerWithInterval:block:")]
		IntPtr _StartGcdTimer (double interval, Action block);

		[Static]
		[Wrap ("new DispatchSource.Timer (_StartGcdTimer (interval, block))")]
		DispatchSource StartGcdTimer (double interval, Action block);

		// +(void)stopGCDTimer:(dispatch_source_t)timer;
		[Internal]
		[Static]
		[Export ("stopGCDTimer:")]
		void _StopGcdTimer (IntPtr timer);

		[Static]
		[Wrap ("_StopGcdTimer (timer.Handle)")]
		void StopGcdTimer (DispatchSource timer);
	}

	#region Facebook.Bolts

	// This just binds what is needed to work
	[BaseType (typeof (NSObject), Name = "BFTask")]
	interface Task {

		[Export ("result", ArgumentSemantic.Strong)]
		NSObject Result { get; }

		[Export ("error", ArgumentSemantic.Strong)]
		NSError Error { get; }

		[Export ("exception", ArgumentSemantic.Strong)]
		[Obsolete ("Task exception handling is deprecated and will be removed in a future release.")]
		NSException Exception { get; }

		[Export ("isCancelled", ArgumentSemantic.Assign)]
		bool IsCancelled { get; }

		[Export ("isFaulted", ArgumentSemantic.Assign)]
		bool IsFaulted { get; }

		[Export ("isCompleted", ArgumentSemantic.Assign)]
		bool IsCompleted { get; }
	}

	interface IAppLinkResolving {

	}

	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "BFAppLinkResolving")]
	interface AppLinkResolving {

		// @required -(BFTask *)appLinkFromURLInBackground:(NSURL *)url;
		[Abstract]
		[Export ("appLinkFromURLInBackground:")]
		Task AppLinkInBackground (NSUrl url);
	}

	#endregion
}

namespace Facebook.LoginKit {
	// @interface FBSDKDeviceLoginCodeInfo : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKDeviceLoginCodeInfo")]
	interface DeviceLoginCodeInfo {
		// @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
		[Export ("identifier")]
		string Identifier { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull loginCode;
		[Export ("loginCode")]
		string LoginCode { get; }

		// @property (readonly, copy, nonatomic) NSURL * _Nonnull verificationURL;
		[Export ("verificationURL", ArgumentSemantic.Copy)]
		NSUrl VerificationUrl { get; }

		// @property (readonly, copy, nonatomic) NSDate * _Nonnull expirationDate;
		[Export ("expirationDate", ArgumentSemantic.Copy)]
		NSDate ExpirationDate { get; }

		// @property (readonly, assign, nonatomic) NSUInteger pollingInterval;
		[Export ("pollingInterval")]
		nuint PollingInterval { get; }
	}

	interface IDeviceLoginManagerDelegate { }

	// @protocol FBSDKDeviceLoginManagerDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKDeviceLoginManagerDelegate")]
	interface DeviceLoginManagerDelegate {
		// @required -(void)deviceLoginManager:(FBSDKDeviceLoginManager * _Nonnull)loginManager startedWithCodeInfo:(FBSDKDeviceLoginCodeInfo * _Nonnull)codeInfo;
		[Abstract]
		[EventArgs ("DeviceLoginManagerStarted")]
		[Export ("deviceLoginManager:startedWithCodeInfo:")]
		void Started (DeviceLoginManager loginManager, DeviceLoginCodeInfo codeInfo);

		// @required -(void)deviceLoginManager:(FBSDKDeviceLoginManager * _Nonnull)loginManager completedWithResult:(FBSDKDeviceLoginManagerResult * _Nullable)result error:(NSError * _Nullable)error;
		[Abstract]
		[EventArgs ("DeviceLoginManagerCompleted")]
		[Export ("deviceLoginManager:completedWithResult:error:")]
		void Completed (DeviceLoginManager loginManager, [NullAllowed] DeviceLoginManagerResult result, [NullAllowed] NSError error);
	}

	// @interface FBSDKDeviceLoginManager : NSObject <NSNetServiceDelegate>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject),
		   Name = "FBSDKDeviceLoginManager",
		   Delegates = new [] { "Delegate" },
	           Events = new [] { typeof (DeviceLoginManagerDelegate) })]
	interface DeviceLoginManager : INSNetServiceDelegate {
		// -(instancetype _Nonnull)initWithPermissions:(NSArray<NSString *> * _Nullable)permissions enableSmartLogin:(BOOL)enableSmartLogin __attribute__((objc_designated_initializer));
		[Export ("initWithPermissions:enableSmartLogin:")]
		[DesignatedInitializer]
		IntPtr Constructor ([NullAllowed] string [] permissions, bool enableSmartLogin);

		// @property (nonatomic, weak) id<FBSDKDeviceLoginManagerDelegate> _Nullable delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IDeviceLoginManagerDelegate Delegate { get; set; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable permissions;
		[NullAllowed, Export ("permissions", ArgumentSemantic.Copy)]
		string [] Permissions { get; }

		// @property (copy, nonatomic) NSURL * _Nullable redirectURL;
		[NullAllowed, Export ("redirectURL", ArgumentSemantic.Copy)]
		NSUrl RedirectUrl { get; set; }

		// -(void)start;
		[Export ("start")]
		void Start ();

		// -(void)cancel;
		[Export ("cancel")]
		void Cancel ();
	}

	// @interface FBSDKDeviceLoginManagerResult : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKDeviceLoginManagerResult")]
	interface DeviceLoginManagerResult {
		// @property (readonly, nonatomic, strong) FBSDKAccessToken * _Nullable accessToken;
		[NullAllowed, Export ("accessToken", ArgumentSemantic.Strong)]
		CoreKit.AccessToken AccessToken { get; }

		// @property (readonly, getter = isCancelled, assign, nonatomic) BOOL cancelled;
		[Export ("isCancelled")]
		bool IsCancelled { get; }
	}

	// @interface FBSDKLoginButton : FBSDKButton
	[BaseType (typeof (CoreKit.Button),
		Name = "FBSDKLoginButton",
		Delegates = new [] { "Delegate" },
		Events = new [] { typeof (LoginButtonDelegate) })]
	interface LoginButton {

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// extern NSString *const FBSDKLoginErrorDomain;
		[Field ("FBSDKLoginErrorDomain", "__Internal")]
		NSString ErrorDomain { get; }

		// @property (assign, nonatomic) FBSDKDefaultAudience defaultAudience;
		[Export ("defaultAudience", ArgumentSemantic.Assign)]
		DefaultAudience DefaultAudience { get; set; }

		// @property (nonatomic, weak) id<FBSDKLoginButtonDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		ILoginButtonDelegate Delegate { get; set; }

		// @property (assign, nonatomic) FBSDKLoginBehavior loginBehavior;
		[Export ("loginBehavior", ArgumentSemantic.Assign)]
		LoginBehavior LoginBehavior { get; set; }

		// @property (copy, nonatomic) NSArray * publishPermissions;
		[NullAllowed]
		[Export ("publishPermissions", ArgumentSemantic.Copy)]
		string [] PublishPermissions { get; set; }

		// @property (copy, nonatomic) NSArray * readPermissions;
		[NullAllowed]
		[Export ("readPermissions", ArgumentSemantic.Copy)]
		string [] ReadPermissions { get; set; }

		// @property (assign, nonatomic) FBSDKLoginButtonTooltipBehavior tooltipBehavior;
		[Export ("tooltipBehavior", ArgumentSemantic.Assign)]
		LoginButtonTooltipBehavior TooltipBehavior { get; set; }

		// @property (assign, nonatomic) FBSDKTooltipColorStyle tooltipColorStyle;
		[Export ("tooltipColorStyle", ArgumentSemantic.Assign)]
		TooltipColorStyle TooltipColorStyle { get; set; }
	}

	interface ILoginButtonDelegate {

	}

	// @protocol FBSDKLoginButtonDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKLoginButtonDelegate")]
	interface LoginButtonDelegate {

		// @required -(void)loginButton:(FBSDKLoginButton *)loginButton didCompleteWithResult:(FBSDKLoginManagerLoginResult *)result error:(NSError *)error;
		[Abstract]
		[EventArgs ("LoginButtonCompleted")]
		[EventName ("Completed")]
		[Export ("loginButton:didCompleteWithResult:error:")]
		void DidComplete (LoginButton loginButton, LoginManagerLoginResult result, NSError error);

		// @required -(void)loginButtonDidLogOut:(FBSDKLoginButton *)loginButton;
		[Abstract]
		[EventArgs ("LoginButtonLoggedOut")]
		[EventName ("LoggedOut")]
		[Export ("loginButtonDidLogOut:")]
		void DidLogOut (LoginButton loginButton);

		[DelegateName ("LoginButtonWillLogin")]
		[DefaultValue (true)]
		[Export ("loginButtonWillLogin:")]
		bool WillLogin (LoginButton loginButton);
	}

	// typedef void (^FBSDKLoginManagerRequestTokenHandler)(FBSDKLoginManagerLoginResult *NSError *);
	delegate void LoginManagerRequestTokenHandler (LoginManagerLoginResult result, NSError error);
	delegate void LoginManagerRenewSystemCredentialsHandler (ACAccountCredentialRenewResult credentials, NSError error);

	// @interface FBSDKLoginManager : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKLoginManager")]
	interface LoginManager {

		// @property (assign, nonatomic) FBSDKDefaultAudience defaultAudience;
		[Export ("defaultAudience", ArgumentSemantic.Assign)]
		DefaultAudience DefaultAudience { get; set; }

		// @property (assign, nonatomic) FBSDKLoginBehavior loginBehavior;
		[Export ("loginBehavior", ArgumentSemantic.Assign)]
		LoginBehavior LoginBehavior { get; set; }

		// -(void)logInWithReadPermissions:(NSArray *)permissions handler:(FBSDKLoginManagerRequestTokenHandler)handler;
		[Obsolete ("Use LogInWithReadPermissions (string[], UIViewController, LoginManagerRequestTokenHandler) method instead")]
		[Async]
		[Export ("logInWithReadPermissions:handler:")]
		void LogInWithReadPermissions ([NullAllowed] string [] permissions, LoginManagerRequestTokenHandler handler);

		// -(void)logInWithPublishPermissions:(NSArray *)permissions handler:(FBSDKLoginManagerRequestTokenHandler)handler;
		[Obsolete ("Use LogInWithPublishPermissions (string[], UIViewController, LoginManagerRequestTokenHandler) method instead")]
		[Async]
		[Export ("logInWithPublishPermissions:handler:")]
		void LogInWithPublishPermissions ([NullAllowed] string [] permissions, LoginManagerRequestTokenHandler handler);

		// - (void)logInWithReadPermissions:(NSArray *)permissions fromViewController:(UIViewController *)fromViewController handler:(FBSDKLoginManagerRequestTokenHandler)handler;
		[Async]
		[Export ("logInWithReadPermissions:fromViewController:handler:")]
		void LogInWithReadPermissions ([NullAllowed] string [] permissions, [NullAllowed] UIViewController fromViewController, LoginManagerRequestTokenHandler handler);

		// - (void)logInWithPublishPermissions:(NSArray *)permissions fromViewController:(UIViewController *)fromViewController handler:(FBSDKLoginManagerRequestTokenHandler)handler;
		[Async]
		[Export ("logInWithPublishPermissions:fromViewController:handler:")]
		void LogInWithPublishPermissions ([NullAllowed] string [] permissions, [NullAllowed] UIViewController fromViewController, LoginManagerRequestTokenHandler handler);

		// -(void)logOut;
		[Export ("logOut")]
		void LogOut ();

		// +(void)renewSystemCredentials:(void (^)(ACAccountCredentialRenewResult, NSError *))handler;
		[Static]
		[Async]
		[Export ("renewSystemCredentials:")]
		void RenewSystemCredentials (LoginManagerRenewSystemCredentialsHandler handler);
	}

	// @interface FBSDKLoginManagerLoginResult : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKLoginManagerLoginResult")]
	interface LoginManagerLoginResult {

		// @property (copy, nonatomic) FBSDKAccessToken * token;
		[NullAllowed]
		[Export ("token", ArgumentSemantic.Copy)]
		CoreKit.AccessToken Token { get; set; }

		// @property (readonly, nonatomic) BOOL isCancelled;
		[Export ("isCancelled")]
		bool IsCancelled { get; }

		// @property (copy, nonatomic) NSSet * grantedPermissions;
		[NullAllowed]
		[Export ("grantedPermissions", ArgumentSemantic.Copy)]
		NSSet GrantedPermissions { get; set; }

		// @property (copy, nonatomic) NSSet * declinedPermissions;
		[NullAllowed]
		[Export ("declinedPermissions", ArgumentSemantic.Copy)]
		NSSet DeclinedPermissions { get; set; }

		// -(instancetype)initWithToken:(FBSDKAccessToken *)token isCancelled:(BOOL)isCancelled grantedPermissions:(NSSet *)grantedPermissions declinedPermissions:(NSSet *)declinedPermissions __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithToken:isCancelled:grantedPermissions:declinedPermissions:")]
		IntPtr Constructor ([NullAllowed] CoreKit.AccessToken token, bool isCancelled, [NullAllowed] NSSet grantedPermissions, [NullAllowed] NSSet declinedPermissions);
	}

	// @interface FBSDKLoginTooltipView : FBSDKTooltipView
	[BaseType (typeof (TooltipView),
		Name = "FBSDKLoginTooltipView",
		Delegates = new [] { "Delegate" },
		Events = new [] { typeof (LoginTooltipViewDelegate) })]
	interface LoginTooltipView {

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (assign, nonatomic) id<FBSDKLoginTooltipViewDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		ILoginTooltipViewDelegate Delegate { get; set; }

		// @property (assign, nonatomic) BOOL forceDisplay;
		[Export ("forceDisplay")]
		bool ForceDisplay { get; set; }
	}

	interface ILoginTooltipViewDelegate {

	}

	// @protocol FBSDKLoginTooltipViewDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKLoginTooltipViewDelegate")]
	interface LoginTooltipViewDelegate {

		// @optional -(BOOL)loginTooltipView:(FBSDKLoginTooltipView *)view shouldAppear:(BOOL)appIsEligible;
		[DelegateName ("LoginTooltipViewShouldAppear")]
		[DefaultValue (true)]
		[Export ("loginTooltipView:shouldAppear:")]
		bool ShouldAppear (LoginTooltipView view, bool appIsEligible);

		// @optional -(void)loginTooltipViewWillAppear:(FBSDKLoginTooltipView *)view;
		[EventArgs ("LoginTooltipViewWillAppear")]
		[Export ("loginTooltipViewWillAppear:")]
		void WillAppear (LoginTooltipView view);

		// @optional -(void)loginTooltipViewWillNotAppear:(FBSDKLoginTooltipView *)view;
		[EventArgs ("LoginTooltipViewWillNotAppear")]
		[Export ("loginTooltipViewWillNotAppear:")]
		void WillNotAppear (LoginTooltipView view);
	}

	// @interface FBSDKTooltipView : UIView
	[BaseType (typeof (UIView), Name = "FBSDKTooltipView")]
	interface TooltipView {

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (assign, nonatomic) CFTimeInterval displayDuration;
		[Export ("displayDuration")]
		double DisplayDuration { get; set; }

		// @property (assign, nonatomic) FBSDKTooltipColorStyle colorStyle;
		[Export ("colorStyle", ArgumentSemantic.Assign)]
		TooltipColorStyle ColorStyle { get; set; }

		// @property (copy, nonatomic) NSString * message;
		[Export ("message", ArgumentSemantic.Copy)]
		string Message { get; set; }

		// @property (copy, nonatomic) NSString * tagline;
		[Export ("tagline", ArgumentSemantic.Copy)]
		string Tagline { get; set; }

		// -(instancetype)initWithTagline:(NSString *)tagline message:(NSString *)message colorStyle:(FBSDKTooltipColorStyle)colorStyle;
		[Export ("initWithTagline:message:colorStyle:")]
		IntPtr Constructor (string tagline, string message, TooltipColorStyle colorStyle);

		// -(void)presentFromView:(UIView *)anchorView;
		[Export ("presentFromView:")]
		void PresentFromView (UIView anchorView);

		// -(void)presentInView:(UIView *)view withArrowPosition:(CGPoint)arrowPosition direction:(FBSDKTooltipViewArrowDirection)arrowDirection;
		[Export ("presentInView:withArrowPosition:direction:")]
		void PresentInView (UIView view, CGPoint arrowPosition, TooltipViewArrowDirection arrowDirection);

		// -(void)dismiss;
		[Export ("dismiss")]
		void Dismiss ();
	}
}

namespace Facebook.MessengerShareKit {
	// @interface FBSDKMessengerBroadcastContext : FBSDKMessengerContext
	[BaseType (typeof (MessengerContext), Name = "FBSDKMessengerBroadcastContext")]
	interface MessengerBroadcastContext {

	}

	// @interface FBSDKMessengerShareButton : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKMessengerShareButton")]
	interface MessengerShareButton {

		// +(UIButton *)rectangularButtonWithStyle:(FBSDKMessengerShareButtonStyle)style;
		[Static]
		[Export ("rectangularButtonWithStyle:")]
		UIButton RectangularButton (MessengerShareButtonStyle style);

		// +(UIButton *)circularButtonWithStyle:(FBSDKMessengerShareButtonStyle)style width:(CGFloat)width;
		[Static]
		[Export ("circularButtonWithStyle:width:")]
		UIButton CircularButton (MessengerShareButtonStyle style, nfloat width);

		// +(UIButton *)circularButtonWithStyle:(FBSDKMessengerShareButtonStyle)style;
		[Static]
		[Export ("circularButtonWithStyle:")]
		UIButton CircularButton (MessengerShareButtonStyle style);
	}

	// @interface FBSDKMessengerContext : NSObject <NSSecureCoding>
	[BaseType (typeof (NSObject), Name = "FBSDKMessengerContext")]
	interface MessengerContext : INSSecureCoding {

	}

	// @interface FBSDKMessengerShareOptions : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKMessengerShareOptions")]
	interface MessengerShareOptions {

		// @property (readwrite, copy, nonatomic) NSString * metadata;
		[Export ("metadata", ArgumentSemantic.Copy)]
		string Metadata { get; set; }

		// @property (readwrite, copy, nonatomic) NSURL * sourceURL;
		[NullAllowed]
		[Export ("sourceURL", ArgumentSemantic.Copy)]
		NSUrl SourceUrl { get; set; }

		// @property (nonatomic, readwrite, assign) BOOL renderAsSticker;
		[Export ("renderAsSticker")]
		bool RenderAsSticker { get; set; }

		// @property (readwrite, nonatomic, strong) FBSDKMessengerContext * contextOverride;
		[NullAllowed]
		[Export ("contextOverride", ArgumentSemantic.Strong)]
		MessengerContext ContextOverride { get; set; }
	}

	// @interface FBSDKMessengerSharer : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKMessengerSharer")]
	interface MessengerSharer {

		// +(FBSDKMessengerPlatformCapability)messengerPlatformCapabilities;
		[Obsolete ("This is deprecated as of iOS 9. If you use this, you must configure your plist as described in https://developers.facebook.com/docs/ios/ios9")]
		[Static]
		[Export ("messengerPlatformCapabilities")]
		MessengerPlatformCapability MessengerPlatformCapabilities { get; }

		// +(void)openMessenger;
		[Static]
		[Export ("openMessenger")]
		void OpenMessenger ();

		// +(void)shareImage:(UIImage *)image withMetadata:(NSString *)metadata withContext:(FBSDKMessengerContext *)context __attribute__((deprecated("use use shareImage:withOptions: instead")));
		[Obsolete ("Use ShareImage (UIImage, MessengerShareOptions) instead")]
		[Static]
		[Export ("shareImage:withMetadata:withContext:")]
		void ShareImage ([NullAllowed] UIImage image, string metadata, [NullAllowed] MessengerContext context);

		// +(void)shareImage:(UIImage *)image withOptions:(FBSDKMessengerShareOptions *)options;
		[Static]
		[Export ("shareImage:withOptions:")]
		void ShareImage ([NullAllowed] UIImage image, [NullAllowed] MessengerShareOptions options);

		// +(void)shareAnimatedGIF:(NSData *)animatedGIFData withMetadata:(NSString *)metadata withContext:(FBSDKMessengerContext *)context __attribute__((deprecated("use use shareAnimatedGIF:withOptions: instead")));
		[Obsolete ("Use ShareAnimatedGif (NSData, MessengerShareOptions) instead")]
		[Static]
		[Export ("shareAnimatedGIF:withMetadata:withContext:")]
		void ShareAnimatedGif ([NullAllowed] NSData animatedGIFData, string metadata, [NullAllowed] MessengerContext context);

		// +(void)shareAnimatedGIF:(NSData *)animatedGIFData withOptions:(FBSDKMessengerShareOptions *)options;
		[Static]
		[Export ("shareAnimatedGIF:withOptions:")]
		void ShareAnimatedGif ([NullAllowed] NSData animatedGIFData, [NullAllowed] MessengerShareOptions options);

		// +(void)shareAnimatedWebP:(NSData *)animatedWebPData withMetadata:(NSString *)metadata withContext:(FBSDKMessengerContext *)context __attribute__((deprecated("use use shareAnimatedWebP:withOptions: instead")));
		[Obsolete ("Use ShareAnimatedWebP (NSData, MessengerShareOptions) instead")]
		[Static]
		[Export ("shareAnimatedWebP:withMetadata:withContext:")]
		void ShareAnimatedWebP ([NullAllowed] NSData animatedWebPData, string metadata, [NullAllowed] MessengerContext context);

		// +(void)shareAnimatedWebP:(NSData *)animatedWebPData withOptions:(FBSDKMessengerShareOptions *)options;
		[Static]
		[Export ("shareAnimatedWebP:withOptions:")]
		void ShareAnimatedWebP ([NullAllowed] NSData animatedWebPData, [NullAllowed] MessengerShareOptions options);

		// +(void)shareVideo:(NSData *)videoData withMetadata:(NSString *)metadata withContext:(FBSDKMessengerContext *)context __attribute__((deprecated("use use shareVideo:withOptions: instead")));
		[Obsolete ("Use ShareVideo (NSData, MessengerShareOptions) instead")]
		[Static]
		[Export ("shareVideo:withMetadata:withContext:")]
		void ShareVideo ([NullAllowed] NSData videoData, string metadata, [NullAllowed] MessengerContext context);

		// +(void)shareVideo:(NSData *)videoData withOptions:(FBSDKMessengerShareOptions *)options;
		[Static]
		[Export ("shareVideo:withOptions:")]
		void ShareVideo ([NullAllowed] NSData videoData, [NullAllowed] MessengerShareOptions options);

		// +(void)shareAudio:(NSData *)audioData withMetadata:(NSString *)metadata withContext:(FBSDKMessengerContext *)context __attribute__((deprecated("use use shareAudio:withOptions: instead")));
		[Obsolete ("Use ShareAudio (NSData, MessengerShareOptions) instead")]
		[Static]
		[Export ("shareAudio:withMetadata:withContext:")]
		void ShareAudio ([NullAllowed] NSData audioData, string metadata, [NullAllowed] MessengerContext context);

		// +(void)shareAudio:(NSData *)audioData withOptions:(FBSDKMessengerShareOptions *)options;
		[Static]
		[Export ("shareAudio:withOptions:")]
		void ShareAudio ([NullAllowed] NSData audioData, [NullAllowed] MessengerShareOptions options);
	}

	interface IMessengerUrlHandlerDelegate {

	}

	// @protocol FBSDKMessengerURLHandlerDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKMessengerURLHandlerDelegate")]
	interface MessengerUrlHandlerDelegate {

		// @optional -(void)messengerURLHandler:(FBSDKMessengerURLHandler *)messengerURLHandler didHandleReplyWithContext:(FBSDKMessengerURLHandlerReplyContext *)context;
		[EventArgs ("MessengerUrlHandlerReplyHandled")]
		[EventName ("ReplyHandled")]
		[Export ("messengerURLHandler:didHandleReplyWithContext:")]
		void DidHandleReply (MessengerUrlHandler messengerURLHandler, MessengerUrlHandlerReplyContext context);

		// @optional -(void)messengerURLHandler:(FBSDKMessengerURLHandler *)messengerURLHandler didHandleOpenFromComposerWithContext:(FBSDKMessengerURLHandlerOpenFromComposerContext *)context;
		[EventArgs ("MessengerUrlHandlerOpenHandledFromComposer")]
		[EventName ("OpenHandledFromComposer")]
		[Export ("messengerURLHandler:didHandleOpenFromComposerWithContext:")]
		void DidHandleOpenFromComposer (MessengerUrlHandler messengerURLHandler, MessengerUrlHandlerOpenFromComposerContext context);

		// @optional -(void)messengerURLHandler:(FBSDKMessengerURLHandler *)messengerURLHandler didHandleCancelWithContext:(FBSDKMessengerURLHandlerCancelContext *)context;
		[EventArgs ("MessengerUrlHandlerCancelHandled")]
		[EventName ("CancelHandled")]
		[Export ("messengerURLHandler:didHandleCancelWithContext:")]
		void DidHandleCancel (MessengerUrlHandler messengerURLHandler, MessengerUrlHandlerCancelContext context);
	}

	// @interface FBSDKMessengerURLHandler : NSObject
	[BaseType (typeof (NSObject),
		Name = "FBSDKMessengerURLHandler",
		Delegates = new [] { "Delegate" },
		Events = new [] { typeof (MessengerUrlHandlerDelegate) })]
	interface MessengerUrlHandler {

		// -(BOOL)canOpenURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication;
		[Export ("canOpenURL:sourceApplication:")]
		bool CanOpenURL (NSUrl url, string sourceApplication);

		// -(BOOL)openURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication;
		[Export ("openURL:sourceApplication:")]
		bool OpenURL (NSUrl url, string sourceApplication);

		// @property (nonatomic, weak) id<FBSDKMessengerURLHandlerDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IMessengerUrlHandlerDelegate Delegate { get; set; }
	}

	// @interface FBSDKMessengerURLHandlerCancelContext : FBSDKMessengerContext
	[BaseType (typeof (MessengerContext), Name = "FBSDKMessengerURLHandlerCancelContext")]
	interface MessengerUrlHandlerCancelContext {

	}

	// @interface FBSDKMessengerURLHandlerOpenFromComposerContext : FBSDKMessengerContext
	[DisableDefaultCtor]
	[BaseType (typeof (MessengerContext), Name = "FBSDKMessengerURLHandlerOpenFromComposerContext")]
	interface MessengerUrlHandlerOpenFromComposerContext {

		// @property (readonly, copy, nonatomic) NSString * metadata;
		[Export ("metadata", ArgumentSemantic.Copy)]
		string Metadata { get; }

		// @property (readonly, copy, nonatomic) NSSet * userIDs;
		[Export ("userIDs", ArgumentSemantic.Copy)]
		NSSet UserIDs { get; }
	}

	// @interface FBSDKMessengerURLHandlerReplyContext : FBSDKMessengerContext
	[BaseType (typeof (MessengerContext), Name = "FBSDKMessengerURLHandlerReplyContext")]
	interface MessengerUrlHandlerReplyContext {
		// @property (readonly, copy, nonatomic) NSString * metadata;
		[Export ("metadata", ArgumentSemantic.Copy)]
		string Metadata { get; }

		// @property (readonly, copy, nonatomic) NSSet * userIDs;
		[Export ("userIDs", ArgumentSemantic.Copy)]
		NSSet UserIDs { get; }
	}
}

namespace Facebook.PlacesKit {
	[Static]
	interface FieldConstants {
		// extern NSString *const FBSDKPlacesFieldKeyAbout;
		[Field ("FBSDKPlacesFieldKeyAbout", "__Internal")]
		NSString About { get; }

		// extern NSString *const FBSDKPlacesFieldKeyAppLinks;
		[Field ("FBSDKPlacesFieldKeyAppLinks", "__Internal")]
		NSString AppLinks { get; }

		// extern NSString *const FBSDKPlacesFieldKeyCategories;
		[Field ("FBSDKPlacesFieldKeyCategories", "__Internal")]
		NSString Categories { get; }

		// extern NSString *const FBSDKPlacesFieldKeyCheckins;
		[Field ("FBSDKPlacesFieldKeyCheckins", "__Internal")]
		NSString Checkins { get; }

		// extern NSString *const FBSDKPlacesFieldKeyContext;
		[Field ("FBSDKPlacesFieldKeyContext", "__Internal")]
		NSString Context { get; }

		// extern NSString *const FBSDKPlacesFieldKeyConfidence;
		[Field ("FBSDKPlacesFieldKeyConfidence", "__Internal")]
		NSString Confidence { get; }

		// extern NSString *const FBSDKPlacesFieldKeyCoverPhoto;
		[Field ("FBSDKPlacesFieldKeyCoverPhoto", "__Internal")]
		NSString CoverPhoto { get; }

		// extern NSString *const FBSDKPlacesFieldKeyDescription;
		[Field ("FBSDKPlacesFieldKeyDescription", "__Internal")]
		NSString Description { get; }

		// extern NSString *const FBSDKPlacesFieldKeyEngagement;
		[Field ("FBSDKPlacesFieldKeyEngagement", "__Internal")]
		NSString Engagement { get; }

		// TODO: This field is marked as extern in .h file but its symbol is missing
		// extern NSString *const FBSDKPlacesFieldKeyFanCount;
		//[Field ("FBSDKPlacesFieldKeyFanCount", "__Internal")]
		//NSString FanCount { get; }

		// extern NSString *const FBSDKPlacesFieldKeyHours;
		[Field ("FBSDKPlacesFieldKeyHours", "__Internal")]
		NSString Hours { get; }

		// extern NSString *const FBSDKPlacesFieldKeyIsAlwaysOpen;
		[Field ("FBSDKPlacesFieldKeyIsAlwaysOpen", "__Internal")]
		NSString IsAlwaysOpen { get; }

		// extern NSString *const FBSDKPlacesFieldKeyIsPermanentlyClosed;
		[Field ("FBSDKPlacesFieldKeyIsPermanentlyClosed", "__Internal")]
		NSString IsPermanentlyClosed { get; }

		// extern NSString *const FBSDKPlacesFieldKeyIsVerified;
		[Field ("FBSDKPlacesFieldKeyIsVerified", "__Internal")]
		NSString IsVerified { get; }

		// extern NSString *const FBSDKPlacesFieldKeyLocation;
		[Field ("FBSDKPlacesFieldKeyLocation", "__Internal")]
		NSString Location { get; }

		// extern NSString *const FBSDKPlacesFieldKeyLink;
		[Field ("FBSDKPlacesFieldKeyLink", "__Internal")]
		NSString Link { get; }

		// extern NSString *const FBSDKPlacesFieldKeyName;
		[Field ("FBSDKPlacesFieldKeyName", "__Internal")]
		NSString Name { get; }

		// extern NSString *const FBSDKPlacesFieldKeyOverallStarRating;
		[Field ("FBSDKPlacesFieldKeyOverallStarRating", "__Internal")]
		NSString OverallStarRating { get; }

		// extern NSString *const FBSDKPlacesFieldKeyParking;
		[Field ("FBSDKPlacesFieldKeyParking", "__Internal")]
		NSString Parking { get; }

		// extern NSString *const FBSDKPlacesFieldKeyPaymentOptions;
		[Field ("FBSDKPlacesFieldKeyPaymentOptions", "__Internal")]
		NSString PaymentOptions { get; }

		// extern NSString *const FBSDKPlacesFieldKeyPlaceID;
		[Field ("FBSDKPlacesFieldKeyPlaceID", "__Internal")]
		NSString PlaceId { get; }

		// extern NSString *const FBSDKPlacesFieldKeyPhone;
		[Field ("FBSDKPlacesFieldKeyPhone", "__Internal")]
		NSString Phone { get; }

		// extern NSString *const FBSDKPlacesFieldKeyPhotos;
		[Field ("FBSDKPlacesFieldKeyPhotos", "__Internal")]
		NSString Photos { get; }

		// extern NSString *const FBSDKPlacesFieldKeyPriceRange;
		[Field ("FBSDKPlacesFieldKeyPriceRange", "__Internal")]
		NSString PriceRange { get; }

		// extern NSString *const FBSDKPlacesFieldKeyProfilePhoto;
		[Field ("FBSDKPlacesFieldKeyProfilePhoto", "__Internal")]
		NSString ProfilePhoto { get; }

		// extern NSString *const FBSDKPlacesFieldKeyRatingCount;
		[Field ("FBSDKPlacesFieldKeyRatingCount", "__Internal")]
		NSString RatingCount { get; }

		// extern NSString *const FBSDKPlacesFieldKeyRestaurantServices;
		[Field ("FBSDKPlacesFieldKeyRestaurantServices", "__Internal")]
		NSString RestaurantServices { get; }

		// extern NSString *const FBSDKPlacesFieldKeyRestaurantSpecialties;
		[Field ("FBSDKPlacesFieldKeyRestaurantSpecialties", "__Internal")]
		NSString RestaurantSpecialties { get; }

		// extern NSString *const FBSDKPlacesFieldKeySingleLineAddress;
		[Field ("FBSDKPlacesFieldKeySingleLineAddress", "__Internal")]
		NSString SingleLineAddress { get; }

		// extern NSString *const FBSDKPlacesFieldKeyWebsite;
		[Field ("FBSDKPlacesFieldKeyWebsite", "__Internal")]
		NSString Website { get; }

		// extern NSString *const FBSDKPlacesFieldKeyWorkflows;
		[Field ("FBSDKPlacesFieldKeyWorkflows", "__Internal")]
		NSString Workflows { get; }
	}

	[Static]
	interface ResponseConstants {
		// extern NSString *const FBSDKPlacesResponseKeyCity;
		[Field ("FBSDKPlacesResponseKeyCity", "__Internal")]
		NSString City { get; }

		// extern NSString *const FBSDKPlacesResponseKeyCityID;
		[Field ("FBSDKPlacesResponseKeyCityID", "__Internal")]
		NSString CityId { get; }

		// extern NSString *const FBSDKPlacesResponseKeyCountry;
		[Field ("FBSDKPlacesResponseKeyCountry", "__Internal")]
		NSString Country { get; }

		// extern NSString *const FBSDKPlacesResponseKeyCountryCode;
		[Field ("FBSDKPlacesResponseKeyCountryCode", "__Internal")]
		NSString CountryCode { get; }

		// extern NSString *const FBSDKPlacesResponseKeyLatitude;
		[Field ("FBSDKPlacesResponseKeyLatitude", "__Internal")]
		NSString Latitude { get; }

		// extern NSString *const FBSDKPlacesResponseKeyLongitude;
		[Field ("FBSDKPlacesResponseKeyLongitude", "__Internal")]
		NSString Longitude { get; }

		// extern NSString *const FBSDKPlacesResponseKeyRegion;
		[Field ("FBSDKPlacesResponseKeyRegion", "__Internal")]
		NSString Region { get; }

		// extern NSString *const FBSDKPlacesResponseKeyRegionID;
		[Field ("FBSDKPlacesResponseKeyRegionID", "__Internal")]
		NSString RegionId { get; }

		// extern NSString *const FBSDKPlacesResponseKeyState;
		[Field ("FBSDKPlacesResponseKeyState", "__Internal")]
		NSString State { get; }

		// extern NSString *const FBSDKPlacesResponseKeyStreet;
		[Field ("FBSDKPlacesResponseKeyStreet", "__Internal")]
		NSString Street { get; }

		// extern NSString *const FBSDKPlacesResponseKeyZip;
		[Field ("FBSDKPlacesResponseKeyZip", "__Internal")]
		NSString Zip { get; }

		// extern NSString *const FBSDKPlacesResponseKeyMatchedCategories;
		[Field ("FBSDKPlacesResponseKeyMatchedCategories", "__Internal")]
		NSString MatchedCategories { get; }

		// extern NSString *const FBSDKPlacesResponseKeyPhotoSource;
		[Field ("FBSDKPlacesResponseKeyPhotoSource", "__Internal")]
		NSString PhotoSource { get; }

		// extern NSString *const FBSDKPlacesResponseKeyData;
		[Field ("FBSDKPlacesResponseKeyData", "__Internal")]
		NSString Data { get; }

		// extern NSString *const FBSDKPlacesResponseKeyUrl;
		[Field ("FBSDKPlacesResponseKeyUrl", "__Internal")]
		NSString Url { get; }
	}

	[Static]
	interface ParameterConstants {
		// extern NSString *const FBSDKPlacesParameterKeySummary;
		[Field ("FBSDKPlacesParameterKeySummary", "__Internal")]
		NSString Summary { get; }
	}

	[Static]
	interface SummaryConstants {
		// extern NSString *const FBSDKPlacesSummaryKeyTracking;
		[Field ("FBSDKPlacesSummaryKeyTracking", "__Internal")]
		NSString Tracking { get; }
	}

	// typedef void (^FBSDKPlaceGraphRequestCompletion)(FBSDKGraphRequest * _Nullable, CLLocation * _Nullable, NSError * _Nullable);
	delegate void PlaceGraphRequestCompletionHandler ([NullAllowed] CoreKit.GraphRequest graphRequest, [NullAllowed] CLLocation location, [NullAllowed] NSError error);

	// typedef void (^FBSDKCurrentPlaceGraphRequestCompletion)(FBSDKGraphRequest * _Nullable, NSError * _Nullable);
	delegate void CurrentPlaceGraphRequestCompletionHandler ([NullAllowed] CoreKit.GraphRequest graphRequest, [NullAllowed] NSError error);

	// @interface FBSDKPlacesManager : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKPlacesManager")]
	interface PlacesManager {
		// -(void)generatePlaceSearchRequestForSearchTerm:(NSString * _Nullable)searchTerm categories:(NSArray<NSString *> * _Nullable)categories fields:(NSArray<NSString *> * _Nullable)fields distance:(CLLocationDistance)distance cursor:(NSString * _Nullable)cursor completion:(FBSDKPlaceGraphRequestCompletion _Nonnull)completion;
		[Export ("generatePlaceSearchRequestForSearchTerm:categories:fields:distance:cursor:completion:")]
		void GeneratePlaceSearchRequest ([NullAllowed] string searchTerm, [NullAllowed] string [] categories, [NullAllowed] string [] fields, double distance, [NullAllowed] string cursor, PlaceGraphRequestCompletionHandler completion);

		// -(FBSDKGraphRequest * _Nullable)placeSearchRequestForLocation:(CLLocation * _Nullable)location searchTerm:(NSString * _Nullable)searchTerm categories:(NSArray<NSString *> * _Nullable)categories fields:(NSArray<NSString *> * _Nullable)fields distance:(CLLocationDistance)distance cursor:(NSString * _Nullable)cursor;
		[return: NullAllowed]
		[Export ("placeSearchRequestForLocation:searchTerm:categories:fields:distance:cursor:")]
		CoreKit.GraphRequest GeneratePlaceSearchRequest ([NullAllowed] CLLocation location, [NullAllowed] string searchTerm, [NullAllowed] string [] categories, [NullAllowed] string [] fields, double distance, [NullAllowed] string cursor);

		// -(void)generateCurrentPlaceRequestWithMinimumConfidenceLevel:(FBSDKPlaceLocationConfidence)minimumConfidence fields:(NSArray<NSString *> * _Nullable)fields completion:(FBSDKCurrentPlaceGraphRequestCompletion _Nonnull)completion;
		[Export ("generateCurrentPlaceRequestWithMinimumConfidenceLevel:fields:completion:")]
		void GenerateCurrentPlaceRequest (PlaceLocationConfidence minimumConfidence, [NullAllowed] string [] fields, CurrentPlaceGraphRequestCompletionHandler completion);

		// -(void)generateCurrentPlaceRequestForCurrentLocation:(CLLocation * _Nonnull)currentLocation withMinimumConfidenceLevel:(FBSDKPlaceLocationConfidence)minimumConfidence fields:(NSArray<NSString *> * _Nullable)fields completion:(FBSDKCurrentPlaceGraphRequestCompletion _Nonnull)completion;
		[Export ("generateCurrentPlaceRequestForCurrentLocation:withMinimumConfidenceLevel:fields:completion:")]
		void GenerateCurrentPlaceRequest (CLLocation currentLocation, PlaceLocationConfidence minimumConfidence, [NullAllowed] string [] fields, CurrentPlaceGraphRequestCompletionHandler completion);

		// -(FBSDKGraphRequest * _Nonnull)currentPlaceFeedbackRequestForPlaceID:(NSString * _Nonnull)placeID tracking:(NSString * _Nonnull)tracking wasHere:(BOOL)wasHere;
		[Export ("currentPlaceFeedbackRequestForPlaceID:tracking:wasHere:")]
		CoreKit.GraphRequest GenerateCurrentPlaceFeedbackRequest (string placeId, string tracking, bool wasHere);

		// -(FBSDKGraphRequest * _Nonnull)placeInfoRequestForPlaceID:(NSString * _Nonnull)placeID fields:(NSArray<NSString *> * _Nullable)fields;
		[Export ("placeInfoRequestForPlaceID:fields:")]
		CoreKit.GraphRequest GeneratePlaceInfoRequest (string placeId, [NullAllowed] string [] fields);
	}
}

namespace Facebook.ShareKit {
	// @interface FBSDKAppGroupAddDialog : NSObject
	[BaseType (typeof (NSObject),
		Name = "FBSDKAppGroupAddDialog",
		Delegates = new [] { "Delegate" },
		Events = new [] { typeof (AppGroupAddDialogDelegate) })]
	[Obsolete ("App and game groups are being deprecated. See https://developers.facebook.com/docs/games/services/game-groups for more information.")]
	interface AppGroupAddDialog {

		// +(instancetype)showWithContent:(FBSDKAppGroupContent *)content delegate:(id<FBSDKAppGroupAddDialogDelegate>)delegate;
		[Static]
		[Export ("showWithContent:delegate:")]
		[Obsolete ("App and game groups are being deprecated. See https://developers.facebook.com/docs/games/services/game-groups for more information.")]
		AppGroupAddDialog Show ([NullAllowed] AppGroupContent content, [NullAllowed] IAppGroupAddDialogDelegate aDelegate);

		// @property (nonatomic, weak) id<FBSDKAppGroupAddDialogDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		[Obsolete ("App and game groups are being deprecated. See https://developers.facebook.com/docs/games/services/game-groups for more information.")]
		IAppGroupAddDialogDelegate Delegate { get; set; }

		// @property (copy, nonatomic) FBSDKAppGroupContent * content;
		[NullAllowed]
		[Export ("content", ArgumentSemantic.Copy)]
		[Obsolete ("App and game groups are being deprecated. See https://developers.facebook.com/docs/games/services/game-groups for more information.")]
		AppGroupContent Content { get; set; }

		// -(BOOL)canShow;
		[Export ("canShow")]
		[Obsolete ("App and game groups are being deprecated. See https://developers.facebook.com/docs/games/services/game-groups for more information.")]
		bool CanShow { get; }

		// -(BOOL)show;
		[Export ("show")]
		[Obsolete ("App and game groups are being deprecated. See https://developers.facebook.com/docs/games/services/game-groups for more information.")]
		bool Show ();

		// -(BOOL)validateWithError:(NSError **)errorRef;
		[Export ("validateWithError:")]
		[Obsolete ("App and game groups are being deprecated. See https://developers.facebook.com/docs/games/services/game-groups for more information.")]
		bool Validate (out NSError error);
	}

	interface IAppGroupAddDialogDelegate {

	}

	// @protocol FBSDKAppGroupAddDialogDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKAppGroupAddDialogDelegate")]
	[Obsolete ("App and game groups are being deprecated. See https://developers.facebook.com/docs/games/services/game-groups for more information.")]
	interface AppGroupAddDialogDelegate {

		// @required -(void)appGroupAddDialog:(FBSDKAppGroupAddDialog *)appGroupAddDialog didCompleteWithResults:(NSDictionary *)results;
		[Abstract]
		[EventArgs ("AppGroupAddDialogCompleted")]
		[EventName ("Completed")]
		[Export ("appGroupAddDialog:didCompleteWithResults:")]
		[Obsolete ("App and game groups are being deprecated. See https://developers.facebook.com/docs/games/services/game-groups for more information.")]
		void DidComplete (AppGroupAddDialog appGroupAddDialog, NSDictionary results);

		// @required -(void)appGroupAddDialog:(FBSDKAppGroupAddDialog *)appGroupAddDialog didFailWithError:(NSError *)error;
		[Abstract]
		[EventArgs ("AppGroupAddDialogFailed")]
		[EventName ("Failed")]
		[Export ("appGroupAddDialog:didFailWithError:")]
		[Obsolete ("App and game groups are being deprecated. See https://developers.facebook.com/docs/games/services/game-groups for more information.")]
		void DidFail (AppGroupAddDialog appGroupAddDialog, NSError error);

		// @required -(void)appGroupAddDialogDidCancel:(FBSDKAppGroupAddDialog *)appGroupAddDialog;
		[Abstract]
		[EventArgs ("AppGroupAddDialogCancelled")]
		[EventName ("Cancelled")]
		[Export ("appGroupAddDialogDidCancel:")]
		[Obsolete ("App and game groups are being deprecated. See https://developers.facebook.com/docs/games/services/game-groups for more information.")]
		void DidCancel (AppGroupAddDialog appGroupAddDialog);
	}

	// @interface FBSDKAppGroupContent : NSObject <FBSDKCopying, NSSecureCoding>
	[BaseType (typeof (NSObject), Name = "FBSDKAppGroupContent")]
	interface AppGroupContent : CoreKit.Copying, INSSecureCoding {

		// @property (copy, nonatomic) NSString * groupDescription;
		[Export ("groupDescription", ArgumentSemantic.Copy)]
		string GroupDescription { get; set; }

		// @property (copy, nonatomic) NSString * name;
		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; set; }

		// @property (assign, nonatomic) FBSDKAppGroupPrivacy privacy;
		[Export ("privacy", ArgumentSemantic.Assign)]
		AppGroupPrivacy Privacy { get; set; }

		// -(BOOL)isEqualToAppGroupContent:(FBSDKAppGroupContent *)content;
		[Export ("isEqualToAppGroupContent:")]
		bool IsEqualToAppGroupContent (AppGroupContent content);
	}

	// @interface FBSDKAppGroupJoinDialog : NSObject
	[BaseType (typeof (NSObject),
		Name = "FBSDKAppGroupJoinDialog",
		Delegates = new [] { "Delegate" },
		Events = new [] { typeof (AppGroupJoinDialogDelegate) })]
	[Obsolete ("App and game groups are being deprecated. See https://developers.facebook.com/docs/games/services/game-groups for more information.")]
	interface AppGroupJoinDialog {

		// +(instancetype)showWithGroupID:(NSString *)groupID delegate:(id<FBSDKAppGroupJoinDialogDelegate>)delegate;
		[Static]
		[Export ("showWithGroupID:delegate:")]
		[Obsolete ("App and game groups are being deprecated. See https://developers.facebook.com/docs/games/services/game-groups for more information.")]
		AppGroupJoinDialog Show (string groupID, [NullAllowed] IAppGroupJoinDialogDelegate aDelegate);

		// @property (nonatomic, weak) id<FBSDKAppGroupJoinDialogDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		[Obsolete ("App and game groups are being deprecated. See https://developers.facebook.com/docs/games/services/game-groups for more information.")]
		IAppGroupJoinDialogDelegate Delegate { get; set; }

		// @property (copy, nonatomic) NSString * groupID;
		[Export ("groupID", ArgumentSemantic.Copy)]
		[Obsolete ("App and game groups are being deprecated. See https://developers.facebook.com/docs/games/services/game-groups for more information.")]
		string GroupID { get; set; }

		// -(BOOL)canShow;
		[Export ("canShow")]
		[Obsolete ("App and game groups are being deprecated. See https://developers.facebook.com/docs/games/services/game-groups for more information.")]
		bool CanShow { get; }

		// -(BOOL)show;
		[Export ("show")]
		[Obsolete ("App and game groups are being deprecated. See https://developers.facebook.com/docs/games/services/game-groups for more information.")]
		bool Show ();

		// -(BOOL)validateWithError:(NSError **)errorRef;
		[Export ("validateWithError:")]
		[Obsolete ("App and game groups are being deprecated. See https://developers.facebook.com/docs/games/services/game-groups for more information.")]
		bool Validate (out NSError error);
	}

	interface IAppGroupJoinDialogDelegate {

	}

	// @protocol FBSDKAppGroupJoinDialogDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKAppGroupJoinDialogDelegate")]
	[Obsolete ("App and game groups are being deprecated. See https://developers.facebook.com/docs/games/services/game-groups for more information.")]
	interface AppGroupJoinDialogDelegate {

		// @required -(void)appGroupJoinDialog:(FBSDKAppGroupJoinDialog *)appGroupJoinDialog didCompleteWithResults:(NSDictionary *)results;
		[Abstract]
		[EventArgs ("AppGroupJoinDialogCompleted")]
		[EventName ("Completed")]
		[Export ("appGroupJoinDialog:didCompleteWithResults:")]
		[Obsolete ("App and game groups are being deprecated. See https://developers.facebook.com/docs/games/services/game-groups for more information.")]
		void DidComplete (AppGroupJoinDialog appGroupJoinDialog, NSDictionary results);

		// @required -(void)appGroupJoinDialog:(FBSDKAppGroupJoinDialog *)appGroupJoinDialog didFailWithError:(NSError *)error;
		[Abstract]
		[EventArgs ("AppGroupJoinDialogFailed")]
		[EventName ("Failed")]
		[Export ("appGroupJoinDialog:didFailWithError:")]
		[Obsolete ("App and game groups are being deprecated. See https://developers.facebook.com/docs/games/services/game-groups for more information.")]
		void DidFail (AppGroupJoinDialog appGroupJoinDialog, NSError error);

		// @required -(void)appGroupJoinDialogDidCancel:(FBSDKAppGroupJoinDialog *)appGroupJoinDialog;
		[Abstract]
		[EventArgs ("AppGroupJoinDialogCancelled")]
		[EventName ("Cancelled")]
		[Export ("appGroupJoinDialogDidCancel:")]
		[Obsolete ("App and game groups are being deprecated. See https://developers.facebook.com/docs/games/services/game-groups for more information.")]
		void DidCancel (AppGroupJoinDialog appGroupJoinDialog);
	}

	// @interface FBSDKAppInviteContent : NSObject <FBSDKCopying, NSSecureCoding>
	[BaseType (typeof (NSObject), Name = "FBSDKAppInviteContent")]
	interface AppInviteContent : CoreKit.Copying, INSSecureCoding {

		// @property (copy, nonatomic) NSURL * appLinkURL;
		[NullAllowed]
		[Export ("appLinkURL", ArgumentSemantic.Copy)]
		NSUrl AppLinkURL { get; set; }

		// @property (nonatomic, copy) NSURL *appInvitePreviewImageURL;
		[NullAllowed]
		[Export ("appInvitePreviewImageURL", ArgumentSemantic.Copy)]
		NSUrl PreviewImageURL { get; set; }

		// @property (nonatomic, copy) NSString *promotionCode;
		[Export ("promotionCode")]
		string PromotionCode { get; set; }

		// @property (nonatomic, copy) NSString *promotionText;
		[Export ("promotionText")]
		string PromotionText { get; set; }

		// @property FBSDKAppInviteDestination destination;
		[Export ("destination")]
		AppInviteDestination Destination { get; set; }

		// -(BOOL)isEqualToAppInviteContent:(FBSDKAppInviteCon	tent *)content;
		[Export ("isEqualToAppInviteContent:")]
		bool IsEqualToAppInviteContent (AppInviteContent content);
	}

	// @interface FBSDKAppInviteDialog : NSObject
	[Obsolete ("App Invites no longer supported")]
	[BaseType (typeof (NSObject),
		Name = "FBSDKAppInviteDialog",
		Delegates = new [] { "Delegate" },
		Events = new [] { typeof (AppInviteDialogDelegate) })]
	interface AppInviteDialog {
		// +(instancetype)showWithContent:(FBSDKAppInviteContent *)content delegate:(id<FBSDKAppInviteDialogDelegate>)delegate;
		[Obsolete ("Use Show (UIViewController, AppInviteContent, IAppInviteDialogDelegate) method instead")]
		[Static]
		[Export ("showWithContent:delegate:")]
		AppInviteDialog Show ([NullAllowed] AppInviteContent content, [NullAllowed] IAppInviteDialogDelegate aDelegate);

		// + (instancetype)showFromViewController:(UIViewController *)viewController withContent:(FBSDKAppInviteContent *)content delegate:(id<FBSDKAppInviteDialogDelegate>)delegate;
		[Static]
		[Export ("showFromViewController:withContent:delegate:")]
		AppInviteDialog Show (UIViewController fromViewController, [NullAllowed] AppInviteContent content, [NullAllowed] IAppInviteDialogDelegate aDelegate);

		// @property (nonatomic, weak) UIViewController *fromViewController;
		[NullAllowed]
		[Export ("fromViewController", ArgumentSemantic.Weak)]
		UIViewController FromViewController { get; set; }

		// @property (nonatomic, weak) id<FBSDKAppInviteDialogDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IAppInviteDialogDelegate Delegate { get; set; }

		// @property (copy, nonatomic) FBSDKAppInviteContent * content;
		[NullAllowed]
		[Export ("content", ArgumentSemantic.Copy)]
		AppInviteContent Content { get; set; }

		// -(BOOL)canShow;
		[Export ("canShow")]
		bool CanShow { get; }

		// -(BOOL)show;
		[Export ("show")]
		bool Show ();

		// -(BOOL)validateWithError:(NSError **)errorRef;
		[Export ("validateWithError:")]
		bool Validate (out NSError error);
	}

	interface IAppInviteDialogDelegate {

	}

	// @protocol FBSDKAppInviteDialogDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKAppInviteDialogDelegate")]
	interface AppInviteDialogDelegate {

		// @required -(void)appInviteDialog:(FBSDKAppInviteDialog *)appInviteDialog didCompleteWithResults:(NSDictionary *)results;
		[Abstract]
		[EventArgs ("AppInviteDialogCompleted")]
		[EventName ("Completed")]
		[Export ("appInviteDialog:didCompleteWithResults:")]
		void DidComplete (AppInviteDialog appInviteDialog, NSDictionary results);

		// @required -(void)appInviteDialog:(FBSDKAppInviteDialog *)appInviteDialog didFailWithError:(NSError *)error;
		[Abstract]
		[EventArgs ("AppInviteDialogFailed")]
		[EventName ("Failed")]
		[Export ("appInviteDialog:didFailWithError:")]
		void DidFail (AppInviteDialog appInviteDialog, NSError error);
	}

	// @interface FBSDKCameraEffectArguments : NSObject <FBSDKCopying, NSSecureCoding>
	[BaseType (typeof (NSObject), Name = "FBSDKCameraEffectArguments")]
	interface CameraEffectArguments : CoreKit.Copying, INSSecureCoding {
		// -(void)setString:(NSString *)string forKey:(NSString *)key;
		[Export ("setString:forKey:")]
		void SetString (string aString, string key);

		// -(NSString *)stringForKey:(NSString *)key;
		[Export ("stringForKey:")]
		string GetString (string key);

		// -(void)setArray:(NSArray<NSString *> *)array forKey:(NSString *)key;
		[Export ("setArray:forKey:")]
		void SetArray (string [] array, string key);

		// -(NSArray *)arrayForKey:(NSString *)key;
		[Export ("arrayForKey:")]
		string [] GetArray (string key);
	}

	// @interface FBSDKCameraEffectTextures : NSObject <FBSDKCopying, NSSecureCoding>
	[BaseType (typeof (NSObject), Name = "FBSDKCameraEffectTextures")]
	interface CameraEffectTextures : CoreKit.Copying, INSSecureCoding {
		// -(void)setImage:(UIImage *)image forKey:(NSString *)key;
		[Export ("setImage:forKey:")]
		void SetImage (UIImage image, string key);

		// -(UIImage *)imageForKey:(NSString *)key;
		[Export ("imageForKey:")]
		UIImage GetImage (string key);
	}

	// @interface FBSDKGameRequestContent : NSObject <FBSDKCopying, NSSecureCoding>
	[BaseType (typeof (NSObject), Name = "FBSDKGameRequestContent")]
	interface GameRequestContent : CoreKit.Copying, INSSecureCoding {

		// @property (assign, nonatomic) FBSDKGameRequestActionType actionType;
		[Export ("actionType", ArgumentSemantic.Assign)]
		GameRequestActionType ActionType { get; set; }

		// -(BOOL)isEqualToGameRequestContent:(FBSDKGameRequestContent *)content;
		[Export ("isEqualToGameRequestContent:")]
		bool IsEqualToGameRequestContent (GameRequestContent content);

		// @property (copy, nonatomic) NSString * data;
		[Export ("data", ArgumentSemantic.Copy)]
		string Data { get; set; }

		// @property (assign, nonatomic) FBSDKGameRequestFilter filters;
		[Export ("filters", ArgumentSemantic.Assign)]
		GameRequestFilter Filters { get; set; }

		// @property (copy, nonatomic) NSString * message;
		[Export ("message", ArgumentSemantic.Copy)]
		string Message { get; set; }

		// @property (copy, nonatomic) NSString * objectID;
		[Export ("objectID", ArgumentSemantic.Copy)]
		string ObjectID { get; set; }

		// @property (nonatomic, copy) NSArray *recipients;
		[NullAllowed]
		[Export ("recipients", ArgumentSemantic.Copy)]
		string [] Recipients { get; set; }

		// @property (copy, nonatomic) NSArray * recipientSuggestions;
		[NullAllowed]
		[Export ("recipientSuggestions", ArgumentSemantic.Copy)]
		string [] RecipientSuggestions { get; set; }

		// @property (copy, nonatomic) NSArray * to;
		[Obsolete ("Use Recipients property instead")]
		[NullAllowed]
		[Export ("to", ArgumentSemantic.Copy)]
		string [] To { get; set; }

		// @property (copy, nonatomic) NSArray * suggestions;
		[Obsolete ("Use RecipientSuggestions property instead")]
		[NullAllowed]
		[Export ("suggestions", ArgumentSemantic.Copy)]
		string [] Suggestions { get; set; }

		// @property (copy, nonatomic) NSString * title;
		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; set; }
	}

	// @interface FBSDKGameRequestDialog : NSObject
	[BaseType (typeof (NSObject),
		Name = "FBSDKGameRequestDialog",
		Delegates = new [] { "Delegate" },
		Events = new [] { typeof (GameRequestDialogDelegate) })]
	interface GameRequestDialog {

		// +(instancetype)showWithContent:(FBSDKGameRequestContent *)content delegate:(id<FBSDKGameRequestDialogDelegate>)delegate;
		[Static]
		[Export ("showWithContent:delegate:")]
		GameRequestDialog Show ([NullAllowed] GameRequestContent content, [NullAllowed] IGameRequestDialogDelegate aDelegate);

		// @property (nonatomic, weak) id<FBSDKGameRequestDialogDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IGameRequestDialogDelegate Delegate { get; set; }

		// @property (copy, nonatomic) FBSDKGameRequestContent * content;
		[NullAllowed]
		[Export ("content", ArgumentSemantic.Copy)]
		GameRequestContent Content { get; set; }

		// @property (assign, nonatomic) BOOL frictionlessRequestsEnabled;
		[Export ("frictionlessRequestsEnabled")]
		bool FrictionlessRequestsEnabled { get; set; }

		// -(BOOL)canShow;
		[Export ("canShow")]
		bool CanShow { get; }

		// -(BOOL)show;
		[Export ("show")]
		bool Show ();

		// -(BOOL)validateWithError:(NSError **)errorRef;
		[Export ("validateWithError:")]
		bool Validate (out NSError error);
	}

	interface IGameRequestDialogDelegate {

	}

	// @protocol FBSDKGameRequestDialogDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKGameRequestDialogDelegate")]
	interface GameRequestDialogDelegate {

		// @required -(void)gameRequestDialog:(FBSDKGameRequestDialog *)gameRequestDialog didCompleteWithResults:(NSDictionary *)results;
		[Abstract]
		[EventArgs ("GameRequestDialogCompleted")]
		[EventName ("Completed")]
		[Export ("gameRequestDialog:didCompleteWithResults:")]
		void DidComplete (GameRequestDialog gameRequestDialog, NSDictionary results);

		// @required -(void)gameRequestDialog:(FBSDKGameRequestDialog *)gameRequestDialog didFailWithError:(NSError *)error;
		[Abstract]
		[EventArgs ("GameRequestDialogFailed")]
		[EventName ("Failed")]
		[Export ("gameRequestDialog:didFailWithError:")]
		void DidFail (GameRequestDialog gameRequestDialog, NSError error);

		// @required -(void)gameRequestDialogDidCancel:(FBSDKGameRequestDialog *)gameRequestDialog;
		[Abstract]
		[EventArgs ("GameRequestDialogCancelled")]
		[EventName ("Cancelled")]
		[Export ("gameRequestDialogDidCancel:")]
		void DidCancel (GameRequestDialog gameRequestDialog);
	}

	// @interface FBSDKHashtag : NSObject <FBSDKCopying, NSSecureCoding>
	[BaseType (typeof (NSObject), Name = "FBSDKHashtag")]
	interface Hashtag : CoreKit.Copying, INSSecureCoding {
		// + (instancetype)hashtagWithString:(NSString *)hashtagString;
		[Static]
		[Export ("hashtagWithString:")]
		Hashtag Create (string hashtag);

		// @property (nonatomic, readwrite, copy) NSString *stringRepresentation;
		[Export ("stringRepresentation")]
		string StringRepresentation { get; set; }

		// @property (nonatomic, readonly, assign, getter=isValid) BOOL valid;
		[Export ("valid")]
		bool Valid { [Bind ("isValid")] get; set; }

		// - (BOOL)isEqualToHashtag:(FBSDKHashtag *)hashtag;
		[Export ("isEqualToHashtag:")]
		bool Equals (Hashtag hashtag);
	}

	// @interface FBSDKLikeButton : FBSDKButton <FBSDKLiking>
	[Obsolete]
	[BaseType (typeof (CoreKit.Button), Name = "FBSDKLikeButton")]
	interface LikeButton : Liking {

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (getter = isSoundEnabled, assign, nonatomic) BOOL soundEnabled;
		[Export ("soundEnabled")]
		bool SoundEnabled { [Bind ("isSoundEnabled")] get; set; }
	}

	// @interface FBSDKLikeControl : UIControl <FBSDKLiking>
	[Obsolete]
	[BaseType (typeof (UIControl), Name = "FBSDKLikeControl")]
	interface LikeControl : Liking {

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (nonatomic, strong) UIColor * foregroundColor;
		[Export ("foregroundColor", ArgumentSemantic.Strong)]
		UIColor ForegroundColor { get; set; }

		// @property (assign, nonatomic) FBSDKLikeControlAuxiliaryPosition likeControlAuxiliaryPosition;
		[Export ("likeControlAuxiliaryPosition", ArgumentSemantic.Assign)]
		LikeControlAuxiliaryPosition LikeControlAuxiliaryPosition { get; set; }

		// @property (assign, nonatomic) FBSDKLikeControlHorizontalAlignment likeControlHorizontalAlignment;
		[Export ("likeControlHorizontalAlignment", ArgumentSemantic.Assign)]
		LikeControlHorizontalAlignment LikeControlHorizontalAlignment { get; set; }

		// @property (assign, nonatomic) FBSDKLikeControlStyle likeControlStyle;
		[Export ("likeControlStyle", ArgumentSemantic.Assign)]
		LikeControlStyle LikeControlStyle { get; set; }

		// @property (assign, nonatomic) CGFloat preferredMaxLayoutWidth;
		[Export ("preferredMaxLayoutWidth", ArgumentSemantic.Assign)]
		nfloat PreferredMaxLayoutWidth { get; set; }

		// @property (getter = isSoundEnabled, assign, nonatomic) BOOL soundEnabled;
		[Export ("soundEnabled")]
		bool SoundEnabled { [Bind ("isSoundEnabled")] get; set; }
	}

	interface ILiking {

	}

	// @protocol FBSDKLiking <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKLiking")]
	interface Liking {

		// @required @property (copy, nonatomic) NSString * objectID;
		[Export ("objectID")]
		string GetObjectId ();

		[Export ("setObjectID:")]
		void SetObjectId (string id);

		// @required @property (assign, nonatomic) FBSDKLikeObjectType objectType;
		[Export ("objectType")]
		LikeObjectType GetObjectType ();

		[Export ("setObjectType:")]
		void SetObjectType (LikeObjectType type);
	}

	// @interface FBSDKMessageDialog : NSObject <FBSDKSharingDialog>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKMessageDialog")]
	interface MessageDialog : SharingDialog {

		// +(instancetype)showWithContent:(id<FBSDKSharingContent>)content delegate:(id<FBSDKSharingDelegate>)delegate;
		[Static]
		[Export ("showWithContent:delegate:")]
		MessageDialog Show ([NullAllowed] ISharingContent content, [NullAllowed] ISharingDelegate aDelegate);
	}

	// @interface FBSDKSendButton : FBSDKButton <FBSDKSharingButton>
	[BaseType (typeof (CoreKit.Button), Name = "FBSDKSendButton")]
	interface SendButton : SharingButton {

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);
	}

	// @interface FBSDKShareAPI : NSObject <FBSDKSharing>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKShareAPI")]
	interface ShareAPI : Sharing {

		// extern NSString *const FBSDKShareErrorDomain;
		[Field ("FBSDKShareErrorDomain", "__Internal")]
		NSString ErrorDomain { get; }

		// +(instancetype)shareWithContent:(id<FBSDKSharingContent>)content delegate:(id<FBSDKSharingDelegate>)delegate;
		[Static]
		[Export ("shareWithContent:delegate:")]
		ShareAPI Share ([NullAllowed] ISharingContent content, [NullAllowed] ISharingDelegate aDelegate);

		// @property (nonatomic, copy) NSString *message;
		[Export ("message", ArgumentSemantic.Copy)]
		string Message { get; set; }

		// @property (nonatomic, copy) NSString *graphNode;
		[Export ("graphNode", ArgumentSemantic.Copy)]
		string GraphNode { get; set; }

		// @property (nonatomic, strong) FBSDKAccessToken *accessToken;
		[NullAllowed]
		[Export ("accessToken", ArgumentSemantic.Strong)]
		CoreKit.AccessToken AccessToken { get; set; }

		// -(BOOL)canShare;
		[Export ("canShare")]
		bool CanShare ();

		// -(BOOL)createOpenGraphObject:(FBSDKShareOpenGraphObject *)openGraphObject;
		[Export ("createOpenGraphObject:")]
		bool CreateOpenGraphObject (ShareOpenGraphObject openGraphObject);

		// -(BOOL)share;
		[Export ("share")]
		bool Share ();
	}

	// @interface FBSDKShareButton : FBSDKButton <FBSDKSharingButton>
	[BaseType (typeof (CoreKit.Button), Name = "FBSDKShareButton")]
	interface ShareButton : SharingButton {

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);
	}

	// @interface FBSDKShareCameraEffectContent : NSObject <FBSDKSharingContent>
	[BaseType (typeof (NSObject), Name = "FBSDKShareCameraEffectContent")]
	interface ShareCameraEffectContent : SharingContent {
		// @property (copy, nonatomic) NSString * effectID;
		[Export ("effectID")]
		string EffectId { get; set; }

		// @property (copy, nonatomic) FBSDKCameraEffectArguments * effectArguments;
		[Export ("effectArguments", ArgumentSemantic.Copy)]
		CameraEffectArguments EffectArguments { get; set; }

		// @property (copy, nonatomic) FBSDKCameraEffectTextures * effectTextures;
		[Export ("effectTextures", ArgumentSemantic.Copy)]
		CameraEffectTextures EffectTextures { get; set; }

		// -(BOOL)isEqualToShareCameraEffectContent:(FBSDKShareCameraEffectContent *)content;
		[Export ("isEqualToShareCameraEffectContent:")]
		bool Equals (ShareCameraEffectContent content);
	}

	// @interface FBSDKShareDialog : NSObject <FBSDKSharingDialog>
	[BaseType (typeof (NSObject), Name = "FBSDKShareDialog")]
	interface ShareDialog : SharingDialog {

		// +(instancetype)showFromViewController:(UIViewController *)viewController withContent:(id<FBSDKSharingContent>)content delegate:(id<FBSDKSharingDelegate>)delegate;
		[Static]
		[Export ("showFromViewController:withContent:delegate:")]
		ShareDialog Show (UIViewController viewController, [NullAllowed] ISharingContent content, [NullAllowed] ISharingDelegate aDelegate);

		// @property (nonatomic, weak) UIViewController * fromViewController;
		[NullAllowed]
		[Export ("fromViewController", ArgumentSemantic.Weak)]
		UIViewController FromViewController { get; set; }

		// @property (assign, nonatomic) FBSDKShareDialogMode mode;
		[Export ("mode", ArgumentSemantic.Assign)]
		ShareDialogMode Mode { get; set; }
	}

	// @interface FBSDKShareLinkContent : NSObject <FBSDKSharingContent>
	[BaseType (typeof (NSObject), Name = "FBSDKShareLinkContent")]
	interface ShareLinkContent : SharingContent {

		// @property (copy, nonatomic) NSString * contentDescription;
		[Obsolete ("This property is deprecated from Graph API 2.9. See https://developers.facebook.com/docs/apps/changelog#v2_9_deprecations")]
		[Export ("contentDescription")]
		string ContentDescription { get; }

		// @property (copy, nonatomic) NSString * contentTitle;
		[Obsolete ("This property is deprecated from Graph API 2.9. See https://developers.facebook.com/docs/apps/changelog#v2_9_deprecations")]
		[Export ("contentTitle")]
		string ContentTitle { get; }

		// @property (copy, nonatomic) NSURL * imageURL;
		[Obsolete ("This property is deprecated from Graph API 2.9. See https://developers.facebook.com/docs/apps/changelog#v2_9_deprecations")]
		[NullAllowed]
		[Export ("imageURL")]
		NSUrl ImageURL { get; }

		// @property (nonatomic, copy) NSString *quote;
		[Export ("quote")]
		string Quote { get; set; }

		// -(BOOL)isEqualToShareLinkContent:(FBSDKShareLinkContent *)content;
		[Export ("isEqualToShareLinkContent:")]
		bool IsEqualToShareLinkContent (ShareLinkContent content);
	}

	// @interface FBSDKShareMediaContent : NSObject <FBSDKSharingContent>
	[BaseType (typeof (NSObject), Name = "FBSDKShareMediaContent")]
	interface ShareMediaContent {
		// @property (nonatomic, copy) NSArray *media;
		[Export ("media", ArgumentSemantic.Copy)]
		NSObject [] Media { get; set; }

		// - (BOOL)isEqualToShareMediaContent:(FBSDKShareMediaContent *)content;
		[Export ("isEqualToShareMediaContent:")]
		bool Equals (ShareMediaContent content);
	}

	interface IShareMessengerActionButton { }

	// @protocol FBSDKShareMessengerActionButton <FBSDKCopying, NSSecureCoding>
	[Protocol (Name = "FBSDKShareMessengerActionButton")]
	interface ShareMessengerActionButton : CoreKit.Copying, INSSecureCoding {
		// @required @property (copy, nonatomic) NSString * title;
		[Abstract]
		[Export ("title")]
		string Title { get; set; }
	}

	// @interface FBSDKShareMessengerGenericTemplateContent : NSObject <FBSDKSharingContent>
	[BaseType (typeof (NSObject), Name = "FBSDKShareMessengerGenericTemplateContent")]
	interface ShareMessengerGenericTemplateContent : SharingContent {
		// @property (assign, nonatomic) BOOL isSharable;
		[Export ("isSharable")]
		bool IsSharable { get; set; }

		// @property (assign, nonatomic) FBSDKShareMessengerGenericTemplateImageAspectRatio imageAspectRatio;
		[Export ("imageAspectRatio", ArgumentSemantic.Assign)]
		ShareMessengerGenericTemplateImageAspectRatio ImageAspectRatio { get; set; }

		// @property (copy, nonatomic) FBSDKShareMessengerGenericTemplateElement * element;
		[Export ("element", ArgumentSemantic.Copy)]
		ShareMessengerGenericTemplateElement Element { get; set; }
	}

	// @interface FBSDKShareMessengerGenericTemplateElement : NSObject <FBSDKCopying, NSSecureCoding>
	[BaseType (typeof (NSObject), Name = "FBSDKShareMessengerGenericTemplateElement")]
	interface ShareMessengerGenericTemplateElement : CoreKit.Copying, INSSecureCoding {
		// @property (copy, nonatomic) NSString * title;
		[Export ("title")]
		string Title { get; set; }

		// @property (copy, nonatomic) NSString * subtitle;
		[Export ("subtitle")]
		string Subtitle { get; set; }

		// @property (copy, nonatomic) NSURL * imageURL;
		[Export ("imageURL", ArgumentSemantic.Copy)]
		NSUrl ImageUrl { get; set; }

		// @property (copy, nonatomic) id<FBSDKShareMessengerActionButton> defaultAction;
		[Export ("defaultAction", ArgumentSemantic.Copy)]
		IShareMessengerActionButton DefaultAction { get; set; }

		// @property (copy, nonatomic) id<FBSDKShareMessengerActionButton> button;
		[Export ("button", ArgumentSemantic.Copy)]
		IShareMessengerActionButton Button { get; set; }
	}

	// @interface FBSDKShareMessengerMediaTemplateContent : NSObject <FBSDKSharingContent>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKShareMessengerMediaTemplateContent")]
	interface ShareMessengerMediaTemplateContent : SharingContent {
		// @property (assign, nonatomic) FBSDKShareMessengerMediaTemplateMediaType mediaType;
		[Export ("mediaType", ArgumentSemantic.Assign)]
		ShareMessengerMediaTemplateMediaType MediaType { get; set; }

		// @property (readonly, copy, nonatomic) NSString * attachmentID;
		[Export ("attachmentID")]
		string AttachmentId { get; }

		// @property (readonly, copy, nonatomic) NSURL * mediaURL;
		[Export ("mediaURL", ArgumentSemantic.Copy)]
		NSUrl MediaUrl { get; }

		// @property (copy, nonatomic) id<FBSDKShareMessengerActionButton> button;
		[Export ("button", ArgumentSemantic.Copy)]
		IShareMessengerActionButton Button { get; set; }

		// -(instancetype)initWithAttachmentID:(NSString *)attachmentID;
		[Export ("initWithAttachmentID:")]
		IntPtr Constructor (string attachmentId);

		// -(instancetype)initWithMediaURL:(NSURL *)mediaURL;
		[Export ("initWithMediaURL:")]
		IntPtr Constructor (NSUrl mediaUrl);
	}

	// @interface FBSDKShareMessengerOpenGraphMusicTemplateContent : NSObject <FBSDKSharingContent>
	[BaseType (typeof (NSObject), Name = "FBSDKShareMessengerOpenGraphMusicTemplateContent")]
	interface ShareMessengerOpenGraphMusicTemplateContent : SharingContent {
		// @property (copy, nonatomic) NSURL * url;
		[Export ("url", ArgumentSemantic.Copy)]
		NSUrl Url { get; set; }

		// @property (copy, nonatomic) id<FBSDKShareMessengerActionButton> button;
		[Export ("button", ArgumentSemantic.Copy)]
		IShareMessengerActionButton Button { get; set; }
	}

	// @interface FBSDKShareMessengerURLActionButton : NSObject <FBSDKShareMessengerActionButton>
	[BaseType (typeof (NSObject), Name = "FBSDKShareMessengerURLActionButton")]
	interface ShareMessengerUrlActionButton : ShareMessengerActionButton {
		// @property (copy, nonatomic) NSURL * url;
		[Export ("url", ArgumentSemantic.Copy)]
		NSUrl Url { get; set; }

		// @property (assign, nonatomic) FBSDKShareMessengerURLActionButtonWebviewHeightRatio webviewHeightRatio;
		[Export ("webviewHeightRatio", ArgumentSemantic.Assign)]
		ShareMessengerURLActionButtonWebviewHeightRatio WebviewHeightRatio { get; set; }

		// @property (assign, nonatomic) BOOL isMessengerExtensionURL;
		[Export ("isMessengerExtensionURL")]
		bool IsMessengerExtensionUrl { get; set; }

		// @property (copy, nonatomic) NSURL * fallbackURL;
		[Export ("fallbackURL", ArgumentSemantic.Copy)]
		NSUrl FallbackUrl { get; set; }

		// @property (assign, nonatomic) BOOL shouldHideWebviewShareButton;
		[Export ("shouldHideWebviewShareButton")]
		bool ShouldHideWebviewShareButton { get; set; }
	}

	// @interface FBSDKShareOpenGraphAction : FBSDKShareOpenGraphValueContainer <FBSDKCopying, NSSecureCoding>
	[DisableDefaultCtor]
	[BaseType (typeof (ShareOpenGraphValueContainer), Name = "FBSDKShareOpenGraphAction")]
	interface ShareOpenGraphAction : CoreKit.Copying, INSSecureCoding {

		// +(instancetype)actionWithType:(NSString *)actionType object:(FBSDKShareOpenGraphObject *)object key:(NSString *)key;
		[Static]
		[Export ("actionWithType:object:key:")]
		ShareOpenGraphAction Action (string actionType, [NullAllowed] ShareOpenGraphObject graphObject, string key);

		// +(instancetype)actionWithType:(NSString *)actionType objectID:(NSString *)objectID key:(NSString *)key;
		[Static]
		[Export ("actionWithType:objectID:key:")]
		ShareOpenGraphAction Action (string actionType, string objectID, string key);

		// +(instancetype)actionWithType:(NSString *)actionType objectURL:(NSURL *)objectURL key:(NSString *)key;
		[Static]
		[Export ("actionWithType:objectURL:key:")]
		ShareOpenGraphAction Action (string actionType, [NullAllowed] NSUrl objectUrl, string key);

		// @property (copy, nonatomic) NSString * actionType;
		[Export ("actionType", ArgumentSemantic.Copy)]
		string ActionType { get; set; }

		// -(BOOL)isEqualToShareOpenGraphAction:(FBSDKShareOpenGraphAction *)action;
		[Export ("isEqualToShareOpenGraphAction:")]
		bool IsEqualToShareOpenGraphAction (ShareOpenGraphAction action);
	}

	// @interface FBSDKShareOpenGraphContent : NSObject <FBSDKSharingContent>
	[BaseType (typeof (NSObject), Name = "FBSDKShareOpenGraphContent")]
	interface ShareOpenGraphContent : SharingContent {

		// @property (copy, nonatomic) FBSDKShareOpenGraphAction * action;
		[NullAllowed]
		[Export ("action", ArgumentSemantic.Copy)]
		ShareOpenGraphAction Action { get; set; }

		// @property (copy, nonatomic) NSString * previewPropertyName;
		[Export ("previewPropertyName", ArgumentSemantic.Copy)]
		string PreviewPropertyName { get; set; }

		// -(BOOL)isEqualToShareOpenGraphContent:(FBSDKShareOpenGraphContent *)content;
		[Export ("isEqualToShareOpenGraphContent:")]
		bool IsEqualToShareOpenGraphContent (ShareOpenGraphContent content);
	}

	// @interface FBSDKShareOpenGraphObject : FBSDKShareOpenGraphValueContainer <FBSDKCopying, NSSecureCoding>
	[DisableDefaultCtor]
	[BaseType (typeof (ShareOpenGraphValueContainer), Name = "FBSDKShareOpenGraphObject")]
	interface ShareOpenGraphObject : CoreKit.Copying, INSSecureCoding {

		// +(instancetype)objectWithProperties:(NSDictionary *)properties;
		[Static]
		[Export ("objectWithProperties:")]
		ShareOpenGraphObject ObjectWithProperties ([NullAllowed] NSDictionary properties);

		// -(BOOL)isEqualToShareOpenGraphObject:(FBSDKShareOpenGraphObject *)object;
		[Export ("isEqualToShareOpenGraphObject:")]
		bool IsEqualToShareOpenGraphObject (ShareOpenGraphObject aObject);
	}

	interface IShareOpenGraphValueContaining {

	}

	delegate void ShareOpenGraphValueContainingEnumerateHandle (string key, NSObject id, ref bool stop);

	// @protocol FBSDKShareOpenGraphValueContaining <NSObject, NSSecureCoding>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKShareOpenGraphValueContaining")]
	interface ShareOpenGraphValueContaining : INSSecureCoding {

		// @required -(NSArray *)arrayForKey:(NSString *)key;
		[Abstract]
		[Export ("arrayForKey:")]
		NSObject [] ArrayForKey (string key);

		// @required -(void)enumerateKeysAndObjectsUsingBlock:(void (^)(NSString *, id, BOOL *))block;
		[Abstract]
		[Export ("enumerateKeysAndObjectsUsingBlock:")]
		unsafe void EnumerateKeysAndObjectsUsingBlock (ShareOpenGraphValueContainingEnumerateHandle handle);

		// @required -(NSEnumerator *)keyEnumerator;
		[Abstract]
		[Export ("keyEnumerator")]
		NSEnumerator KeyEnumerator ();

		// @required -(NSNumber *)numberForKey:(NSString *)key;
		[Abstract]
		[Export ("numberForKey:")]
		NSNumber NumberForKey (string key);

		// @required -(NSEnumerator *)objectEnumerator;
		[Abstract]
		[Export ("objectEnumerator")]
		NSEnumerator ObjectEnumerator ();

		// @required -(FBSDKShareOpenGraphObject *)objectForKey:(NSString *)key;
		[Abstract]
		[Export ("objectForKey:")]
		ShareOpenGraphObject ObjectForKey (string key);

		// @required -(id)objectForKeyedSubscript:(NSString *)key;
		[Abstract]
		[Export ("objectForKeyedSubscript:")]
		NSObject ObjectForKeyedSubscript (string key);

		// @required -(void)parseProperties:(NSDictionary *)properties;
		[Abstract]
		[Export ("parseProperties:")]
		void ParseProperties (NSDictionary properties);

		// @required -(FBSDKSharePhoto *)photoForKey:(NSString *)key;
		[Abstract]
		[Export ("photoForKey:")]
		SharePhoto PhotoForKey (string key);

		// @required -(void)removeObjectForKey:(NSString *)key;
		[Abstract]
		[Export ("removeObjectForKey:")]
		void RemoveObjectForKey (string key);

		// @required -(void)setArray:(NSArray *)array forKey:(NSString *)key;
		[Abstract]
		[Export ("setArray:forKey:")]
		void SetArray (NSObject [] array, string key);

		// @required -(void)setNumber:(NSNumber *)number forKey:(NSString *)key;
		[Abstract]
		[Export ("setNumber:forKey:")]
		void SetNumber (NSNumber number, string key);

		// @required -(void)setObject:(FBSDKShareOpenGraphObject *)object forKey:(NSString *)key;
		[Abstract]
		[Export ("setObject:forKey:")]
		void SetObject (ShareOpenGraphObject graphObject, string key);

		// @required -(void)setPhoto:(FBSDKSharePhoto *)photo forKey:(NSString *)key;
		[Abstract]
		[Export ("setPhoto:forKey:")]
		void SetPhoto (SharePhoto photo, string key);

		// @required -(void)setString:(NSString *)string forKey:(NSString *)key;
		[Abstract]
		[Export ("setString:forKey:")]
		void SetString (string aString, string key);

		// @required -(void)setURL:(NSURL *)URL forKey:(NSString *)key;
		[Abstract]
		[Export ("setURL:forKey:")]
		void SetURL (NSUrl Url, string key);

		// @required -(NSString *)stringForKey:(NSString *)key;
		[Abstract]
		[Export ("stringForKey:")]
		string GetString (string key);

		// @required -(NSURL *)URLForKey:(NSString *)key;
		[Abstract]
		[Export ("URLForKey:")]
		NSUrl GetUrl (string key);
	}

	// @interface FBSDKShareOpenGraphValueContainer : NSObject <FBSDKShareOpenGraphValueContaining>
	[BaseType (typeof (NSObject), Name = "FBSDKShareOpenGraphValueContainer")]
	interface ShareOpenGraphValueContainer : ShareOpenGraphValueContaining {

	}

	// @interface FBSDKSharePhoto : NSObject <FBSDKCopying, NSSecureCoding>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKSharePhoto")]
	interface SharePhoto : CoreKit.Copying, INSSecureCoding {

		// +(instancetype)photoWithImage:(UIImage *)image userGenerated:(BOOL)userGenerated;
		[Static]
		[Export ("photoWithImage:userGenerated:")]
		SharePhoto From ([NullAllowed] UIImage image, bool userGenerated);

		// +(instancetype)photoWithImageURL:(NSURL *)imageURL userGenerated:(BOOL)userGenerated;
		[Static]
		[Export ("photoWithImageURL:userGenerated:")]
		SharePhoto From ([NullAllowed] NSUrl imageURL, bool userGenerated);

		// @property (nonatomic, strong) UIImage * image;
		[NullAllowed]
		[Export ("image", ArgumentSemantic.Strong)]
		UIImage Image { get; set; }

		// @property (copy, nonatomic) NSURL * imageURL;
		[NullAllowed]
		[Export ("imageURL", ArgumentSemantic.Copy)]
		NSUrl ImageUrl { get; set; }

		// @property (getter = isUserGenerated, assign, nonatomic) BOOL userGenerated;
		[Export ("userGenerated")]
		bool UserGenerated { [Bind ("isUserGenerated")] get; set; }

		// -(BOOL)isEqualToSharePhoto:(FBSDKSharePhoto *)photo;
		[Export ("isEqualToSharePhoto:")]
		bool IsEqualToSharePhoto (SharePhoto photo);

		// @property (nonatomic, copy) NSString *caption;
		[Export ("caption", ArgumentSemantic.Copy)]
		string Caption { get; set; }
	}

	// @interface FBSDKSharePhotoContent : NSObject <FBSDKSharingContent>
	[BaseType (typeof (NSObject), Name = "FBSDKSharePhotoContent")]
	interface SharePhotoContent : SharingContent {

		// @property (copy, nonatomic) NSArray * photos;
		[NullAllowed]
		[Export ("photos", ArgumentSemantic.Copy)]
		SharePhoto [] Photos { get; set; }

		// -(BOOL)isEqualToSharePhotoContent:(FBSDKSharePhotoContent *)content;
		[Export ("isEqualToSharePhotoContent:")]
		bool IsEqualToSharePhotoContent (SharePhotoContent content);
	}

	// @interface FBSDKShareVideo : NSObject <FBSDKCopying, NSSecureCoding>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKShareVideo")]
	interface ShareVideo : CoreKit.Copying, INSSecureCoding {

		// +(instancetype)videoWithVideoURL:(NSURL *)videoURL;
		[Static]
		[Export ("videoWithVideoURL:")]
		ShareVideo From ([NullAllowed] NSUrl videoURL);

		// + (instancetype)videoWithVideoURL:(NSURL *)videoURL previewPhoto:(FBSDKSharePhoto *)previewPhoto;
		[Static]
		[Export ("videoWithVideoURL:previewPhoto:")]
		ShareVideo From ([NullAllowed] NSUrl videoURL, [NullAllowed] SharePhoto previewPhoto);

		// @property (copy, nonatomic) NSURL * videoURL;
		[NullAllowed]
		[Export ("videoURL", ArgumentSemantic.Copy)]
		NSUrl VideoUrl { get; set; }

		// @property (nonatomic, copy) FBSDKSharePhoto *previewPhoto;
		[NullAllowed]
		[Export ("previewPhoto", ArgumentSemantic.Copy)]
		SharePhoto PreviewPhoto { get; set; }

		// -(BOOL)isEqualToShareVideo:(FBSDKShareVideo *)video;
		[Export ("isEqualToShareVideo:")]
		bool IsEqualToShareVideo (ShareVideo video);
	}

	// @interface FBSDKShareVideoContent : NSObject <FBSDKSharingContent>
	[BaseType (typeof (NSObject), Name = "FBSDKShareVideoContent")]
	interface ShareVideoContent : SharingContent {

		// @property (copy, nonatomic) FBSDKSharePhoto * previewPhoto;
		[NullAllowed]
		[Export ("previewPhoto", ArgumentSemantic.Copy)]
		SharePhoto PreviewPhoto { get; set; }

		// @property (copy, nonatomic) FBSDKShareVideo * video;
		[NullAllowed]
		[Export ("video", ArgumentSemantic.Copy)]
		ShareVideo Video { get; set; }

		// -(BOOL)isEqualToShareVideoContent:(FBSDKShareVideoContent *)content;
		[Export ("isEqualToShareVideoContent:")]
		bool IsEqualToShareVideoContent (ShareVideoContent content);
	}

	interface ISharing {

	}

	// @protocol FBSDKSharing <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKSharing")]
	interface Sharing {

		// @required @property (nonatomic, weak) id<FBSDKSharingDelegate> delegate;
		[Export ("delegate")]
		ISharingDelegate GetDelegate ();

		[Export ("setDelegate:")]
		void SetDelegate ([NullAllowed] ISharingDelegate aDelegate);

		// @required @property (copy, nonatomic) id<FBSDKSharingContent> shareContent;
		[Export ("shareContent")]
		ISharingContent GetShareContent ();

		[Export ("setShareContent:")]
		void SetShareContent ([NullAllowed] ISharingContent shareContent);

		// @required @property (assign, nonatomic) BOOL shouldFailOnDataError;
		[Export ("shouldFailOnDataError")]
		bool GetShouldFailOnDataError ();

		[Export ("setShouldFailOnDataError:")]
		void SetShouldFailOnDataError (bool shouldFail);

		// @required -(BOOL)validateWithError:(NSError **)errorRef;
		[Export ("validateWithError:")]
		bool ValidateWithError (out NSError errorRef);
	}

	interface ISharingDialog {

	}

	// @protocol FBSDKSharingDialog <FBSDKSharing>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKSharingDialog")]
	interface SharingDialog : Sharing {

		// @required -(BOOL)canShow;
		[Abstract]
		[Export ("canShow")]
		bool CanShow ();

		// @required -(BOOL)show;
		[Abstract]
		[Export ("show")]
		bool Show ();
	}

	interface ISharingDelegate {

	}

	// @protocol FBSDKSharingDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKSharingDelegate")]
	interface SharingDelegate {

		// @required -(void)sharer:(id<FBSDKSharing>)sharer didCompleteWithResults:(NSDictionary *)results;
		[Abstract]
		[Export ("sharer:didCompleteWithResults:")]
		void DidComplete (ISharing sharer, NSDictionary results);

		// @required -(void)sharer:(id<FBSDKSharing>)sharer didFailWithError:(NSError *)error;
		[Abstract]
		[Export ("sharer:didFailWithError:")]
		void DidFail (ISharing sharer, NSError error);

		// @required -(void)sharerDidCancel:(id<FBSDKSharing>)sharer;
		[Abstract]
		[Export ("sharerDidCancel:")]
		void DidCancel (ISharing sharer);
	}

	interface ISharingButton {

	}

	// @protocol FBSDKSharingButton <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKSharingButton")]
	interface SharingButton {

		// @required @property (copy, nonatomic) id<FBSDKSharingContent> shareContent;
		[Export ("shareContent")]
		ISharingContent GetShareContent ();

		[Export ("setShareContent:")]
		void SetShareContent ([NullAllowed] ISharingContent shareContent);
	}

	interface ISharingContent {

	}

	// @protocol FBSDKSharingContent <FBSDKCopying, NSSecureCoding>
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKSharingContent")]
	interface SharingContent : CoreKit.Copying, INSSecureCoding {

		// @required @property (copy, nonatomic) NSURL * contentURL;
		[Abstract]
		[Export ("contentURL")]
		NSUrl GetContentUrl ();

		[Abstract]
		[Export ("setContentURL:")]
		void SetContentUrl ([NullAllowed] NSUrl url);

		// @required @property (copy, nonatomic) NSArray * peopleIDs;
		[Abstract]
		[Export ("peopleIDs")]
		string [] GetPeopleIds ();

		[Abstract]
		[Export ("setPeopleIDs:")]
		void SetPeopleIds ([NullAllowed] string [] peolpleId);

		// @required @property (copy, nonatomic) NSString * placeID;
		[Abstract]
		[Export ("placeID")]
		string GetPlaceId ();

		[Abstract]
		[Export ("setPlaceID:")]
		void SetPlaceId (string placeId);

		// @property (nonatomic, copy) FBSDKHashtag *hashtag;
		[Abstract]
		[Export ("hashtag", ArgumentSemantic.Copy)]
		Hashtag Hashtag { get; set; }

		// @required @property (copy, nonatomic) NSString * ref;
		[Abstract]
		[Export ("ref")]
		string GetRef ();

		[Abstract]
		[Export ("setRef:")]
		void SetRef (string aRef);

		// @required @property (copy, nonatomic) NSString * pageID;
		[Abstract]
		[Export ("pageID")]
		string PageId { get; set; }

		// @required @property (readonly, copy, nonatomic) NSString * shareUUID;
		[Abstract]
		[Export ("shareUUID")]
		string ShareUuid { get; }
	}
}