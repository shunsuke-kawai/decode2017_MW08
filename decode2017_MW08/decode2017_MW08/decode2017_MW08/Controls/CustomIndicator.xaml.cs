using decode2017_MW08.Interfaces;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace decode2017_MW08.Controls
{
    public partial class CustomIndicator : ContentView
    {
        private readonly string _htmlPath;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="htmlPath"></param>
        public CustomIndicator()
        {
            InitializeComponent();
            _htmlPath = DependencyService.Get<IHtmlPath>().GetHtmlPath() + "Sample_Spinner.html";
        }

        /// <summary>
        /// ソースを再読み込みする
        /// </summary>
        /// <param name="propertyName"></param>
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(IsVisible))
            {
                webView.Source = IsVisible ? _htmlPath : null;
            }
        }
    }
}
