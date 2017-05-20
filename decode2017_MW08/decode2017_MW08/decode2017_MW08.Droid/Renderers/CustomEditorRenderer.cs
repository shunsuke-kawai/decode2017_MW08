using Android.Graphics;
using Android.Graphics.Drawables;
using decode2017_MW08.Controls;
using decode2017_MW08.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace decode2017_MW08.Droid.Renderers
{
    public class CustomEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            var el = (CustomEditor)this.Element;
            var nativeEditText = (global::Android.Widget.EditText)Control;

            var shape = new ShapeDrawable(new Android.Graphics.Drawables.Shapes.RectShape());
            shape.Paint.Color = el.BorderColor.ToAndroid();
            shape.Paint.SetStyle(Paint.Style.Stroke);
            nativeEditText.Background = shape;
        }
    }
}