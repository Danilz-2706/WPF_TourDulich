using Domain.Interfaces;
using Infrastructure.Persistence.Repositories;
using Ninject.Modules;
using Service.Interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourDulich.NInject
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            //EF
            Bind(typeof(IEFRepository<>)).To(typeof(EFRepository<>)).InThreadScope();

            //ChiPhi
            Bind<IChiPhiRepository>().To<ChiPhiRepository>().InThreadScope();
            Bind<IChiPhiService>().To<ChiPhiService>().InThreadScope();

            //ChiTietDoan
            Bind<IChiTietDoanRepository>().To<ChiTietDoanRepository>().InThreadScope();
            Bind<IChiTietDoanService>().To<ChiTietDoanService>().InThreadScope();

            //DiaDiem
            Bind<IDiaDiemRepository>().To<DiaDiemRepository>().InThreadScope();
            Bind<IDiaDiemService>().To<DiaDiemService>().InThreadScope();

            //DiemThamQuan
            Bind<IDiemThamQuanRepository>().To<DiemThamQuanRepository>().InThreadScope();
            Bind<IDiemThamQuanService>().To<DiemThamQuanService>().InThreadScope();

            //DoanDuLich
            Bind<IDoanDuLichRepository>().To<DoanDuLichRepository>().InThreadScope();
            Bind<IDoanDuLichService>().To<DoanDuLichService>().InThreadScope();

            //GiaTour
            Bind<IGiaTourRepository>().To<GiaTourRepository>().InThreadScope();
            Bind<IGiaTourService>().To<GiaTourService>().InThreadScope();

            //Khach
            Bind<IKhachRepository>().To<KhachRepository>().InThreadScope();
            Bind<IKhachService>().To<KhachService>().InThreadScope();

            //LoaiChiPhi
            Bind<ILoaiChiPhiRepository>().To<LoaiChiPhiRepository>().InThreadScope();
            Bind<ILoaiChiPhiService>().To<LoaiChiPhiService>().InThreadScope();

            //LoaiHinhDuLich
            Bind<ILoaiHinhDuLichRepository>().To<LoaiHinhDuLichRepository>().InThreadScope();
            Bind<ILoaiHinhDuLichService>().To<LoaiHinhDuLichService>().InThreadScope();

            //NhanVien
            Bind<INhanVienRepository>().To<NhanVienRepository>().InThreadScope();
            Bind<INhanVienService>().To<NhanVienService>().InThreadScope();

            //NoiDungTour
            Bind<INoiDungTourRepository>().To<NoiDungTourRepository>().InThreadScope();
            Bind<INoiDungTourService>().To<NoiDungTourService>().InThreadScope();

            //PhanBoNhanVienDoan
            Bind<IPhanBoNhanVienDoanRepository>().To<PhanBoNhanVienDoanRepository>().InThreadScope();
            Bind<IPhanBoNhanVienDoanService>().To<PhanBoNhanVienDoanService>().InThreadScope();

            //TourDuLich
            Bind<ITourDuLichRepository>().To<TourDuLichRepository>().InThreadScope();
            Bind<ITourDuLichService>().To<TourDuLichService>().InThreadScope();
        }
    }
}
