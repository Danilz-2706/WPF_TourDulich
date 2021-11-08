using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence
{
    public class GiaTourConfiguration : IEntityTypeConfiguration<GiaTour>
    {
        public void Configure(EntityTypeBuilder<GiaTour> builder)
        {
            builder.ToTable("GiaTour");
            builder.HasKey(gia => gia.MaGia);
            builder.HasOne(gia => gia.TourDuLich).WithMany(tour => tour.GiaTours).HasForeignKey(gia => gia.MaTour);
        }
    }
}