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
            builder.Ignore(tour => tour.TenLoaiHinh);
            builder.HasKey(tour => tour.MaTour);
            builder.HasOne(tour => tour.LoaiHinh).WithMany(lh => lh.TourDuLiches).HasForeignKey(tour => tour.MaLoaiHinh);
            builder.HasData(
                new TourDuLich { MaTour = 1, TenGoi = "Sài Gòn - Ninh Thuận", DacDiem = "Vui", MaLoaiHinh = 1  }
                );

            //Many-to-Many with Địa Điểm
            builder.HasMany(t => t.DiaDiems).WithMany(d => d.TourDuLiches).UsingEntity<DiemThamQuan>(
                j => j.HasOne(dtq => dtq.DiaDiem).WithMany(dd => dd.DiemThamQuans).HasForeignKey(dtq => dtq.MaDiaDiem),
                j => j.HasOne(dtq => dtq.TourDuLich).WithMany(tour => tour.DiemThamQuans).HasForeignKey(dtq => dtq.MaTour),
                j =>
                {
                    j.ToTable("DiemThamQuan");
                    j.HasKey(dtq => new { dtq.MaDiaDiem, dtq.MaTour });
                }
                );
        }
    }
}