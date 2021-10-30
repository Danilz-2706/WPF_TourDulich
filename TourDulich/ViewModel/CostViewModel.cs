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
    class CostViewModel

    {
        private CollectionViewSource CostItemsCollection;
        public ICollectionView CostSourceCollection => CostItemsCollection.View;
        public CostViewModel()
        {
            //Obser.... Lam moi lai danh sach //
            ObservableCollection<CostItems> costItems = new ObservableCollection<CostItems>
            {
                new CostItems { CostName = "Tour", CostImage = @"Assets/Icon/DT1__UI--icon/tour.png" },
                new CostItems { CostName = "Tour Group", CostImage = @"Assets/Icon/DT1__UI--icon/tourist group.png" },
                new CostItems { CostName = "Tourist Attraction", CostImage = @"Assets/Icon/DT1__UI--icon/tourist attraction.png" },
                new CostItems { CostName = "Price", CostImage = @"Assets/Icon/DT1__UI--icon/price.png" },
                new CostItems { CostName = "Cost", CostImage = @"Assets/Icon/DT1__UI--icon/cost.png" },
                new CostItems { CostName = "User", CostImage = @"Assets/Icon/DT1__UI--icon/user.png" },
                new CostItems { CostName = "Staff", CostImage = @"Assets/Icon/DT1__UI--icon/staff.png" },
                new CostItems { CostName = "Statistics", CostImage = @"Assets/Icon/DT1__UI--icon/statistics.png" }
            };

            CostItemsCollection = new CollectionViewSource { Source = costItems };

            // Set Startup Page
        }
    }
}
