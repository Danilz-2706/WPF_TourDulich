using Domain.Entities;
using Domain.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class ChiPhiService : IChiPhiService
    {
        private readonly IChiPhiRepository chiPhiRepository;

        public ChiPhiService(IChiPhiRepository chiPhiRepository)
        {
            this.chiPhiRepository = chiPhiRepository;
        }

        public bool Create(ChiPhi chiPhi)
        {
            chiPhiRepository.Add(chiPhi);
            return true;
        }

        public ChiPhi Get(params object[] keyValues)
        {
            var chiPhi = chiPhiRepository.GetBy(keyValues);
            return chiPhi;
        }

        public bool Update(ChiPhi chiPhi)
        {
            chiPhiRepository.Update(chiPhi, chiPhi.MaChiPhi);
            return true;
        }

        public bool Delete(params object[] keyValues)
        {
            var chiPhi = chiPhiRepository.GetBy(keyValues);
            chiPhiRepository.Delete(chiPhi);
            return true;
        }

        public IEnumerable<ChiPhi> GetDTOs()
        {
            return chiPhiRepository.GetAll();
        }
    }
}
