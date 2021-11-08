using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TourDuLich.Model
{
    public class NhanVienDTO
    {
        [Display(Name = "Mã nhân viên")]
        public int MaNhanVien { get; set; }
        [Display(Name = "Tên nhân viên")]
        [Required]
        public string TenNhanVien { get; set; }
    }
}
