using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence
{
    public class ChiPhiConfiguration : IEntityTypeConfiguration<ChiPhi>
    {
        public void Configure(EntityTypeBuilder<ChiPhi> builder)
        {
            builder.ToTable("ChiPhi");
            builder.HasKey(cp => cp.MaChiPhi);
            builder.HasOne(cp => cp.LoaiChiPhi).WithMany(lcp => lcp.ChiPhis).HasForeignKey(cp => cp.MaLoaiChiPhi);
            builder.HasOne(cp => cp.DoanDuLich).WithMany(doan => doan.ChiPhis).HasForeignKey(cp => cp.MaDoan);
        }
    }
}