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
using TourDulich.View.AdminManagerView;

namespace TourDulich.ViewModel
{
    public class PriceViewModel : BaseViewModel
    {
        private readonly IGiaTourService giaTourService;
        private readonly ITourDuLichService tourDuLichService;

        public int MaGia { get; set; }
        public int MaTour { get; set; }
        //public string TenTour { get; set; }
        public long ThanhTien { get; set; }
        public DateTime? ThoiGianBatDau { get; set; }
        public DateTime? ThoiGianKetThuc { get; set; }
        private TourDuLich _SelectedTour;
        public TourDuLich SelectedTour
        {
            get => _SelectedTour;
            set
            {
                _SelectedTour = value;

            }
        }


        private GiaTour _SelectedItem;
        public GiaTour SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                if (SelectedItem != null)
                {
                    MaGia = SelectedItem.MaGia;
                    ThanhTien = SelectedItem.ThanhTien;
                    ThoiGianBatDau = SelectedItem.ThoiGianBatDau;
                    ThoiGianKetThuc = SelectedItem.ThoiGianKetThuc;
                    //TenTour = SelectedItem.TourDuLich.TenGoi;

                    SelectedTour = SelectedItem.TourDuLich;
                }
            }
        }

        #region Các biến chức năng thêm giá
        private TourDuLich _AddSelectedTour;
        public TourDuLich AddSelectedTour
        {
            get => _AddSelectedTour;
            set
            {
                _AddSelectedTour = value;
            }
        }
        private long _AddThanhTien;
        public long AddThanhTien { get => _AddThanhTien; set { _AddThanhTien = value; } }
        private DateTime? _AddThoiGianBatDau;
        public DateTime? AddThoiGianBatDau { get => _AddThoiGianBatDau; set { _AddThoiGianBatDau = value; } }
        private DateTime? _AddThoiGianKetThuc;
        public DateTime? AddThoiGianKetThuc { get => _AddThoiGianKetThuc; set { _AddThoiGianKetThuc = value; } }
        #endregion

        #region Các biến dùng để mở và đóng các view con

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ICommand Close_GiaThem { get; set; }
        public ICommand Save { get; set; }
        public ICommand Reset { get; set; }

        #endregion


        private ObservableCollection<GiaTour> _list;
        public ObservableCollection<GiaTour> List { get => _list; set { _list = value; } }
        private ObservableCollection<TourDuLich> _listTour;
        public ObservableCollection<TourDuLich> ListTour { get => _listTour; set { _listTour = value; } }
        public PriceViewModel()
        {

        }
        public PriceViewModel(IGiaTourService giaTourService, ITourDuLichService tourDuLichService)
        {
            this.giaTourService = giaTourService;
            this.tourDuLichService = tourDuLichService;
            List = new ObservableCollection<GiaTour>(this.giaTourService.GetDTOs());
            ListTour = new ObservableCollection<TourDuLich>(this.tourDuLichService.GetDTOs());
            #region Commands

            #region Add
            AddCommand = new RelayCommand<object>(p => { return true; }, p => { Add(); });
            Close_GiaThem = new RelayCommand<object>(p => { return true; }, p => { CloseThem(p); });

            //ViewChild
            //Reset
            Reset = new RelayCommand<object>(p => { return true; }, p => { AddThoiGianBatDau = null; AddThoiGianKetThuc = null; AddThanhTien = 0; AddSelectedTour = null; });

            //Save
            Save = new RelayCommand<object>(p =>
            {
                return AddThoiGianBatDau!=null&& AddThoiGianKetThuc != null && AddThanhTien > 0 && AddSelectedTour != null;
            }, p =>
            {
                try
                {
                    var dd = new GiaTour() { MaTour= AddSelectedTour.MaTour, ThoiGianBatDau= (DateTime)AddThoiGianBatDau, ThoiGianKetThuc = (DateTime)AddThoiGianKetThuc, ThanhTien = AddThanhTien };
                    giaTourService.Create(dd);
                    CloseThem(p);
                    MessageBox.Show($"Bạn đã thêm giá tour: Tour: {dd.MaTour} - Thời gian bắt đầu: {dd.ThoiGianBatDau} - Thời gian kết thúc: {dd.ThoiGianKetThuc} - Giá tiền: {dd.ThanhTien}");

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
                    return SelectedItem.ThanhTien != ThanhTien || SelectedItem.ThoiGianBatDau != ThoiGianBatDau || SelectedItem.ThoiGianKetThuc != ThoiGianKetThuc || SelectedItem.TourDuLich != SelectedTour;
                }
                return false;
            }, p =>
            {
                try
                {
                    var dd = new GiaTour() { MaGia = SelectedItem.MaGia, MaTour = SelectedTour.MaTour, ThoiGianBatDau = (DateTime)ThoiGianBatDau, ThoiGianKetThuc = (DateTime)ThoiGianKetThuc, ThanhTien = ThanhTien };
                    giaTourService.Update(dd);

                    int a = 0;
                    foreach (var i in List)
                    {
                        if (i.MaGia == dd.MaGia)
                        {
                            List.Remove(this.giaTourService.Get(dd.MaGia));
                            List.Insert(a, this.giaTourService.Get(dd.MaGia));
                            MessageBox.Show($"Bạn sửa gia Tour: Tour: {dd.TourDuLich.TenGoi}");

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
                    var dd = new GiaTour() { MaGia = SelectedItem.MaGia };
                    giaTourService.Delete(dd.MaGia);
                    foreach (var i in List)
                    {
                        if (i.MaGia == dd.MaGia)
                        {
                            List.Remove(i);
                            MaGia = 0;
                            ThoiGianBatDau = null;
                            ThoiGianKetThuc = null;
                            ThanhTien = 0;
                            SelectedTour = null;
                            MessageBox.Show($"Bạn đã xóa loại hình: Mã {i.MaGia}");
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
            Gia_Them x = new Gia_Them();
            x.DataContext = this;
            ListTour = new ObservableCollection<TourDuLich>(tourDuLichService.GetDTOs());
            MaGia = 0;
            ThoiGianBatDau = null;
            ThoiGianKetThuc = null;
            ThanhTien = 0;
            SelectedTour = null;
            x.ShowDialog();

        }
        private void CloseThem(object obj) 
        { 
            Gia_Them x = obj as Gia_Them; 
            List = new ObservableCollection<GiaTour>(giaTourService.GetDTOs());
            x.Close();
        }
    }
}
