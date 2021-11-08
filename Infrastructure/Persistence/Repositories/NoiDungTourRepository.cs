using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Repositories
{
    public class NoiDungTourRepository : EFRepository<NoiDungTour>, INoiDungTourRepository
    {
        public NoiDungTourRepository(TourContext context) : base(context)
        {
        }

        public IEnumerable<NoiDungTour> GetNoiDungTours()
        {
            List<NoiDungTour> nd = new ();
            nd = (from t in context.NoiDungTours select t).ToList();
            return nd;
        }
        public int CountNoiDungTour()
        {
            var c = context.NoiDungTours.Count();
            return c;
        }
    }
}