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
        }
    }
}