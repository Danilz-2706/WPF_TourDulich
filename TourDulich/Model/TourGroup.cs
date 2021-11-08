using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourDulich.Model
{
    class TourGroup
    {
        public string TenDoan { get; set; }
        public DateTime? NgayDi { get; set; }
        public DateTime? NgayVe { get; set; }
        public string DoanhThu { get; set; }
        public string NoiDung { get; set; }
        public string MaDoan { get; set; }
        public List<NhanVien> NhanVien { get; set; }
        public Tour Tour { get; set; }
    }
}
