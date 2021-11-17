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
    public class DiaDiemService : IDiaDiemService
    {
        private readonly IDiaDiemRepository diaDiemRepository;

        public DiaDiemService(IDiaDiemRepository diaDiemRepository)
        {
            this.diaDiemRepository = diaDiemRepository;
        }

        public bool Create(DiaDiem dto)
        {
            diaDiemRepository.Add(dto);
            return true;
        }

        public DiaDiem Get(int maDD)
        {
            var dd = diaDiemRepository.GetBy(maDD);
            return dd;
        }
        public bool Update(DiaDiem dto)
        {
            diaDiemRepository.Update(dto, dto.MaDiaDiem);
            return true;
        }

        public bool Delete(int maDD)
        {
            var dd = diaDiemRepository.GetBy(maDD);
            diaDiemRepository.Delete(dd);
            return true;
        }

        public IEnumerable<DiaDiem> GetDTOs()
        {
            return diaDiemRepository.GetAll();
        }

    }
}
