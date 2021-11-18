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

        private ICommand _EditCommand;
        public ICommand EditCommand { get => _EditCommand; set => _EditCommand = value; }

       
        public ICommand _Save { get; set; }
        public ICommand Save { get => _Save; set => _Save = value; }

        // Các biến trong ViewChild_Add
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
        public ObservableCollection<NhanVien> List { get => _list; set { _list = value;  } }

        public NhanVienViewModel()
        {

        }
        public NhanVienViewModel(INhanVienService nhanVienService)
        {
            this.nhanVienService = nhanVienService;
            List = new ObservableCollection<NhanVien>(this.nhanVienService.GetDTOs());


            #region Commands

            #region Add
            AddCommand = new RelayCommand<object>(p => { return true; }, p => { Add(); });
            Close_ThemNV = new RelayCommand<object>(p => { return true; }, p => { CloseThem(p); });

            //ViewChild
            //Reset
            Reset = new RelayCommand<object>(p => { return true; }, p => { AddTenNhanVien = null; AddNhiemVu = null; });

            //Save
            Save = new RelayCommand<object>(p => 
            {
                return !string.IsNullOrEmpty(AddTenNhanVien) ;
            }, p => 
            {
                try
                {
                    var nv = new NhanVien() { TenNhanVien = AddTenNhanVien};
                    nhanVienService.Create(nv);
                    CloseThem(p);
                    List.Add(nv);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
            });
            #endregion

            #region Edit
            EditCommand = new RelayCommand<object>(p =>
            {
                if (SelectedItem != null)
                {
                    return  SelectedItem.TenNhanVien != TenNhanVien;
                }
                return false;
            }, p =>
            {
                try
                {
                    var nv = new NhanVien() { TenNhanVien = TenNhanVien, MaNhanVien=SelectedItem.MaNhanVien};
                    nhanVienService.Update(nv);

                    int a = 0;
                    foreach (var i in List)
                    {
                        if (i.MaNhanVien == nv.MaNhanVien)
                        {
                            List.Remove(this.nhanVienService.Get(nv.MaNhanVien));
                            List.Insert(a, this.nhanVienService.Get(nv.MaNhanVien));
                            break;
                        }
                        else
                        {
                            a++;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
            });
            #endregion

            #region Delete
            DeleteCommand = new RelayCommand<object>(p =>
            {
                return SelectedItem!=null;
            }, p =>
            {
                try
                {
                    var nv = new NhanVien() { MaNhanVien = SelectedItem.MaNhanVien };
                    nhanVienService.Delete(nv.MaNhanVien);
                    foreach (var i in List)
                    {
                        if (i.MaNhanVien == nv.MaNhanVien)
                        {
                            List.Remove(i);
                            MaNhanVien = 0;
                            TenNhanVien = null;
                            break;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
            });
            #endregion

            #endregion
        }

        private void Add()
        {
            NhanVien_Them x = new NhanVien_Them();
            x.DataContext = this;
            x.ShowDialog();
            AddTenNhanVien = null;
            AddNhiemVu = null;
        }
        private void CloseThem(object obj) { NhanVien_Them x = obj as NhanVien_Them; x.Close(); }
    }
}
