using System;
namespace Domain.Entities
{
    public class DiemThamQuan
    {
        public TourDuLich TourDuLich { get; set; }
        public int MaTour { get; set; }
        public DiaDiem DiaDiem { get; set; }
        public int MaDiaDiem { get; set; }
        public int ThuTu { get; set; }
    }
}
