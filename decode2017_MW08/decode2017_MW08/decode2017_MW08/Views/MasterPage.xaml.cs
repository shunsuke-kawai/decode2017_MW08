using decode2017_MW08.ViewModels;
using Xamarin.Forms;

namespace decode2017_MW08.Views
{
    public partial class MasterPage : ContentPage
    {
        public MasterPage()
        {
            InitializeComponent();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await (BindingContext as PrismMasterDetailPageViewModel).NavigationPage((string)e.Item);
        }
    }
}
