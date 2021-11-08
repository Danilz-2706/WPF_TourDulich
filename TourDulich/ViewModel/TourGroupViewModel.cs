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
        private string _DoanhThu;
        public string DoanhThu
        {
            get => _DoanhThu;
            set
            {
                _DoanhThu = value; OnPropertyChanged();
            }
        }
        private string _NoiDung;
        public string NoiDung
        {
            get => _NoiDung;
            set
            {
                _NoiDung = value; OnPropertyChanged();
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

        private Tour _SelectedTour;
        public Tour SelectedTour
        {
            get => _SelectedTour;
            set
            {
                _SelectedTour = value; OnPropertyChanged();
                
            }
        }

        private List<NhanVien> _Nhanvien;
        public List<NhanVien> NhanVien
        {
            get => _Nhanvien;
            set
            {
                _Nhanvien = value; OnPropertyChanged();

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
                    TenDoan = SelectedItem.TenDoan;
                    NgayDi = SelectedItem.NgayDi;
                    NgayVe = SelectedItem.NgayVe;
                    DoanhThu = SelectedItem.DoanhThu;
                    NoiDung = SelectedItem.NoiDung;
                    SelectedTour = SelectedItem.Tour;
                    NhanVien = SelectedItem.NhanVien;
                }
            }
        }

        private ObservableCollection<TourGroup> _list;
        public ObservableCollection<TourGroup> ListGroup { get => _list; set { _list = value;OnPropertyChanged(); } }

        private ObservableCollection<Tour> _Tour;
        public ObservableCollection<Tour> Tour { get => _Tour; set { _Tour = value; OnPropertyChanged(); } }

        public TourGroupViewModel() {
            ListGroup = new ObservableCollection<TourGroup>
            {
                new TourGroup{DoanhThu="a", MaDoan="a9", NgayDi=DateTime.ParseExact("24/01/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("12/10/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenDoan="asd1", Tour=new Tour{ Ma="DALAT", Ten="Đà Lạt - Nha Trang"}, NhanVien=new List<NhanVien>{ new NhanVien { TenNV1 = "Dat" }, new NhanVien { TenNV1 = "Nhan" }, new NhanVien { TenNV1 = "An" }, new NhanVien { TenNV1 = "Lam" } },NoiDung="What's up ... Mic check" },
                new TourGroup{ DoanhThu="a", MaDoan="a8", NgayDi=DateTime.ParseExact("25/02/2022", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("11/11/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenDoan="asd2", Tour=new Tour{ Ma="DALAT", Ten="Đà Lạt - Nha Trang"}, NhanVien=new List<NhanVien>{ new NhanVien { TenNV1 = "Dat" } },NoiDung="What's up ",},
                new TourGroup{  DoanhThu="a", MaDoan="a7", NgayDi=DateTime.ParseExact("26/04/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("30/12/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenDoan="asd3",Tour=new Tour{ Ma="DALAT", Ten="Đà Lạt - Nha Trang"}, NhanVien=new List<NhanVien>{ new NhanVien { TenNV1 = "Dat" } },NoiDung="What's up ... Mic checksssssssssss" },
                new TourGroup{  DoanhThu="a", MaDoan="a6", NgayDi=DateTime.ParseExact("27/03/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("04/11/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenDoan="asd4", Tour=new Tour{ Ma="DALAT", Ten="Đà Lạt - Nha Trang"}, NhanVien=new List<NhanVien>{ new NhanVien { TenNV1 = "Dat" } },NoiDung="What's up ... Mic check3333333333333" },
                new TourGroup{  DoanhThu="a", MaDoan="a5", NgayDi=DateTime.ParseExact("01/02/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("14/03/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenDoan="asd5", Tour=new Tour{ Ma="DALAT", Ten="Đà Lạt - Nha Trang"},NhanVien=new List<NhanVien>{ new NhanVien { TenNV1 = "Dat" } },NoiDung="What's up ... Mic checkdsfasdfsdfasdfsadf" },
                new TourGroup{  DoanhThu="a", MaDoan="a4", NgayDi=DateTime.ParseExact("22/01/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("21/05/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenDoan="asd6", Tour=new Tour{ Ma="DALAT", Ten="Đà Lạt - Nha Trang"},NhanVien=new List<NhanVien>{ new NhanVien { TenNV1 = "Dat" } }},
                new TourGroup{  DoanhThu="a", MaDoan="a7", NgayDi=DateTime.ParseExact("26/04/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("30/12/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenDoan="asd3",Tour=new Tour{ Ma="DALAT", Ten="Đà Lạt - Nha Trang"},NhanVien=new List<NhanVien>{ new NhanVien { TenNV1 = "Dat" } },NoiDung="What's up ... Mic checksssssssssss" },
                new TourGroup{DoanhThu="a", MaDoan="a9", NgayDi=DateTime.ParseExact("24/01/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("12/10/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenDoan="asd1", Tour=new Tour{ Ma="DALAT", Ten="Đà Lạt - Nha Trang"}, NhanVien=new List<NhanVien>{ new NhanVien { TenNV1 = "Dat" } },NoiDung="What's up ... Mic check" },
                new TourGroup{ DoanhThu="a", MaDoan="a8", NgayDi=DateTime.ParseExact("25/02/2022", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("11/11/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenDoan="asd2", Tour=new Tour{ Ma="DALAT", Ten="Đà Lạt - Nha Trang"}, NhanVien=new List<NhanVien>{ new NhanVien { TenNV1 = "Dat" } },NoiDung="What's up ",},
                new TourGroup{  DoanhThu="a", MaDoan="a7", NgayDi=DateTime.ParseExact("26/04/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("30/12/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenDoan="asd3",Tour=new Tour{ Ma="DALAT", Ten="Đà Lạt - Nha Trang"}, NhanVien=new List<NhanVien>{ new NhanVien { TenNV1 = "Dat" } },NoiDung="What's up ... Mic checksssssssssss" },
                new TourGroup{  DoanhThu="a", MaDoan="a6", NgayDi=DateTime.ParseExact("27/03/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("04/11/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenDoan="asd4", Tour=new Tour{ Ma="DALAT", Ten="Đà Lạt - Nha Trang"}, NhanVien=new List<NhanVien>{ new NhanVien { TenNV1 = "Dat" } },NoiDung="What's up ... Mic check3333333333333" },
                new TourGroup{  DoanhThu="a", MaDoan="a5", NgayDi=DateTime.ParseExact("01/02/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("14/03/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenDoan="asd5", Tour=new Tour{ Ma="DALAT", Ten="Đà Lạt - Nha Trang"},NhanVien=new List<NhanVien>{ new NhanVien { TenNV1 = "Dat" } },NoiDung="What's up ... Mic checkdsfasdfsdfasdfsadf" },
                new TourGroup{  DoanhThu="a", MaDoan="a4", NgayDi=DateTime.ParseExact("22/01/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("21/05/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenDoan="asd6", Tour=new Tour{ Ma="DALAT", Ten="Đà Lạt - Nha Trang"},NhanVien=new List<NhanVien>{ new NhanVien { TenNV1 = "Dat" } }},
                new TourGroup{  DoanhThu="a", MaDoan="a7", NgayDi=DateTime.ParseExact("26/04/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("30/12/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenDoan="asd3",Tour=new Tour{ Ma="DALAT", Ten="Đà Lạt - Nha Trang"},NhanVien=new List<NhanVien>{ new NhanVien { TenNV1 = "Dat" } },NoiDung="What's up ... Mic checksssssssssss" },
                new TourGroup{DoanhThu="a", MaDoan="a9", NgayDi=DateTime.ParseExact("24/01/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("12/10/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenDoan="asd1", Tour=new Tour{ Ma="DALAT", Ten="Đà Lạt - Nha Trang"}, NhanVien=new List<NhanVien>{ new NhanVien { TenNV1 = "Dat" } },NoiDung="What's up ... Mic check" },
                new TourGroup{ DoanhThu="a", MaDoan="a8", NgayDi=DateTime.ParseExact("25/02/2022", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("11/11/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenDoan="asd2", Tour=new Tour{ Ma="DALAT", Ten="Đà Lạt - Nha Trang"}, NhanVien=new List<NhanVien>{ new NhanVien { TenNV1 = "Dat" } },NoiDung="What's up ",},
                new TourGroup{  DoanhThu="a", MaDoan="a7", NgayDi=DateTime.ParseExact("26/04/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("30/12/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenDoan="asd3",Tour=new Tour{ Ma="DALAT", Ten="Đà Lạt - Nha Trang"}, NhanVien=new List<NhanVien>{ new NhanVien { TenNV1 = "Dat" } },NoiDung="What's up ... Mic checksssssssssss" },
                new TourGroup{  DoanhThu="a", MaDoan="a6", NgayDi=DateTime.ParseExact("27/03/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("04/11/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenDoan="asd4", Tour=new Tour{ Ma="DALAT", Ten="Đà Lạt - Nha Trang"}, NhanVien=new List<NhanVien>{ new NhanVien { TenNV1 = "Dat" } },NoiDung="What's up ... Mic check3333333333333" },
                new TourGroup{  DoanhThu="a", MaDoan="a5", NgayDi=DateTime.ParseExact("01/02/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("14/03/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenDoan="asd5", Tour=new Tour{ Ma="DALAT", Ten="Đà Lạt - Nha Trang"},NhanVien=new List<NhanVien>{ new NhanVien { TenNV1 = "Dat" } },NoiDung="What's up ... Mic checkdsfasdfsdfasdfsadf" },
                new TourGroup{  DoanhThu="a", MaDoan="a4", NgayDi=DateTime.ParseExact("22/01/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("21/05/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenDoan="asd6", Tour=new Tour{ Ma="DALAT", Ten="Đà Lạt - Nha Trang"},NhanVien=new List<NhanVien>{ new NhanVien { TenNV1 = "Dat" } }},
                new TourGroup{  DoanhThu="a", MaDoan="a7", NgayDi=DateTime.ParseExact("26/04/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), NgayVe =DateTime.ParseExact("30/12/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture), TenDoan="asd3",Tour=new Tour{ Ma="DALAT", Ten="Đà Lạt - Nha Trang"},NhanVien=new List<NhanVien>{ new NhanVien { TenNV1 = "Dat" } },NoiDung="What's up ... Mic checksssssssssss" }
            };

            Tour = new ObservableCollection<Tour>
            {
                new Tour{Ma = "12", Ten="Đà Lạt - Nha Trang"},
                new Tour{Ma = "123", Ten="HCM - Hà Nội"},
                new Tour{Ma = "124", Ten="Cà Mau - Hà Giang"},
                new Tour{Ma = "11", Ten="Quận 1 - Hầm Thủ Thiêm"},

                new Tour{Ma = "11", Ten="Quận 1 - Hầm Thủ Thiêm"},
                new Tour{Ma = "11", Ten="Quận 1 - Hầm Thủ Thiêm"},
                new Tour{Ma = "11", Ten="Quận 1 - Hầm Thủ Thiêm"},
                new Tour{Ma = "11", Ten="Quận 1 - Hầm Thủ Thiêm"},
                new Tour{Ma = "11", Ten="Quận 1 - Hầm Thủ Thiêm"},
                new Tour{Ma = "11", Ten="Quận 1 - Hầm Thủ Thiêm"},
                new Tour{Ma = "11", Ten="Quận 1 - Hầm Thủ Thiêm"},
                new Tour{Ma = "1232", Ten="SGU - Sư phạm"}
            };

        }
    }
    
}
