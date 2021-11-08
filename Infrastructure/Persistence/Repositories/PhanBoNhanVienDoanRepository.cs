using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Repositories
{
    public class PhanBoNhanVienDoanRepository : EFRepository<PhanBoNhanVienDoan>, IPhanBoNhanVienDoanRepository
    {
        public PhanBoNhanVienDoanRepository(TourContext context) : base(context)
        {
        }

        public IEnumerable<PhanBoNhanVienDoan> GetPhanBoNhanVienDoans()
        {
            List<PhanBoNhanVienDoan> d = new ();
            d = (from t in context.PhanBoNhanVien_Doans select t).ToList();
            return d;
        }
        public int CountPhanBoNhanVienDoan()
        {
            var c = context.PhanBoNhanVien_Doans.Count();
            return c;
        }
    }
}