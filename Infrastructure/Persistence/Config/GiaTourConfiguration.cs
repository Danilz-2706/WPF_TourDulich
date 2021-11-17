using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Persistence
{
    public class GiaTourConfiguration : IEntityTypeConfiguration<GiaTour>
    {
        public void Configure(EntityTypeBuilder<GiaTour> builder)
        {
            builder.ToTable("GiaTour");
            builder.HasKey(gia => gia.MaGia);
            builder.HasOne(gia => gia.TourDuLich).WithMany(tour => tour.GiaTours).HasForeignKey(gia => gia.MaTour);
            builder.HasData(
                new GiaTour { MaGia = 1, MaTour = 1, ThanhTien = 100000, ThoiGianBatDau = new DateTime(2021,12,24), ThoiGianKetThuc = new DateTime(2021, 12, 30) }
                );
        }
    }
}