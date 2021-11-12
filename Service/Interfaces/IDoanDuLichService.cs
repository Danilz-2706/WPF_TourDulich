using Domain.Entities;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IDoanDuLichService : IService<DoanDuLich>
    {
        bool CreateNDT(NoiDungTour dto);
        NoiDungTour GetNDT(int id);
        bool UpdateNDT(NoiDungTour dto);
        bool DeleteNDT(int id);
        /*IEnumerable<Khach> GetKhach_DTOs(int id);
        IEnumerable<NhanVien> GetNV_DTOs(int id);
        IEnumerable<ChiPhi> GetCP_DTOs(int id);*/
    }
}
