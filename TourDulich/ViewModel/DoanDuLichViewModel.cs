using Domain.Entities;
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
        

        private TourDuLich _SelectedTour;
        public TourDuLich SelectedTour
        {
            get => _SelectedTour;
            set
            {
                _SelectedTour = value;

            }
        }

        private NoiDungTour _SelectedNoiDungTour;
        public NoiDungTour SelectedNoiDungTour
        {
            get => _SelectedNoiDungTour;
            set
            {
                _SelectedNoiDungTour = value;

            }
        }
        #endregion


        #region Lấy giá trị     NHÂN VIÊN     được chọn tham chiếu qua các ô cần dùng
        public int MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string NhiemVu { get; set; }
        private NhanVien _SelectedItemNhanVien;
        public NhanVien SelectedItemNhanVien
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
        private ICommand _AddNVn;
        public ICommand AddNVn { get => _AddNVn; set => _AddNVn = value; }

        private ICommand _AddNV;
        public ICommand AddNV { get => _AddNV; set => _AddNV = value; }

        #endregion

        #region Lấy giá trị     KHÁCH HÀNG     được chọn tham chiếu qua các ô cần dùng
        public int MaKhachHang { get; set; }
        public string HoTen { get; set; }
        public string SDT { get; set; }

        //private VaiTro VaiTro2;
        //public VaiTro VaiTro1 { get => Enum.GetValues(VaiTr); set => VaiTro2=value; }

        private Khach _SelectedItemKhach;
        public Khach SelectedItemKhach
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
                    //VaiTro1 = SelectedItemKhach.VaiTro;
                }
            }
        }

        private ICommand _AddKHn;
        public ICommand AddKHn { get => _AddKHn; set => _AddKHn = value; }

        private ICommand _AddKH;
        public ICommand AddKH { get => _AddKH; set => _AddKH = value; }

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

        private ICommand _AddCPn;
        public ICommand AddCPn { get => _AddCPn; set => _AddCPn = value; }

        private ICommand _AddCP;
        public ICommand AddCP { get => _AddCP; set => _AddCP = value; }

        #endregion


        private PhanBoNhanVienDoan _SelectedChooseNV;
        public PhanBoNhanVienDoan SelectedChooseNV
        {
            get => _SelectedChooseNV;
            set
            {
                _SelectedChooseNV = value;

            }
        }
        private ChiTietDoan _SelectedChooseKH;
        public ChiTietDoan SelectedChooseKH
        {
            get => _SelectedChooseKH;
            set
            {
                _SelectedChooseKH = value;

            }
        }
        private Domain.Entities.ChiPhi _SelectedChooseCP;
        public Domain.Entities.ChiPhi SelectedChooseCP
        {
            get => _SelectedChooseCP;
            set
            {
                _SelectedChooseCP = value;

            }
        }



        private ICollection<PhanBoNhanVienDoan> _SelectedPhanBoNhanVienDoan;
        public ICollection<PhanBoNhanVienDoan> SelectedPhanBoNhanVienDoan
        {
            get => _SelectedPhanBoNhanVienDoan;
            set
            {
                _SelectedPhanBoNhanVienDoan = value;

            }
        }
        private ICollection<ChiTietDoan> _SelectedPhanBoKhach;
        public ICollection<ChiTietDoan> SelectedPhanBoKhach
        {
            get => _SelectedPhanBoKhach;
            set
            {
                _SelectedPhanBoKhach = value;

            }
        }
        private ICollection<Domain.Entities.ChiPhi> _SelectedChiPhi;
        public ICollection<Domain.Entities.ChiPhi> SelectedChiPhi
        {
            get => _SelectedChiPhi;
            set
            {
                _SelectedChiPhi = value;

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
                    NgayKhoiHanh = SelectedItem.NgayKhoiHanh;
                    NgayKetThuc = SelectedItem.NgayKetThuc;
                    DoanhThu = SelectedItem.DoanhThu;

                    SelectedTour = SelectedItem.Tour;
                    SelectedNoiDungTour = SelectedItem.NoiDungTour;

                    SelectedPhanBoNhanVienDoan = SelectedItem.PhanBoNhanVienDoans;
                    SelectedPhanBoKhach = SelectedItem.ChiTietDoans;
                    

                    SelectedChiPhi = SelectedItem.ChiPhis;
                }
            }
        }
       
        #endregion

        #region Các biến chức năng trong Thêm Đoàn

        private string _AddTenDoan;
        public string AddTenDoan { get => _AddTenDoan; set { _AddTenDoan = value; } }
        private TourDuLich _AddSelectedTour;
        public TourDuLich AddSelectedTour
        {
            get => _AddSelectedTour;
            set
            {
                _AddSelectedTour = value;
            }
        }
        private DateTime? _AddNgayKhoiHanh;
        public DateTime? AddNgayKhoiHanh { get => _AddNgayKhoiHanh; set { _AddNgayKhoiHanh = value; } }
        private DateTime? _AddNgayKetThuc;
        public DateTime? AddNgayKetThuc { get => _AddNgayKetThuc; set { _AddNgayKetThuc = value; } }
        private string _AddKhachSan;
        public string AddKhachSan { get => _AddKhachSan; set { _AddKhachSan = value; } }
        private string _AddHanhTrinh;
        public string AddHanhTrinh { get => _AddHanhTrinh; set { _AddHanhTrinh = value; } }
        private string _AddDiemThamQuan;
        public string AddDiemThamQuan { get => _AddDiemThamQuan; set { _AddDiemThamQuan = value; } }

        private ICommand _Reset;
        public ICommand Reset { get => _Reset; set => _Reset = value; }

        private ICommand _Save;
        public ICommand Save { get => _Save; set => _Save = value; }
        #endregion


        #region Danh sách Đoàn, Tour, Nhân viên, Chi phí, Khách hàng
        private ObservableCollection<TourDuLich> _listTour;
        public ObservableCollection<TourDuLich> ListTour { get => _listTour; set { _listTour = value; } }

        private ObservableCollection<NhanVien> _listNhanvien;
        public ObservableCollection<NhanVien> ListNhanvien { get => _listNhanvien; set { _listNhanvien = value; } }

        private ObservableCollection<DoanDuLich> _list;
        public ObservableCollection<DoanDuLich> ListGroup { get => _list; set { _list = value; } }

        private ObservableCollection<NoiDungTour> _listNoiDung;
        public ObservableCollection<NoiDungTour> ListNoiDung { get => _listNoiDung; set { _listNoiDung = value; } }

        private ObservableCollection<Domain.Entities.ChiPhi> _listChiPhi;
        public ObservableCollection<Domain.Entities.ChiPhi> ListChiPhi { get => _listChiPhi; set { _listChiPhi = value; } }

        private ObservableCollection<LoaiChiPhi> _listLoaiChiPhi;
        public ObservableCollection<LoaiChiPhi> listLoaiChiPhi { get => _listLoaiChiPhi; set { _listLoaiChiPhi = value; } }

        private ObservableCollection<Khach> _listKhach;
        public ObservableCollection<Khach> ListKhach { get => _listKhach; set { _listKhach = value; } }

        private ObservableCollection<ChiTietDoan> _listChiTietDoan;
        public ObservableCollection<ChiTietDoan> ListChiTietDoan { get => _listChiTietDoan; set { _listChiTietDoan = value; } }
        
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

            ListChiTietDoan = new ObservableCollection<ChiTietDoan>();
            

            ListChiPhi = new ObservableCollection<Domain.Entities.ChiPhi>(this.chiPhiService.GetDTOs());
            listLoaiChiPhi = new ObservableCollection<LoaiChiPhi>(this.loaiChiPhiService.GetDTOs());

            ListKhach = new ObservableCollection<Khach>(this.khachService.GetDTOs());

            //VaiTro1 = new VaiTro();
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
                var ddl = new DoanDuLich() { TenDoan = AddTenDoan, MaTour = AddSelectedTour.MaTour, NgayKhoiHanh = (DateTime)AddNgayKhoiHanh, NgayKetThuc = (DateTime)AddNgayKetThuc};
                doanDuLichService.Create(ddl);

                var ndt = new NoiDungTour() { KhachSan = AddKhachSan, HanhTrinh = AddHanhTrinh, DiaDiemThamQuan = AddDiemThamQuan, MaDoan = this.doanDuLichService.Get(ddl.MaDoan).MaDoan };
                noiDungTourService.Create(ndt);
                
                ddl.NoiDungTour = ndt;
                CloseThem(p);
                ListGroup.Add(ddl);

                MessageBox.Show($"Bạn đã thêm đoàn du lịch mới: Tên đoàn {ddl.TenDoan} - Ngày khởi hành: {ddl.NgayKhoiHanh} - Ngày kết thúc: {ddl.NgayKetThuc}");

            });
        }
        private void CloseThem(object obj) { DoanDuLich_Them x = obj as DoanDuLich_Them; x.Close();  }
        #endregion



        #region Bên trong Chi Tiết Đoàn
        private void Show()
        {
            DoanDuLich_ChiTiet x = new DoanDuLich_ChiTiet();
            x.DataContext = this;
            x.ShowDialog();
        }
        private void CloseChiTiet(object obj) { DoanDuLich_ChiTiet x = obj as DoanDuLich_ChiTiet; x.Close(); 
        }


        private void ShowThemNV(object p) 
        {
            CloseChiTiet(p);
            DoanDuLich_ThemNhanVien x = new DoanDuLich_ThemNhanVien();
            x.DataContext = this;
            ListNhanvien = new ObservableCollection<NhanVien>(this.nhanVienService.GetDTOs());
            x.ShowDialog();

        }
        private void DoanThemNhanVien()
        {
            
            AddNV = new RelayCommand<DoanDuLich_ThemNhanVien>(p =>
            {
                if (SelectedItemNhanVien != null)
                {
                    foreach (var i in SelectedItem.PhanBoNhanVienDoans)
                    {
                        if (SelectedItemNhanVien.MaNhanVien == i.MaNhanVien) { return false; }
                    }
                    return true;
                }
                else
                {
                    return MaNhanVien != 0 && !string.IsNullOrEmpty(TenNhanVien) && !string.IsNullOrEmpty(NhiemVu);
                }
            }, p =>
            {
                var pbnv = new PhanBoNhanVienDoan() { MaDoan = SelectedItem.MaDoan, MaNhanVien = SelectedItemNhanVien.MaNhanVien, NhiemVu = NhiemVu };

                pbnv.NhanVien= SelectedItemNhanVien;
                SelectedPhanBoNhanVienDoan.Add(pbnv);

                CloseThemNV(p);
                MessageBox.Show($"Bạn đã thêm nhân viên: Tên nhân viên {TenNhanVien} - Nhiệm vụ: {pbnv.NhiemVu} ");
                
                Show();

                var ddl1 = SelectedItem;
                ddl1.PhanBoNhanVienDoans.Add(pbnv);

                int a = 0;
                foreach (var i in ListGroup)
                {
                    if (i.MaDoan == ddl1.MaDoan)
                    {
                        ListGroup.Remove(this.doanDuLichService.Get(SelectedItem.MaDoan));
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
                //phanBoNhanVienDoanService.Create(pbnv);

            });
            AddNVn = new RelayCommand<DoanDuLich_ThemNhanVien>(p =>
            {
                if (SelectedItemNhanVien != null)
                {
                    foreach (var i in SelectedItem.PhanBoNhanVienDoans)
                    {
                        if (SelectedItemNhanVien.MaNhanVien == i.MaNhanVien) { return false; }
                    }
                    return true;
                }
                else
                {
                    return MaNhanVien != 0 && !string.IsNullOrEmpty(TenNhanVien) && !string.IsNullOrEmpty(NhiemVu);
                }
            }, p =>
            {
                var pbnv = new PhanBoNhanVienDoan() { MaDoan = SelectedItem.MaDoan, MaNhanVien = SelectedItemNhanVien.MaNhanVien, NhiemVu = NhiemVu };
                //phanBoNhanVienDoanService.Create(pbnv);

                pbnv.NhanVien = SelectedItemNhanVien;
                SelectedPhanBoNhanVienDoan.Add(pbnv);

                MessageBox.Show($"Bạn đã thêm nhân viên: Tên nhân viên {TenNhanVien} - Nhiệm vụ: {pbnv.NhiemVu} ");

                var ddl1 = SelectedItem;
                ddl1.PhanBoNhanVienDoans.Add(pbnv);

                int a = 0;
                foreach (var i in ListGroup)
                {
                    if (i.MaDoan == ddl1.MaDoan)
                    {
                        ListGroup.Remove(this.doanDuLichService.Get(SelectedItem.MaDoan));
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
        private void CloseThemNV(object obj) { DoanDuLich_ThemNhanVien x = obj as DoanDuLich_ThemNhanVien; x.Close();  }














        private void ShowThemKH(object p) 
        {
            CloseChiTiet(p);
            DoanDuLich_ThemKhachHang x = new DoanDuLich_ThemKhachHang();
            x.DataContext = this;
            x.ShowDialog(); 
        }
        private void DoanThemKhachHang()
        {
            AddKH = new RelayCommand<DoanDuLich_ThemKhachHang>(p =>
            {
                if (SelectedItemNhanVien != null)
                {
                    foreach (var i in SelectedItem.ChiTietDoans)
                    {
                        if (SelectedItemKhach.MaKhachHang == i.MaKhachHang) { return false; }
                    }
                    return true;
                }
                else
                {
                    return MaKhachHang != 0 && !string.IsNullOrEmpty(HoTen) && !string.IsNullOrEmpty(SDT);

                }


            }, p =>
            {
                var ctd = new ChiTietDoan() { MaDoan = SelectedItem.MaDoan, MaKhachHang = SelectedItemKhach.MaKhachHang };

                ctd.Khach = SelectedItemKhach;
                SelectedPhanBoKhach.Add(ctd);

                CloseThemKH(p);
                MessageBox.Show($"Bạn đã thêm khách hàng: Tên khách hàng {HoTen}");

                Show();

                var ddl1 = SelectedItem;
                ddl1.ChiTietDoans.Add(ctd);

                int a = 0;
                foreach (var i in ListGroup)
                {
                    if (i.MaDoan == ddl1.MaDoan)
                    {
                        ListGroup.Remove(this.doanDuLichService.Get(SelectedItem.MaDoan));
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
            });
            AddKHn = new RelayCommand<DoanDuLich_ThemKhachHang>(p =>
            {
                if (SelectedItemNhanVien != null)
                {
                    foreach (var i in SelectedItem.ChiTietDoans)
                    {
                        if (SelectedItemKhach.MaKhachHang == i.MaKhachHang) { return false; }
                    }
                    return true;
                }
                else
                {
                    return MaKhachHang != 0 && !string.IsNullOrEmpty(HoTen) && !string.IsNullOrEmpty(SDT);

                }

            }, p =>
            {
                var ctd = new ChiTietDoan() { MaDoan = SelectedItem.MaDoan, MaKhachHang = SelectedItemKhach.MaKhachHang };

                ctd.Khach = SelectedItemKhach;
                SelectedPhanBoKhach.Add(ctd);

                MessageBox.Show($"Bạn đã thêm khách hàng: Tên khách hàng {HoTen}");

                var ddl1 = SelectedItem;
                ddl1.ChiTietDoans.Add(ctd);

                int a = 0;
                foreach (var i in ListGroup)
                {
                    if (i.MaDoan == ddl1.MaDoan)
                    {
                        ListGroup.Remove(this.doanDuLichService.Get(SelectedItem.MaDoan));
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
            });
        }
        private void DoanXoaKhachHang() { }
        private void CloseThemKH(object obj) { DoanDuLich_ThemKhachHang x = obj as DoanDuLich_ThemKhachHang; x.Close();  }



        private void ShowThemCP(object p) 
        {
            CloseChiTiet(p);
            DoanDuLich_ThemChiPhi x = new DoanDuLich_ThemChiPhi(); 
            x.DataContext = this;
            x.ShowDialog(); 
        }
        private void DoanThemChiPhi()
        {
            AddCP = new RelayCommand<DoanDuLich_ThemChiPhi>(p =>
            {
                return MaLoaiChiPhi != 0 && !string.IsNullOrEmpty(TenLoaiChiPhi) && SoTien > 0;

            }, p =>
            {
                var cp = new Domain.Entities.ChiPhi() { MaDoan = SelectedItem.MaDoan, MaLoaiChiPhi = SelectedItemLoaiChiPhi.MaLoaiChiPhi, SoTien = SoTien };
                chiPhiService.Create(cp);

                cp.LoaiChiPhi = SelectedItemLoaiChiPhi;
                SelectedChiPhi.Add(cp);

                CloseThemCP(p);
                MessageBox.Show($"Bạn đã thêm chi phí: Tên chi phí {cp.LoaiChiPhi.TenLoaiChiPhi} - Số tiền: {SoTien}");


                Show();

                var ddl1 = SelectedItem;
                ddl1.ChiPhis.Add(cp);

                int a = 0;
                foreach (var i in ListGroup)
                {
                    if (i.MaDoan == ddl1.MaDoan)
                    {
                        ListGroup.Remove(this.doanDuLichService.Get(SelectedItem.MaDoan));
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
            });
            AddCPn = new RelayCommand<DoanDuLich_ThemChiPhi>(p =>
            {
                return MaLoaiChiPhi != 0 && !string.IsNullOrEmpty(TenLoaiChiPhi) && SoTien >0;

            }, p =>
            {
                var cp = new Domain.Entities.ChiPhi() { MaDoan = SelectedItem.MaDoan, MaLoaiChiPhi= SelectedItemLoaiChiPhi.MaLoaiChiPhi, SoTien = SoTien };
                chiPhiService.Create(cp);

                cp.LoaiChiPhi = SelectedItemLoaiChiPhi;
                SelectedChiPhi.Add(cp);

                MessageBox.Show($"Bạn đã thêm chi phí: Tên chi phí {cp.LoaiChiPhi.TenLoaiChiPhi} - Số tiền: {SoTien}");

                var ddl1 = SelectedItem;
                ddl1.ChiPhis.Add(cp);

                int a = 0;
                foreach (var i in ListGroup)
                {
                    if (i.MaDoan == ddl1.MaDoan)
                    {
                        ListGroup.Remove(this.doanDuLichService.Get(SelectedItem.MaDoan));
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
            });

        }
        private void DoanXoaChiPhi() 
        {
            DoanXoaCP = new RelayCommand<DoanDuLich_ChiTiet>(p =>
            {
                return SelectedChooseCP != null;
            }, p =>
            {
                var cp = new Domain.Entities.ChiPhi() { MaChiPhi = SelectedChooseCP.MaChiPhi };
                chiPhiService.Delete(cp.MaChiPhi);

                //MessageBox.Show($"Bạn đã xóa chi phí: Tên chi phí {SelectedChooseCP.LoaiChiPhi.TenLoaiChiPhi} - Số tiền: {SelectedChooseCP.SoTien} ");
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
            );
        }
        private void CloseThemCP(object obj) { DoanDuLich_ThemChiPhi x = obj as DoanDuLich_ThemChiPhi; x.Close();  }
        #endregion
        
        
        #endregion
    }
}
