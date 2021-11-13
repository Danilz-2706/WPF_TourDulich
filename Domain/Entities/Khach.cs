using Domain.Entities.Enum;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Khach
    {
        public int MaKhachHang { get; set; }
        public string HoTen { get; set; }
        public string SoCMND{ get; set; }
        public string DiaChi { get; set; }
	    public Gender GioiTinh { get; set; }
        public string SDT { get; set; }
        public string QuocTich { get; set; }
        public ICollection<ChiTietDoan> ChiTietDoans { get; set; }
        public ICollection<DoanDuLich> DoanDuLiches { get; set; }
    }
}
