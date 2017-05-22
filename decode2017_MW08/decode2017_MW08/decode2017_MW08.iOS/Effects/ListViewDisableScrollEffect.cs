using decode2017_MW08.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(ListViewDisableScrollEffect), "ListViewDisableScrollEffect")]
namespace decode2017_MW08.iOS.Effects
{
    public class ListViewDisableScrollEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var listView = Control as UITableView;

            if (listView != null)
                listView.ScrollEnabled = false;
        }

        protected override void OnDetached()
        {
        }
    }
}