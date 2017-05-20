using Xamarin.Forms;

namespace decode2017_MW08.Views
{
    public partial class ListViewHasNoHightlightPage : ContentPage
    {
        public ListViewHasNoHightlightPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
        }
    }
}
