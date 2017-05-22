using decode2017_MW08.Interfaces;
using decode2017_MW08.UWP.Platforms;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace decode2017_MW08.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new decode2017_MW08.App(new UwpInitializer()));
        }
    }

    public class UwpInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType(typeof(IBeacapp), typeof(Beacapp_UWP));
        }
    }

}
