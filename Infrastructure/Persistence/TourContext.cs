using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class TourContext : DbContext
    {
        public TourContext(DbContextOptions<TourContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //apply tất cả mà không phải thêm từng cái config
        }

        public DbSet<TourDuLich> TourDuLiches { get; set; }
        public DbSet<DiemThamQuan> DiemThamQuans { get; set; }
        public DbSet<DiaDiem> DiaDiems { get; set; }
        public DbSet<LoaiHinhDuLich> LoaiHinhDuLiches { get; set; }
        public DbSet<GiaTour> GiaTours { get; set; }
        public DbSet<DoanDuLich> DoanDuLiches { get; set; }
        public DbSet<NoiDungTour> NoiDungTours { get; set; }
        public DbSet<Khach> Khaches { get; set; }
        public DbSet<ChiTietDoan> ChiTietDoans { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<PhanBoNhanVienDoan> PhanBoNhanVien_Doans { get; set; }
        public DbSet<ChiPhi> ChiPhis { get; set; }
        public DbSet<LoaiChiPhi> LoaiChiPhis { get; set; }

    }
}