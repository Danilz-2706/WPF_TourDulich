using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence
{
    public class DiaDiemConfiguration : IEntityTypeConfiguration<DiaDiem>
    {
        public void Configure(EntityTypeBuilder<DiaDiem> builder)
        {
            builder.ToTable("DiaDiem");
            builder.HasKey(dd => dd.MaDiaDiem);

            builder.HasData(
                new DiaDiem { MaDiaDiem=1, TenDiaDiem = "Chùa Sài Gòn"},
                new DiaDiem { MaDiaDiem = 2, TenDiaDiem = "Chùa Hà Nội" }
                );
        }
    }
}