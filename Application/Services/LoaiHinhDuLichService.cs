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
    public class LoaiHinhDuLichService : ILoaiHinhDuLichService
    {
        private readonly ILoaiHinhDuLichRepository loaiHinhDuLichRepository;
        private readonly IMapper mapper;

        public LoaiHinhDuLichService(ILoaiHinhDuLichRepository loaiHinhDuLichRepository, IMapper mapper )
        {
            this.loaiHinhDuLichRepository = loaiHinhDuLichRepository;
            this.mapper = mapper;
        }

        public bool Create(LoaiHinhDuLichDTO dto)
        {
            var lh = mapper.Map<LoaiHinhDuLich>(dto);
            loaiHinhDuLichRepository.Add(lh);
            return true;
        }

        public LoaiHinhDuLichDTO Get(int maLH)
        {
            var lh = loaiHinhDuLichRepository.GetBy(maLH);
            return mapper.Map<LoaiHinhDuLichDTO>(lh);
        }

        public bool Update(LoaiHinhDuLichDTO dto)
        {
            var lh = loaiHinhDuLichRepository.GetBy(dto.MaLoaiHinh);
            mapper.Map<LoaiHinhDuLichDTO, LoaiHinhDuLich>(dto,lh);
            loaiHinhDuLichRepository.Update(lh);
            return true;
        }

        public bool Delete(int maLH)
        {
            var lh = loaiHinhDuLichRepository.GetBy(maLH);
            loaiHinhDuLichRepository.Delete(lh);
            return true;
        }

        public IEnumerable<LoaiHinhDuLichDTO> GetDTOs(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var lhs = loaiHinhDuLichRepository.Filter(sortOrder, searchString, pageIndex, pageSize, out count);
            return mapper.Map<IEnumerable<LoaiHinhDuLichDTO>>(lhs);
        }
        
    }
}
