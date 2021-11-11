using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourDulich.Model;

namespace TourDulich.ViewModel
{
    public class LocationViewModel : BaseViewModel
    {
        public string MaDiaDiem { get; set; }
        public string TenDiaDiem { get; set; }
        //public ObservableCollection<DiaDiemDTO> List { get; set; }

    }
}
