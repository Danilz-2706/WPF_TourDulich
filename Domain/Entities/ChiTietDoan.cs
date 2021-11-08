using Domain.Entities.Enum;
using System;
namespace Domain.Entities
{
    public class ChiTietDoan
    {
        public DoanDuLich Doan { get; set; }
        public int MaDoan { get; set; }
        public Khach Khach { get; set; }
        public int MaKhachHang { get; set; }
        public VaiTro VaiTro { get; set; }
    }
}
