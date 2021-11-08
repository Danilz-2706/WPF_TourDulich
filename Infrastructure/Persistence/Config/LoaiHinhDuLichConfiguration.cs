using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence
{
    public class LoaiHinhDuLichConfiguration : IEntityTypeConfiguration<LoaiHinhDuLich>
    {
        public void Configure(EntityTypeBuilder<LoaiHinhDuLich> builder)
        {
            builder.ToTable("LoaiHinhDuLich");
            builder.HasKey(lh => lh.MaLoaiHinh);

            builder.HasData(
                new LoaiHinhDuLich { MaLoaiHinh = 1, TenLoaiHinh = "Du lịch trong nước"},
                new LoaiHinhDuLich { MaLoaiHinh = 2, TenLoaiHinh = "Du lịch ngoài nước" }
                );
        }
    }
}