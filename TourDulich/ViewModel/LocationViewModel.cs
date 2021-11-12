
using Domain.Interfaces;
using Infrastructure.Persistence.Repositories;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourDulich.Model;

namespace TourDulich.ViewModel
{
    public class LocationViewModel : BaseViewModel
    {
        public string MaDiaDiem { get; set; }
        public string TenDiaDiem { get; set; }


        private ObservableCollection<DiaDiemService> _List;
        public ObservableCollection<DiaDiemService> List { get => _List; set { _List = value; } }
        public LocationViewModel()
        {
            //List = new ObservableCollection<DiaDiemService>(new DiaDiemService(new DiaDiemRepository()).GetDTOs);
            
        }

    }
}
