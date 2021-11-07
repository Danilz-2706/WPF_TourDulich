using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourDulich.Model;

namespace TourDulich.ViewModel
{
    class TourGroupViewModel:BaseViewModel
    {
        private string _MaDoan;
        public string MaDoan
        {
            get => _MaDoan;
            set
            {
                _MaDoan = value;OnPropertyChanged();
            }
        }

        private string _TenDoan;
        public string TenDoan
        {
            get => _TenDoan;
            set
            {
                _TenDoan = value; OnPropertyChanged();
            }
        }
        private List<NhanVien> _TenNV;
        public List<NhanVien> TenNV
        {
            get => _TenNV;
            set
            {
                _TenNV = value; OnPropertyChanged();
            }
        }
        private DateTime? _NgayDi;
        public DateTime? NgayDi
        {
            get => _NgayDi;
            set
            {
                _NgayDi = value; OnPropertyChanged();
            }
        }
        private DateTime? _NgayVe;
        public DateTime? NgayVe
        {
            get => _NgayVe;
            set
            {
                _NgayVe = value; OnPropertyChanged();
            }
        }
        private TourGroup _SelectedItem;
        public TourGroup SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value; OnPropertyChanged();
                if(SelectedItem != null)
                {
                    MaDoan = SelectedItem.MaDoan;
                    TenDoan = SelectedItem.TenTour;
                    NgayDi = SelectedItem.NgayDi;
                    NgayVe = SelectedItem.NgayVe;
                    TenNV = SelectedItem.TenNV;
                }
            }
        }

        private ObservableCollection<TourGroup> _list;
        public ObservableCollection<TourGroup> ListGroup { get => _list; set { _list = value;OnPropertyChanged(); } }
        public TourGroupViewModel() {
            ListGroup = new ObservableCollection<TourGroup>
            {
                new TourGroup{ MaTour="a1", DoanhThu="a", MaDoan="a9", NgayDi=DateTime.ParseExact("24/01/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("12/10/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenTour="asd1", TenNV=new List<NhanVien>{new NhanVien{ TenNV1="Dat"}} },
                new TourGroup{ MaTour="a2", DoanhThu="a", MaDoan="a8", NgayDi=DateTime.ParseExact("25/02/2022", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("11/11/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenTour="asd2", TenNV=new List<NhanVien>{new NhanVien{ TenNV1="Dat"}}},
                new TourGroup{ MaTour="a3", DoanhThu="a", MaDoan="a7", NgayDi=DateTime.ParseExact("26/04/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("30/12/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenTour="asd3", TenNV=new List<NhanVien>{new NhanVien{ TenNV1="Dat"}}},
                new TourGroup{ MaTour="a4", DoanhThu="a", MaDoan="a6", NgayDi=DateTime.ParseExact("27/03/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("04/11/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenTour="asd4", TenNV=new List<NhanVien>{new NhanVien{ TenNV1="Dat"}}},
                new TourGroup{ MaTour="a5", DoanhThu="a", MaDoan="a5", NgayDi=DateTime.ParseExact("01/02/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("14/03/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenTour="asd5", TenNV=new List<NhanVien>{new NhanVien{ TenNV1="Dat"}}},
                new TourGroup{ MaTour="a6", DoanhThu="a", MaDoan="a4", NgayDi=DateTime.ParseExact("22/01/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("21/05/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenTour="asd6", TenNV =new List<NhanVien>{new NhanVien{ TenNV1="Dat"}}},
                new TourGroup{ MaTour="a7", DoanhThu="a", MaDoan="a3", NgayDi=DateTime.ParseExact("26/01/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("26/02/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenTour="asd7", TenNV=new List<NhanVien>{new NhanVien{ TenNV1="Dat"}}},
                new TourGroup{ MaTour="a8", DoanhThu="a", MaDoan="a2", NgayDi=DateTime.ParseExact("27/01/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("25/01/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenTour="asd8", TenNV=new List<NhanVien>{new NhanVien{ TenNV1="Dat"}}},
                new TourGroup{ MaTour="a2", DoanhThu="a", MaDoan="a8", NgayDi=DateTime.ParseExact("25/02/2022", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("11/11/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenTour="asd2", TenNV=new List<NhanVien>{new NhanVien{ TenNV1="Dat"}}},
                new TourGroup{ MaTour="a3", DoanhThu="a", MaDoan="a7", NgayDi=DateTime.ParseExact("26/04/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("30/12/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenTour="asd3", TenNV=new List<NhanVien>{new NhanVien{ TenNV1="Dat"}}},
                new TourGroup{ MaTour="a5", DoanhThu="a", MaDoan="a5", NgayDi=DateTime.ParseExact("01/02/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("14/03/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenTour="asd5", TenNV=new List<NhanVien>{new NhanVien{ TenNV1="Dat"}}},
                new TourGroup{ MaTour="a6", DoanhThu="a", MaDoan="a4", NgayDi=DateTime.ParseExact("22/01/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("21/05/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenTour="asd6", TenNV =new List<NhanVien>{new NhanVien{ TenNV1="Dat"}}},
                new TourGroup{ MaTour="a7", DoanhThu="a", MaDoan="a3", NgayDi=DateTime.ParseExact("26/01/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("26/02/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenTour="asd7", TenNV=new List<NhanVien>{new NhanVien{ TenNV1="Dat"}}},
                new TourGroup{ MaTour="a8", DoanhThu="a", MaDoan="a2", NgayDi=DateTime.ParseExact("27/01/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("25/01/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenTour="asd8", TenNV=new List<NhanVien>{new NhanVien{ TenNV1="Dat"}}},
                new TourGroup{ MaTour="a2", DoanhThu="a", MaDoan="a8", NgayDi=DateTime.ParseExact("25/02/2022", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("11/11/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenTour="asd2", TenNV=new List<NhanVien>{new NhanVien{ TenNV1="Dat"}}},
                new TourGroup{ MaTour="a3", DoanhThu="a", MaDoan="a7", NgayDi=DateTime.ParseExact("26/04/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("30/12/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenTour="asd3", TenNV=new List<NhanVien>{new NhanVien{ TenNV1="Dat"}}},
                new TourGroup{ MaTour="a5", DoanhThu="a", MaDoan="a5", NgayDi=DateTime.ParseExact("01/02/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("14/03/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenTour="asd5", TenNV=new List<NhanVien>{new NhanVien{ TenNV1="Dat"}}},
                new TourGroup{ MaTour="a6", DoanhThu="a", MaDoan="a4", NgayDi=DateTime.ParseExact("22/01/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("21/05/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenTour="asd6", TenNV =new List<NhanVien>{new NhanVien{ TenNV1="Dat"}}},
                new TourGroup{ MaTour="a7", DoanhThu="a", MaDoan="a3", NgayDi=DateTime.ParseExact("26/01/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("26/02/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenTour="asd7", TenNV=new List<NhanVien>{new NhanVien{ TenNV1="Dat"}}},
                new TourGroup{ MaTour="a8", DoanhThu="a", MaDoan="a2", NgayDi=DateTime.ParseExact("27/01/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("25/01/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenTour="asd8", TenNV=new List<NhanVien>{new NhanVien{ TenNV1="Dat"}}},
                new TourGroup{ MaTour="a2", DoanhThu="a", MaDoan="a8", NgayDi=DateTime.ParseExact("25/02/2022", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("11/11/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenTour="asd2", TenNV=new List<NhanVien>{new NhanVien{ TenNV1="Dat"}}},
                new TourGroup{ MaTour="a3", DoanhThu="a", MaDoan="a7", NgayDi=DateTime.ParseExact("26/04/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("30/12/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenTour="asd3", TenNV=new List<NhanVien>{new NhanVien{ TenNV1="Dat"}}}
            };
        }
    }
    
}
