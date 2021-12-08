using Domain.Entities;
using Domain.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class PhanBoNhanVienDoanService : IPhanBoNhanVienDoanService
    {
        private readonly IPhanBoNhanVienDoanRepository phanBoNhanVienDoanRepository;

        public PhanBoNhanVienDoanService(IPhanBoNhanVienDoanRepository phanBoNhanVienDoanRepository)
        {
            this.phanBoNhanVienDoanRepository = phanBoNhanVienDoanRepository;
        }

        public bool Create(PhanBoNhanVienDoan dto)
        {
            phanBoNhanVienDoanRepository.Add(dto);
            return true;
        }

        public PhanBoNhanVienDoan Get(params object[] keyValues)
        {
            return phanBoNhanVienDoanRepository.GetBy(keyValues);
        }

        public bool Update(PhanBoNhanVienDoan dto)
        {
            phanBoNhanVienDoanRepository.Update(dto,dto.MaDoan);
            return true;
        }

        public bool Delete(int id)
        {
            var pb = phanBoNhanVienDoanRepository.GetBy(id);
            phanBoNhanVienDoanRepository.Delete(pb);
            return true;
        }

        public IEnumerable<PhanBoNhanVienDoan> GetDTOs()
        {
            return phanBoNhanVienDoanRepository.GetAll();
        }
    }
}
