using System;
namespace Domain.Entities
{
    public class GiaTour
    {
        public int MaGia { get; set; }
        public TourDuLich TourDuLich { get; set; }
        public int MaTour { get; set; }
        public long ThanhTien { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
    }
}
