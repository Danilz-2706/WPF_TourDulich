using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Repositories
{
    public class ChiPhiRepository : EFRepository<ChiPhi>, IChiPhiRepository
    {
        public ChiPhiRepository(TourContext context) : base(context)
        {
        }

        public IEnumerable<ChiPhi> GetChiPhis(int maTour)
        {
            /*var cp = (from t in context.DoanDuLiches where t.MaTour == maTour select t.ChiPhis).ToList();
            return cp;*/
            return null;
        }

        public IEnumerable<ChiPhi> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = context.ChiPhis.AsQueryable();

            if (!string.IsNullOrEmpty(searchString) && int.TryParse(searchString,out _))
            {
                query = query.Where(cp => cp.MaLoaiChiPhi == int.Parse(searchString) || cp.MaDoan == int.Parse(searchString) || cp.MaChiPhi == int.Parse(searchString) );
            }

            SortChiPhis(sortOrder, ref query);
            count = query.Count();

            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }

        private static void SortChiPhis(string sortOrder, ref IQueryable<ChiPhi> query)
        {
            switch (sortOrder)
            {
                case "macp_desc":
                    query = query.OrderByDescending(cp => cp.MaChiPhi);
                    break;

                case "macp":
                    query = query.OrderBy(cp => cp.MaChiPhi);
                    break;

                case "madoan_desc":
                    query = query.OrderByDescending(cp => cp.MaDoan);
                    break;

                case "madoan":
                    query = query.OrderBy(cp => cp.MaDoan);
                    break;
            }
        }

        public int CountChiPhi()
        {
            var c = context.ChiPhis.Count();
            return c;
        }
    }
}