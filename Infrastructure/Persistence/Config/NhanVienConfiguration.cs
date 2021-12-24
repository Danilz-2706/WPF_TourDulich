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
            builder.Ignore(nv => nv.NhiemVu);
            builder.HasData(
                new NhanVien { MaNhanVien = 1, TenNhanVien = "Trần Phước An" },
                new NhanVien { MaNhanVien = 2, TenNhanVien = "Đinh Nguyễn Tấn Đạt" },
                new NhanVien { MaNhanVien = 3, TenNhanVien = "Trương Đạt Nhân" },
                new NhanVien { MaNhanVien = 4, TenNhanVien = "Lương Vĩ Lâm" }
                ); ;
        }
    }
}