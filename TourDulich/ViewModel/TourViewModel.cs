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
using System.Windows.Input;
using TourDulich.View.AdminManager;
using TourDulich.View.AdminManagerView;

namespace TourDulich.ViewModel
{
    public class TourViewModel: BaseViewModel
    {
        public ICommand AddTour { get; set; }
        public ICommand EditTour { get; set; }
        public ICommand DeleteTour { get; set; }
        public ICommand CloseTourAdd { get; set; }
        public ICommand CloseTourEdit { get; set; }
        public ICommand CloseTourDelete { get; set; }
        private readonly ITourDuLichService tourDuLichService;

        private ObservableCollection<TourDuLich> _list;
        public ObservableCollection<TourDuLich> List { get => _list; set { _list = value; } }
        
        public TourViewModel() { }
        public TourViewModel(ITourDuLichService tourDuLichService)
        {
            this.tourDuLichService = tourDuLichService;
            List = new ObservableCollection<TourDuLich>(tourDuLichService.GetDTOs());
            //// Commands  -  Add - Edit - Delete - ...... //
            #region Commands
            AddTour = new RelayCommand<object>(p => { return true; }, p => { Add(); });
            EditTour = new RelayCommand<object>(p => { return true; }, p => { Edit(); });
            DeleteTour = new RelayCommand<object>(p => { return true; }, p => { Delete(); });
            CloseTourAdd = new RelayCommand<object>(p => { return true; }, p => { CloseAdd(p); });
            CloseTourEdit = new RelayCommand<object>(p => { return true; }, p => { CloseEdit(p); });
            CloseTourDelete = new RelayCommand<object>(p => { return true; }, p => { CloseDelete(p); });

            #endregion
        }

        private void Add() { TourManagerAdd x = new TourManagerAdd(); x.ShowDialog();}
        private void Edit() { TourManagerEdit x = new TourManagerEdit(); x.ShowDialog(); }
        private void Delete() { TourManagerDelete x = new TourManagerDelete(); x.ShowDialog(); }
        private void CloseAdd(object obj) { TourManagerAdd x = obj as TourManagerAdd; x.Close(); }
        private void CloseEdit(object obj) { TourManagerEdit x = obj as TourManagerEdit; x.Close(); }
        private void CloseDelete(object obj) { TourManagerDelete x = obj as TourManagerDelete; x.Close(); }
    } 
}
