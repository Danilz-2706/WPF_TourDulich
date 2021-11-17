using Domain.Entities;
using Domain.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class NoiDungTourService : INoiDungTourService
    {
        private readonly INoiDungTourRepository noiDungTourRepository;

        public NoiDungTourService(INoiDungTourRepository noiDungTourRepository)
        {
            this.noiDungTourRepository = noiDungTourRepository;
        }

        #region Nội Dung Tour

        public bool Create(NoiDungTour dto)
        {
            noiDungTourRepository.Add(dto);
            return true;
        }

        public NoiDungTour Get(int id)
        {
            return noiDungTourRepository.GetBy(id);
        }

        public bool Update(NoiDungTour dto)
        {
            noiDungTourRepository.Update(dto, dto.MaDoan);
            return true;
        }

        public bool Delete(int id)
        {
            var ndt = noiDungTourRepository.GetBy(id);
            noiDungTourRepository.Delete(ndt);
            return true;
        }

        public IEnumerable<NoiDungTour> GetDTOs()
        {
            return noiDungTourRepository.GetAll();
        }


        #endregion
    }
}
