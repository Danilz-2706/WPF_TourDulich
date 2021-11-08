using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence
{
    public class NhanVienConfiguration : IEntityTypeConfiguration<NhanVien>
    {
        public void Configure(EntityTypeBuilder<NhanVien> builder)
        {
            builder.ToTable("NhanVien");
            builder.HasKey(nv => nv.MaNhanVien);
            builder.HasData(
                new NhanVien { MaNhanVien = 1, TenNhanVien = "An" },
                new NhanVien { MaNhanVien = 2, TenNhanVien = "Đạt" },
                new NhanVien { MaNhanVien = 3, TenNhanVien = "Nhân" },
                new NhanVien { MaNhanVien = 4, TenNhanVien = "Lâm" }
                ); ;
        }
    }
}