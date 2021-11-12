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

        public ChiPhi Get(int maCP)
        {
            var chiPhi = chiPhiRepository.GetBy(maCP);
            return chiPhi;
        }

        public bool Update(ChiPhi chiPhi)
        {
            chiPhiRepository.Update(chiPhi, chiPhi.MaChiPhi);
            return true;
        }

        public bool Delete(int maCP)
        {
            var chiPhi = chiPhiRepository.GetBy(maCP);
            chiPhiRepository.Delete(chiPhi);
            return true;
        }

        public IEnumerable<ChiPhi> GetDTOs()
        {
            return chiPhiRepository.GetAll();
        }
    }
}
