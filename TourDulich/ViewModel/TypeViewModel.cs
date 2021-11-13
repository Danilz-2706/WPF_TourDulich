using Domain.Entities;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourDulich.Model;

namespace TourDulich.ViewModel
{
    public class TypeViewModel : BaseViewModel
    {
        private readonly ILoaiHinhDuLichService loaiHinhDuLichService;

        private ObservableCollection<LoaiHinhDuLich> _list;
        public ObservableCollection<LoaiHinhDuLich> List { get => _list; set { _list = value; } }
        public TypeViewModel()
        {

        }
        public TypeViewModel(ILoaiHinhDuLichService loaiHinhDuLichService)
        {
            this.loaiHinhDuLichService = loaiHinhDuLichService;
            List = new ObservableCollection<LoaiHinhDuLich>(this.loaiHinhDuLichService.GetDTOs());
        }
    }
}
