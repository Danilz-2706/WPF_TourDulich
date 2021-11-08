using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence
{
    public class PhanBoNhanVienDoanConfiguration : IEntityTypeConfiguration<PhanBoNhanVienDoan>
    {
        public void Configure(EntityTypeBuilder<PhanBoNhanVienDoan> builder)
        {
            builder.ToTable("PhanBoNhanVien_Doan");
            builder.HasKey(pb => new {pb.MaDoan,pb.MaNhanVien });
            builder.HasOne(pb => pb.NhanVien).WithMany(nv => nv.PhanBoNhanVienDoans).HasForeignKey(pb => pb.MaNhanVien);
            builder.HasOne(pb => pb.Doan).WithMany(doan => doan.PhanBoNhanVienDoans).HasForeignKey(pb => pb.MaDoan);
        }
    }
}