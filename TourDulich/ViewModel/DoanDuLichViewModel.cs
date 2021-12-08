﻿using Domain.Entities;
using Domain.Entities.Enum;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        private readonly IPhanBoNhanVienDoanService phanBoNhanVienDoanService;
        private readonly INoiDungTourService noiDungTourService;
        private readonly IChiPhiService chiPhiService;
        private readonly ILoaiChiPhiService loaiChiPhiService;

        private readonly IKhachService khachService;
        private readonly IChiTietDoanService chiTietDoanService;
        #endregion

        #region Biến của các ô con để lấy dữ liệu được tham chiếu

        #region màn hình chính
        public int MaDoan { get; set; }
        public string TenDoan { get; set; }
        public DateTime? NgayKhoiHanh { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public long DoanhThu { get; set; }
        public TourDuLich SelectedTour { get; set; }
        public NoiDungTour? SelectedNoiDungTour { get; set; }
        #endregion


        #region Lấy giá trị     NHÂN VIÊN     được chọn tham chiếu qua các ô cần dùng
        public int MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string NhiemVu { get; set; }
        private NhanVien? _SelectedItemNhanVien;
        public NhanVien? SelectedItemNhanVien
        {
            get => _SelectedItemNhanVien;
            set
            {
                _SelectedItemNhanVien = value;
                if (SelectedItemNhanVien != null)
                {
                    MaNhanVien = SelectedItemNhanVien.MaNhanVien;
                    TenNhanVien = SelectedItemNhanVien.TenNhanVien;
                }
            }
        }

        public ICommand AddNVn { get; set; }
        public ICommand AddNV { get; set; }

        #endregion

        #region Lấy giá trị     KHÁCH HÀNG     được chọn tham chiếu qua các ô cần dùng
        public int MaKhachHang { get; set; }
        public string HoTen { get; set; }
        public string SDT { get; set; }
        public VaiTro Vaitro { get; set; }
        public VaiTro AddVaiTro { get; set; }

        private Khach? _SelectedItemKhach;
        public Khach? SelectedItemKhach
        {
            get => _SelectedItemKhach;
            set
            {
                _SelectedItemKhach = value;
                if (SelectedItemKhach != null)
                {
                    MaKhachHang = SelectedItemKhach.MaKhachHang;
                    HoTen = SelectedItemKhach.HoTen;
                    SDT = SelectedItemKhach.SDT;
                    Vaitro = SelectedItemKhach.VaiTro;
                }
            }
        }

        public ICommand AddKHn { get; set; }
        public ICommand AddKH { get; set; }

        #endregion

        #region Lấy giá trị     CHI PHIS     được chọn tham chiếu qua các ô cần dùng
        public int MaLoaiChiPhi { get; set; }
        public string TenLoaiChiPhi { get; set; }
        public long SoTien { get; set; }


        private LoaiChiPhi _SelectedItemLoaiChiPhi;
        public LoaiChiPhi SelectedItemLoaiChiPhi
        {
            get => _SelectedItemLoaiChiPhi;
            set
            {
                _SelectedItemLoaiChiPhi = value;
                if (_SelectedItemLoaiChiPhi != null)
                {
                    MaLoaiChiPhi = _SelectedItemLoaiChiPhi.MaLoaiChiPhi;
                    TenLoaiChiPhi = _SelectedItemLoaiChiPhi.TenLoaiChiPhi;
                }
            }
        }

        public ICommand AddCPn { get; set; }
        public ICommand AddCP { get; set; }
        #endregion

        public PhanBoNhanVienDoan? SelectedChooseNV { get; set; }
        public ChiTietDoan? SelectedChooseKH { get; set; }
        public Domain.Entities.ChiPhi SelectedChooseCP { get; set; }
        public ICollection<PhanBoNhanVienDoan> SelectedPhanBoNhanVienDoan { get; set; }
        ICollection<ChiTietDoan> SelectedPhanBoKhach { get; set; }
        public ICollection<Domain.Entities.ChiPhi> SelectedChiPhi { get; set; }

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
                    NgayKhoiHanh = SelectedItem.NgayKhoiHanh;
                    NgayKetThuc = SelectedItem.NgayKetThuc;
                    DoanhThu = SelectedItem.DoanhThu;
                    SelectedTour = SelectedItem.Tour;
                    SelectedNoiDungTour = SelectedItem.NoiDungTour;
                }
            }
        }

        #endregion

        #region Các biến chức năng trong Thêm Đoàn
        public string AddTenDoan { get; set; }
        public TourDuLich AddSelectedTour { get; set; }
        public DateTime? AddNgayKhoiHanh { get; set; }
        public DateTime? AddNgayKetThuc { get; set; }
        public string AddKhachSan { get; set; }
        public string AddHanhTrinh { get; set; }
        public string AddDiemThamQuan { get; set; }
        public ICommand Reset { get; set; }
        public ICommand Save { get; set; }
        #endregion


        #region Danh sách Đoàn, Tour, Nhân viên, Chi phí, Khách hàng
        public ObservableCollection<TourDuLich> ListTour { get; set; }
        public ObservableCollection<NhanVien> ListNhanvien { get; set; }
        public ObservableCollection<DoanDuLich> ListGroup { get; set; }
        public ObservableCollection<NoiDungTour> ListNoiDung { get; set; }
        public ObservableCollection<Domain.Entities.ChiPhi> ListChiPhi { get; set; }
        public ObservableCollection<LoaiChiPhi> listLoaiChiPhi { get; set; }
        public ObservableCollection<Khach> ListKhach { get; set; }
        public ObservableCollection<ChiTietDoan> ListChiTietDoan { get; set; }
        #endregion

        #region Các biến dùng để mở và đóng các view con

        public ICommand AddCommand { get; set; }
        public ICommand ShowCommand { get; set; }
        public ICommand DoanThemNV { get; set; }
        public ICommand DoanXoaNV { get; set; }
        public ICommand DoanThemKH { get; set; }
        public ICommand DoanXoaKH { get; set; }
        public ICommand DoanThemCP { get; set; }
        public ICommand DoanXoaCP { get; set; }
        public ICommand Close_DoanThem { get; set; }
        public ICommand Close_DoanThemNV { get; set; }
        public ICommand Close_DoanThemKH { get; set; }
        public ICommand Close_DoanThemCP { get; set; }
        public ICommand Close_DoanChiTiet { get; set; }

        #endregion
        public DoanDuLichViewModel() { }

        public DoanDuLichViewModel(IDoanDuLichService doanDuLichService, ITourDuLichService tourDuLichService, INhanVienService nhanVienService, INoiDungTourService noiDungTourService, IChiPhiService chiPhiService, IKhachService khachService, IPhanBoNhanVienDoanService phanBoNhanVienDoanService, IChiTietDoanService chiTietDoanService, ILoaiChiPhiService loaiChiPhiService) {
            this.doanDuLichService = doanDuLichService;
            this.tourDuLichService = tourDuLichService;
            this.nhanVienService = nhanVienService;
            this.noiDungTourService = noiDungTourService;
            this.khachService = khachService;
            this.chiPhiService = chiPhiService;
            this.loaiChiPhiService = loaiChiPhiService;
            this.phanBoNhanVienDoanService = phanBoNhanVienDoanService;
            this.chiTietDoanService = chiTietDoanService;

            ListGroup = new ObservableCollection<DoanDuLich>(this.doanDuLichService.GetDTOs());
            ListTour = new ObservableCollection<TourDuLich>(this.tourDuLichService.GetDTOs());

            #region Thực hiện các chức năng
            // Thêm //
            
            AddCommand = new RelayCommand<object>(p => { return true; }, p => { Add(); });
            AddNew();
            Close_DoanThem = new RelayCommand<object>(p => { return true; }, p => {AddNew(); CloseThem(p); });


            // Hiện chi tiết //
            ShowCommand = new RelayCommand<object>(p => { return true; }, p => { Show(); });
            //DoanXoaNhanVien();
            //DoanXoaKhachHang();
            DoanXoaChiPhi();
            Close_DoanChiTiet = new RelayCommand<object>(p => { return true; }, p => { CloseChiTiet(p); });

            // Hiện chi tiết - Thêm nhân viên //
            DoanThemNV = new RelayCommand<object>(p => { return true; }, p => { ShowThemNV(p); });
            DoanThemNhanVien();
            Close_DoanThemNV = new RelayCommand<object>(p => { return true; }, p => { CloseThemNV(p); Show(); });
            
            // Hiện chi tiết - Thêm khách hàng //
            DoanThemKH = new RelayCommand<object>(p => { return true; }, p => { ShowThemKH(p); });
            DoanThemKhachHang();
            Close_DoanThemKH = new RelayCommand<object>(p => { return true; }, p => { CloseThemKH(p); Show(); });

            // Hiện chi tiết - Thêm chi phí //
            DoanThemCP = new RelayCommand<object>(p => { return true; }, p => { ShowThemCP(p); });
            DoanThemChiPhi();
            Close_DoanThemCP = new RelayCommand<object>(p => { return true; }, p => { CloseThemCP(p); Show(); });

            #endregion
        }

        #region Open View Child

        #region Hàm thực hiện chức năng Thêm đoàn
        //Thêm Đoàn
        private void Add() 
        {
            DoanDuLich_Them x = new DoanDuLich_Them();
            x.DataContext = this;
            x.ShowDialog();
        }
        private void AddNew()
        {
            //ViewChild
            //Reset
            Reset = new RelayCommand<DoanDuLich_Them>(p => { return true; }, p => { AddTenDoan = null; AddSelectedTour = null; AddNgayKhoiHanh = null; AddNgayKetThuc = null; AddKhachSan = null; AddHanhTrinh = null; AddDiemThamQuan = null; });

            //Save
            Save = new RelayCommand<DoanDuLich_Them>(p =>
            {
                return !string.IsNullOrEmpty(AddTenDoan) && AddSelectedTour != null && AddNgayKhoiHanh != null && AddNgayKetThuc != null && !string.IsNullOrEmpty(AddKhachSan) && !string.IsNullOrEmpty(AddHanhTrinh) && !string.IsNullOrEmpty(AddDiemThamQuan);
            }, p =>
            {
                //try
                //{
                    var ddl = new DoanDuLich() { TenDoan = AddTenDoan, MaTour = AddSelectedTour.MaTour, NgayKhoiHanh = (DateTime)AddNgayKhoiHanh, NgayKetThuc = (DateTime)AddNgayKetThuc };
                    if (doanDuLichService.Create(ddl))
                    {
                        var ndt = new NoiDungTour() { KhachSan = AddKhachSan, HanhTrinh = AddHanhTrinh, DiaDiemThamQuan = AddDiemThamQuan, MaDoan = this.doanDuLichService.Get(ddl.MaDoan).MaDoan };
                        if (noiDungTourService.Create(ndt))
                        {
                        //ddl.NoiDungTour = ndt;
                            //ListGroup.Add(this.doanDuLichService.Get(ddl.MaDoan));
                            CloseThem(p);
                            MessageBox.Show($"Bạn đã thêm đoàn du lịch mới: Tên đoàn {ddl.TenDoan} - Ngày khởi hành: {ddl.NgayKhoiHanh} - Ngày kết thúc: {ddl.NgayKetThuc}");
                        }
                    }
                //}
                //catch
                //{
                //    MessageBox.Show("Lỗi ở thêm Đoàn Du Lịch");
                //}
                
            });
        }
        private void CloseThem(object obj) 
        { 
            DoanDuLich_Them x = obj as DoanDuLich_Them; 
            x.Close();
            AddTenDoan = null;
            AddSelectedTour = null;
            AddNgayKhoiHanh = null;
            AddNgayKetThuc = null;
            AddKhachSan = null;
            SelectedItem = null;
            AddHanhTrinh = null;
            AddDiemThamQuan = null;
            ListGroup = new ObservableCollection<DoanDuLich>(doanDuLichService.GetDTOs());
        }
        #endregion

        #region Bên trong Chi Tiết Đoàn

        #region Chi tiết chính
        private void Show()
        {
            DoanDuLich_ChiTiet x = new DoanDuLich_ChiTiet();
            x.DataContext = this;
            SelectedPhanBoNhanVienDoan = SelectedItem.PhanBoNhanVienDoans;
            SelectedPhanBoKhach = SelectedItem.ChiTietDoans;
            SelectedChiPhi = SelectedItem.ChiPhis;
            x.ShowDialog();
        }
        private void CloseChiTiet(object obj) 
        { 
            DoanDuLich_ChiTiet x = obj as DoanDuLich_ChiTiet;
            x.Close(); 
            SelectedPhanBoNhanVienDoan = null;
            SelectedPhanBoKhach = null;
            SelectedChiPhi = null;
        }
        #endregion

        #region Thêm nhân viên vô đoàn
        
        private void ShowThemNV(object p) 
        {
            CloseChiTiet(p);
            DoanDuLich_ThemNhanVien x = new DoanDuLich_ThemNhanVien();
            x.DataContext = this;
            ListNhanvien = new ObservableCollection<NhanVien>(nhanVienService.GetDTOs());
            x.ShowDialog();
        }
        private void DoanThemNhanVien()
        {
            AddNV = new RelayCommand<DoanDuLich_ThemNhanVien>(p =>
            {
                if (SelectedItemNhanVien != null)
                {
                    /*if (SelectedItem.PhanBoNhanVienDoans.Count() == 0) return true;
                    else
                    {
                        foreach (var i in SelectedItem.PhanBoNhanVienDoans)
                        {
                            if (SelectedItemNhanVien.MaNhanVien == i.MaNhanVien) { return false; }
                        }
                        return true;
                    }*/
                    return SelectedItem.PhanBoNhanVienDoans.Any(x => x.MaNhanVien == SelectedItemNhanVien.MaNhanVien);
                }
                else
                {
                    return MaNhanVien != 0 && !string.IsNullOrEmpty(TenNhanVien) && !string.IsNullOrEmpty(NhiemVu);
                }
            }, p =>
            {
                try
                {
                    var pbnv = new PhanBoNhanVienDoan() { MaDoan = this.doanDuLichService.Get(SelectedItem.MaDoan).MaDoan, MaNhanVien = SelectedItemNhanVien.MaNhanVien, NhiemVu = NhiemVu };
                    if (phanBoNhanVienDoanService.Create(pbnv))
                    {
                        pbnv.NhanVien = SelectedItemNhanVien;
                        CloseThemNV(p);
                        MessageBox.Show($"Bạn đã thêm nhân viên: Tên nhân viên {TenNhanVien} - Nhiệm vụ: {pbnv.NhiemVu} ");
                        var ddl1 = this.doanDuLichService.Get(SelectedItem.MaDoan);
                        ddl1.PhanBoNhanVienDoans.Add(pbnv);
                        Show();

                        int a = 0;
                        foreach (var i in ListGroup)
                        {
                            if (i.MaDoan == ddl1.MaDoan)
                            {
                                ListGroup.Remove(this.doanDuLichService.Get(SelectedItem.MaDoan));
                                ListGroup.Insert(a, this.doanDuLichService.Get(ddl1.MaDoan));
                                SelectedItem = ddl1;
                                SelectedItemNhanVien = null;
                                break;
                            }
                            else
                            {
                                a++;
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi ở thêm NHÂN VIÊN - Đoàn Du Lịch");
                }

            });
            AddNVn = new RelayCommand<DoanDuLich_ThemNhanVien>(p =>
            {
                if (SelectedItemNhanVien != null)
                {
                    return SelectedItem.PhanBoNhanVienDoans.Any(x => x.MaNhanVien == SelectedItemNhanVien.MaNhanVien);

                }
                else
                {
                    return MaNhanVien != 0 && !string.IsNullOrEmpty(TenNhanVien) && !string.IsNullOrEmpty(NhiemVu);
                }
            }, p =>
            {
                try
                {
                    var pbnv = new PhanBoNhanVienDoan() { MaDoan = this.doanDuLichService.Get(SelectedItem.MaDoan).MaDoan, MaNhanVien = SelectedItemNhanVien.MaNhanVien, NhiemVu = NhiemVu };
                    if (phanBoNhanVienDoanService.Create(pbnv))
                    {
                        //pbnv.NhanVien = SelectedItemNhanVien;
                        MessageBox.Show($"Bạn đã thêm nhân viên: Tên nhân viên {TenNhanVien} - Nhiệm vụ: {SelectedItemNhanVien.NhiemVu} ");


                        var ddl1 = this.doanDuLichService.Get(SelectedItem.MaDoan);
                        ddl1.PhanBoNhanVienDoans.Add(pbnv);
                        int a = 0;
                        foreach (var i in ListGroup)
                        {
                            if (i.MaDoan == ddl1.MaDoan)
                            {
                                ListGroup.Remove(this.doanDuLichService.Get(SelectedItem.MaDoan));
                                ListGroup.Insert(a, this.doanDuLichService.Get(ddl1.MaDoan));
                                SelectedItem = ddl1;
                                SelectedItemNhanVien = null;

                                break;
                            }
                            else
                            {
                                a++;
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi ở thêm NHÂN VIÊN - Đoàn Du Lịch");
                }     
            });
        }
        private void DoanXoaNhanVien()
        {
            //DoanXoaNV = new RelayCommand<DoanDuLich_ChiTiet>(p =>
            //{
            //    return SelectedChooseNV!=null;
            //}, p =>
            //{
            //    var pbnv = new PhanBoNhanVienDoan() { MaDoan = SelectedChooseNV.MaDoan, MaNhanVien = SelectedChooseNV.MaNhanVien, NhiemVu = SelectedChooseNV.NhiemVu };
            //    //phanBoNhanVienDoanService.Delete(pbnv.MaDoan,pbnv.MaNhanVien);


            //    MessageBox.Show($"Bạn đã xóa nhân viên: Tên nhân viên {TenNhanVien} - Nhiệm vụ: {pbnv.NhiemVu} ");
            //    var ddl1 = SelectedItem;
            //    ddl1.PhanBoNhanVienDoans.Remove(pbnv);

            //    int a = 0;
            //    foreach (var i in ListGroup)
            //    {
            //        if (i.MaDoan == ddl1.MaDoan)
            //        {
            //            ListGroup.Remove(i);
            //            SelectedItem = null;
            //            ListGroup.Insert(a, ddl1);
            //            SelectedItem = ddl1;
            //            break;
            //        }
            //        else
            //        {
            //            a++;
            //        }
            //    }
            //    //phanBoNhanVienDoanService.Create(pbnv);

            //}
            //);
        }
        private void CloseThemNV(object obj) 
        { 
            DoanDuLich_ThemNhanVien x = obj as DoanDuLich_ThemNhanVien;
            x.Close();
            SelectedItemNhanVien = null;
            NhiemVu = null;
            SelectedPhanBoNhanVienDoan = SelectedItem.PhanBoNhanVienDoans;

        }
        #endregion

        #region Thêm khách hàng vô đoàn
        private void ShowThemKH(object p) 
        {
            CloseChiTiet(p);
            DoanDuLich_ThemKhachHang x = new DoanDuLich_ThemKhachHang();
            x.DataContext = this;
            ListKhach = new ObservableCollection<Khach>(this.khachService.GetDTOs());
            x.ShowDialog(); 
        }
        private void DoanThemKhachHang()
        {
            AddKH = new RelayCommand<DoanDuLich_ThemKhachHang>(p =>
            {
                if (SelectedItemKhach != null)
                {
                    return SelectedItem.ChiTietDoans.Any(x => x.MaKhachHang == SelectedItemKhach.MaKhachHang);
                }
                else
                {
                    return MaKhachHang != 0 && !string.IsNullOrEmpty(HoTen) && !string.IsNullOrEmpty(SDT);
                }
            }, p =>
            {
                /*try
                {*/
                    var ctd = new ChiTietDoan() { MaDoan = this.doanDuLichService.Get(SelectedItem.MaDoan).MaDoan, MaKhachHang = SelectedItemKhach.MaKhachHang, VaiTro = AddVaiTro };
                    if (chiTietDoanService.Create(ctd))
                    {
                        ctd.Khach = SelectedItemKhach;
                        CloseThemKH(p);
                        MessageBox.Show($"Bạn đã thêm khách hàng: Tên khách hàng {HoTen}");

                        var ddl1 = doanDuLichService.Get(SelectedItem.MaDoan);
                        ddl1.ChiTietDoans.Add(ctd);
                        Show();

                        int a = 0;
                        foreach (var i in ListGroup)
                        {
                            if (i.MaDoan == ddl1.MaDoan)
                            {
                                ListGroup.Remove(this.doanDuLichService.Get(SelectedItem.MaDoan));
                                ListGroup.Insert(a, this.doanDuLichService.Get(ddl1.MaDoan));
                                SelectedItem = ddl1;
                                SelectedItemKhach = null;
                                break;
                            }
                            else
                            {
                                a++;
                            }
                        }
                    }
                /*}
                catch
                {
                    MessageBox.Show("Lỗi ở thêm KHÁCH HÀNG - Đoàn Du Lịch");
                }*/ 
            });
            AddKHn = new RelayCommand<DoanDuLich_ThemKhachHang>(p =>
            {

                if (SelectedItemKhach != null)
                {
                    return SelectedItem.ChiTietDoans.Any(x => x.MaKhachHang == SelectedItemKhach.MaKhachHang);
                }
                else
                {
                    return MaKhachHang != 0 && !string.IsNullOrEmpty(HoTen) && !string.IsNullOrEmpty(SDT);
                }
            }, p =>
            {
                /*try
                {*/
                    var ctd = new ChiTietDoan() { MaDoan = this.doanDuLichService.Get(SelectedItem.MaDoan).MaDoan, MaKhachHang = SelectedItemKhach.MaKhachHang, VaiTro = AddVaiTro };
                    if (chiTietDoanService.Create(ctd))
                    {
                        ctd.Khach = SelectedItemKhach;
                        MessageBox.Show($"Bạn đã thêm khách hàng: Tên khách hàng {HoTen}");
                        var ddl1 = this.doanDuLichService.Get(SelectedItem.MaDoan);
                        ddl1.ChiTietDoans.Add(ctd);
                        int a = 0;
                        foreach (var i in ListGroup)
                        {
                            if (i.MaDoan == ddl1.MaDoan)
                            {
                                ListGroup.Remove(this.doanDuLichService.Get(SelectedItem.MaDoan));
                                ListGroup.Insert(a, this.doanDuLichService.Get(ddl1.MaDoan));
                                SelectedItem = ddl1;
                                SelectedItemKhach = null;

                                break;
                            }
                            else
                            {
                                a++;
                            }
                        }
                    }
                /*}
                catch
                {
                    MessageBox.Show("Lỗi ở thêm KHÁCH HÀNG - Đoàn Du Lịch");
                }*/
            });
        }
        private void DoanXoaKhachHang() { }
        private void CloseThemKH(object obj) 
        { 
            DoanDuLich_ThemKhachHang x = obj as DoanDuLich_ThemKhachHang; 
            x.Close();
            SelectedItemKhach = null;
        }
        #endregion

        #region Thêm chi phí vô đoàn
        private void ShowThemCP(object p) 
        {
            CloseChiTiet(p);
            DoanDuLich_ThemChiPhi x = new DoanDuLich_ThemChiPhi(); 
            x.DataContext = this;
            listLoaiChiPhi = new ObservableCollection<LoaiChiPhi>(this.loaiChiPhiService.GetDTOs());
            x.ShowDialog(); 
        }
        private void DoanThemChiPhi()
        {
            AddCP = new RelayCommand<DoanDuLich_ThemChiPhi>(p =>
            {
                return MaLoaiChiPhi != 0 && !string.IsNullOrEmpty(TenLoaiChiPhi) && SoTien > 0;
            }, p =>
            {
                try
                {
                    var cp = new Domain.Entities.ChiPhi() { MaDoan = this.doanDuLichService.Get(SelectedItem.MaDoan).MaDoan, MaLoaiChiPhi = SelectedItemLoaiChiPhi.MaLoaiChiPhi, SoTien = SoTien };
                    if (chiPhiService.Create(cp))
                    {
                        cp.LoaiChiPhi = SelectedItemLoaiChiPhi;
                        CloseThemCP(p);
                        MessageBox.Show($"Bạn đã thêm chi phí: Tên chi phí {cp.LoaiChiPhi.TenLoaiChiPhi} - Số tiền: {SoTien}");
                        Show();
                        var ddl1 = this.doanDuLichService.Get(SelectedItem.MaDoan);
                        ddl1.ChiPhis.Add(cp);
                        int a = 0;
                        foreach (var i in ListGroup)
                        {
                            if (i.MaDoan == ddl1.MaDoan)
                            {
                                ListGroup.Remove(this.doanDuLichService.Get(SelectedItem.MaDoan));
                                ListGroup.Insert(a, this.doanDuLichService.Get(ddl1.MaDoan));
                                SelectedItem = ddl1;
                                break;
                            }
                            else
                            {
                                a++;
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi ở thêm CHI PHÍ - Đoàn Du Lịch");
                }
                
            });
            AddCPn = new RelayCommand<DoanDuLich_ThemChiPhi>(p =>
            {
                return MaLoaiChiPhi != 0 && !string.IsNullOrEmpty(TenLoaiChiPhi) && SoTien >0;
            }, p =>
            {
                try
                {
                    var cp = new Domain.Entities.ChiPhi() { MaDoan = this.doanDuLichService.Get(SelectedItem.MaDoan).MaDoan, MaLoaiChiPhi = SelectedItemLoaiChiPhi.MaLoaiChiPhi, SoTien = SoTien };
                    if (chiPhiService.Create(cp))
                    {
                        cp.LoaiChiPhi = SelectedItemLoaiChiPhi;
                        MessageBox.Show($"Bạn đã thêm chi phí: Tên chi phí {cp.LoaiChiPhi.TenLoaiChiPhi} - Số tiền: {SoTien}");
                        var ddl1 = this.doanDuLichService.Get(SelectedItem.MaDoan);
                        ddl1.ChiPhis.Add(cp);
                        int a = 0;
                        foreach (var i in ListGroup)
                        {
                            if (i.MaDoan == ddl1.MaDoan)
                            {
                                ListGroup.Remove(this.doanDuLichService.Get(SelectedItem.MaDoan));
                                SelectedItem = null;
                                ListGroup.Insert(a, this.doanDuLichService.Get(ddl1.MaDoan));
                                SelectedItem = ddl1;
                                break;
                            }
                            else
                            {
                                a++;
                            }
                        }
                    }       
                }
                catch
                {
                    MessageBox.Show("Lỗi ở thêm CHI PHÍ - Đoàn Du Lịch");
                }
            });

        }
        private void DoanXoaChiPhi() 
        {
            DoanXoaCP = new RelayCommand<DoanDuLich_ChiTiet>(p =>
            {
                return SelectedChooseCP != null;
            }, p =>
            {
                try
                {
                    var cp = new Domain.Entities.ChiPhi() { MaChiPhi = SelectedChooseCP.MaChiPhi };
                    if (chiPhiService.Delete(cp.MaChiPhi))
                    {
                        //MessageBox.Show($"Bạn đã xóa chi phí: Tên chi phí {SelectedChooseCP.LoaiChiPhi.TenLoaiChiPhi} - Số tiền: {SelectedChooseCP.SoTien} ");
                        MessageBox.Show($"Bạn đã xóa chi phí !");
                        SelectedChiPhi.Remove(cp);
                        var ddl1 = SelectedItem;
                        ddl1.ChiPhis.Remove(cp);
                        int a = 0;
                        foreach (var i in ListGroup)
                        {
                            if (i.MaDoan == ddl1.MaDoan)
                            {
                                ListGroup.Remove(i);
                                SelectedItem = null;
                                ListGroup.Insert(a, ddl1);
                                SelectedItem = ddl1;
                                break;
                            }
                            else
                            {
                                a++;
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi ở xóa CHI PHÍ - Đoàn Du Lịch");
                }
            }
            );
        }
        private void CloseThemCP(object obj) 
        { 
            DoanDuLich_ThemChiPhi x = obj as DoanDuLich_ThemChiPhi; 
            x.Close();
            SelectedItemLoaiChiPhi = null;
        }
        #endregion

        #endregion


        #endregion
    }
}
