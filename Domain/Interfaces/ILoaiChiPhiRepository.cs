using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface ILoaiChiPhiRepository : IEFRepository<LoaiChiPhi>
    {
        int CountLoaiChiPhi();

        IEnumerable<LoaiChiPhi> GetLoaiChiPhis();

        IEnumerable<LoaiChiPhi> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
    }
}