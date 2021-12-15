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

        public NhanVien Get(params object[] keyValues)
        {
            return nhanVienRepository.GetBy(keyValues);
        }

        public bool Update(NhanVien dto)
        {
            nhanVienRepository.Update(dto, dto.MaNhanVien);
            return true;
        }

        public bool Delete(params object[] keyValues)
        {
            var nv = nhanVienRepository.GetBy(keyValues);
            nhanVienRepository.Delete(nv);
            return true;
        }

        public IEnumerable<NhanVien> GetDTOs()
        {
            return nhanVienRepository.GetAll();
        }
    }
}
