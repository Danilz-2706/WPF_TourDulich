using Domain.Entities;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourDulich.ViewModel
{
    public class NhanVienViewModel
    {
        private readonly INhanVienService nhanVienService;

        private ObservableCollection<NhanVien> _list;
        public ObservableCollection<NhanVien> List { get => _list; set { _list = value; } }
        public NhanVienViewModel()
        {

        }
        public NhanVienViewModel(INhanVienService nhanVienService)
        {
            this.nhanVienService = nhanVienService;
            List = new ObservableCollection<NhanVien>(this.nhanVienService.GetDTOs());
        }
    }
}
