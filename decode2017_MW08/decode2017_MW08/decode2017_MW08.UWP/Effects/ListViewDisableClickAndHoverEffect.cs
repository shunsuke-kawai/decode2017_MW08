using decode2017_MW08.UWP.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(ListViewDisableClickAndHoverEffect), "ListViewDisableClickAndHoverEffect")]
namespace decode2017_MW08.UWP.Effects
{
    public class ListViewDisableClickAndHoverEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var listView = Control as Windows.UI.Xaml.Controls.ListView;

            if (listView == null) { return; }

            listView.ItemContainerStyle = (Windows.UI.Xaml.Style)App.Current.Resources["DisableClickAndHoverStyle"];
        }

        protected override void OnDetached()
        {

        }
    }
}
