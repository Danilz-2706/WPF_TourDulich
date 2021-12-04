
using Domain.Entities;
using Infrastructure.Persistence.Repositories;
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
    public class LocationViewModel : BaseViewModel
    {
        private IDiaDiemService diaDiemService;


        public int MaDiaDiem { get; set; }
        public string TenDiaDiem { get; set; }


        #region Các biến chức năng thêm nhân viên
        public ICommand AddCommand { get; set; }
        public ICommand Close_ThemDD { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand Reset { get; set; }

        private ICommand _EditCommand;
        public ICommand EditCommand { get => _EditCommand; set => _EditCommand = value; }


        private ICommand _Save;
        public ICommand Save { get => _Save; set => _Save = value; }

        // Các biến trong ViewChild_Add
        private string _addtendiadiem;
        public string AddTenDiaDiem { get => _addtendiadiem; set => _addtendiadiem = value; }

        #endregion


        #region Lấy giá trị được chọn tham chiếu qua các ô cần dùng
        private DiaDiem _SelectedItem;
        public DiaDiem SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                if (SelectedItem != null)
                {
                    MaDiaDiem = SelectedItem.MaDiaDiem;
                    TenDiaDiem = SelectedItem.TenDiaDiem;
                }
            }
        }
        #endregion


        private ObservableCollection<DiaDiem> _list;
        public ObservableCollection<DiaDiem> List { get => _list; set { _list = value; } }

        public LocationViewModel()
        {

        }
        public LocationViewModel(IDiaDiemService diaDiemService)
        {
            this.diaDiemService = diaDiemService;
            List = new ObservableCollection<DiaDiem>(this.diaDiemService.GetDTOs());


            #region Commands

            #region Add
            AddCommand = new RelayCommand<object>(p => { return true; }, p => { Add(); });
            Close_ThemDD = new RelayCommand<object>(p => { return true; }, p => { CloseThem(p); });

            //ViewChild
            //Reset
            Reset = new RelayCommand<object>(p => { return true; }, p => { AddTenDiaDiem = null;});

            //Save
            Save = new RelayCommand<object>(p =>
            {
                return !string.IsNullOrEmpty(AddTenDiaDiem);
            }, p =>
            {
                try
                {
                    var dd = new DiaDiem() { TenDiaDiem = AddTenDiaDiem };
                    diaDiemService.Create(dd);
                    List.Add(dd);
                    CloseThem(p);
                    MessageBox.Show($"Bạn đã thêm địa điểm: Tên: {dd.TenDiaDiem}");

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
                    return SelectedItem.TenDiaDiem != TenDiaDiem;
                }
                return false;
            }, p =>
            {
                try
                {
                    var dd = new DiaDiem() { TenDiaDiem = TenDiaDiem, MaDiaDiem = SelectedItem.MaDiaDiem };
                    diaDiemService.Update(dd);

                    int a = 0;
                    foreach (var i in List)
                    {
                        if (i.MaDiaDiem == dd.MaDiaDiem)
                        {
                            List.Remove(this.diaDiemService.Get(dd.MaDiaDiem));
                            List.Insert(a, this.diaDiemService.Get(dd.MaDiaDiem));
                            MessageBox.Show($"Bạn sửa địa điểm: Tên: {dd.TenDiaDiem}");

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
                    var dd = new DiaDiem() { MaDiaDiem = SelectedItem.MaDiaDiem };
                    diaDiemService.Delete(dd.MaDiaDiem);
                    foreach (var i in List)
                    {
                        if (i.MaDiaDiem == dd.MaDiaDiem)
                        {
                            List.Remove(i);
                            MaDiaDiem = 0;
                            TenDiaDiem = null;
                            MessageBox.Show($"Bạn đã xóa địa điểm: Mã {i.MaDiaDiem} - Tên: {i.TenDiaDiem}");
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
            LocationManager_Them x = new LocationManager_Them();
            x.DataContext = this;
            x.ShowDialog();
            AddTenDiaDiem = null;
        }
        private void CloseThem(object obj) { LocationManager_Them x = obj as LocationManager_Them; x.Close(); }
    }
}
