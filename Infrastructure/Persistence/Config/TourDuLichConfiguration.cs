using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence
{
    public class TourDuLichConfiguration : IEntityTypeConfiguration<TourDuLich>
    {
        public void Configure(EntityTypeBuilder<TourDuLich> builder)
        {
            builder.ToTable("TourDuLich");
            builder.HasKey(tour => tour.MaTour);
            builder.HasOne(tour => tour.LoaiHinh).WithMany(lh => lh.TourDuLiches).HasForeignKey(tour => tour.MaLoaiHinh);
        }
    }
}