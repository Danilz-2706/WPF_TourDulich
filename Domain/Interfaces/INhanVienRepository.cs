using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface INhanVienRepository : IEFRepository<NhanVien>
    {
        int CountNhanVien();

        IEnumerable<NhanVien> GetNhanViens();

        IEnumerable<NhanVien> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
    }
}