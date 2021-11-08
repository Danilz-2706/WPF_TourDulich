using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface ILoaiHinhDuLichRepository : IEFRepository<LoaiHinhDuLich>
    {
        int CountLoaiHinh();

        IEnumerable<LoaiHinhDuLich> GetLoaiHinhs();

        IEnumerable<LoaiHinhDuLich> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
    }
}