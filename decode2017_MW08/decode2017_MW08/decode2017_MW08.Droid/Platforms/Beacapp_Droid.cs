using decode2017_MW08.Interfaces;
using Org.Json;
using Xamarin.Forms;

namespace decode2017_MW08.Droid.Platforms
{
    public class FireEventListener : Java.Lang.Object, Com.Beacapp.IFireEventListener
    {
        public event FireEventCallback fireEventCallback;
        public void FireEvent(JSONObject p)
        {
            fireEventCallback(p.ToString());
        }

    }

    public class EventUpdateListener : Java.Lang.Object, Com.Beacapp.IUpdateEventsListener
    {
        public event EventUpdateCallback eventUpdateCallback;
        public Beacapp_Droid beacappInterfaceImpl;
        public void OnUpdateFinished(Com.Beacapp.JBCPException p0)
        {
            eventUpdateCallback(beacappInterfaceImpl.MappingResponceCode(p0.Code));
        }
        public void OnUpdateProgress(int p0, int p1)
        {
            //呼ばれない
        }

    }

    public class Beacapp_Droid : IBeacapp
    {
        //イベント更新完了
        public event EventUpdateCallback eventUpdateCallback;

        //イベント発火
        public event FireEventCallback fireEventCallback;

        private Com.Beacapp.JBCPManager manager;

        //Beacapp初期化
        public BeacappResponceCode InitializeBeacapp(string requestToken, string secretKey)
        {
            try
            {
                manager = Com.Beacapp.JBCPManager.GetManager(Forms.Context, requestToken, secretKey, null);
                FireEventListener fireEventListener = new FireEventListener();
                fireEventListener.fireEventCallback += fireEventCallback;

                EventUpdateListener eventUpdateListener = new EventUpdateListener();
                eventUpdateListener.beacappInterfaceImpl = this;
                eventUpdateListener.eventUpdateCallback += eventUpdateCallback;

                manager.UpdateEventsListener = eventUpdateListener;
                manager.FireEventListener = fireEventListener;
            }
            catch (Com.Beacapp.JBCPException e)
            {
                return MappingResponceCode(e.Code);
            }
            return MappingResponceCode(0);
        }

        //DeviceID取得
        public string GetDeviceID()
        {
            if (manager == null)
            {
                return null;
            }
            try
            {
                return manager.DeviceIdentifier;
            }
            catch (Com.Beacapp.JBCPException e)
            {
                return null;
            }
        }

        //Beacappイベント更新
        public BeacappResponceCode updateEvent()
        {
            if (manager == null)
            {
                return MappingResponceCode(1001);
            }
            try
            {
                manager.StartUpdateEvents();
            }
            catch (Com.Beacapp.JBCPException e)
            {
                return MappingResponceCode(e.Code);
            }
            return MappingResponceCode(0);
        }

        //スキャン開始
        public BeacappResponceCode StartScan()
        {
            if (manager == null)
            {
                return MappingResponceCode(1001);
            }
            try
            {
                manager.StartScan();
            }
            catch (Com.Beacapp.JBCPException e)
            {
                return MappingResponceCode(e.Code);
            }
            return MappingResponceCode(0);
        }

        //スキャン停止
        public BeacappResponceCode StopScan()
        {
            if (manager == null)
            {
                return MappingResponceCode(1001);
            }
            try
            {
                manager.StopScan();
            }
            catch (Com.Beacapp.JBCPException e)
            {
                return MappingResponceCode(e.Code);
            }
            return MappingResponceCode(0);
        }

        public BeacappResponceCode MappingResponceCode(int responce)
        {
            switch (responce)
            {
                case (int)BeacappAndroidResponceCode.SUCCESS:
                    return BeacappResponceCode.SUCCESS;
                case (int)BeacappAndroidResponceCode.INVALID_ACTIVATION_KEY:
                    return BeacappResponceCode.INVALID_ACTIVATION_KEY;
                case (int)BeacappAndroidResponceCode.NOT_INITIALIZE_YET:
                    return BeacappResponceCode.NOT_INITIALIZE_YET;
                case (int)BeacappAndroidResponceCode.DB_ERROR:
                    return BeacappResponceCode.DB_ERROR;
                case (int)BeacappAndroidResponceCode.NETWORK_ERROR:
                    return BeacappResponceCode.NETEORK_ERROR;
                case (int)BeacappAndroidResponceCode.ACCESS_TOKEN_EXPIRED:
                    return BeacappResponceCode.ACCESS_TOKEN_EXPIRED;
                case (int)BeacappAndroidResponceCode.BLUETOOTH_LE_NOT_SUPPORTED:
                    return BeacappResponceCode.NOT_SUPPOTED_BLUETOOTH;
                case (int)BeacappAndroidResponceCode.BLUETOOTH_LE_NOT_ENABLED:
                    return BeacappResponceCode.NOT_SUPPOTED_BLUETOOTH;
                case (int)BeacappAndroidResponceCode.START_SCAN_FAILED:
                    return BeacappResponceCode.CANNOT_START_SCAN;
                case (int)BeacappAndroidResponceCode.SYSTEM_ERROR:
                    return BeacappResponceCode.UNKOWN_ERROR;
                default:
                    return BeacappResponceCode.UNKOWN_ERROR;
            }
        }
    }

    //Androidのエラーマッピング用
    enum BeacappAndroidResponceCode
    {
        SUCCESS = 0,//    SUCCESS 成功
        INVALID_ACTIVATION_KEY = 1000,//      アクティベーションキーが不正
        NOT_INITIALIZE_YET = 1001,//      SDK未初期化エラー
        DB_ERROR = 1002,//        DB関連のエラー
        NETWORK_ERROR = 1003,//       ネットワークラー
        ACCESS_TOKEN_EXPIRED = 1004,//        アクセストークンの有効期限切れ
        BLUETOOTH_LE_NOT_SUPPORTED = 1005,//      Bluetoothデバイスをサポートしていない
        BLUETOOTH_LE_NOT_ENABLED = 1006,//        Bluetoothが使用不可
        START_SCAN_FAILED = 1007,//       StartScan失敗
        GPS_NOT_AUTHORIZED = 1008,// GPSの許可がない
        ILLEGAL_LOG_DATA = 1009,//ログのデータ形式あ不正
        TOO_FREQUENT_LOG = 1010,//頻繁なログ要求
        SYSTEM_ERROR = 9999,//    SYSTEM_ERROR    SDKのエラー
    }
}