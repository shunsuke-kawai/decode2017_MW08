using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace decode2017_MW08.ViewModels
{
    public class CustomIndicatorViewModel : BindableBase
    {
        private bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }


        public CustomIndicatorViewModel()
        {

        }

        /// <summary>
        /// ボタンタップコマンド
        /// </summary>
        ICommand _btnTappedCommand;
        public ICommand BtnTappedCommand =>
            _btnTappedCommand ?? (_btnTappedCommand = new Command(ExecuteBtnTappedCommand));

        /// <summary>
        /// ボタンタップ処理
        /// </summary>
        /// <returns></returns>
        public void ExecuteBtnTappedCommand()
        {
            IsBusy = !_isBusy;
        }
    }
}
