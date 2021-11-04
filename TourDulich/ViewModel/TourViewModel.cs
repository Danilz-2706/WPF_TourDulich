using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using TourDulich.View.AdminManager;
using TourDulich.View.AdminManagerView;

namespace TourDulich.ViewModel
{
    class TourViewModel: BaseViewModel
    {
        public ICommand AddTour { get; set; }
        public ICommand EditTour { get; set; }
        public ICommand DeleteTour { get; set; }
        
        public TourViewModel()
        {



            //// Commands  -  Add - Edit - Delete - ...... //
            #region Commands
            AddTour = new RelayCommand<object>(p => { return true; }, p => { Add(); });
            EditTour = new RelayCommand<object>(p => { return true; }, p => { Edit(); });
            DeleteTour = new RelayCommand<object>(p => { return true; }, p => { Delete(); });

            #endregion
        }

        private void Add() { TourManagerAdd x = new TourManagerAdd(); x.ShowDialog(); }
        private void Edit() { TourManagerEdit x = new TourManagerEdit(); x.ShowDialog(); }
        private void Delete() { TourManagerDelete x = new TourManagerDelete(); x.ShowDialog(); }
    } 
}
