using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TourDulich.Model;

namespace TourDulich.ViewModel
{
    class AdminViewModel
    {
        private CollectionViewSource AdminItemsCollection;
        public ICollectionView AdminSourceCollection => AdminItemsCollection.View;
        public AdminViewModel()
        {
            //Obser.... Lam moi lai danh sach //
            ObservableCollection<AdminItems> adminItems = new ObservableCollection<AdminItems>
            {
                new AdminItems { AdminName = "Tour", AdminImage = @"Assets/Icon/DT1__UI--icon/tour.png" },
                new AdminItems { AdminName = "Tour Group", AdminImage = @"Assets/Icon/DT1__UI--icon/tourist group.png" },
                new AdminItems { AdminName = "Tourist Attraction", AdminImage = @"Assets/Icon/DT1__UI--icon/tourist attraction.png" },
                new AdminItems { AdminName = "Price", AdminImage = @"Assets/Icon/DT1__UI--icon/price.png" },
                new AdminItems { AdminName = "Cost", AdminImage = @"Assets/Icon/DT1__UI--icon/cost.png" },
                new AdminItems { AdminName = "User", AdminImage = @"Assets/Icon/DT1__UI--icon/user.png" },
                new AdminItems { AdminName = "Staff", AdminImage = @"Assets/Icon/DT1__UI--icon/staff.png" },
                new AdminItems { AdminName = "Statistics", AdminImage = @"Assets/Icon/DT1__UI--icon/statistics.png" }
            };

            AdminItemsCollection = new CollectionViewSource { Source = adminItems };

            // Set Startup Page
        }
    }
}
