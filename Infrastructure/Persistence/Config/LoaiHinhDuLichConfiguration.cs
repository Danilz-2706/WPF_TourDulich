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
        }
    }
}