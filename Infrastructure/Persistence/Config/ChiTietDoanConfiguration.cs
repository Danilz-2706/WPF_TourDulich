using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence
{
    public class ChiTietDoanConfiguration : IEntityTypeConfiguration<ChiTietDoan>
    {
        public void Configure(EntityTypeBuilder<ChiTietDoan> builder)
        {
            builder.ToTable("ChiTietDoan");
            builder.HasKey(ctd => new { ctd.MaDoan,ctd.MaKhachHang});
            builder.HasOne(ctd => ctd.Khach).WithMany(khach => khach.ChiTietDoans).HasForeignKey(ctd => ctd.MaKhachHang);
            builder.HasOne(ctd => ctd.Doan).WithMany(doan => doan.ChiTietDoans).HasForeignKey(ctd => ctd.MaDoan);
        }
    }
}