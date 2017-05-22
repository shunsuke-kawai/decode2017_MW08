using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using CoreBluetooth;
using CoreLocation;


namespace BeacappLibrary
{
    // @protocol JBCPManagerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface JBCPManagerDelegate
    {
        // @optional -(BOOL)manager:(JBCPManager * _Nonnull)manager shouldUpdateEvents:(NSDictionary * _Nullable)info;
        [Export("manager:shouldUpdateEvents:")]
        bool ManagerShouldUpdateEvents(JBCPManager manager, [NullAllowed] NSDictionary info);

        // @required -(void)manager:(JBCPManager * _Nonnull)manager didFinishUpdateEvents:(NSError * _Nullable)error;
        [Abstract]
        [Export("manager:didFinishUpdateEvents:")]
        void ManagerDidFinishUpdateEvents(JBCPManager manager, [NullAllowed] NSError error);

        // @required -(void)manager:(JBCPManager * _Nonnull)manager fireEvent:(NSDictionary * _Nonnull)event;
        [Abstract]
        [Export("manager:fireEvent:")]
        void ManagerFireEvent(JBCPManager manager, NSDictionary @event);

        // @optional -(void)manager:(JBCPManager * _Nonnull)manager didUpdateMonitoringStatus:(CLAuthorizationStatus)authrizationStatus peripheralState:(CBPeripheralManagerState)peripheralState;
        [Export("manager:didUpdateMonitoringStatus:peripheralState:")]
        void ManagerDidUpdateMonitoringStatus(JBCPManager manager, CLAuthorizationStatus authrizationStatus, CBPeripheralManagerState peripheralState);

        // @optional -(void)manager:(JBCPManager * _Nonnull)manager didFailWithError:(NSError * _Nullable)error;
        [Export("manager:didFailWithError:")]
        void ManagerDidFailLoadWithError(JBCPManager manager, [NullAllowed] NSError error);

        // @optional -(void)manager:(JBCPManager * _Nonnull)manager didRangedBeacon:(NSArray<CLBeacon *> * _Nullable)beacons;
        [Export("manager:didRangedBeacon:")]
        void ManagerDidRangedBeacon(JBCPManager manager, [NullAllowed] CLBeacon[] beacons);
    }

    // @interface JBCPManager : NSObject
    [BaseType(typeof(NSObject))]
    interface JBCPManager
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        JBCPManagerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<JBCPManagerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (assign, nonatomic) BOOL verboseMode;
        [Export("verboseMode")]
        bool VerboseMode { get; set; }

        // @property (readonly, assign, nonatomic) BOOL isNeedActivation;
        [Export("isNeedActivation")]
        bool IsNeedActivation { get; }

        // +(JBCPManager * _Nonnull)sharedManager;
        [Static]
        [Export("sharedManager")]
        JBCPManager SharedManager { get; }

        // +(void)setApiHostUrl:(NSString * _Nonnull)url;
        [Static]
        [Export("setApiHostUrl:")]
        void SetApiHostUrl(string url);

        // +(NSString * _Nonnull)getApiHostUrl;
        [Static]
        [Export("getApiHostUrl")]
        string ApiHostUrl { get; }

        // -(BOOL)initializeWithRequestToken:(NSString * _Nonnull)requestToken secretKey:(NSString * _Nonnull)secretKey options:(NSDictionary * _Nullable)options error:(NSError * _Nullable * _Nullable)error;
        [Export("initializeWithRequestToken:secretKey:options:error:")]
        bool InitializeWithRequestToken(string requestToken, string secretKey, [NullAllowed] NSDictionary options, [NullAllowed] out NSError error);

        // -(BOOL)startUpdateEvents:(NSError * _Nullable * _Nullable)error;
        [Export("startUpdateEvents:")]
        bool StartUpdateEvents([NullAllowed] out NSError error);

        // -(BOOL)startScan:(NSError * _Nullable * _Nullable)error;
        [Export("startScan:")]
        bool StartScan([NullAllowed] out NSError error);

        // -(BOOL)startScanWithSchedule:(JBCPEventSchedule)schedule error:(NSError * _Nullable * _Nullable)error;
        [Export("startScanWithSchedule:error:")]
        bool StartScanWithSchedule(JBCPEventSchedule schedule, [NullAllowed] out NSError error);

        // -(BOOL)startScanWithSchedule:(JBCPEventSchedule)schedule withRanging:(BOOL)ranging error:(NSError * _Nullable * _Nullable)error;
        [Export("startScanWithSchedule:withRanging:error:")]
        bool StartScanWithSchedule(JBCPEventSchedule schedule, bool ranging, [NullAllowed] out NSError error);

        // -(BOOL)stopScan:(NSError * _Nullable * _Nullable)error;
        [Export("stopScan:")]
        bool StopScan([NullAllowed] out NSError error);

        // -(NSString * _Nullable)getDeviceIdentifier:(NSError * _Nullable * _Nullable)error;
        [Export("getDeviceIdentifier:")]
        [return: NullAllowed]
        string GetDeviceIdentifier([NullAllowed] out NSError error);

        // -(BOOL)clearActivationData;
        [Export("clearActivationData")]
        bool ClearActivationData { get; }

        // -(BOOL)setAdditionalLog:(NSString * _Nullable)value error:(NSError * _Nullable * _Nullable)error;
        [Export("setAdditionalLog:error:")]
        bool SetAdditionalLog([NullAllowed] string value, [NullAllowed] out NSError error);

        // -(BOOL)customLog:(NSString * _Nonnull)value error:(NSError * _Nullable * _Nullable)error;
        [Export("customLog:error:")]
        bool CustomLog(string value, [NullAllowed] out NSError error);
    }
}
