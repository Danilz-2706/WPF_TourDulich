using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourDulich.Model;

namespace TourDulich.ViewModel
{
    public class TypeViewModel : BaseViewModel
    {
        public string MaLoaiHinh { get; set; }
        public string TenLoaiHinh { get; set; }
        //public ObservableCollection<LoaiHinhDuLichDTO> List { get; set; }
    }
}
