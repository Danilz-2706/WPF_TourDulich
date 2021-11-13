using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class TourDuLich
    {
        public int MaTour { get; set; }
        public string TenGoi { get; set; }
        public string DacDiem { get; set; }
        public ICollection<GiaTour> GiaTours { get; set; }
        public int MaLoaiHinh { get; set; }
        public LoaiHinhDuLich LoaiHinh { get; set; }
        public ICollection<DiemThamQuan> DiemThamQuans { get; set; }
        public ICollection<DiaDiem> DiaDiems { get; set; }
        public ICollection<DoanDuLich> DoanDuLichs { get; set; }
    }
}
