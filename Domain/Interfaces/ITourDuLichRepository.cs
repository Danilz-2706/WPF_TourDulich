using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface ITourDuLichRepository : IEFRepository<TourDuLich>
    {
        int CountTourDuLich();
        IEnumerable<TourDuLich> GetTours();
        IEnumerable<DiaDiem> GetDiaDiemsByTour(int id);
        IEnumerable<TourDuLich> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
    }
}