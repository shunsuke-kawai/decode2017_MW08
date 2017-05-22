#if __IPHONE__SIMULATOR__

using System;
using decode2017_MW08.Interfaces;

public class Beacapp_iOS : IBeacapp
{
    public event EventUpdateCallback eventUpdateCallback;
    public event FireEventCallback fireEventCallback;

    public string GetDeviceID()
    {
        throw new NotImplementedException();
    }

    public BeacappResponceCode InitializeBeacapp(string requestToken, string secretKey)
    {
        return BeacappResponceCode.UNKOWN_ERROR;
    }

    public BeacappResponceCode StartScan()
    {
        throw new NotImplementedException();
    }

    public BeacappResponceCode StopScan()
    {
        throw new NotImplementedException();
    }

    public BeacappResponceCode updateEvent()
    {
        throw new NotImplementedException();
    }
}

#else
using Foundation;
using decode2017_MW08.Interfaces;

namespace JMAS.MicrosoftDeCode2017.iOS.Platforms
{
    public class JBCPManagerDelegateiOS : BeacappLibrary.JBCPManagerDelegate
    {
        public event EventUpdateCallback eventUpdateCallback;
        public event FireEventCallback fireEventCallback;
        public Beacapp_iOS beacappInterfaceImpl;
        public override void ManagerDidFinishUpdateEvents(BeacappLibrary.JBCPManager manager, NSError error)
        {
            if (error == null)
            {
                eventUpdateCallback(0);
            }
            else
            {
                eventUpdateCallback(beacappInterfaceImpl.MappingResponceCode((int)error.Code));
            }
        }

        public override void ManagerFireEvent(BeacappLibrary.JBCPManager manager, NSDictionary @event)
        {
            fireEventCallback(@event.ToString());
        }
    }

    public class Beacapp_iOS : IBeacapp
    {
        private BeacappLibrary.JBCPManager manager;
        //Beacapp初期化
        public BeacappResponceCode InitializeBeacapp(string requestToken, string secretKey)
        {
            manager = BeacappLibrary.JBCPManager.SharedManager;
            JBCPManagerDelegateiOS jBCPManagerDelegateiOS = new JBCPManagerDelegateiOS();
            jBCPManagerDelegateiOS.beacappInterfaceImpl = this;
            jBCPManagerDelegateiOS.eventUpdateCallback += eventUpdateCallback;
            jBCPManagerDelegateiOS.fireEventCallback += fireEventCallback;
            manager.Delegate = jBCPManagerDelegateiOS;
            NSError error = null;
            manager.InitializeWithRequestToken(requestToken, secretKey, null, out error);
            if (error == null)
            {
                return MappingResponceCode(0);
            }
            else
            {
                return MappingResponceCode((int)error.Code);
            }
        }

        //DeviceID取得
        public string GetDeviceID()
        {
            BeacappLibrary.JBCPManager manager = BeacappLibrary.JBCPManager.SharedManager;
            NSError error = null;
            string deviceID = manager.GetDeviceIdentifier(out error);
            if (error != null)
            {
                return deviceID;
            }
            else
            {
                return null;
            }
        }

        //Beacappイベント更新
        public BeacappResponceCode updateEvent()
        {
            BeacappLibrary.JBCPManager manager = BeacappLibrary.JBCPManager.SharedManager;
            NSError error = null;
            manager.StartUpdateEvents(out error);
            if (error == null)
            {
                return MappingResponceCode(0);
            }
            else
            {
                return MappingResponceCode((int)error.Code);
            }
        }

        //スキャン開始
        public BeacappResponceCode StartScan()
        {
            BeacappLibrary.JBCPManager manager = BeacappLibrary.JBCPManager.SharedManager;
            NSError error = null;
            manager.StartScan(out error);
            if (error == null)
            {
                return MappingResponceCode(0);
            }
            else
            {
                return MappingResponceCode((int)error.Code);
            }
        }

        //スキャン停止
        public BeacappResponceCode StopScan()
        {
            BeacappLibrary.JBCPManager manager = BeacappLibrary.JBCPManager.SharedManager;
            NSError error = null;
            manager.StopScan(out error);
            if (error == null)
            {
                return MappingResponceCode(0);
            }
            else
            {
                return MappingResponceCode((int)error.Code);
            }

        }

