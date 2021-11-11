using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DiaDiemService : IDiaDiemService
    {
        private readonly IDiaDiemRepository diaDiemRepository;
        private readonly IMapper mapper;

        public DiaDiemService(IDiaDiemRepository diaDiemRepository, IMapper mapper)
        {
            this.diaDiemRepository = diaDiemRepository;
            this.mapper = mapper;
        }

        public bool Create(DiaDiemDTO dto)
        {


            throw new NotImplementedException();
        }

        public DiaDiemDTO Get(int maDD)
        {
            throw new NotImplementedException();
        }
        public bool Update(DiaDiemDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int maDD)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DiaDiemDTO> GetDTOs(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            throw new NotImplementedException();
        }

    }
}
