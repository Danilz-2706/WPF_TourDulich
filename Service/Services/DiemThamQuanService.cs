using Domain.Entities;
using Domain.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class DiemThamQuanService : IDiemThamQuanService 
    { 
        private readonly IDiemThamQuanRepository diemThamQuanRepository;

        public DiemThamQuanService(IDiemThamQuanRepository diemThamQuanRepository)
        {
            this.diemThamQuanRepository = diemThamQuanRepository;
        }

        public bool Create(DiemThamQuan dto)
        {
            diemThamQuanRepository.Add(dto);
            return true;
        }

        public DiemThamQuan Get(params object[] keyValues)
        {
            return diemThamQuanRepository.GetBy(keyValues);
        }

        public bool Update(DiemThamQuan dto)
        {
            diemThamQuanRepository.Update(dto,dto.MaDiaDiem);
            return true;
        }

        public bool Delete(int id)
        {
            var dtq = diemThamQuanRepository.GetBy(id);
            diemThamQuanRepository.Delete(dtq);
            return true;
        }

        public IEnumerable<DiemThamQuan> GetDTOs()
        {
            return diemThamQuanRepository.GetAll();
        }
    }
}
