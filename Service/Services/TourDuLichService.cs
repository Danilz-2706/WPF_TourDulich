using Domain.Entities;
using Domain.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class TourDuLichService : ITourDuLichService
    {
        private readonly ITourDuLichRepository tourDuLichRepository;

        public TourDuLichService(ITourDuLichRepository tourDuLichRepository)
        {
            this.tourDuLichRepository = tourDuLichRepository;
        }

        public bool Create(TourDuLich dto)
        {
            tourDuLichRepository.Add(dto);
            return true;
        }
        public TourDuLich Get(params object[] keyValues)
        {
            return tourDuLichRepository.GetBy(keyValues);
        }

        public bool Update(TourDuLich dto)
        {
            tourDuLichRepository.Update(dto, dto.MaTour);
            return true;
        }

        public bool Delete(params object[] keyValues)
        {
            var tour = tourDuLichRepository.GetBy(keyValues);
            tourDuLichRepository.Delete(tour);
            return true;
        }

        public IEnumerable<TourDuLich> GetDTOs()
        {
            return tourDuLichRepository.GetAll();
        }

        public IEnumerable<DiaDiem> GetDiaDiemsByTour(int id)
        {
            return tourDuLichRepository.GetDiaDiemsByTour(id);
        }
    }
}
