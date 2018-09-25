using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM.ViewModel;

namespace Test
{

    public class MenuItem : ViewModelBase
    {
        public MenuItem()
        {
            this.Items = new ObservableCollection<MenuItem>();
        }

        public string Title { get; set; }

        private ObservableCollection<MenuItem> items;
        public ObservableCollection<MenuItem> Items {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }
    }

    class MainViewModel : ViewModelBase
    {
        public string[] MyStringArray { get; set; } = new string[] { "one", "two", "three" };
        public string MyString { get; set; } = "three";
        public string GuessWhat { get; set; } = Path.GetFileName(@"C:\dev\wpf\Test2");

        public ObservableCollection<MenuItem> TreeItems { get; set; } = new ObservableCollection<MenuItem>();
        public MainViewModel()
        {
            var root = new MenuItem() { Title = "Menu" };
            MenuItem childItem1 = new MenuItem() { Title = "Child item #1" };
            childItem1.Items.Add(new MenuItem() { Title = "Child item #1.1" });
            childItem1.Items.Add(new MenuItem() { Title = "Child item #1.2" });
            root.Items.Add(childItem1);
            TreeItems.Add(root);
        }

        private MenuItem menuItem;

        public MenuItem SelectedItem
        {
            get { return menuItem; }
            set {
                menuItem = value;
                if ((menuItem.Items?.Count??0) > 0)
                {
                    return;
                }
                menuItem.Items = new ObservableCollection<MenuItem>();
                for (int i = 1; i <= 3; i++)
                {
                    
                    menuItem.Items.Add(new MenuItem() { Title = menuItem.Title+"."+ i });
                }
            }
        }

    }
}
