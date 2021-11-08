using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Repositories
{
    public class ChiTietDoanRepository : EFRepository<ChiTietDoan>, IChiTietDoanRepository
    {
        public ChiTietDoanRepository(TourContext context) : base(context)
        {
        }

        public IEnumerable<ChiTietDoan> GetChiTietDoans()
        {
            List<ChiTietDoan> ctd = new ();
            ctd = (from t in context.ChiTietDoans select t).ToList();
            return ctd;
        }
        public int CountChiTietDoan()
        {
            var c = context.ChiTietDoans.Count();
            return c;
        }
    }
}