using Prism.Mvvm;
using System.Windows.Input;
using Xamarin.Forms;

namespace decode2017_MW08.ViewModels
{
    public class CustomIndicatorPageViewModel : BindableBase
    {
        private bool _customIsVisible = false;
        public bool CustomIsVisible
        {
            get { return _customIsVisible; }
            set { SetProperty(ref _customIsVisible, value); }
        }

        private bool _normalIsVisible = false;
        public bool NormalIsVisible
        {
            get { return _normalIsVisible; }
            set { SetProperty(ref _normalIsVisible, value); }
        }


        public CustomIndicatorPageViewModel()
        {

        }

        ICommand _btnCustomTappedCommand;
        public ICommand BtnCustomTappedCommand =>
            _btnCustomTappedCommand ?? (_btnCustomTappedCommand = new Command(ExecuteBtnCustomTappedCommand));

        public void ExecuteBtnCustomTappedCommand()
        {
            CustomIsVisible = !_customIsVisible;
            NormalIsVisible = false;
        }

        ICommand _btnNormalTappedCommand;
        public ICommand BtnNormalTappedCommand =>
            _btnNormalTappedCommand ?? (_btnNormalTappedCommand = new Command(ExecuteBtnNormalTappedCommand));

        public void ExecuteBtnNormalTappedCommand()
        {
            NormalIsVisible = !_normalIsVisible;
            CustomIsVisible = false;
        }
    }
}
