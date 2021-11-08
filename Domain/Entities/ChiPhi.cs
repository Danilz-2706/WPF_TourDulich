using System;
namespace Domain.Entities
{
    public class ChiPhi
    {
        public int MaChiPhi { get; set; }
        public DoanDuLich DoanDuLich { get; set; }
        public int MaDoan { get; set; }
        public long SoTien { get; set; }
        public int MaLoaiChiPhi { get; set; }
        public LoaiChiPhi LoaiChiPhi { get; set; }
    }
}
