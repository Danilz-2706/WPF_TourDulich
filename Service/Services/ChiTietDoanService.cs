using Domain.Entities;
using Domain.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class ChiTietDoanService : IChiTietDoanService
    {
        private readonly IChiTietDoanRepository chiTietDoanRepository;

        public ChiTietDoanService(IChiTietDoanRepository chiTietDoanRepository)
        {
            this.chiTietDoanRepository = chiTietDoanRepository;
        }

        public bool Create(ChiTietDoan dto)
        {
            chiTietDoanRepository.Add(dto);
            return true;
        }

        public ChiTietDoan Get(params object[] keyValues)
        {
            return chiTietDoanRepository.GetBy(keyValues);
        }

        public bool Update(ChiTietDoan dto)
        {
            chiTietDoanRepository.Update(dto, dto.MaDoan);
            return true;
        }

        public bool Delete(params object[] keyValues)
        {
            var ctd = chiTietDoanRepository.GetBy(keyValues);
            chiTietDoanRepository.Delete(ctd);
            return true;
        }

        public IEnumerable<ChiTietDoan> GetDTOs()
        {
            return chiTietDoanRepository.GetAll();
        }
    }
}
