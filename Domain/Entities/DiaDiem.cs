using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class DiaDiem
    {
        public int MaDiaDiem { get; set; }
        public string TenDiaDiem { get; set; }
        public ICollection<DiemThamQuan> DiemThamQuans { get; set; }
        public ICollection<TourDuLich> TourDuLiches { get; set; }
    }
}
