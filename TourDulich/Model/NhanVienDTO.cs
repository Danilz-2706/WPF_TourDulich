using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TourDuLich.Model
{
    public class NhanVienDTO
    {
        [Display(Name = "M� nh�n vi�n")]
        public int MaNhanVien { get; set; }
        [Display(Name = "T�n nh�n vi�n")]
        [Required]
        public string TenNhanVien { get; set; }
    }
}
