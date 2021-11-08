using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Repositories
{
    public class KhachRepository : EFRepository<Khach>, IKhachRepository
    {
        public KhachRepository(TourContext context) : base(context)
        {
        }

        public IEnumerable<Khach> GetKhaches()
        {
            List<Khach> kh = new ();
            kh = (from t in context.Khaches select t).ToList();
            kh.Insert(0, new Khach { MaKhachHang = 0, HoTen = "Chọn khách"});
            return kh;
        }

        public IEnumerable<Khach> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = context.Khaches.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(kh => kh.HoTen.Contains(searchString));
            }

            SortKhaches(sortOrder, ref query);
            count = query.Count();

            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }

        private static void SortKhaches(string sortOrder, ref IQueryable<Khach> query)
        {
            switch (sortOrder)
            {
                case "ma_desc":
                    query = query.OrderByDescending(kh => kh.MaKhachHang);
                    break;

                case "ma":
                    query = query.OrderBy(kh => kh.MaKhachHang);
                    break;

                case "ten_desc":
                    query = query.OrderByDescending(kh => kh.HoTen);
                    break;

                case "ten":
                    query = query.OrderBy(kh => kh.HoTen);
                    break;
            }
        }

        public int CountKhach()
        {
            var c = context.Khaches.Count();
            return c;
        }
    }
}