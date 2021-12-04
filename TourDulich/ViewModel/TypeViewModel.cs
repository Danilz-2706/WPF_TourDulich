using Domain.Entities;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TourDulich.Model;
using TourDulich.View.AdminManagerView;

namespace TourDulich.ViewModel
{
    public class TypeViewModel : BaseViewModel
    {
        private ILoaiHinhDuLichService loaiHinhDuLichService;


        public int MaLoaiHinh { get; set; }
        public string TenLoaiHinh { get; set; }


        #region Các biến chức năng thêm nhân viên
        public ICommand AddCommand { get; set; }
        public ICommand Close_ThemLHDL { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand Reset { get; set; }

        private ICommand _EditCommand;
        public ICommand EditCommand { get => _EditCommand; set => _EditCommand = value; }


        private ICommand _Save;
        public ICommand Save { get => _Save; set => _Save = value; }

        // Các biến trong ViewChild_Add
        private string _addtenloaihinh;
        public string AddTenLoaiHinh { get => _addtenloaihinh; set => _addtenloaihinh = value; }

        #endregion


        #region Lấy giá trị được chọn tham chiếu qua các ô cần dùng
        private LoaiHinhDuLich _SelectedItem;
        public LoaiHinhDuLich SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                if (SelectedItem != null)
                {
                    MaLoaiHinh = SelectedItem.MaLoaiHinh;
                    TenLoaiHinh = SelectedItem.TenLoaiHinh;
                }
            }
        }
        #endregion


        private ObservableCollection<LoaiHinhDuLich> _list;
        public ObservableCollection<LoaiHinhDuLich> List { get => _list; set { _list = value; } }

        public TypeViewModel()
        {

        }
        public TypeViewModel(ILoaiHinhDuLichService loaiHinhDuLichService)
        {
            this.loaiHinhDuLichService = loaiHinhDuLichService;
            List = new ObservableCollection<LoaiHinhDuLich>(this.loaiHinhDuLichService.GetDTOs());


            #region Commands

            #region Add
            AddCommand = new RelayCommand<object>(p => { return true; }, p => { Add(); });
            Close_ThemLHDL = new RelayCommand<object>(p => { return true; }, p => { CloseThem(p); });

            //ViewChild
            //Reset
            Reset = new RelayCommand<object>(p => { return true; }, p => { AddTenLoaiHinh = null; });

            //Save
            Save = new RelayCommand<object>(p =>
            {
                return !string.IsNullOrEmpty(AddTenLoaiHinh);
            }, p =>
            {
                try
                {
                    var dd = new LoaiHinhDuLich() { TenLoaiHinh = AddTenLoaiHinh };
                    loaiHinhDuLichService.Create(dd);
                    List.Add(dd);
                    CloseThem(p);
                    MessageBox.Show($"Bạn đã thêm loại hình: Tên: {dd.TenLoaiHinh}");

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
                    return SelectedItem.TenLoaiHinh != TenLoaiHinh;
                }
                return false;
            }, p =>
            {
                try
                {
                    var dd = new LoaiHinhDuLich() { TenLoaiHinh = TenLoaiHinh, MaLoaiHinh = SelectedItem.MaLoaiHinh };
                    loaiHinhDuLichService.Update(dd);

                    int a = 0;
                    foreach (var i in List)
                    {
                        if (i.MaLoaiHinh == dd.MaLoaiHinh)
                        {
                            List.Remove(this.loaiHinhDuLichService.Get(dd.MaLoaiHinh));
                            List.Insert(a, this.loaiHinhDuLichService.Get(dd.MaLoaiHinh));
                            MessageBox.Show($"Bạn sửa loại hình: Tên: {dd.TenLoaiHinh}");

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
                    var dd = new LoaiHinhDuLich() { MaLoaiHinh = SelectedItem.MaLoaiHinh };
                    loaiHinhDuLichService.Delete(dd.MaLoaiHinh);
                    foreach (var i in List)
                    {
                        if (i.MaLoaiHinh == dd.MaLoaiHinh)
                        {
                            List.Remove(i);
                            MaLoaiHinh = 0;
                            TenLoaiHinh = null;
                            MessageBox.Show($"Bạn đã xóa loại hình: Mã {i.MaLoaiHinh} - Tên: {i.TenLoaiHinh}");
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
            TypeManager_Them x = new TypeManager_Them();
            x.DataContext = this;
            x.ShowDialog();
            AddTenLoaiHinh = null;
        }
        private void CloseThem(object obj) { TypeManager_Them x = obj as TypeManager_Them; x.Close(); }
    }
}
