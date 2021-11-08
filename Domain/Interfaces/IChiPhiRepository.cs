using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IChiPhiRepository : IEFRepository<ChiPhi>
    {
        int CountChiPhi();

        IEnumerable<ChiPhi> GetChiPhis();

        IEnumerable<ChiPhi> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
    }
}