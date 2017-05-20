using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace decode2017_MW08.Extensions
{
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(Source)) { return null; }

            if (Device.RuntimePlatform != Device.Windows)
            {
                return ImageSource.FromResource(Source);
            }
            else
            {
                var assembly = typeof(App).GetTypeInfo().Assembly;
                return ImageSource.FromResource(Source, assembly);
            }
        }
    }
}
