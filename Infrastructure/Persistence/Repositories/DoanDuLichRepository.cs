using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Repositories
{
    public class DoanDuLichRepository : EFRepository<DoanDuLich>, IDoanDuLichRepository
    {
        public DoanDuLichRepository(TourContext context) : base(context)
        {
        }

        public override IEnumerable<DoanDuLich> GetAll()
        {

            return context.DoanDuLiches.Include(d => d.ChiTietDoans).Include(c => c.ChiPhis).Include(nv => nv.PhanBoNhanVienDoans)
                .Include(ntd => ntd.NoiDungTour).Include(t => t.Tour).Include(k => k.Khaches).Include(nv => nv.NhanViens).ToList();
        }

        public IEnumerable<Khach> GetKhachsByDoan(int id)
        {
            var list = (from doan in context.DoanDuLiches
                        where doan.MaDoan == id
                        from ctd in doan.ChiTietDoans
                        from kh in doan.Khaches
                        where kh.MaKhachHang == ctd.MaKhachHang
                        select new Khach
                        {
                            MaKhachHang = kh.MaKhachHang,
                            HoTen = kh.HoTen,
                            SoCMND = kh.SoCMND,
                            DiaChi = kh.DiaChi,
                            GioiTinh = kh.GioiTinh,
                            SDT = kh.SDT,
                            QuocTich = kh.QuocTich,
                            VaiTro = ctd.VaiTro
                        }).AsNoTracking().ToList();
            return list;
        }

        public IEnumerable<NhanVien> GetNVsByDoan(int id)
        {
            var list = (from doan in context.DoanDuLiches
                        where doan.MaDoan == id
                        from nv in doan.NhanViens
                        from pbnv in doan.PhanBoNhanVienDoans
                        where nv.MaNhanVien == pbnv.MaNhanVien
                        select new NhanVien
                        {
                            MaNhanVien = nv.MaNhanVien,
                            TenNhanVien = nv.TenNhanVien,
                            NhiemVu = pbnv.NhiemVu
                        }).AsNoTracking().ToList();
            return list;
        }

        public IEnumerable<ChiPhi> GetCPsByDoan(int id)
        {
            var list = (from doan in context.DoanDuLiches
                        where doan.MaDoan == id
                        from cp in doan.ChiPhis
                        where cp.MaLoaiChiPhi == cp.LoaiChiPhi.MaLoaiChiPhi
                        select new ChiPhi
                        {
                            MaChiPhi = cp.MaChiPhi,
                            MaDoan = cp.MaDoan,
                            SoTien = cp.SoTien,
                            MaLoaiChiPhi = cp.MaLoaiChiPhi,
                            TenLoaiChiPhi = cp.LoaiChiPhi.TenLoaiChiPhi
                        }).AsNoTracking().ToList();
            return list;
        }

        public IEnumerable<DoanDuLich> GetDoans()
        {
            return context.DoanDuLiches.Include(d => d.ChiTietDoans).Include(c => c.ChiPhis).Include(nv => nv.PhanBoNhanVienDoans).Include(ntd => ntd.NoiDungTour).Include(t => t.Tour).ToList();
        }

        public IEnumerable<DoanDuLich> GetDoans_Eager()
        {
            throw new System.NotImplementedException();
        }

        public DoanDuLich GetDoan_Eager(int id)
        {
            var d = context.DoanDuLiches.Where(x => x.MaDoan == id).Include(d => d.ChiTietDoans).Include(c => c.ChiPhis).Include(nv => nv.PhanBoNhanVienDoans).FirstOrDefault();
            return d;
        }

        public IEnumerable<DoanDuLich> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = context.DoanDuLiches.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(d => d.TenDoan.Contains(searchString));
            }

            SortDoans(sortOrder, ref query);
            count = query.Count();

            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }

        private static void SortDoans(string sortOrder, ref IQueryable<DoanDuLich> query)
        {
            switch (sortOrder)
            {
                case "ma_desc":
                    query = query.OrderByDescending(t => t.MaDoan);
                    break;

                case "ma":
                    query = query.OrderBy(t => t.MaDoan);
                    break;

                case "ten_desc":
                    query = query.OrderByDescending(t => t.TenDoan);
                    break;

                case "ten":
                    query = query.OrderBy(t => t.TenDoan);
                    break;
            }
        }

        public int CountDoanDuLich()
        {
            var c = context.DoanDuLiches.Count();
            return c;
        }
        public void UpdateDoanhThu(int id)
        {
            var doan = context.DoanDuLiches.Find(id);

            var giaTour = context.GiaTours.Where(x => (doan.MaTour == x.MaTour) && doan.NgayKhoiHanh >= x.ThoiGianBatDau &&
            doan.NgayKhoiHanh <= x.ThoiGianKetThuc).Select(x => x).FirstOrDefault();

            context.Entry(doan).Collection(kh => kh.Khaches).Load();
            doan.DoanhThu = doan.Khaches.Count() * giaTour.ThanhTien;
            context.SaveChanges();
        }
    }
}