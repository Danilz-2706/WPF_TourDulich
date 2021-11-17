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
    public class KhachHangViewModel

    {
        private readonly IKhachService khachService;

        private ObservableCollection<Khach> _list;
        public ObservableCollection<Khach> List { get => _list; set { _list = value; } }
        public KhachHangViewModel(IKhachService khachService) {
            this.khachService = khachService;
            List = new ObservableCollection<Khach>(khachService.GetDTOs());
        }
    }
}
