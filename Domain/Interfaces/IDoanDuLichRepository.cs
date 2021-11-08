using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IDoanDuLichRepository : IEFRepository<DoanDuLich>
    {
        int CountDoanDuLich();

        IEnumerable<DoanDuLich> GetDoans();

        IEnumerable<DoanDuLich> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
    }
}