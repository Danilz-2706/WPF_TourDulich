using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence
{
    public class NoiDungTourConfiguration : IEntityTypeConfiguration<NoiDungTour>
    {
        public void Configure(EntityTypeBuilder<NoiDungTour> builder)
        {
            builder.ToTable("NoiDungTour");
            builder.HasKey(ndt => ndt.MaDoan);
            builder.HasData(new NoiDungTour { MaDoan = 1, DiaDiemThamQuan = "Danh lam thắng cảnh", KhachSan = "Khách sạn Hồ Thị Điểm", HanhTrinh = "Xuyên Việt" });
        }
    }
}