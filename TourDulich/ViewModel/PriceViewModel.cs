using Domain.Entities;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourDulich.View.AdminManagerView;

namespace TourDulich.ViewModel
{
    public class PriceViewModel : BaseViewModel
    {
        private readonly IGiaTourService giaTourService;

        private ObservableCollection<GiaTour> _list;
        public ObservableCollection<GiaTour> List { get => _list; set { _list = value; } }
        public PriceViewModel()
        {

        }
        public PriceViewModel(IGiaTourService giaTourService)
        {
            this.giaTourService = giaTourService;
            List = new ObservableCollection<GiaTour>(this.giaTourService.GetDTOs());
        }
    }
}
