using Domain.Entities;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourDulich.View.AdminManagerView;

namespace TourDulich.ViewModel
{
    public class NhanVienViewModel: BaseViewModel
    {
        private INhanVienService nhanVienService;


        public int MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public ICollection<PhanBoNhanVienDoan> PhanBoNhanVienDoans { get; set; }
        public ICollection<DoanDuLich> DoanDuLiches { get; set; }
        public string NhiemVu { get; set; }


        #region Các biến chức năng thêm nhân viên
        public ICommand AddCommand { get; set; }
        public ICommand Close_ThemNV { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand Reset { get; set; }

       
        public ICommand _Save { get; set; }
        public ICommand Save { get => _Save; set => _Save = value; }

        private string _addtennhanvien;
        public string AddTenNhanVien { get=>_addtennhanvien; set => _addtennhanvien = value; }

        private string _addnhiemvu;
        public string AddNhiemVu { get => _addnhiemvu; set => _addnhiemvu = value; }

        #endregion


        #region Lấy giá trị được chọn tham chiếu qua các ô cần dùng
        private NhanVien _SelectedItem;
        public NhanVien SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                if (SelectedItem != null)
                {
                    MaNhanVien = SelectedItem.MaNhanVien;
                    TenNhanVien = SelectedItem.TenNhanVien;
                    PhanBoNhanVienDoans = SelectedItem.PhanBoNhanVienDoans;
                    DoanDuLiches = SelectedItem.DoanDuLiches;
                    NhiemVu = SelectedItem.NhiemVu;
                }
            }
        }
        #endregion

        private ObservableCollection<NhanVien> _list;
        public ObservableCollection<NhanVien> List { get => _list; set { _list = value;} }
        public NhanVienViewModel()
        {

        }
        public NhanVienViewModel(INhanVienService nhanVienService)
        {
            this.nhanVienService = nhanVienService;
            List = new ObservableCollection<NhanVien>(this.nhanVienService.GetDTOs());


            #region Commands
            AddCommand = new RelayCommand<object>(p => { return true; }, p => { Add(); });
            Close_ThemNV = new RelayCommand<object>(p => { return true; }, p => { CloseThem(p); });

            //command ViewChild
            Reset = new RelayCommand<object>(p => { return true; }, p => { AddTenNhanVien = null; AddNhiemVu = null; });
            Save = new RelayCommand<object>(p => 
            {
                return !string.IsNullOrEmpty(AddTenNhanVien) && !string.IsNullOrEmpty(AddNhiemVu);
            }, p => 
            {
                var nv = new NhanVien() { TenNhanVien = AddTenNhanVien};
                nhanVienService.Create(nv);
                //Khúc này là khúc cần reload lại lên View. 
                // Có 2 hướng xử lý
                // 1 - Kiễm tra kỹ mode biding đúng chưa -> tui nghĩ là ổn. Vì để TwoWay là cái check dễ nhất. TowWay mà ko chạy được thì các Mode khác sẽ chạy ko được....
                // 2 - kiểm tra các biến trong lớp nhân viên khi được set thuộc tính thì có bắt được sự kiện hay ko. 
                // Tui đang kiểm tra lại cái cách 2.

                List.Add(nv);

            });


            //EditCommand = new RelayCommand<object>(p =>
            //{
            //    return !string.IsNullOrEmpty(TenNhanVien);
            //}, p =>
            //{
            //    ....................

      


            //});


            //DeleteCommand = new RelayCommand<object>(p =>
            //{
            //    return !string.IsNullOrEmpty(TenNhanVien);
            //}, p =>
            //{
            //    var nv = new NhanVien() { MaNhanVien = SelectedItem.MaNhanVien };
            //    nhanVienService.Delete(nv.MaNhanVien);

            //    List.Remove(nv);


            //});
            #endregion
        }

        private void Add() { NhanVien_Them x = new NhanVien_Them(); x.ShowDialog(); }
        private void CloseThem(object obj) { NhanVien_Them x = obj as NhanVien_Them; x.Close(); }
    }
}
