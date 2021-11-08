using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Repositories
{
    public class DoanDuLichRepository : EFRepository<DoanDuLich>, IDoanDuLichRepository
    {
        public DoanDuLichRepository(TourContext context) : base(context)
        {
        }

        public IEnumerable<DoanDuLich> GetDoans()
        {
            List<DoanDuLich> d = new();
            d = (from t in context.DoanDuLiches select t).ToList();
            d.Insert(0, new DoanDuLich { MaDoan = 0, TenDoan = "Chọn đoàn" });
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
    }
}