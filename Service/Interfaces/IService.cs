using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetDTOs();
        bool Create(T dto);
        T Get(params object[] keyValues);
        bool Update(T dto);
        bool Delete(int id);
    }
}
