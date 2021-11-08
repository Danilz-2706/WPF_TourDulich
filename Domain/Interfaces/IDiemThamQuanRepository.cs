using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IDiemThamQuanRepository : IEFRepository<DiemThamQuan>
    {
        int CountDiemThamQuan();

        IEnumerable<DiemThamQuan> GetDiemThamQuans();
    }
}