﻿using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Repositories
{
    public class TourDuLichRepository : EFRepository<TourDuLich>, ITourDuLichRepository
    {
        public TourDuLichRepository(TourContext context) : base(context)
        {
        }

        public override IEnumerable<TourDuLich> GetAll()
        {
            return context.TourDuLiches.Include(x => x.DiaDiems).Include(x => x.DiemThamQuans)
                .Include(x => x.LoaiHinh).Include(x => x.GiaTours).ToList();
        }

        public IEnumerable<DiaDiem> GetDiaDiemsByTour(int id)
        {
            var list = (from dtq in context.DiemThamQuans
                        from dd in context.DiaDiems
                        where dd.MaDiaDiem == dtq.MaDiaDiem && dtq.MaTour == id
                        select new DiaDiem
                        {
                            MaDiaDiem = dd.MaDiaDiem,
                            TenDiaDiem = dd.TenDiaDiem,
                            ThuTu = dtq.ThuTu
                        }).ToList();
            return list;
        }

        public IEnumerable<TourDuLich> GetTours()
        {
            List<TourDuLich> tour = new();
            tour = (from t in context.TourDuLiches select t).ToList();
            tour.Insert(0, new TourDuLich { MaTour = 0, TenGoi = "Chọn tour" });
            return tour;
        }

        public IEnumerable<TourDuLich> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = context.TourDuLiches.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(tour => tour.TenGoi.Contains(searchString));
            }

            SortTours(sortOrder, ref query);
            count = query.Count();

            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }

        private static void SortTours(string sortOrder, ref IQueryable<TourDuLich> query)
        {
            switch (sortOrder)
            {
                case "ma_desc":
                    query = query.OrderByDescending(t => t.MaTour);
                    break;

                case "ma":
                    query = query.OrderBy(t => t.MaTour);
                    break;

                case "ten_desc":
                    query = query.OrderByDescending(t => t.TenGoi);
                    break;

                case "ten":
                    query = query.OrderBy(t => t.TenGoi);
                    break;
            }
        }

        public int CountTourDuLich()
        {
            var c = context.TourDuLiches.Count();
            return c;
        }
    }
}