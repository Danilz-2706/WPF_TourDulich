using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Repositories
{
    public class GiaTourRepository : EFRepository<GiaTour>, IGiaTourRepository
    {
        public GiaTourRepository(TourContext context) : base(context)
        {
        }

        public IEnumerable<GiaTour> GetGias()
        {
            List<GiaTour> g = new ();
            g = (from t in context.GiaTours select t).ToList();
            return g;
        }

        public IEnumerable<GiaTour> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = context.GiaTours.AsQueryable();

            if (!string.IsNullOrEmpty(searchString) && int.TryParse(searchString, out _))
            {
                query = query.Where(kh => kh.MaTour == int.Parse(searchString));
            }

            SortGias(sortOrder, ref query);
            count = query.Count();

            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }

        private static void SortGias(string sortOrder, ref IQueryable<GiaTour> query)
        {
            switch (sortOrder)
            {
                case "ma_desc":
                    query = query.OrderByDescending(g => g.MaGia);
                    break;

                case "ma":
                    query = query.OrderBy(g => g.MaGia);
                    break;
            }
        }

        public int CountGiaTour()
        {
            var c = context.GiaTours.Count();
            return c;
        }
    }
}