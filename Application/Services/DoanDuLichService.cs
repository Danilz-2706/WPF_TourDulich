using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DoanDuLichService : IDoanDuLichService
    {
        private readonly IDoanDuLichRepository doanDuLichRepository;
        private readonly INoiDungTourRepository noiDungTourRepository;
        private readonly IKhachRepository khachRepository;
        private readonly IChiTietDoanRepository chiTietDoanRepository;
        private readonly IMapper mapper;

        public DoanDuLichService(IDoanDuLichRepository doanDuLichRepository,INoiDungTourRepository noiDungTourRepository,
            IKhachRepository khachRepository,IChiTietDoanRepository chiTietDoanRepository, IMapper mapper)
        {
            this.doanDuLichRepository = doanDuLichRepository;
            this.noiDungTourRepository = noiDungTourRepository;
            this.khachRepository = khachRepository;
            this.chiTietDoanRepository = chiTietDoanRepository;
            this.mapper = mapper;
        }

        #region Đoàn Du Lịch

        public bool Create(DoanDuLichDTO dto)
        {
            var doan = mapper.Map<DoanDuLich>(dto);
            doanDuLichRepository.Add(doan);
            return true;
        }

        public DoanDuLichDTO Get(int maDoan)
        {
            var doan = doanDuLichRepository.GetBy(maDoan);
            return mapper.Map<DoanDuLichDTO>(doan);
        }

        public bool Update(DoanDuLichDTO dto)
        {
            var doan = doanDuLichRepository.GetBy(dto.MaDoan);
            mapper.Map<DoanDuLichDTO, DoanDuLich>(dto, doan);
            doanDuLichRepository.Update(doan);
            return true;
        }

        public bool Delete(int maDoan)
        {
            var doan = doanDuLichRepository.GetBy(maDoan);
            doanDuLichRepository.Delete(doan);
            return true;
        }

        public IEnumerable<DoanDuLichDTO> GetDTOs(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var doans = doanDuLichRepository.Filter(sortOrder, searchString, pageIndex, pageSize, out count);
            return mapper.Map<IEnumerable<DoanDuLichDTO>>(doans);
        }

        #endregion

        #region Nội Dung Tour

        public bool CreateNDT(NoiDungTourDTO dto)
        {
            var ndt = mapper.Map<NoiDungTour>(dto);
            noiDungTourRepository.Add(ndt);
            return true;
        }

        public NoiDungTourDTO GetNDT(int id)
        {
            var ndt = noiDungTourRepository.GetBy(id);
            return mapper.Map<NoiDungTourDTO>(ndt);
        }

        public bool UpdateNDT(NoiDungTourDTO dto)
        {
            var ndt = noiDungTourRepository.GetBy(dto.MaDoan);
            mapper.Map<NoiDungTourDTO, NoiDungTour>(dto, ndt);
            noiDungTourRepository.Update(ndt);
            return true;
        }

        public bool DeleteNDT(int id)
        {
            var ndt = noiDungTourRepository.GetBy(id);
            noiDungTourRepository.Delete(ndt);
            return true;
        }

        #endregion

        #region Khách

        public IEnumerable<KhachDTO> GetKhach_DTOs(int id)
        {
            var ctds = chiTietDoanRepository.GetAll().Where(x => x.MaDoan == id);
            var khachs = khachRepository.GetAll().Where(x => ctds.Any(c => c.MaKhachHang == x.MaKhachHang));
            var khachDTOs = mapper.Map<IEnumerable<KhachDTO>>(khachs).ToList();
            var dtos = khachDTOs.Select(x => { x.VaiTro = ctds.Where(
                 c => c.MaKhachHang == x.MaKhachHang).FirstOrDefault().VaiTro; return x;
            }).ToList();
            
            return dtos;
        }

        #endregion
    }
}