        public BeacappResponceCode MappingResponceCode(int responce)
        {
            switch (responce)
            {
                case (int)BeacappIOSResponceCode.JBCPCodeSuccess:
                    return BeacappResponceCode.SUCCESS;
                case (int)BeacappIOSResponceCode.JBCPCodeInvalidActivationKey:
                    return BeacappResponceCode.INVALID_ACTIVATION_KEY;
                case (int)BeacappIOSResponceCode.JBCPCodeNotInitializeYet:
                    return BeacappResponceCode.NOT_INITIALIZE_YET;
                case (int)BeacappIOSResponceCode.JBCPCodeDBError:
                    return BeacappResponceCode.DB_ERROR;
                case (int)BeacappIOSResponceCode.JBCPCodeNetworkError:
                    return BeacappResponceCode.NETEORK_ERROR;
                case (int)BeacappIOSResponceCode.JBCPCodeAccessCodeExpired:
                    return BeacappResponceCode.ACCESS_TOKEN_EXPIRED;
                case (int)BeacappIOSResponceCode.JBCPCodeNotSupportedBlutooth:
                    return BeacappResponceCode.NOT_SUPPOTED_BLUETOOTH;
                case (int)BeacappIOSResponceCode.JBCPCodeInvalidSDKVersion:
                    return BeacappResponceCode.INVALID_SDK_VERSION;
                case (int)BeacappIOSResponceCode.JBCPCodeNeedsDelegateSet:
                    return BeacappResponceCode.NEED_DELEGATE_SET;
                case (int)BeacappIOSResponceCode.JBCPCodeInvalidBackgroundRunning:
                    return BeacappResponceCode.INVALID_BACKGROUND_RUNNING;
                case (int)BeacappIOSResponceCode.JBCPCodeInvalidData:
                    return BeacappResponceCode.INVALID_DATA;
                case (int)BeacappIOSResponceCode.JBCPCodeCannotStartLocation:
                    return BeacappResponceCode.CANNOT_START_LOCATION;
                case (int)BeacappIOSResponceCode.JBCPCodeAWSError:
                    return BeacappResponceCode.AWS_ERROR;
                case (int)BeacappIOSResponceCode.JBCPCodeAlreadyScanning:
                    return BeacappResponceCode.ALREADY_SCANNING;
                case (int)BeacappIOSResponceCode.JBCPCodeUnKnownError:
                    return BeacappResponceCode.UNKOWN_ERROR;
                default:
                    return BeacappResponceCode.UNKOWN_ERROR;
            }
        }
        //イベント更新完了
        public event EventUpdateCallback eventUpdateCallback;

        //イベント発火
        public event FireEventCallback fireEventCallback;


    }

    enum BeacappIOSResponceCode
    {
        JBCPCodeSuccess = 0,    // 成功
        JBCPCodeInvalidActivationKey = 1000,    // アクティベーションキーが不正
        JBCPCodeNotInitializeYet = 1001,    // SDK未初期化エラー
        JBCPCodeDBError = 1002, // DB関連のエラー
        JBCPCodeNetworkError = 1003,    // ネットワークエラー
        JBCPCodeAccessCodeExpired = 1004,   // アクセストークンの有効期限切れ
        JBCPCodeNotSupportedBlutooth = 1005, // デバイスをサポートしていない
        JBCPCodeInvalidSDKVersion = 1006, //バージョン違い
        JBCPCodeNeedsDelegateSet = 1007, // デリゲート未定義
        JBCPCodeInvalidBackgroundRunning = 1008, //バックグラウンド実行はできない
        JBCPCodeInvalidData = 1009, // データ不整合
        JBCPCodeCannotStartLocation = 1010, // 位置情報サービスが開始できない
        JBCPCodeAWSError = 1011, // AWSでエラーが発生した
        JBCPCodeAlreadyScanning = 1012, // すでにビーコンのスキャンを開始している
        JBCPCodeUnKnownError = 9999 // UnknownError
    }
}
#endif