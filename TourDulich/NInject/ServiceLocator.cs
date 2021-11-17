using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourDulich.ViewModel;

namespace TourDulich.NInject
{
    public class ServiceLocator
    {
        public IKernel Kernel { get; private set; } = new StandardKernel(new ServiceModule());
        /*private readonly IKernel kernel;

        public ServiceLocator()
        {
            kernel = new StandardKernel(new ServiceModule());
        }*/


        //Đoàn du lịch//
        public DoanDuLichViewModel DoanDuLichViewModel
        {
            get
            {
                return Kernel.Get<DoanDuLichViewModel>();
            }
        }
         
        public TourViewModel TourViewModel
        {
            get
            {
                return Kernel.Get<TourViewModel>();
            }

        }


        //Khách hàng//
        public KhachHangViewModel KhachHangViewModel
        {
            get
            {
                return Kernel.Get<KhachHangViewModel>();
            }
        }

        //Nhân viên//
        public NhanVienViewModel NhanVienViewModel
        {
            get
            {
                return Kernel.Get<NhanVienViewModel>();
            }
        }

        //Địa điểm//
        public LocationViewModel LocationViewModel
        {
            get
            {
                return Kernel.Get<LocationViewModel>();
            }
        }

        //Tour//
        public TourViewModel TourViewModel
        {
            get
            {
                return Kernel.Get<TourViewModel>();
            }
        }

        //Loại hình//
        public TypeViewModel TypeViewModel
        {
            get
            {
                return Kernel.Get<TypeViewModel>();
            }
        }

        //Giá//
        public PriceViewModel PriceViewModel
        {
            get
            {
                return Kernel.Get<PriceViewModel>();
            }
        }

        //Chi phí//
        public CostViewModel CostViewModel
        {
            get
            {
                return Kernel.Get<CostViewModel>();
            }
        }




    }
}
