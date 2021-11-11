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
    public class GiaTourService : IGiaTourService
    {
        private readonly IGiaTourRepository giaTourRepository;

        public GiaTourService(IGiaTourRepository giaTourRepository)
        {
            this.giaTourRepository = giaTourRepository;
        }

        public bool Create(GiaTour dto)
        {
            giaTourRepository.Add(dto);
            return true;
        }
        public GiaTour Get(int id)
        {
            return giaTourRepository.GetBy(id);
        }

        public bool Update(GiaTour dto)
        {
            giaTourRepository.Update(dto, dto.MaGia);
            return true;
        }

        public bool Delete(int id)
        {
            var gia = giaTourRepository.GetBy(id);
            giaTourRepository.Delete(gia);
            return true;
        }

        public IEnumerable<GiaTour> GetDTOs()
        {
            return giaTourRepository.GetAll();
        }
    }
}
