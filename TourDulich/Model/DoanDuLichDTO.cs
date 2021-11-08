using System;
using System.Collections.Generic;

namespace TourDulich.Model
{
    public class DoanDuLichDTO
    {
        public int MaDoan { get; set; }
        public int MaTour { get; set; }
        public string TenDoan { get; set; }
        public DateTime NgayKhoiHanh { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public long DoanhThu { get; set; }
    }
}
