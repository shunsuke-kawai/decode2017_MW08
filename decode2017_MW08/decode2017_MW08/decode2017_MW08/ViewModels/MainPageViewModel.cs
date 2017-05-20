﻿using Prism.Mvvm;
using Prism.Navigation;

namespace decode2017_MW08.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title = "MainPage";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainPageViewModel()
        {

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
