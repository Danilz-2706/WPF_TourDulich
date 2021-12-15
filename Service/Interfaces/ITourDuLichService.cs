using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITourDuLichService : IService<TourDuLich>
    {
        IEnumerable<DiaDiem> GetDiaDiemsByTour(int id);
    }
}
