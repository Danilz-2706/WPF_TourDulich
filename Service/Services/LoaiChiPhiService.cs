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
    public class LoaiChiPhiService : ILoaiChiPhiService
    {
        private readonly ILoaiChiPhiRepository loaiChiPhiRepository;

        public LoaiChiPhiService(ILoaiChiPhiRepository loaiChiPhiRepository)
        {
            this.loaiChiPhiRepository = loaiChiPhiRepository;
        }

        public bool Create(LoaiChiPhi dto)
        {
            loaiChiPhiRepository.Add(dto);
            return true;
        }

        public LoaiChiPhi Get(params object[] keyValues)
        {
            return loaiChiPhiRepository.GetBy(keyValues);
        } 

        public bool Update(LoaiChiPhi dto)
        {
            loaiChiPhiRepository.Update(dto, dto.MaLoaiChiPhi);
            return true;
        }

        public bool Delete(int maLCP)
        {
            var lcp = loaiChiPhiRepository.GetBy(maLCP);
            loaiChiPhiRepository.Delete(lcp);
            return true;
        }

        public IEnumerable<LoaiChiPhi> GetDTOs()
        {
            return loaiChiPhiRepository.GetAll();
        }
    }
}
