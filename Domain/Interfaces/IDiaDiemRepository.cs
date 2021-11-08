using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IDiaDiemRepository : IEFRepository<DiaDiem>
    {
        int CountDiaDiem();

        IEnumerable<DiaDiem> GetDiaDiems();

        IEnumerable<DiaDiem> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
    }
}