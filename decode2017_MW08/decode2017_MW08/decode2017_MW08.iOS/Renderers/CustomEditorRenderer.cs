using decode2017_MW08.Controls;
using decode2017_MW08.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace decode2017_MW08.iOS.Renderers
{
    public class CustomEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            Control.Layer.BorderWidth = 0.6f;
            Control.Layer.BorderColor = Color.FromRgb(209, 209, 209).ToCGColor();
            Control.Layer.CornerRadius = 5;
        }
    }
}