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
    public class NhanVienService : INhanVienService
    {
        private readonly INhanVienRepository nhanVienRepository;

        public NhanVienService(INhanVienRepository nhanVienRepository)
        {
            this.nhanVienRepository = nhanVienRepository;
        }

        public bool Create(NhanVien dto)
        {
            nhanVienRepository.Add(dto);
            return true;
        }

        public NhanVien Get(int maNV)
        {
            return nhanVienRepository.GetBy(maNV);
        }

        public bool Update(NhanVien dto)
        {
            nhanVienRepository.Update(dto, dto.MaNhanVien);
            return true;
        }

        public bool Delete(int maNV)
        {
            var nv = nhanVienRepository.GetBy(maNV);
            nhanVienRepository.Delete(nv);
            return true;
        }

        public IEnumerable<NhanVien> GetDTOs()
        {
            return nhanVienRepository.GetAll();
        }
    }
}
