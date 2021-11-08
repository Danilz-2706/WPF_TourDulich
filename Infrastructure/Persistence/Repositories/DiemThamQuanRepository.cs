using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Repositories
{
    public class DiemThamQuanRepository : EFRepository<DiemThamQuan>, IDiemThamQuanRepository
    {
        public DiemThamQuanRepository(TourContext context) : base(context)
        {
        }

        public IEnumerable<DiemThamQuan> GetDiemThamQuans()
        {
            List<DiemThamQuan> d = new ();
            d = (from t in context.DiemThamQuans select t).ToList();
            return d;
        }
        public int CountDiemThamQuan()
        {
            var c = context.DiemThamQuans.Count();
            return c;
        }
    }
}