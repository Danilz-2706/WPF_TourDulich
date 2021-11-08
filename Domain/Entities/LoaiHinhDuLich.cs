using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class LoaiHinhDuLich
    {
        public int MaLoaiHinh { get; set; }
        public string TenLoaiHinh { get; set; }
        public ICollection<TourDuLich> TourDuLiches { get; set; }
    }
}
