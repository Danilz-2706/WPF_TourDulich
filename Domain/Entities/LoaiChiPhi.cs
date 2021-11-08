using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class LoaiChiPhi
    {
        public int MaLoaiChiPhi { get; set; }
        public string TenLoaiChiPhi { get; set; }

        public ICollection<ChiPhi> ChiPhis { get; set; }
    }
}
