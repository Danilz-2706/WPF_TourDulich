using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using TourDulich.Model;
/// <summary>
/// Hien thi cac doi tuong cua Model len tren View.
/// </summary>

namespace TourDulich.ViewModel
{
    class NavigationViewModel : BaseViewModel
    {

        private CollectionViewSource MenuItemsCollection;
        public ICollectionView SourceCollection => MenuItemsCollection.View;
        public NavigationViewModel()
        {
            //Obser.... Lam moi lai danh sach //
            ObservableCollection<MenuItems> menuItems = new ObservableCollection<MenuItems>
            {
                new MenuItems { MenuName = "Admin", MenuImage = @"Assets/Icon/DT1__UI--icon/Admin.png" },
                new MenuItems { MenuName = "Tour", MenuImage = @"Assets/Icon/DT1__UI--icon/tour.png" },
                new MenuItems { MenuName = "Tour Group", MenuImage = @"Assets/Icon/DT1__UI--icon/tourist group.png" },
                new MenuItems { MenuName = "Tourist Attraction", MenuImage = @"Assets/Icon/DT1__UI--icon/tourist attraction.png" },
                new MenuItems { MenuName = "Price", MenuImage = @"Assets/Icon/DT1__UI--icon/price.png" },
                new MenuItems { MenuName = "Cost", MenuImage = @"Assets/Icon/DT1__UI--icon/cost.png" },
                new MenuItems { MenuName = "User", MenuImage = @"Assets/Icon/DT1__UI--icon/user.png" },
                new MenuItems { MenuName = "Staff", MenuImage = @"Assets/Icon/DT1__UI--icon/staff.png" },
                new MenuItems { MenuName = "Statistics", MenuImage = @"Assets/Icon/DT1__UI--icon/statistics.png" }
            };

            MenuItemsCollection = new CollectionViewSource { Source = menuItems };

            // Set Startup Page
        }

        // Menu Button Command
        private ICommand _menucommand;
        public ICommand MenuCommand
        {
            get
            {
                if (_menucommand == null)
                {
                    _menucommand = new RelayCommand<object>(param => SwitchViews(param));
                }
                return _menucommand;
            }
        }

        // Select ViewModel
        private object _selectedViewModel;
        public object SelectedViewModel
        {
            get => _selectedViewModel;
            set { _selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
        }

        // Switch Views
        public void SwitchViews(object parameter)
        {
            switch (parameter)
            {
                case "Admin":
                    SelectedViewModel = new AdminViewModel();
                    break;
                case "Tour":
                    SelectedViewModel = new TourViewModel();
                    break;
                case "Cost":
                    SelectedViewModel = new CostViewModel();
                    break;
                default:
                    SelectedViewModel = new AdminViewModel();
                    break;
            }
        }


    }
}
