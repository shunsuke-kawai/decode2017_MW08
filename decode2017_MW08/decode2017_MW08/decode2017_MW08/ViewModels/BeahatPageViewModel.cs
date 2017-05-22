using Plugin.Beahat.Abstractions;
using Prism.Mvvm;
using Prism.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace decode2017_MW08.ViewModels
{
    public class BeahatPageViewModel : BindableBase
    {
        /// <summary>
        /// Beahat
        /// </summary>
        private readonly IBeahat _beahat;

        /// <summary>
        /// ダイアログサービス
        /// </summary>
        private readonly IPageDialogService _pageDialogService;

        private string _uuid = "Uuid:";
        public string Uuid
        {
            get { return _uuid; }
            set { SetProperty(ref _uuid, value); }
        }

        private string _major = "Major:";
        public string Major
        {
            get { return _major; }
            set { SetProperty(ref _major, value); }
        }

        private string _minor = "Minor:";
        public string Minor
        {
            get { return _minor; }
            set { SetProperty(ref _minor, value); }
        }

        private string _txPower = "TxPower:";
        public string TxPower
        {
            get { return _txPower; }
            set { SetProperty(ref _txPower, value); }
        }

        private string _rssi = "Rssi:";
        public string Rssi
        {
            get { return _rssi; }
            set { SetProperty(ref _rssi, value); }
        }

        private string _distance = "Distance:";
        public string Distance
        {
            get { return _distance; }
            set { SetProperty(ref _distance, value); }
        }

        public BeahatPageViewModel(IPageDialogService pageDialogService, IBeahat beahat)
        {
            _pageDialogService = pageDialogService;
            _beahat = beahat;

            _beahat.AddEvent(new Guid("00000000-E919-1001-B000-001C4D7363D8"), 1, 10);
        }

        /// <summary>
        /// スタンプ探索コマンド
        /// </summary>
        ICommand _searchStampCommand;
        public ICommand SearchStampCommand =>
            _searchStampCommand ?? (_searchStampCommand = new Command(async () => await ExecuteSearchStampCommand()));

        /// <summary>
        /// スタンプ探索処理
        /// </summary>
        private async Task ExecuteSearchStampCommand()
        {
            Uuid = "Uuid:";
            Major = "Major:";
            Minor = "Minor:";
            TxPower = "TxPower:";
            Rssi = "Rssi:";
            Distance = "Distance:";

            // Bluetoothの有無確認
            if (!_beahat.BluetoothIsAvailableOnThisDevice())
            {
                await _pageDialogService.DisplayAlertAsync("", "お使いの端末は Bluetooth に対応していません。", "OK");
                return;
            }

            // Bluetoothのオンオフ確認
            if (!_beahat.BluetoothIsEnableOnThisDevice())
            {
                if (Device.RuntimePlatform == Device.Windows)
                {
                    await _pageDialogService.DisplayAlertAsync("", "Bluetooth が OFF になっています。", "OK");
                }
                else
                {
                    var isOK = await _pageDialogService.DisplayAlertAsync("", "Bluetooth が OFF になっています。\n設定画面を表示しますか？", "はい", "いいえ");
                    if (isOK)
                    {
                        _beahat.RequestUserToTurnOnBluetooth();
                    }
                }

                return;
            }

            _beahat.StartScan();

            await Task.Delay(3000);

            _beahat.StopScan();

            if (_beahat.DetectedBeaconList.Count > 0)
            {
                var getStamp = _beahat.DetectedBeaconList.FirstOrDefault();

                Uuid = "Uuid:" + getStamp.Uuid.ToString();
                Major = "Major:" + getStamp.Major.ToString();
                Minor = "Minor:" + getStamp.Minor.ToString();
                TxPower = "TxPower:" + getStamp.TxPower.ToString();
                Rssi = "Rssi:" + getStamp.Rssi.ToString();
                Distance = "Distance:" + getStamp.EstimatedDistanceMeter.ToString();
            }
            else
            {
                await _pageDialogService.DisplayAlertAsync("", "検知できませんでした。", "OK");
            }
        }
    }
}
