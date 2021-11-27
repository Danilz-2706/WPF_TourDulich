using Domain.Entities;
using Domain.Entities.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Persistence
{
    public class DoanDuLichConfiguration : IEntityTypeConfiguration<DoanDuLich>
    {
        public void Configure(EntityTypeBuilder<DoanDuLich> builder)
        {
            builder.ToTable("DoanDuLich");
            builder.HasKey(doan => doan.MaDoan);
            builder.Ignore(doan => doan.TenTour);
            builder.HasData(new DoanDuLich { MaDoan = 1, TenDoan = "Tour siêu VIP", MaTour = 1, NgayKhoiHanh = new DateTime(2021,12,24), NgayKetThuc = new DateTime(2021, 12, 24) });
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
                    j.HasData(new ChiTietDoan { MaDoan= 1 , MaKhachHang = 1, VaiTro = VaiTro.VIP });
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
                    j.HasData(new PhanBoNhanVienDoan { MaDoan = 1, MaNhanVien = 1, NhiemVu = "Tài xế" });
                }

                );
        }
    }
}