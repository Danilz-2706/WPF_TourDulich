using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Repositories
{
    public class DoanDuLichRepository : EFRepository<DoanDuLich>, IDoanDuLichRepository
    {
        public DoanDuLichRepository(TourContext context) : base(context)
        {
        }

        public override IEnumerable<DoanDuLich> GetAll()
        {
            /*context.DoanDuLiches.ToList().ForEach(x => {
                x.TenTour = x.Tour.TenGoi; 
            });*/

            return context.DoanDuLiches.Include(d => d.ChiTietDoans).Include(c => c.ChiPhis).Include(nv => nv.PhanBoNhanVienDoans)
                .Include(ntd => ntd.NoiDungTour).Include(t => t.Tour).Include(k => k.Khaches).Include(nv => nv.NhanViens).ToList();
        }

        public IEnumerable<DoanDuLich> GetDoans()
        {
            return context.DoanDuLiches.Include(d => d.ChiTietDoans).Include(c => c.ChiPhis).Include(nv => nv.PhanBoNhanVienDoans).Include(ntd => ntd.NoiDungTour).Include(t => t.Tour).ToList();
        }

        public IEnumerable<DoanDuLich> GetDoans_Eager()
        {
            throw new System.NotImplementedException();
        }

        public DoanDuLich GetDoan_Eager(int id)
        {
            var d = context.DoanDuLiches.Where(x => x.MaDoan == id).Include(d => d.ChiTietDoans).Include(c => c.ChiPhis).Include(nv => nv.PhanBoNhanVienDoans).FirstOrDefault();
            return d;
        }

        public IEnumerable<DoanDuLich> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = context.DoanDuLiches.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(d => d.TenDoan.Contains(searchString));
            }

            SortDoans(sortOrder, ref query);
            count = query.Count();

            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }

        private static void SortDoans(string sortOrder, ref IQueryable<DoanDuLich> query)
        {
            switch (sortOrder)
            {
                case "ma_desc":
                    query = query.OrderByDescending(t => t.MaDoan);
                    break;

                case "ma":
                    query = query.OrderBy(t => t.MaDoan);
                    break;

                case "ten_desc":
                    query = query.OrderByDescending(t => t.TenDoan);
                    break;

                case "ten":
                    query = query.OrderBy(t => t.TenDoan);
                    break;
            }
        }

        public int CountDoanDuLich()
        {
            var c = context.DoanDuLiches.Count();
            return c;
        }
        
    }
}