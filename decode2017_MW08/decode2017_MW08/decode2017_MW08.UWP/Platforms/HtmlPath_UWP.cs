using decode2017_MW08.Interfaces;
using decode2017_MW08.UWP.Platforms;
using Xamarin.Forms;

[assembly: Dependency(typeof(HtmlPath_UWP))]
namespace decode2017_MW08.UWP.Platforms
{
    public class HtmlPath_UWP : IHtmlPath
    {
        public string GetHtmlPath()
        {
            return "ms-appx-web:///";
        }
    }
}
