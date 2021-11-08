using System;
namespace Domain.Entities

{
    public class NoiDungTour
    {

        //Sửa này dùm tui, không biết làm sao để cho nó vừa là khóa chính, vừa là khóa ngoại
        public DoanDuLich Doan { get; set; }
        public int MaDoan { get; set; }
        public string HanhTrinh { get; set; }
        public string KhachSan { get; set; }
        public string DiaDiemThamQuan { get; set; }

    }
}
