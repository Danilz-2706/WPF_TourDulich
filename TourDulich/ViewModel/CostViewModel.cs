using Domain.Entities;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using TourDulich.Model;

namespace TourDulich.ViewModel
{
    public class CostViewModel :BaseViewModel

    {
        private ILoaiChiPhiService loaiChiPhiService;


        public int MaLoaiChiPhi { get; set; }
        public string TenLoaiChiPhi { get; set; }
       


        #region Các biến chức năng thêm loại chi phí
        public ICommand AddCommand { get; set; }
        public ICommand Close_ThemLCP { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand Reset { get; set; }

        private ICommand _EditCommand;
        public ICommand EditCommand { get => _EditCommand; set => _EditCommand = value; }


        private ICommand _Save;
        public ICommand Save { get => _Save; set => _Save = value; }

        // Các biến trong ViewChild_Add
        private string _addtenloaichiphi;
        public string AddTenLoaiChiPhi { get => _addtenloaichiphi; set => _addtenloaichiphi = value; }

        #endregion


        #region Lấy giá trị được chọn tham chiếu qua các ô cần dùng
        private LoaiChiPhi _SelectedItem;
        public LoaiChiPhi SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                if (SelectedItem != null)
                {
                    MaLoaiChiPhi = SelectedItem.MaLoaiChiPhi;
                    TenLoaiChiPhi = SelectedItem.TenLoaiChiPhi;
                }
            }
        }
        #endregion


        private ObservableCollection<LoaiChiPhi> _list;
        public ObservableCollection<LoaiChiPhi> List { get => _list; set { _list = value; } }

        public CostViewModel()
        {

        }
        public CostViewModel(ILoaiChiPhiService loaiChiPhiService)
        {
            this.loaiChiPhiService = loaiChiPhiService;
            List = new ObservableCollection<LoaiChiPhi>(this.loaiChiPhiService.GetDTOs());


            #region Commands

            #region Add
            //AddCommand = new RelayCommand<object>(p => { return true; }, p => { Add(); });
            //Close_ThemLCP = new RelayCommand<object>(p => { return true; }, p => { CloseThem(p); });

            //ViewChild
            //Reset
            Reset = new RelayCommand<object>(p => { return true; }, p => { AddTenLoaiChiPhi = null;});

            //Save
            Save = new RelayCommand<object>(p =>
            {
                return !string.IsNullOrEmpty(AddTenLoaiChiPhi);
            }, p =>
            {
                try
                {
                    var lcp = new LoaiChiPhi() { TenLoaiChiPhi = AddTenLoaiChiPhi };
                    loaiChiPhiService.Create(lcp);
                    List.Add(lcp);
                    //CloseThem(p);
                    MessageBox.Show($"Bạn đã thêm loại chi phí: Mã {lcp.MaLoaiChiPhi} - Tên: {lcp.TenLoaiChiPhi}");

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
                    return SelectedItem.TenLoaiChiPhi != TenLoaiChiPhi;
                }
                return false;
            }, p =>
            {
                try
                {
                    var lcp = new LoaiChiPhi() { TenLoaiChiPhi = TenLoaiChiPhi, MaLoaiChiPhi = SelectedItem.MaLoaiChiPhi };
                    loaiChiPhiService.Update(lcp);

                    int a = 0;
                    foreach (var i in List)
                    {
                        if (i.MaLoaiChiPhi == lcp.MaLoaiChiPhi)
                        {
                            List.Remove(this.loaiChiPhiService.Get(lcp.MaLoaiChiPhi));
                            List.Insert(a, this.loaiChiPhiService.Get(lcp.MaLoaiChiPhi));
                            MessageBox.Show($"Bạn sửa loại chi phí: Mã {lcp.MaLoaiChiPhi} - Tên: {lcp.TenLoaiChiPhi}");

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
                    var lcp = new LoaiChiPhi() { MaLoaiChiPhi = SelectedItem.MaLoaiChiPhi };
                    loaiChiPhiService.Delete(lcp.MaLoaiChiPhi);
                    foreach (var i in List)
                    {
                        if (i.MaLoaiChiPhi == lcp.MaLoaiChiPhi)
                        {
                            List.Remove(i);
                            MaLoaiChiPhi = 0;
                            TenLoaiChiPhi = null;
                            MessageBox.Show($"Bạn đã xóa nhân viên: Mã {i.MaLoaiChiPhi} - Tên: {i.TenLoaiChiPhi}");
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

    //    private void Add()
    //    {
    //        NhanVien_Them x = new NhanVien_Them();
    //        x.DataContext = this;
    //        x.ShowDialog();
    //        AddTenNhanVien = null;
    //        AddNhiemVu = null;
    //    }
    //    private void CloseThem(object obj) { NhanVien_Them x = obj as NhanVien_Them; x.Close(); }
    //}
}
}
