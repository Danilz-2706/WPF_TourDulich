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
    public class LoaiHinhDuLichService : ILoaiHinhDuLichService
    {
        private readonly ILoaiHinhDuLichRepository loaiHinhDuLichRepository;

        public LoaiHinhDuLichService(ILoaiHinhDuLichRepository loaiHinhDuLichRepository)
        {
            this.loaiHinhDuLichRepository = loaiHinhDuLichRepository;
        }

        public bool Create(LoaiHinhDuLich dto)
        {
            loaiHinhDuLichRepository.Add(dto);
            return true;
        }

        public LoaiHinhDuLich Get(int maLH)
        {
            return loaiHinhDuLichRepository.GetBy(maLH);
        }

        public bool Update(LoaiHinhDuLich dto)
        {
            loaiHinhDuLichRepository.Update(dto, dto.MaLoaiHinh);
            return true;
        }

        public bool Delete(int maLH)
        {
            var lh = loaiHinhDuLichRepository.GetBy(maLH);
            loaiHinhDuLichRepository.Delete(lh);
            return true;
        }

        public IEnumerable<LoaiHinhDuLich> GetDTOs()
        {
            return loaiHinhDuLichRepository.GetAll();
        }
        
    }
}
