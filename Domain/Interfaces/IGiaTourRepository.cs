using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IGiaTourRepository : IEFRepository<GiaTour>
    {
        int CountGiaTour();

        IEnumerable<GiaTour> GetGias();

        IEnumerable<GiaTour> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
    }
}