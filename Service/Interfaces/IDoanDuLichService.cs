using Domain.Entities;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IDoanDuLichService : IService<DoanDuLich>
    {
        IEnumerable<Khach> GetKhachsByDoan(int id);
        IEnumerable<NhanVien> GetNVsByDoan(int id);
        IEnumerable<ChiPhi> GetCPsByDoan(int id);
        void UpdateDoanhThu(int id);
    }
}
