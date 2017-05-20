using Android.Widget;
using decode2017_MW08.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(ListViewHasNoHighlightEffect), "ListViewHasNoHighlightEffect")]
namespace decode2017_MW08.Droid.Effects
{
    class ListViewHasNoHighlightEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var listView = Control as AbsListView;

            if (listView == null) return;

            listView.SetSelector(Resource.Drawable.NoHighlightViewCellBackground);
        }

        protected override void OnDetached()
        {

        }
    }
}