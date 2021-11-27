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
            builder.Ignore(cp => cp.TenLoaiChiPhi);
            builder.HasKey(cp => cp.MaChiPhi);
            builder.HasOne(cp => cp.LoaiChiPhi).WithMany(lcp => lcp.ChiPhis).HasForeignKey(cp => cp.MaLoaiChiPhi);
            builder.HasOne(cp => cp.DoanDuLich).WithMany(doan => doan.ChiPhis).HasForeignKey(cp => cp.MaDoan);
            builder.HasData(
                    new ChiPhi { MaChiPhi = 1, MaDoan = 1, SoTien = 50000, MaLoaiChiPhi = 1 },
                    new ChiPhi { MaChiPhi = 2, MaDoan = 1, SoTien = 50000, MaLoaiChiPhi = 2 }
                );
        }
    }
}