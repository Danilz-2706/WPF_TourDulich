using System;
using System.Collections.Generic;
using TourDulich.Model.Enum;

namespace TourDulich.Model
{
    public class KhachDTO
    {
        public int MaKhachHang { get; set; }
        public string HoTen { get; set; }
        public string SoCMND{ get; set; }
        public string DiaChi { get; set; }
	    public Gender GioiTinh { get; set; }
        public string SDT { get; set; }
        public string QuocTich { get; set; }
    }
}
