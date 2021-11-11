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
    public class GiaTourService : IGiaTourService
    {
        private readonly IGiaTourRepository giaTourRepository;
        private readonly IMapper mapper;

        public GiaTourService(IGiaTourRepository giaTourRepository, IMapper mapper)
        {
            this.giaTourRepository = giaTourRepository;
            this.mapper = mapper;
        }

        public bool Create(GiaTourDTO dto)
        {
            var gia = mapper.Map<GiaTour>(dto);
            giaTourRepository.Add(gia);
            return true;
        }
        public GiaTourDTO Get(int id)
        {
            var gia = giaTourRepository.GetBy(id);
            return mapper.Map<GiaTourDTO>(gia);
        }

        public bool Update(GiaTourDTO dto)
        {
            var gia = giaTourRepository.GetBy(dto.MaGia);
            mapper.Map<GiaTourDTO, GiaTour>(dto, gia);
            giaTourRepository.Update(gia);
            return true;
        }

        public bool Delete(int id)
        {
            var gia = giaTourRepository.GetBy(id);
            giaTourRepository.Delete(gia);
            return true;
        }

        public IEnumerable<GiaTourDTO> GetDTOs(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var gias = giaTourRepository.Filter(sortOrder, searchString, pageIndex, pageSize, out count);
            return mapper.Map<IEnumerable<GiaTourDTO>>(gias);
        }
    }
}
