using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class ChiPhiService : IChiPhiService
    {
        private readonly IChiPhiRepository chiPhiRepository;
        private readonly IMapper mapper;

        public ChiPhiService(IChiPhiRepository chiPhiRepository, IMapper mapper)
        {
            this.chiPhiRepository = chiPhiRepository;
            this.mapper = mapper;
        }

        public bool Create(ChiPhiDTO chiPhiDTO)
        {
            var chiPhi = mapper.Map<ChiPhi>(chiPhiDTO);
            chiPhiRepository.Add(chiPhi);
            return true;
        }

        public ChiPhiDTO Get(int maCP)
        {
            var chiPhi = chiPhiRepository.GetBy(maCP);
            return mapper.Map<ChiPhiDTO>(chiPhi);
        }

        public bool Update(ChiPhiDTO chiPhiDTO)
        {
            var chiPhi = chiPhiRepository.GetBy(chiPhiDTO.MaChiPhi);
            mapper.Map<ChiPhiDTO, ChiPhi>(chiPhiDTO, chiPhi);
            chiPhiRepository.Update(chiPhi);
            return true;
        }

        public bool Delete(int maCP)
        {
            var chiPhi = chiPhiRepository.GetBy(maCP);
            chiPhiRepository.Delete(chiPhi);
            return true;
        }

        public IEnumerable<ChiPhiDTO> GetDTOs(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var chiPhis = chiPhiRepository.Filter(sortOrder, searchString, pageIndex, pageSize, out count);
            return mapper.Map<IEnumerable<ChiPhiDTO>>(chiPhis);
        }
    }
}
