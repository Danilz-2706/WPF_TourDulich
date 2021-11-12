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

        public Khach Get(int id)
        {
            return khachRepository.GetBy(id);
        }

        public bool Update(Khach dto)
        {
            khachRepository.Update(dto, dto.MaKhachHang);
            return true;
        }

        public bool Delete(int id)
        {
            var kh = khachRepository.GetBy(id);
            khachRepository.Delete(kh);
            return true;
        }

        public IEnumerable<Khach> GetDTOs()
        {
            return khachRepository.GetAll();
        }
    }
}
