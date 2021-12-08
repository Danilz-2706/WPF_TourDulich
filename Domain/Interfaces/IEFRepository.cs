using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEFRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetBy(params object[] keyValues);

        void Add(T entity);

        void Update(T entity);

        void Update(T entity, params object[] keyValues);

        void Delete(T entity);
    }
}