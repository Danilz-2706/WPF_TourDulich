﻿using Domain.Entities;
using Domain.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
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
        public GiaTour Get(params object[] keyValues)
        {
            return giaTourRepository.GetBy(keyValues);
        }

        public bool Update(GiaTour dto)
        {
            giaTourRepository.Update(dto, dto.MaGia);
            return true;
        }

        public bool Delete(params object[] keyValues)
        {
            var gia = giaTourRepository.GetBy(keyValues);
            giaTourRepository.Delete(gia);
            return true;
        }

        public IEnumerable<GiaTour> GetDTOs()
        {
           
           return giaTourRepository.GetAll();
        }

        public IEnumerable<GiaTour> GetDTOsByMaTour(int id)
        {
            return giaTourRepository.GetAll().Where(x => x.MaTour == id);
        }
    }
}
