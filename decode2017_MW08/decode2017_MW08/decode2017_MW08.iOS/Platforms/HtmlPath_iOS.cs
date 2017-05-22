using Foundation;
using decode2017_MW08.Interfaces;
using Xamarin.Forms;
using decode2017_MW08.iOS.Platforms;

[assembly: Dependency(typeof(HtmlPath_iOS))]
namespace decode2017_MW08.iOS.Platforms
{
    public class HtmlPath_iOS : IHtmlPath
    {
        public string GetHtmlPath()
        {
            return NSBundle.MainBundle.BundleUrl.ToString();
        }
    }
}