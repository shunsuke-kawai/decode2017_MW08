using decode2017_MW08.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(WebView), typeof(CustomWebViewRenderer))]
namespace decode2017_MW08.Droid.Renderers
{
    public class CustomWebViewRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (Element == null) return;

            Control.SetBackgroundColor(Element.BackgroundColor.ToAndroid());
            Control.ClearCache(true);
        }
    }
}