using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence
{
    public class LoaiChiPhiConfiguration : IEntityTypeConfiguration<LoaiChiPhi>
    {
        public void Configure(EntityTypeBuilder<LoaiChiPhi> builder)
        {
            builder.ToTable("LoaiChiPhi");
            builder.HasKey(lcp => lcp.MaLoaiChiPhi);
            
        }
    }
}