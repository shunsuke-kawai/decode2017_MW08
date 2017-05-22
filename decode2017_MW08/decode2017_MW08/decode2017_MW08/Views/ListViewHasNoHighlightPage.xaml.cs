using Xamarin.Forms;

namespace decode2017_MW08.Views
{
    public partial class ListViewHasNoHighlightPage : ContentPage
    {
        public ListViewHasNoHighlightPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
        }
    }
}
