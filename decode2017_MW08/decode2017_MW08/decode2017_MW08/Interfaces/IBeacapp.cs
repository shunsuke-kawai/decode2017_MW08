namespace decode2017_MW08.Interfaces
{
    //イベント更新完了Delegate
    public delegate void EventUpdateCallback(BeacappResponceCode responseCode);

    //イベント発火Delegate
    public delegate void FireEventCallback(string fireEvent);

    public interface IBeacapp
    {
        //Beacapp初期化
        BeacappResponceCode InitializeBeacapp(string requestToken, string secretKey);

        //DeviceID取得
        string GetDeviceID();

        //Beacappイベント更新
        BeacappResponceCode updateEvent();

        //イベント更新完了
        event EventUpdateCallback eventUpdateCallback;

        //イベント発火
        event FireEventCallback fireEventCallback;

        //スキャン開始
        BeacappResponceCode StartScan();

        //スキャン停止
        BeacappResponceCode StopScan();
    }
}

public enum BeacappResponceCode
{
    SUCCESS = 0x0,  //成功
    INVALID_ACTIVATION_KEY = 0xf000,    //アクティベーションキーが不正
    NOT_INITIALIZE_YET = 0xf001,    //SDK未初期化エラー
    DB_ERROR = 0xf002,  //DB関連のエラー
    NETEORK_ERROR = 0xf003, //ネットワークラー
    ACCESS_TOKEN_EXPIRED = 0xf004,  //アクセストークンの有効期限切れ
    NOT_SUPPOTED_BLUETOOTH = 0xf005,    //Bluetoothデバイスをサポートしていない
    INVALID_SDK_VERSION = 0xf006,   //SDKバージョン違い
    NEED_DELEGATE_SET = 0xf007, //デリゲート未定義
    INVALID_BACKGROUND_RUNNING = 0xf008,    //バックグランド実行は出来ない
    INVALID_DATA = 0xf009,  //データ不整合
    CANNOT_START_LOCATION = 0xf00a, //位置情報サービスが開始できない
    CANNOT_START_SCAN = 0xf00b, //位置情報サービスが開始できない
    AWS_ERROR = 0xf00c, //AWSでエラーが発生した
    ALREADY_SCANNING = 0xf00d,  //すでにビーコンのスキャンを開始している
    NOT_SUPPOTED_PLATFORM = 0xfffe, //原因不明のエラーが発生した
    UNKOWN_ERROR = 0xffff   //原因不明のエラーが発生した
}

