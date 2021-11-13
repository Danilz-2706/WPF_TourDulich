using Domain.Entities;
using Domain.Entities.Enum;
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
            builder.Ignore(khach => khach.VaiTro);
            builder.HasData(
                new Khach { MaKhachHang=1, HoTen = "Lâm Chấn Thương", SoCMND = "123456789",DiaChi = "Hồ Ly Shiet",GioiTinh = Gender.MALE,SDT="0123456789", QuocTich ="Việt Nam"  },
                new Khach { MaKhachHang = 2, HoTen = "Hứa Xong Chuồn", SoCMND = "123456788", DiaChi = "Không Một Ai Biết", GioiTinh = Gender.MALE, SDT = "0123456788", QuocTich = "Việt Nam" }
                );;
        }
    }
}