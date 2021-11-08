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
            //builder.HasOne(pm => pm.PhieuMuon).WithMany(ctpm => ctpm.ChiTietPhieuMuons).HasForeignKey(pm => pm.MaPM);
        }
    }
}