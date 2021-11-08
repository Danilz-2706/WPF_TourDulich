using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IKhachRepository : IEFRepository<Khach>
    {
        int CountKhach();

        IEnumerable<Khach> GetKhaches();

        IEnumerable<Khach> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
    }
}