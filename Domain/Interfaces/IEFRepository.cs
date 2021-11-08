using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEFRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetBy(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}