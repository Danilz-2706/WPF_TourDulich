using Domain.Entities;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourDulich.Model;
using TourDulich.View.AdminManagerView;

namespace TourDulich.ViewModel
{
    public class DoanDuLichViewModel:BaseViewModel
    {
        #region Khai báo các Service để dùng trong Đoàn
        private readonly IDoanDuLichService doanDuLichService;
        private readonly ITourDuLichService tourDuLichService;
        private readonly INhanVienService nhanVienService;
        #endregion

        #region Biến của các ô con để lấy dữ liệu được tham chiếu
        public int MaDoan { get; set; }
        public TourDuLich Tour { get; set; }
        public NoiDungTour NoiDungTour { get; set; }
        public string TenDoan { get; set; }
        public DateTime? NgayKhoiHanh { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public long DoanhThu { get; set; }
        public ICollection<ChiTietDoan> ChiTietDoans { get; set; }
        public ICollection<Khach> Khaches { get; set; }
        public ICollection<Domain.Entities.ChiPhi> ChiPhis { get; set; }
        public ICollection<PhanBoNhanVienDoan> PhanBoNhanVienDoans { get; set; }
        public ICollection<NhanVien> NhanViens { get; set; }

        private TourDuLich _SelectedTour;
        public TourDuLich SelectedTour
        {
            get => _SelectedTour;
            set
            {
                _SelectedTour = value;

            }
        }

        #endregion

        #region Lấy giá trị được chọn tham chiếu qua các ô cần dùng
        private DoanDuLich _SelectedItem;
        public DoanDuLich SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                if (SelectedItem != null)
                {
                    MaDoan = SelectedItem.MaDoan;
                    TenDoan = SelectedItem.TenDoan;
                    NoiDungTour = SelectedItem.NoiDungTour;
                    NgayKhoiHanh = SelectedItem.NgayKhoiHanh;
                    NgayKetThuc = SelectedItem.NgayKetThuc;
                    DoanhThu = SelectedItem.DoanhThu;

                    SelectedTour = SelectedItem.Tour;
                    NhanViens = SelectedItem.NhanViens;
                }
            }
        }
        #endregion

        #region Danh sách Đoàn, Tour, Nhân viên, Chi phí, Khách hàng
        private ObservableCollection<TourDuLich> _listTour;

        public ObservableCollection<TourDuLich> ListTour { get => _listTour; set { _listTour = value; } }

        private ObservableCollection<NhanVien> _listNhanvien;

        public ObservableCollection<NhanVien> ListNhanvien { get => _listNhanvien; set { _listNhanvien = value; } }

        private ObservableCollection<DoanDuLich> _list;

        public ObservableCollection<DoanDuLich> ListGroup { get => _list; set { _list = value; } }
        #endregion

        #region Các biến dùng để mở và đóng các view con

        public ICommand AddCommand { get; set; }
        public ICommand ShowCommand { get; set; }
        public ICommand DoanThemNV { get; set; }
        public ICommand DoanThemKH { get; set; }
        public ICommand DoanThemCP { get; set; }
        public ICommand Close_DoanThem { get; set; }
        public ICommand Close_DoanThemNV { get; set; }
        public ICommand Close_DoanThemKH { get; set; }
        public ICommand Close_DoanThemCP { get; set; }
        public ICommand Close_DoanChiTiet { get; set; }

        #endregion
        public DoanDuLichViewModel() { }
        public DoanDuLichViewModel(IDoanDuLichService doanDuLichService, ITourDuLichService tourDuLichService, INhanVienService nhanVienService) {
            this.doanDuLichService = doanDuLichService;
            this.tourDuLichService = tourDuLichService;
            this.nhanVienService = nhanVienService;
            ListGroup = new ObservableCollection<DoanDuLich>(this.doanDuLichService.GetDTOs());
            ListTour = new ObservableCollection<TourDuLich>(this.tourDuLichService.GetDTOs());
            ListNhanvien = new ObservableCollection<NhanVien>(this.nhanVienService.GetDTOs());

            #region Thực hiện các chức năng

            AddCommand = new RelayCommand<object>(p => { return true; }, p => { Add(); });
            Close_DoanThem = new RelayCommand<object>(p =>      { return true; }, p => { CloseThem(p); });

            ShowCommand = new RelayCommand<object>(p => { return true; }, p => { Show(); });
            Close_DoanChiTiet = new RelayCommand<object>(p => { return true; }, p => { CloseChiTiet(p); });
            
            DoanThemNV = new RelayCommand<object>(p => { return true; }, p => { ShowThemNV(); });
            Close_DoanThemNV = new RelayCommand<object>(p =>    { return true; }, p => { CloseThemNV(p); });
            
            DoanThemKH = new RelayCommand<object>(p => { return true; }, p => { ShowThemKH(); });
            Close_DoanThemKH = new RelayCommand<object>(p => { return true; }, p => { CloseThemKH(p); });
            
            DoanThemCP = new RelayCommand<object>(p => { return true; }, p => { ShowThemCP(); });
            Close_DoanThemCP = new RelayCommand<object>(p => { return true; }, p => { CloseThemCP(p); });

            #endregion
        }


        #region Open View Child
        private void Add() { DoanDuLich_Them x = new DoanDuLich_Them(); x.ShowDialog(); }
        private void CloseThem(object obj) { DoanDuLich_Them x = obj as DoanDuLich_Them; x.Close();  }


        private void Show() { DoanDuLich_ChiTiet x = new DoanDuLich_ChiTiet(); x.ShowDialog(); }
        private void CloseChiTiet(object obj) { DoanDuLich_ChiTiet x = obj as DoanDuLich_ChiTiet; x.Close();  }


        private void ShowThemNV() { DoanDuLich_ThemNhanVien x = new DoanDuLich_ThemNhanVien(); x.ShowDialog();  }
        private void CloseThemNV(object obj) { DoanDuLich_ThemNhanVien x = obj as DoanDuLich_ThemNhanVien; x.Close();  }

        private void ShowThemKH() { DoanDuLich_ThemKhachHang x = new DoanDuLich_ThemKhachHang(); x.ShowDialog(); }
        private void CloseThemKH(object obj) { DoanDuLich_ThemKhachHang x = obj as DoanDuLich_ThemKhachHang; x.Close();  }

        private void ShowThemCP() { DoanDuLich_ThemChiPhi x = new DoanDuLich_ThemChiPhi(); x.ShowDialog(); }
        private void CloseThemCP(object obj) { DoanDuLich_ThemChiPhi x = obj as DoanDuLich_ThemChiPhi; x.Close();  }

        #endregion



    }
}
