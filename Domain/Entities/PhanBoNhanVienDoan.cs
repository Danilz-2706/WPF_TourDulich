using System;
namespace Domain.Entities
{
    public class PhanBoNhanVienDoan
    {
        public NhanVien NhanVien { get; set; }
        public int MaNhanVien { get; set; }
        public DoanDuLich Doan { get; set; }
        public int MaDoan { get; set; }
        public string NhiemVu { get; set; }
    }
}
