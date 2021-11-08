using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IPhanBoNhanVienDoanRepository : IEFRepository<PhanBoNhanVienDoan>
    {
        int CountPhanBoNhanVienDoan();

        IEnumerable<PhanBoNhanVienDoan> GetPhanBoNhanVienDoans();
    }
}