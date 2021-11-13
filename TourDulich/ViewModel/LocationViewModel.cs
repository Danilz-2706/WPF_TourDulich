
using Domain.Entities;
using Infrastructure.Persistence.Repositories;
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
    public class LocationViewModel : BaseViewModel
    {
        private readonly IDiaDiemService diaDiemService;


        private ObservableCollection<DiaDiem> _List;
        public ObservableCollection<DiaDiem> List { get => _List; set { _List = value; } }
        public LocationViewModel(IDiaDiemService diaDiemService)
        {
            this.diaDiemService = diaDiemService;
            List = new ObservableCollection<DiaDiem>(this.diaDiemService.GetDTOs());
        }

    }
}
