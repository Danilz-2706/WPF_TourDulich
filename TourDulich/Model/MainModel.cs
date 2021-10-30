using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourDulich.Model
{
    ////Menu Items//
    public class MenuItems
    {
        public string MenuName { get; set; }
        public string MenuImage { get; set; }

    }
    // Admin Page
    public class AdminItems
    {
        public string AdminName { get; set; }
        public string AdminImage { get; set; }
    }

    // Tour Page
    public class TourItems
    {
        public string TourName { get; set; }
        public string TourImage { get; set; }
    }

    // TourGroup Page
    public class TourGroupItems
    {
        public string TourGroupName { get; set; }
        public string TourGroupImage { get; set; }
    }

    // TouristAttraction Page
    public class TouristAttractionItems
    {
        public string TouristAttractionName { get; set; }
        public string TouristAttractionImage { get; set; }
    }

    // Price Page
    public class PriceItems
    {
        public string PriceName { get; set; }
        public string PriceImage { get; set; }
    }

    // Cost Page
    public class CostItems
    {
        public string CostName { get; set; }
        public string CostImage { get; set; }
    }

    // user Page
    public class UserItems
    {
        public string UserName { get; set; }
        public string UserImage { get; set; }
    }

    // Staff Page
    public class StaffItems
    {
        public string StaffName { get; set; }
        public string StaffImage { get; set; }
    }

    // Statistics Page
    public class StatisticsItems
    {
        public string StatisticsName { get; set; }
        public string StatisticsImage { get; set; }
    }
}
