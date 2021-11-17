using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class DoanDuLich
    {
        public int MaDoan { get; set; }
        public TourDuLich Tour { get; set; }
        public string TenTour { get; set; }
        public int MaTour { get; set; }
        public NoiDungTour NoiDungTour { get; set; }
        public string TenDoan { get; set; }
        public DateTime NgayKhoiHanh { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public long DoanhThu { get; set; }
        public ICollection<ChiTietDoan> ChiTietDoans { get; set; }
        public ICollection<Khach> Khaches { get; set; }
        public ICollection<ChiPhi> ChiPhis { get; set; }
        public ICollection<PhanBoNhanVienDoan> PhanBoNhanVienDoans { get; set; }
        public ICollection<NhanVien> NhanViens { get; set; }
    }
}
