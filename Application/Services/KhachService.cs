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
    public class KhachService : IKhachService
    {
        private readonly IKhachRepository khachRepository;
        private readonly IMapper mapper;

        public KhachService(IKhachRepository khachRepository, IMapper mapper)
        {
            this.khachRepository = khachRepository;
            this.mapper = mapper;
        }
        

        public bool Create(KhachDTO dto)
        {
            var kh = mapper.Map<Khach>(dto);
            khachRepository.Add(kh);
            return true;
        }

        public KhachDTO Get(int id)
        {
            var kh = khachRepository.GetBy(id);
            return mapper.Map<KhachDTO>(kh);
        }

        public bool Update(KhachDTO dto)
        {
            var kh = khachRepository.GetBy(dto.MaKhachHang);
            mapper.Map<KhachDTO, Khach>(dto, kh);
            khachRepository.Update(kh);
            return true;
        }

        public bool Delete(int id)
        {
            var kh = khachRepository.GetBy(id);
            khachRepository.Delete(kh);
            return true;
        }

        public IEnumerable<KhachDTO> GetDTOs(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var khachs = khachRepository.Filter(sortOrder, searchString, pageIndex, pageSize, out count);
            return mapper.Map<IEnumerable<KhachDTO>>(khachs);
        }
    }
}
