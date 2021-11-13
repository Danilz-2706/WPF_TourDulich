using Domain.Entities;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TourDulich.Model;

namespace TourDulich.ViewModel
{
    public class CostViewModel

    {
        private readonly IChiPhiService chiPhiService;

        private ObservableCollection<ChiPhi> _list;
        public ObservableCollection<ChiPhi> List { get => _list; set { _list = value; } }
        public CostViewModel()
        {
            
        }
        public CostViewModel(IChiPhiService chiPhiService)
        {
            this.chiPhiService = chiPhiService;
            List = new ObservableCollection<ChiPhi>(this.chiPhiService.GetDTOs());
        }
    }
}
