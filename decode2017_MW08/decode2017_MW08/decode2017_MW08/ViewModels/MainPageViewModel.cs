using decode2017_MW08.Interfaces;
using Prism.Mvvm;
using Xamarin.Forms;

namespace decode2017_MW08.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        /// <summary>
        /// Beacapp
        /// </summary>
        private readonly IBeacapp _beacapp;

        public MainPageViewModel(IBeacapp beacapp)
        {
            _beacapp = beacapp;
            if (Device.RuntimePlatform != Device.Windows && _beacapp != null)
            {
                _beacapp.eventUpdateCallback += (responseCode) =>
                {
                    if (responseCode == BeacappResponceCode.SUCCESS)
                    {
                        _beacapp.StartScan();
                    }
                };

                _beacapp.fireEventCallback += (fireEvent) => { };

                BeacappResponceCode initResponseCOde = _beacapp.InitializeBeacapp("ActivationKey", "SecretKey");
                if (initResponseCOde == BeacappResponceCode.SUCCESS)
                {
                    var result = _beacapp.updateEvent();
                }
            }
        }
    }
}
