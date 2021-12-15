using Service.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class DoanDuLichService : IDoanDuLichService
    {
        private readonly IDoanDuLichRepository doanDuLichRepository;

        public DoanDuLichService(IDoanDuLichRepository doanDuLichRepository)
        {
            this.doanDuLichRepository = doanDuLichRepository;
        }

        #region Đoàn Du Lịch

        public bool Create(DoanDuLich dto)
        {
            doanDuLichRepository.Add(dto);
            return true;
        }

        public DoanDuLich Get(params object[] keyValues)
        {
            return doanDuLichRepository.GetBy(keyValues);
        }

        public bool Update(DoanDuLich dto)
        {
            doanDuLichRepository.Update(dto, dto.MaDoan);
            return true;
        }

        public bool Delete(params object[] keyValues)
        {
            var doan = doanDuLichRepository.GetBy(keyValues);
            doanDuLichRepository.Delete(doan);
            return true;
        }

        public IEnumerable<DoanDuLich> GetDTOs()
        {
            return doanDuLichRepository.GetAll();
        }

        public IEnumerable<Khach> GetKhachsByDoan(int id)
        {
            return doanDuLichRepository.GetKhachsByDoan(id);
        }

        public IEnumerable<NhanVien> GetNVsByDoan(int id)
        {
            return doanDuLichRepository.GetNVsByDoan(id);
        }

        public IEnumerable<ChiPhi> GetCPsByDoan(int id)
        {
            return doanDuLichRepository.GetCPsByDoan(id);
        }

        public void UpdateDoanhThu(int id)
        {
            doanDuLichRepository.UpdateDoanhThu(id);
        }
        #endregion

    }
}
