using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence
{
    public class DoanDuLichConfiguration : IEntityTypeConfiguration<DoanDuLich>
    {
        public void Configure(EntityTypeBuilder<DoanDuLich> builder)
        {
            builder.ToTable("DoanDuLich");
            builder.HasKey(doan => doan.MaDoan);
            //Nội dung tour
            builder.HasOne(doan => doan.NoiDungTour).WithOne(nd => nd.Doan).HasForeignKey<NoiDungTour>(doan => doan.MaDoan);
            //Tour du lịch
            builder.HasOne(doan => doan.Tour).WithMany(tour => tour.DoanDuLichs).HasForeignKey(doan => doan.MaTour);
            //Many-to-Many With Khách
            builder.HasMany(doan => doan.Khaches).WithMany(k => k.DoanDuLiches).UsingEntity<ChiTietDoan>(
                j => j.HasOne(ctd => ctd.Khach).WithMany(khach => khach.ChiTietDoans).HasForeignKey(ctd => ctd.MaKhachHang),
                j => j.HasOne(ctd => ctd.Doan).WithMany(doan => doan.ChiTietDoans).HasForeignKey(ctd => ctd.MaDoan),
                j =>
                {
                    j.ToTable("ChiTietDoan");
                    j.HasKey(ctd => new { ctd.MaDoan, ctd.MaKhachHang });
                }
                );
            //Many-to-Many With Nhân Viên
            builder.HasMany(doan => doan.NhanViens).WithMany(nv => nv.DoanDuLiches).UsingEntity<PhanBoNhanVienDoan>(

                j => j.HasOne(pb => pb.NhanVien).WithMany(nv => nv.PhanBoNhanVienDoans).HasForeignKey(pb => pb.MaNhanVien),
                j => j.HasOne(pb => pb.Doan).WithMany(doan => doan.PhanBoNhanVienDoans).HasForeignKey(pb => pb.MaDoan),
                j =>
                {
                    j.ToTable("PhanBoNhanVien_Doan");
                    j.HasKey(pb => new { pb.MaDoan, pb.MaNhanVien });
                }

                );
        }
    }
}