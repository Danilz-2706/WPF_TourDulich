using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Repositories
{
    public class DiaDiemRepository : EFRepository<DiaDiem>, IDiaDiemRepository
    {
        public DiaDiemRepository(TourContext context) : base(context)
        {
        }

        public IEnumerable<DiaDiem> GetDiaDiems()
        {
            List<DiaDiem> dd = new ();
            dd = (from t in context.DiaDiems select t).ToList();
            dd.Insert(0, new DiaDiem { MaDiaDiem = 0, TenDiaDiem = "Chọn địa điểm" });
            return dd;
        }

        public IEnumerable<DiaDiem> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = context.DiaDiems.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(dd => dd.TenDiaDiem.Contains(searchString));
            }

            SortDiaDiems(sortOrder, ref query);
            count = query.Count();

            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }

        private static void SortDiaDiems(string sortOrder, ref IQueryable<DiaDiem> query)
        {
            switch (sortOrder)
            {
                case "ma_desc":
                    query = query.OrderByDescending(d => d.MaDiaDiem);
                    break;

                case "ma":
                    query = query.OrderBy(d => d.MaDiaDiem);
                    break;

                case "ten_desc":
                    query = query.OrderByDescending(d => d.TenDiaDiem);
                    break;

                case "ten":
                    query = query.OrderBy(d => d.TenDiaDiem);
                    break;
            }
        }

        public int CountDiaDiem()
        {
            var c = context.DiaDiems.Count();
            return c;
        }
    }
}