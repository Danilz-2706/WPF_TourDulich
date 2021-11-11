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
        private readonly INhanVienRepository nhanVienRepository;
        private readonly ILoaiChiPhiRepository loaiChiPhiRepository;
        private readonly IMapper mapper;

        public DoanDuLichService(IDoanDuLichRepository doanDuLichRepository,INoiDungTourRepository noiDungTourRepository,
            IKhachRepository khachRepository,IChiTietDoanRepository chiTietDoanRepository, 
            INhanVienRepository nhanVienRepository, ILoaiChiPhiRepository loaiChiPhiRepository ,IMapper mapper)
        {
            this.doanDuLichRepository = doanDuLichRepository;
            this.noiDungTourRepository = noiDungTourRepository;
            this.khachRepository = khachRepository;
            this.chiTietDoanRepository = chiTietDoanRepository;
            this.nhanVienRepository = nhanVienRepository;
            this.loaiChiPhiRepository = loaiChiPhiRepository;
            this.mapper = mapper;
        }

        #region Đoàn Du Lịch

        public bool Create(DoanDuLich dto)
        {
            doanDuLichRepository.Add(dto);
            return true;
        }

        public DoanDuLich Get(int maDoan)
        {
            return doanDuLichRepository.GetBy(maDoan);
        }

        public bool Update(DoanDuLich dto)
        {
            doanDuLichRepository.Update(dto, dto.MaDoan);
            return true;
        }

        public bool Delete(int maDoan)
        {
            var doan = doanDuLichRepository.GetBy(maDoan);
            doanDuLichRepository.Delete(doan);
            return true;
        }

        public IEnumerable<DoanDuLich> GetDTOs()
        {
            return doanDuLichRepository.GetAll();
        }

        #endregion

        #region Nội Dung Tour

        public bool CreateNDT(NoiDungTour dto)
        {
            noiDungTourRepository.Add(dto);
            return true;
        }

        public NoiDungTour GetNDT(int id)
        {
            return noiDungTourRepository.GetBy(id);
        }

        public bool UpdateNDT(NoiDungTour dto)
        {
            noiDungTourRepository.Update(dto, dto.MaDoan);
            return true;
        }

        public bool DeleteNDT(int id)
        {
            var ndt = noiDungTourRepository.GetBy(id);
            noiDungTourRepository.Delete(ndt);
            return true;
        }

        #endregion

    }
}
