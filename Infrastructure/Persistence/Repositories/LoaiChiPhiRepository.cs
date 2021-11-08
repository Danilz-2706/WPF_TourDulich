using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Repositories
{
    public class LoaiChiPhiRepository : EFRepository<LoaiChiPhi>, ILoaiChiPhiRepository
    {
        public LoaiChiPhiRepository(TourContext context) : base(context)
        {
        }

        public IEnumerable<LoaiChiPhi> GetLoaiChiPhis()
        {
            List<LoaiChiPhi> lcp = new ();
            lcp = (from t in context.LoaiChiPhis select t).ToList();
            lcp.Insert(0, new LoaiChiPhi { MaLoaiChiPhi = 0, TenLoaiChiPhi = "Chọn loại chi phí" });
            return lcp;
        }

        public IEnumerable<LoaiChiPhi> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = context.LoaiChiPhis.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(lcp => lcp.TenLoaiChiPhi.Contains(searchString));
            }

            SortLoaiChiPhis(sortOrder, ref query);
            count = query.Count();

            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }

        private static void SortLoaiChiPhis(string sortOrder, ref IQueryable<LoaiChiPhi> query)
        {
            switch (sortOrder)
            {
                case "ma_desc":
                    query = query.OrderByDescending(l => l.MaLoaiChiPhi);
                    break;

                case "ma":
                    query = query.OrderBy(l => l.MaLoaiChiPhi);
                    break;

                case "ten_desc":
                    query = query.OrderByDescending(l => l.TenLoaiChiPhi);
                    break;

                case "ten":
                    query = query.OrderBy(l => l.TenLoaiChiPhi);
                    break;
            }
        }

        public int CountLoaiChiPhi()
        {
            var c = context.LoaiChiPhis.Count();
            return c;
        }
    }
}