using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface INoiDungTourRepository : IEFRepository<NoiDungTour>
    {
        int CountNoiDungTour();

        IEnumerable<NoiDungTour> GetNoiDungTours();
    }
}