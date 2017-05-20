﻿using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace decode2017_MW08.ViewModels
{
    public class PrismMasterDetailPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

        public List<string> MenuList { get; set; } = new List<string>
        {
            "MainPage",
            "ListViewHasNoHightlightPage",
            "CustomIndicatorPage",
            "GrowImagePage",
            "CustomEditorPage",
        };

        public PrismMasterDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public async Task NavigationPage(string pageName)
        {
            await _navigationService.NavigateAsync($"NavigationPage/{pageName}");
        }
    }
}
