using Prism.Behaviors;
using System;
using System.Collections;
using Xamarin.Forms;

namespace decode2017_MW08.Behaviors
{
    public class ScrollToBehavior : BehaviorBase<ListView>
    {
        public static readonly BindableProperty ScrollToItemProperty = BindableProperty.Create(
            "ScrollToItem", typeof(object), typeof(ScrollToBehavior), null, BindingMode.TwoWay, null,
            ScrollToBehavior.OnScrollToItemPropertyChanged, null, null);

        private static void OnScrollToItemPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            try
            {
                var baseView = bindable as BehaviorBase<ListView>;
                var listView = baseView?.AssociatedObject;
                if (listView == null || newValue == null) { return; }

                if (newValue is IList)
                {
                    var items = (IList)newValue;
                    if (items?.Count > 0)
                    {
                        listView.ScrollTo(items[0], newValue, ScrollToPosition.Start, true);
                    }
                }
                else
                {
                    listView.ScrollTo(newValue, ScrollToPosition.Start, true);
                }
            }
            catch (Exception)
            { }
        }
    }
}
