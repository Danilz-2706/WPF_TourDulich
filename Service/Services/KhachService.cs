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
    public class KhachService : IKhachService
    {
        private readonly IKhachRepository khachRepository;

        public KhachService(IKhachRepository khachRepository)
        {
            this.khachRepository = khachRepository;
        }
        

        public bool Create(Khach dto)
        {
            khachRepository.Add(dto);
            return true;
        }

        public Khach Get(params object[] keyValues)
        {
            return khachRepository.GetBy(keyValues);
        }

        public bool Update(Khach dto)
        {
            khachRepository.Update(dto, dto.MaKhachHang);
            return true;
        }

        public bool Delete(params object[] keyValues)
        {
            var kh = khachRepository.GetBy(keyValues);
            khachRepository.Delete(kh);
            return true;
        }

        public IEnumerable<Khach> GetDTOs()
        {
            return khachRepository.GetAll();
        }
    }
}
