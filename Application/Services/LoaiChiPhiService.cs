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
    public class LoaiChiPhiService : ILoaiChiPhiService
    {
        private readonly ILoaiChiPhiRepository loaiChiPhiRepository;
        private readonly IMapper mapper;

        public LoaiChiPhiService(ILoaiChiPhiRepository loaiChiPhiRepository, IMapper mapper)
        {
            this.loaiChiPhiRepository = loaiChiPhiRepository;
            this.mapper = mapper;
        }

        public bool Create(LoaiChiPhiDTO dto)
        {
            var lcp = mapper.Map<LoaiChiPhi>(dto);
            loaiChiPhiRepository.Add(lcp);
            return true;
        }

        public LoaiChiPhiDTO Get(int maLCP)
        {
            var lcp = loaiChiPhiRepository.GetBy(maLCP);
            return mapper.Map<LoaiChiPhiDTO>(lcp);
        } 

        public bool Update(LoaiChiPhiDTO dto)
        {
            var lcp = loaiChiPhiRepository.GetBy(dto.MaLoaiChiPhi);
            mapper.Map<LoaiChiPhiDTO, LoaiChiPhi>(dto, lcp);
            loaiChiPhiRepository.Update(lcp);
            return true;
        }

        public bool Delete(int maLCP)
        {
            var lcp = loaiChiPhiRepository.GetBy(maLCP);
            loaiChiPhiRepository.Delete(lcp);
            return true;
        }

        public IEnumerable<LoaiChiPhiDTO> GetDTOs(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var lcps = loaiChiPhiRepository.Filter(sortOrder, searchString, pageIndex, pageSize, out count);
            return mapper.Map<IEnumerable<LoaiChiPhiDTO>>(lcps);
        }
    }
}
