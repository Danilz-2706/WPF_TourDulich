using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence
{
    public class DiemThamQuanConfiguration : IEntityTypeConfiguration<DiemThamQuan>
    {
        public void Configure(EntityTypeBuilder<DiemThamQuan> builder)
        {
            builder.ToTable("DiemThamQuan");
            builder.HasKey(dtq => new { dtq.MaDiaDiem,dtq.MaTour });
            builder.HasOne(dtq => dtq.DiaDiem).WithMany(dd => dd.DiemThamQuans).HasForeignKey(dtq => dtq.MaDiaDiem);
            builder.HasOne(dtq => dtq.TourDuLich).WithMany(tour => tour.DiemThamQuans).HasForeignKey(dtq => dtq.MaTour);
        }
    }
}