using Prism.Mvvm;
using System.Collections.Generic;

namespace decode2017_MW08.ViewModels
{
    public class ListViewHasNoHighlightPageViewModel : BindableBase
    {
        public List<string> ItemsSource { get; } = new List<string>
        {
            "AAAAA",
            "BBBBB",
            "CCCCC",
            "DDDDD",
            "EEEEE",
            "FFFFF",
        };

        public ListViewHasNoHighlightPageViewModel()
        {

        }
    }
}
