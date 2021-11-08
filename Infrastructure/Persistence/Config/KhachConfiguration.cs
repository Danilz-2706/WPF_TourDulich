using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence
{
    public class KhachConfiguration : IEntityTypeConfiguration<Khach>
    {
        public void Configure(EntityTypeBuilder<Khach> builder)
        {
            builder.ToTable("Khach");
            builder.HasKey(khach => khach.MaKhachHang);
            //builder.HasOne(pm => pm.PhieuMuon).WithMany(ctpm => ctpm.ChiTietPhieuMuons).HasForeignKey(pm => pm.MaPM);
        }
    }
}