using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
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
        public TourDuLich Get(int id)
        {
            return tourDuLichRepository.GetBy(id);
        }

        public bool Update(TourDuLich dto)
        {
            tourDuLichRepository.Update(dto, dto.MaTour);
            return true;
        }

        public bool Delete(int id)
        {
            var tour = tourDuLichRepository.GetBy(id);
            tourDuLichRepository.Delete(tour);
            return true;
        }

        public IEnumerable<TourDuLich> GetDTOs()
        {
            return tourDuLichRepository.GetAll();
        }
    }
}
