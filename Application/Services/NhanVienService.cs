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
    public class NhanVienService : INhanVienService
    {
        private readonly INhanVienRepository nhanVienRepository;
        private readonly IMapper mapper;

        public NhanVienService(INhanVienRepository nhanVienRepository, IMapper mapper)
        {
            this.nhanVienRepository = nhanVienRepository;
            this.mapper = mapper;
        }

        public bool Create(NhanVienDTO dto)
        {
            var nv = mapper.Map<NhanVien>(dto);
            nhanVienRepository.Add(nv);
            return true;
        }

        public NhanVienDTO Get(int maNV)
        {
            var nv = nhanVienRepository.GetBy(maNV);
            return mapper.Map<NhanVienDTO>(nv);
        }

        public bool Update(NhanVienDTO dto)
        {
            var nv = nhanVienRepository.GetBy(dto.MaNhanVien);
            mapper.Map<NhanVienDTO, NhanVien>(dto, nv);
            nhanVienRepository.Update(nv);
            return true;
        }

        public bool Delete(int maNV)
        {
            var nv = nhanVienRepository.GetBy(maNV);
            nhanVienRepository.Delete(nv);
            return true;
        }

        public IEnumerable<NhanVienDTO> GetDTOs(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var nhanViens = nhanVienRepository.Filter(sortOrder, searchString, pageIndex, pageSize, out count);
            return mapper.Map<IEnumerable<NhanVienDTO>>(nhanViens);
        }
    }
}
