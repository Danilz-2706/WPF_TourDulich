using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetDTOs();
        bool Create(T dto);
        T Get(int id);
        bool Update(T dto);
        bool Delete(int id);
    }
}
