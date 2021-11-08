using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IChiTietDoanRepository : IEFRepository<ChiTietDoan>
    {
        int CountChiTietDoan();

        IEnumerable<ChiTietDoan> GetChiTietDoans();
    }
}