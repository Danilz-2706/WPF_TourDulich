using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetDTOs(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
        bool Create(T dto);
        T Get(int id);
        bool Update(T dto);
        bool Delete(int id);
    }
}
