using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Domain.Entities;
using Service.Interfaces;
using System.Windows.Input;
using TourDulich.View.AdminManager;
using TourDulich.View.AdminManagerView;
using System.Windows;

namespace TourDulich.ViewModel
{
    public class TourViewModel : BaseViewModel
    {
        public readonly ITourDuLichService tourDuLichService;
        public readonly ILoaiHinhDuLichService loaiHinhDuLichService;
        public readonly IDiemThamQuanService diemThamQuanService;
        public readonly IGiaTourService giaTourService;
        public readonly IDiaDiemService diaDiemService;


        #region màn hình chính
        public int MaTour { get; set; }
        public string TenGoi { get; set; }
        public string DacDiem { get; set; }
        public int MaLoaiHinh { get; set; }
        public string TenLoaiHinh { get; set; }
        private LoaiHinhDuLich _SelectedLHDL;
        public LoaiHinhDuLich SelectedLHDL
        {
            get => _SelectedLHDL;
            set
            {
                _SelectedLHDL = value;
            }
        }

        private TourDuLich _SelectedItem;
        public TourDuLich SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                if (SelectedItem != null)
                {
                    MaTour = SelectedItem.MaTour;
                    TenGoi = SelectedItem.TenGoi;
                    DacDiem = SelectedItem.DacDiem;
                    MaLoaiHinh = SelectedItem.MaLoaiHinh;

                    SelectedLHDL = SelectedItem.LoaiHinh;
                    //ListDiaDiem = new ObservableCollection<DiaDiem>(tourDuLichService.)
                }
            }
        }
        #endregion



        private ObservableCollection<TourDuLich> _List;
        public ObservableCollection<TourDuLich> ListTour { get => _List; set { _List = value; } }
        private ObservableCollection<LoaiHinhDuLich> _ListLHDL;
        public ObservableCollection<LoaiHinhDuLich> ListLHDL { get => _ListLHDL; set { _ListLHDL = value; } }
        private ObservableCollection<GiaTour> _ListGiaTour;
        public ObservableCollection<GiaTour>  ListGiaTour { get => _ListGiaTour; set { _ListGiaTour = value; } }
        private ObservableCollection<GiaTour> _ListGias;
        public ObservableCollection<GiaTour> ListGias { get => _ListGias; set { _ListGias = value; } }
        private ObservableCollection<DiemThamQuan> _ListDiaDiemThamQuan;
        public ObservableCollection<DiemThamQuan> ListDiaDiemThamQuan { get => _ListDiaDiemThamQuan; set { _ListDiaDiemThamQuan = value; } }
        private ObservableCollection<DiemThamQuan> _ListDiaDiemThamQuans_Temp;
        public ObservableCollection<DiemThamQuan> ListDiaDiemThamQuans_Temp { get => _ListDiaDiemThamQuans_Temp; set { _ListDiaDiemThamQuans_Temp = value; } }
        private ObservableCollection<DiaDiem> _ListDiaDiem;
        public ObservableCollection<DiaDiem> ListDiaDiem { get => _ListDiaDiem; set { _ListDiaDiem = value; } }



        #region Chức năng thêm Tour
        public ICommand AddTour { get; set; }
        public ICommand CloseTourAdd { get; set; }
        public ICommand ResetNew { get; set; }
        public ICommand SaveNew { get; set; }
        public string AddTenTour { get; set; }
        public string AddDacDiem { get; set; }

        private LoaiHinhDuLich _AddSelectedLHDL;
        public LoaiHinhDuLich AddSelectedLHDL
        {
            get => _AddSelectedLHDL;
            set
            {
                _AddSelectedLHDL = value;
            }
        }
        #endregion

        #region Chức năng chi tiết Tour
        public ICommand ChiTietTour { get; set; }
        public ICommand Close_TourChiTiet { get; set; }
        public ICommand TourThemGia { get; set; }
        public ICommand Close_GiaThem { get; set; }
        public ICommand TourXoaGia { get; set; }
        public ICommand EditDiaDiem { get; set; }
        public ICommand CloseEditDiaDiem { get; set; }
        private GiaTour _SelectedChooseGia;
        public GiaTour SelectedChooseGia { get => _SelectedChooseGia; set => _SelectedChooseGia = value; }
        public ICommand Undo { get; set; }
        public ICommand Agree { get; set; }
        private LoaiHinhDuLich _SelectedLHDLCT;
        public LoaiHinhDuLich SelectedLHDLCT
        {
            get => _SelectedLHDLCT;
            set
            {
                _SelectedLHDLCT = value;
            }
        }

        #region Chức năng thêm giá
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
        public ICommand Save { get; set; }
        public ICommand Reset { get; set; }
        #endregion

        #region Chức năng địa điểm tham quan
        public ICommand AddLocation { get; set; }
        public ICommand RemoveLocation { get; set; }
        public ICommand ResetLocations { get; set; }
        public ICommand SaveLocations { get; set; }

        private DiaDiem _SelectedChoosedDiaDiem;
        public DiaDiem SelectedChoosedDiaDiem
        {
            get => _SelectedChoosedDiaDiem;
            set
            {
                _SelectedChoosedDiaDiem = value;
            }
        }
        private DiemThamQuan _SelectedChoosedDiaDiemThamQuans;
        public DiemThamQuan SelectedChoosedDiaDiemThamQuans
        {
            get => _SelectedChoosedDiaDiemThamQuans;
            set
            {
                _SelectedChoosedDiaDiemThamQuans = value;
            }
        }
        #endregion
        #endregion
        public TourViewModel() { }
        public TourViewModel(ITourDuLichService tourDuLichService, ILoaiHinhDuLichService loaiHinhDuLichService, IGiaTourService giaTourService, IDiemThamQuanService diemThamQuanService, IDiaDiemService diaDiemService)
        {
            this.tourDuLichService = tourDuLichService;
            this.loaiHinhDuLichService = loaiHinhDuLichService;
            this.diemThamQuanService = diemThamQuanService;
            this.giaTourService = giaTourService;
            this.diaDiemService = diaDiemService;
            ListTour = new ObservableCollection<TourDuLich>(this.tourDuLichService.GetDTOs());
            ListLHDL = new ObservableCollection<LoaiHinhDuLich>(this.loaiHinhDuLichService.GetDTOs());


            //// Commands  -  Add - Edit - Delete - ...... //
            #region Commands
            AddTour = new RelayCommand<object>(p => { return true; }, p => { Add(); });
            Addnew();
            CloseTourAdd = new RelayCommand<object>(p => { return true; }, p => { CloseAdd(p); });

            ChiTietTour = new RelayCommand<object>(p => { return SelectedItem != null; }, p => { ShowCT(); });
            Undo_Agree();
            deletePrice();
            Close_TourChiTiet = new RelayCommand<object>(p => { return true; }, p => { CloseCT(p); });

            TourThemGia = new RelayCommand<object>(p => { return SelectedItem != null; }, p => { AddGiaTour(); });
            addNewPrice();
            Close_GiaThem = new RelayCommand<object>(p => { return SelectedItem != null; }, p => { CloseAddGiaTour(p); });
            EditDiaDiem = new RelayCommand<object>(p => { return SelectedItem != null; }, p => { ShowDDTQ(); });
            add_Remove();
            CloseEditDiaDiem = new RelayCommand<object>(p => { return SelectedItem != null; }, p => { CloseDDTQ(p); });

            #endregion
        }

        

        #region Thêm tour mới
        private void Add() 
        { 
            TourManagerAdd x = new TourManagerAdd();
            x.DataContext = this; 
            x.ShowDialog();
        }
        private void Addnew()
        {
            //Reset
            ResetNew = new RelayCommand<TourManagerAdd>(p => { return true; }, p => { AddTenTour = null; AddSelectedLHDL = null; AddDacDiem = null;});

            //Save
            SaveNew = new RelayCommand<TourManagerAdd>(p =>
            {
                return !string.IsNullOrEmpty(AddTenTour) && AddSelectedLHDL != null && AddDacDiem != null;
            }, p =>
            {
                try
                {
                    var tdl = new TourDuLich() { TenGoi = AddTenTour, MaLoaiHinh = AddSelectedLHDL.MaLoaiHinh, DacDiem = AddDacDiem };
                    if (tourDuLichService.Create(tdl))
                    {
                        CloseAdd(p);
                        MessageBox.Show($"Bạn đã thêm tour du lịch mới: Tên tour {tdl.TenGoi} - Đặc điểm {tdl.DacDiem}");
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi ở thêm Đoàn Du Lịch");
                }

            });
        }
        private void CloseAdd(object obj) 
        { 
            TourManagerAdd x = obj as TourManagerAdd;
            x.Close();
            AddTenTour = null;
            AddSelectedLHDL = null;
            AddDacDiem = null;
            ListTour = new ObservableCollection<TourDuLich>(tourDuLichService.GetDTOs());
        }
        #endregion

        #region Chi tiết Tour
        private void ShowCT()
        {
            TourManager_ChiTiet x = new TourManager_ChiTiet();
            x.DataContext = this;
            ListGiaTour = new ObservableCollection<GiaTour>(giaTourService.GetDTOsByMaTour(SelectedItem.MaTour).ToList());
            //ListDiaDiemThamQuan = new ObservableCollection<DiemThamQuan>(...);
            SelectedLHDLCT = SelectedItem.LoaiHinh;
            x.ShowDialog();
            
        }
        private void Undo_Agree()
        {
            Undo = new RelayCommand<DoanDuLich_ChiTiet>(p =>
            {
                return SelectedItem != null && (SelectedItem.TenGoi != TenGoi || SelectedItem.DacDiem != DacDiem || SelectedItem.LoaiHinh.TenLoaiHinh != SelectedLHDLCT.TenLoaiHinh);
            }, p =>
            {
                TenGoi = SelectedItem.TenGoi;
                DacDiem = SelectedItem.DacDiem;
                SelectedLHDLCT = SelectedItem.LoaiHinh;
            });

            Agree = new RelayCommand<DoanDuLich_ChiTiet>(p =>
            {
                return SelectedItem != null && (SelectedItem.TenGoi != TenGoi || SelectedItem.DacDiem != DacDiem || SelectedItem.LoaiHinh.TenLoaiHinh != SelectedLHDLCT.TenLoaiHinh);
            }, p =>
            {
                try
                {
                    var tdl = new TourDuLich() { TenGoi = TenGoi, DacDiem = DacDiem, MaTour = SelectedItem.MaTour, MaLoaiHinh = SelectedLHDLCT.MaLoaiHinh };
                    tourDuLichService.Update(tdl);
                    MessageBox.Show("Lưu thành công!");
                }
                catch
                {
                    MessageBox.Show("Lỗi ở hàm Undo_Agree!");

                }
            });
        }
        private void CloseCT(object obj)
        {
            TourManager_ChiTiet x = obj as TourManager_ChiTiet;
            x.Close();
            ListTour = new ObservableCollection<TourDuLich>(this.tourDuLichService.GetDTOs());
            SelectedChooseGia = null;
        }

        #region Chi tiết Tour - Thêm giá
        private void AddGiaTour()
        {
            Gia_Them x = new Gia_Them();
            x.DataContext = this;
            AddSelectedTour = SelectedItem;
            AddThoiGianBatDau = null;
            AddThoiGianKetThuc = null;
            AddThanhTien = 0;
            x.listtour.IsEnabled = false;
            x.listtour.IsEditable = false;
            x.ShowDialog();
        }
        private void addNewPrice()
        {
            Reset = new RelayCommand<object>(p => { return true; }, p => { AddThoiGianBatDau = null; AddThoiGianKetThuc = null; AddThanhTien = 0;});

            //Save
            Save = new RelayCommand<object>(p =>
            {
                return AddThoiGianBatDau != null && AddThoiGianKetThuc != null && AddThanhTien > 0 && AddSelectedTour != null;
            }, p =>
            {
                try
                {
                    var dd = new GiaTour() { MaTour = AddSelectedTour.MaTour, ThoiGianBatDau = (DateTime)AddThoiGianBatDau, ThoiGianKetThuc = (DateTime)AddThoiGianKetThuc, ThanhTien = AddThanhTien };
                    giaTourService.Create(dd);
                    CloseAddGiaTour(p);
                    MessageBox.Show($"Bạn đã thêm giá tour: Thời gian bắt đầu: {dd.ThoiGianBatDau} - Thời gian kết thúc: {dd.ThoiGianKetThuc} - Giá tiền: {dd.ThanhTien}");

                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
            });
        }
        private void CloseAddGiaTour(object obj)
        {
            Gia_Them x = obj as Gia_Them;
            x.Close();
            ListGiaTour = new ObservableCollection<GiaTour>(giaTourService.GetDTOsByMaTour(SelectedItem.MaTour).ToList());
        }
        #endregion

        #region Chi tiết Tour - Xóa giá
        private void deletePrice()
        {
            //Vẫn chưa thực hiện chức năng xóa giá. Vì có những đoàn đang sử dụng giá tour này
            TourXoaGia = new RelayCommand<object>(p => { return SelectedChooseGia != null; }, p => {
                var dd = new GiaTour() { MaGia = SelectedChooseGia.MaGia };
                giaTourService.Delete(dd.MaGia);
                ListGiaTour = new ObservableCollection<GiaTour>(giaTourService.GetDTOsByMaTour(SelectedItem.MaTour).ToList());
            });
        }
        #endregion

        #region Chi tiết Tour - Chỉnh sửa địa điểm tham quan
        private void ShowDDTQ() 
        { 
            TourManager_Edit_DiaDiemThamQuan x = new TourManager_Edit_DiaDiemThamQuan();
            x.DataContext = this;
            ListDiaDiem = new ObservableCollection<DiaDiem>(this.diaDiemService.GetDTOs());
            ListDiaDiemThamQuans_Temp = ListDiaDiemThamQuan;
            x.ShowDialog();
        }
        private void add_Remove()
        {
            AddLocation = new RelayCommand<object>(p => 
            { 
                if( SelectedChoosedDiaDiem != null && ListDiaDiemThamQuans_Temp.Count() == 0)
                {
                    return true;
                } 
                else if ( SelectedChoosedDiaDiem != null && ListDiaDiemThamQuans_Temp.Count() > 0)
                {
                    foreach(var i in ListDiaDiemThamQuans_Temp){if (i.MaDiaDiem == SelectedChoosedDiaDiem.MaDiaDiem) return false;} return true;
                }
                return false;
            }, p => 
            {
                //if (ListDiaDiemThamQuans_Temp.Count() > 0) SelectedChoosedDiaDiemThamQuans = null;
                
                //Khởi tạo đối tượng mới không được

                //var ddtq = new DiemThamQuan(MaTour = SelectedItem.MaTour, MaDiaDiem = SelectedChoosedDiaDiem.MaDiaDiem, ThuTu = ListDiaDiemThamQuans_Temp.Count()+1);
                //ListDiaDiemThamQuans_Temp.Add(ddtq);
            });
            RemoveLocation = new RelayCommand<object>(p =>
            {
                if (SelectedChoosedDiaDiemThamQuans != null) return true;
                return false;
            }, p =>
            {
                SelectedChoosedDiaDiem = null;
                //Khởi tạo đối tượng mới không được

                //var ddtq = new DiemThamQuan(MaTour = SelectedItem.MaTour, MaDiaDiem = SelectedChoosedDiaDiem.MaDiaDiem);
                //ListDiaDiemThamQuans_Temp.Remove(ddtq);

            });
            //Load danh sách lại như ban đầu
            ResetLocations = new RelayCommand<object>(p =>
            {
                if (ListDiaDiemThamQuans_Temp != ListDiaDiemThamQuan) return true;
                return false;
            }, p =>
            {
                ListDiaDiemThamQuans_Temp = ListDiaDiemThamQuan;
            });
            //Lưu danh sách mới
            SaveLocations = new RelayCommand<object>(p =>
            {
                if (ListDiaDiemThamQuans_Temp != ListDiaDiemThamQuan) return true;
                return false;
            }, p =>
            {
                //foreach (var i in ListDiaDiemThamQuan) diemThamQuanService.Delete(i);
                if (ListDiaDiemThamQuans_Temp.Count() > 0)
                {
                    foreach (var i in ListDiaDiemThamQuans_Temp) diemThamQuanService.Create(i);
                }
                MessageBox.Show("Danh sách các địa điểm tham quan đã được lưu thành công!");
            });
        }
        private void CloseDDTQ(object obj) 
        {
            TourManager_Edit_DiaDiemThamQuan x = obj as TourManager_Edit_DiaDiemThamQuan;
            //ListDiaDiemThamQuan = new ObservableCollection<DiemThamQuan>(...);
            x.Close();
            SelectedChoosedDiaDiem = null;
            SelectedChoosedDiaDiemThamQuans = null;
        }
        #endregion
        #endregion
    }
}
