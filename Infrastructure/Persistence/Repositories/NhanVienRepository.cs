using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Repositories
{
    public class NhanVienRepository : EFRepository<NhanVien>, INhanVienRepository
    {
        public NhanVienRepository(TourContext context) : base(context)
        {
        }

        public IEnumerable<NhanVien> GetNhanViens()
        {
            List<NhanVien> nv = new ();
            nv = (from t in context.NhanViens select t).ToList();
            nv.Insert(0, new NhanVien { MaNhanVien = 0, TenNhanVien = "Chọn nhân viên" });
            return nv;
        }

        public IEnumerable<NhanVien> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = context.NhanViens.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(nv => nv.TenNhanVien.Contains(searchString));
            }

            SortNhanViens(sortOrder, ref query);
            count = query.Count();

            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }

        private static void SortNhanViens(string sortOrder, ref IQueryable<NhanVien> query)
        {
            switch (sortOrder)
            {
                case "ma_desc":
                    query = query.OrderByDescending(tg => tg.MaNhanVien);
                    break;

                case "ma":
                    query = query.OrderBy(tg => tg.MaNhanVien);
                    break;

                case "ten_desc":
                    query = query.OrderByDescending(nv => nv.TenNhanVien);
                    break;

                case "ten":
                    query = query.OrderBy(nv => nv.TenNhanVien);
                    break;
            }
        }

        public int CountNhanVien()
        {
            var c = context.NhanViens.Count();
            return c;
        }
    }
}