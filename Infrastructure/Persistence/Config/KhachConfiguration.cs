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
                new Khach { MaKhachHang = 1, HoTen = "Đoàn Văn Hậu", SoCMND = "263512902", DiaChi = "172 Đinh Tiên Hoàng,Q.3,TP.HCM", GioiTinh = Gender.MALE, SDT = "0945128420", QuocTich = "Việt Nam" },
                new Khach { MaKhachHang = 2, HoTen = "Nguyễn Trần Quốc Bảo", SoCMND = "291234014", DiaChi = "56 Nam Kỳ Khởi Nghĩa,Q.1,TP.HCM", GioiTinh = Gender.MALE, SDT = "0884219420", QuocTich = "Việt Nam" }
                );;
        }
    }
}