using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
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
        private readonly IMapper mapper;

        public TourDuLichService(ITourDuLichRepository tourDuLichRepository, IMapper mapper)
        {
            this.tourDuLichRepository = tourDuLichRepository;
            this.mapper = mapper;
        }

        public bool Create(TourDuLichDTO dto)
        {
            var tour = mapper.Map<TourDuLich>(dto);
            tourDuLichRepository.Add(tour);
            return true;
        }
        public TourDuLichDTO Get(int id)
        {
            var tour = tourDuLichRepository.GetBy(id);
            return mapper.Map<TourDuLichDTO>(tour);
        }

        public bool Update(TourDuLichDTO dto)
        {
            var tour = tourDuLichRepository.GetBy(dto.MaTour);
            mapper.Map<TourDuLichDTO, TourDuLich>(dto, tour);
            tourDuLichRepository.Update(tour);
            return true;
        }

        public bool Delete(int id)
        {
            var tour = tourDuLichRepository.GetBy(id);
            tourDuLichRepository.Delete(tour);
            return true;
        }

        public IEnumerable<TourDuLichDTO> GetDTOs(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var tours = tourDuLichRepository.Filter(sortOrder, searchString, pageIndex, pageSize, out count);
            return mapper.Map<IEnumerable<TourDuLichDTO>>(tours);
        }
    }
}
