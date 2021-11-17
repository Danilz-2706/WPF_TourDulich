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


    }
}
