using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Repositories
{
    public class LoaiHinhDuLichRepository : EFRepository<LoaiHinhDuLich>, ILoaiHinhDuLichRepository
    {
        public LoaiHinhDuLichRepository(TourContext context) : base(context)
        {
        }

        public IEnumerable<LoaiHinhDuLich> GetLoaiHinhs()
        {
            List<LoaiHinhDuLich> lh = new ();
            lh = (from t in context.LoaiHinhDuLiches select t).ToList();
            lh.Insert(0, new LoaiHinhDuLich { MaLoaiHinh = 0, TenLoaiHinh = "Chọn loại hình" });
            return lh;
        }

        public IEnumerable<LoaiHinhDuLich> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = context.LoaiHinhDuLiches.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(lh => lh.TenLoaiHinh.Contains(searchString));
            }

            SortLoaiHinhs(sortOrder, ref query);
            count = query.Count();

            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }

        private static void SortLoaiHinhs(string sortOrder, ref IQueryable<LoaiHinhDuLich> query)
        {
            switch (sortOrder)
            {
                case "ma_desc":
                    query = query.OrderByDescending(l => l.MaLoaiHinh);
                    break;

                case "ma":
                    query = query.OrderBy(l => l.MaLoaiHinh);
                    break;

                case "ten_desc":
                    query = query.OrderByDescending(l => l.TenLoaiHinh);
                    break;

                case "ten":
                    query = query.OrderBy(l => l.TenLoaiHinh);
                    break;
            }
        }

        public int CountLoaiHinh()
        {
            var c = context.LoaiHinhDuLiches.Count();
            return c;
        }
    }
}