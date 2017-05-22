using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace decode2017_MW08.ViewModels
{
    public class ListViewScrollToPageViewModel : BindableBase
    {
        private ObservableCollection<Group> _groupedItems = new ObservableCollection<Group>();
        public ObservableCollection<Group> GroupedItems
        {
            get { return _groupedItems; }
            set { SetProperty(ref _groupedItems, value); }
        }

        private Group _scrollToGroup;
        public Group ScrollToGroup
        {
            get { return _scrollToGroup; }
            set { SetProperty(ref _scrollToGroup, value); }
        }

        public ListViewScrollToPageViewModel()
        {
            GroupedItems = new ObservableCollection<Group>
            {
                new Group("あ")
                {
                    new Item{ Name = "あ" },
                    new Item{ Name = "い" },
                    new Item{ Name = "う" },
                    new Item{ Name = "え" },
                    new Item{ Name = "お" },
                },
                new Group("か")
                {
                    new Item{ Name = "か" },
                    new Item{ Name = "き" },
                    new Item{ Name = "く" },
                    new Item{ Name = "け" },
                    new Item{ Name = "こ" },
                },
                new Group("さ")
                {
                    new Item{ Name = "さ" },
                    new Item{ Name = "し" },
                    new Item{ Name = "す" },
                    new Item{ Name = "せ" },
                    new Item{ Name = "そ" },
                },
                new Group("た")
                {
                    new Item{ Name = "た" },
                    new Item{ Name = "ち" },
                    new Item{ Name = "つ" },
                    new Item{ Name = "て" },
                    new Item{ Name = "と" },
                },
            };
        }

        ICommand _scrollToCommand;
        public ICommand ScrollToCommand =>
            _scrollToCommand ?? (_scrollToCommand = new Command<string>(async (column) => await scrollToGroupAsync(column)));

        private async Task scrollToGroupAsync(string column)
        {
            var group = _groupedItems.Where(n => n.Title == column).FirstOrDefault();
            if (group != null)
            {
                ScrollToGroup = group;

                await Task.Delay(1000);
                ScrollToGroup = null;
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }
    }

    public class Group : ObservableCollection<Item>
    {
        public string Title { get; set; }
        public Group(string title)
        {
            Title = title;
        }
    }
}
