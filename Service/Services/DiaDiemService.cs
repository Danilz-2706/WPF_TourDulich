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


            throw new NotImplementedException();
        }

        public DiaDiem Get(int maDD)
        {
            throw new NotImplementedException();
        }
        public bool Update(DiaDiem dto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int maDD)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DiaDiem> GetDTOs()
        {
            throw new NotImplementedException();
        }

    }
}
