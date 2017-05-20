using decode2017_MW08.Droid.Platforms;
using decode2017_MW08.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(HtmlPath_Droid))]
namespace decode2017_MW08.Droid.Platforms
{
    public class HtmlPath_Droid : IHtmlPath
    {
        public string GetHtmlPath()
        {
            return "file:///android_asset/";
        }
    }
}