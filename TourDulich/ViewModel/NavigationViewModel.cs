using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
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


        //Command Close//
        public void CloseApp(object obj)
        {
            MainWindow x = obj as MainWindow;
            x.Close();
        }
        private ICommand closeCommand;
        public ICommand CloseAppCommand
        {
            get
            {
                if (closeCommand == null)
                {
                    closeCommand = new RelayCommand<object>(p => CloseApp(p));
                }return closeCommand;
            }
        }

        //Command Check Toggle Button//
        private ICommand checkedToogle;
        public ICommand CheckToogleCommand
        {
            get
            {
                if (checkedToogle == null)
                {
                    checkedToogle = new RelayCommand<object>(p => { MainWindow x =new MainWindow(); x.Content.Opacity = 0.5; });
                }
                else
                {
                    checkedToogle = new RelayCommand<object>(p => { MainWindow x = new MainWindow(); x.Content.Opacity = 1; });
                }
                return checkedToogle;

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
                case "Tour Group":
                    SelectedViewModel = new TourGroupViewModel();
                    break;
                case "Tourist Attraction":
                    SelectedViewModel = new TouristAttractionViewModel();
                    break;
                case "Price":
                    SelectedViewModel = new PriceViewModel();
                    break;
                case "Cost":
                    SelectedViewModel = new CostViewModel();
                    break;
                case "User":
                    SelectedViewModel = new UserViewModel();
                    break;
                case "Staff":
                    SelectedViewModel = new StaffViewModel();
                    break;
                case "Statistics":
                    SelectedViewModel = new StatisticsViewModel();
                    break;
                default:
                    SelectedViewModel = new TourViewModel();
                    break;
            }
        }


    }
}
