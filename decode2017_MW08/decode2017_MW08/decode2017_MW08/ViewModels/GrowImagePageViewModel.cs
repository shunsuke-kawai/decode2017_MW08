using Prism.Mvvm;
using System.Windows.Input;
using Xamarin.Forms;

namespace decode2017_MW08.ViewModels
{
    public class GrowImagePageViewModel : BindableBase
    {
        public string _imgTapMsg;
        public string ImgTapMsg
        {
            get { return _imgTapMsg; }
            set { SetProperty(ref _imgTapMsg, value); }
        }

        public GrowImagePageViewModel()
        {

        }

        ICommand _imgTapCommand;
        public ICommand ImgTapCommand =>
            _imgTapCommand ?? (_imgTapCommand = new Command<string>((imgName) => dispMsgAsync(imgName)));

        private void dispMsgAsync(string imgName)
        {
            ImgTapMsg = $"{imgName}がタップされました。";
        }
    }
}
