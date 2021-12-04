using Domain.Entities;
using Domain.Entities.Enum;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TourDulich.View.AdminManagerView;

namespace TourDulich.ViewModel
{
    public class KhachHangViewModel:BaseViewModel

    {
        private IKhachService khachService;


        public int MaKhachHang { get; set; }
        public string HoTen { get; set; }
        public string SoCMND { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string QuocTich { get; set; }
        public Gender Gender { get; set; }
        private Gender _SelectedGender;
        public Gender SelectedGender
        {
            get => _SelectedGender;
            set
            {
                _SelectedGender = value;

            }
        }


        #region Các biến chức năng thêm nhân viên
        public ICommand AddCommand { get; set; }
        public ICommand Close_ThemKH { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand Reset { get; set; }

        private ICommand _EditCommand;
        public ICommand EditCommand { get => _EditCommand; set => _EditCommand = value; }


        private ICommand _Save;
        public ICommand Save { get => _Save; set => _Save = value; }

        // Các biến trong ViewChild_Add
        private string _AddTenKhachHang;
        public string AddTenKhachHang { get => _AddTenKhachHang; set => _AddTenKhachHang = value; }
        private string _AddCMND;
        public string AddCMND { get => _AddCMND; set => _AddCMND = value; }
        private string _AddDiaChi;
        public string AddDiaChi { get => _AddDiaChi; set => _AddDiaChi = value; }
        private string _AddSDT;
        public string AddSDT { get => _AddSDT; set => _AddSDT = value; }
        private string _AddQuocTich;
        public string AddQuocTich { get => _AddQuocTich; set => _AddQuocTich = value; }
        private Gender _AddGender;
        public Gender AddGender
        {
            get => _AddGender;
            set
            {
                _AddGender = value;

            }
        }

        #endregion

        #region Các lệnh sửa Khách Hàng
        private ICommand _EditSaveCommand;
        public ICommand EditSaveCommand { get => _EditSaveCommand; set => _EditSaveCommand = value; }
        private ICommand _EditResetCommand;
        public ICommand EditResetCommand { get => _EditResetCommand; set => _EditResetCommand = value; }
        #endregion

        #region Lấy giá trị được chọn tham chiếu qua các ô cần dùng
        private Khach _SelectedItem;
        public Khach SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                if (SelectedItem != null)
                {
                    MaKhachHang = SelectedItem.MaKhachHang;
                    HoTen = SelectedItem.HoTen;
                    DiaChi = SelectedItem.DiaChi;
                    SoCMND = SelectedItem.SoCMND;
                    SDT = SelectedItem.SDT;
                    QuocTich = SelectedItem.QuocTich;

                    Gender = SelectedItem.GioiTinh;
                }
            }
        }
        #endregion


        private ObservableCollection<Khach> _list;
        public ObservableCollection<Khach> List { get => _list; set { _list = value; } }

        public KhachHangViewModel()
        {

        }
        public KhachHangViewModel(IKhachService khachService)
        {
            this.khachService = khachService;
            List = new ObservableCollection<Khach>(this.khachService.GetDTOs());

            #region Commands

            #region Add
            AddCommand = new RelayCommand<object>(p => { return true; }, p => { Add(); });
            Close_ThemKH = new RelayCommand<object>(p => { return true; }, p => { CloseThem(p); });

            //ViewChild
            //Reset
            Reset = new RelayCommand<object>(p => { return true; }, p => { AddTenKhachHang = null; AddCMND = null; AddDiaChi = null; AddQuocTich = null; AddSDT = null; AddGender = Gender.MALE; });

            //Save
            Save = new RelayCommand<object>(p =>
            {
                return !string.IsNullOrEmpty(AddTenKhachHang);
            }, p =>
            {
                try
                {
                    var kh = new Khach() { HoTen = AddTenKhachHang, DiaChi=AddDiaChi, SoCMND=AddCMND, SDT=AddSDT, QuocTich=AddQuocTich, GioiTinh=AddGender};
                    khachService.Create(kh);
                    List.Add(kh);
                    CloseThem(p);
                    MessageBox.Show($"Bạn đã thêm khách hàng: Tên {kh.HoTen}");

                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
            });
            #endregion

            #region Edit
            //EditCommand = new RelayCommand<object>(p =>
            //{
            //    return SelectedItem != null;
               
            //}, p =>
            //{
               
            //});
            //EditResetCommand = new RelayCommand<object>(p =>
            //{
            //    if (EditCommand.CanExecute(p))
            //    {
            //        return true;
            //    }
            //    return false;
            //}, p =>
            //{
            //    HoTen = SelectedItem.HoTen;
            //    DiaChi = SelectedItem.DiaChi;
            //    SoCMND = SelectedItem.SoCMND;
            //    SDT = SelectedItem.SDT;
            //    QuocTich = SelectedItem.QuocTich;
            //    Gender = SelectedItem.GioiTinh;
            //    SelectedItem = null;
            //});
            EditCommand = new RelayCommand<object>(p =>
            {
                if (SelectedItem != null)
                {
                    return SelectedItem.HoTen != HoTen || SelectedItem.SoCMND != SoCMND || SelectedItem.SDT != SDT || SelectedItem.DiaChi != DiaChi || SelectedItem.QuocTich != QuocTich ||SelectedItem.GioiTinh!=Gender;
                }
                return false;
            }, p =>
            {
                try
                {
                    var kh = new Khach() { MaKhachHang = SelectedItem.MaKhachHang, HoTen = HoTen, DiaChi = DiaChi, SoCMND = SoCMND, SDT = SDT, QuocTich = QuocTich, GioiTinh=Gender };
                    khachService.Update(kh);

                    int a = 0;
                    foreach (var i in List)
                    {
                        if (i.MaKhachHang == kh.MaKhachHang)
                        {
                            List.Remove(this.khachService.Get(kh.MaKhachHang));
                            List.Insert(a, this.khachService.Get(kh.MaKhachHang));
                            MessageBox.Show($"Bạn sửa khách hàng: Mã {kh.MaKhachHang} - Tên: {kh.HoTen}");
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
                return SelectedItem != null;
            }, p =>
            {
                try
                {
                    var kh = new Khach() { MaKhachHang = SelectedItem.MaKhachHang };
                    khachService.Delete(kh.MaKhachHang);
                    foreach (var i in List)
                    {
                        if (i.MaKhachHang == kh.MaKhachHang)
                        {
                            List.Remove(i);
                            MaKhachHang = 0;
                            HoTen = null;
                            DiaChi = null;
                            SoCMND = null;
                            SDT = null;
                            QuocTich = null;
                            MessageBox.Show($"Bạn đã xóa khách hàng: Mã {i.MaKhachHang} - Tên: {i.HoTen}");
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
            KhachHang_Them x = new KhachHang_Them();
            x.DataContext = this;
            x.ShowDialog();
            //AddTenKhachHang = null;
            //AddDiaChi = null;
            //AddCMND = null;
            //AddSDT = null;
            //AddQuocTich = null;
        }
        private void CloseThem(object obj) { KhachHang_Them x = obj as KhachHang_Them; x.Close(); }
    }
}
