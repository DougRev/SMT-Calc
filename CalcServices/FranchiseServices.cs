using CalcData;
using CalcModels.Franchise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CalcServices
{
    public class FranchiseServices
    {
        private readonly Guid _userId;
        public FranchiseServices(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateFranchise(AddFranchise model)
        {
            var entity =
                new Franchise()
                {
                    OwnerId = _userId,
                    FranchiseeId = model.FranchiseeId,
                    FranchiseName = model.FranchiseName,
                    State = model.State,
                    Zips = model.Zips,
                    CreatedUtc = DateTime.Now,
                    YearlySmashes = model.YearlySmashes,
                    XferStation = model.XferStation,
                    DistanceBetweenClients = model.DistanceBetweenClients,
                    DistanceToLandfill = model.DistanceToLandfill,
                    DistanceToHauler = model.DistanceToHauler,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Franchises.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public FranchiseDetail GetFranchiseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Franchises.Single(e => e.Id == id && e.OwnerId == _userId);
                return new FranchiseDetail
                {
                    FranchiseId = entity.Id,
                    FranchiseName = entity.FranchiseName,
                    FranchiseeId = entity.FranchiseeId,
                    OwnerFirst = entity.Franchisee.OwnerFirst,
                    OwnerLast = entity.Franchisee.OwnerLast,
                    State = entity.State,
                    Zips = entity.Zips,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
            }
        }
        public IEnumerable<FranchiseList> GetFranchises()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Franchises.Where(e => e.OwnerId == _userId)
                    .Select(e => new FranchiseList
                    {
                        FranchiseId = e.Id,
                        FranchiseeId = e.Franchisee.Id,
                        FranchiseName = e.FranchiseName,
                        OwnerFirst = e.Franchisee.OwnerFirst,
                        OwnerLast = e.Franchisee.OwnerLast,
                        State = e.State,
                        CreatedUtc = e.CreatedUtc,

                    });
                return query.ToList();
            }
        }
        public bool UpdateFranchise(EditFranchise model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Franchises.Single(e => e.Id == model.FranchiseId);
                entity.FranchiseName = model.FranchiseName;
                entity.Franchisee.Id = model.FranchiseeId;
                entity.State = model.State;
                entity.Zips = model.Zips;
                entity.YearlySmashes = model.YearlySmashes;
                entity.XferStation = model.XferStation;
                entity.DistanceBetweenClients = model.DistanceBetweenClients;
                entity.DistanceToLandfill = model.DistanceToLandfill;
                entity.DistanceToHauler = model.DistanceToHauler;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteFranchise(int franchiseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Franchises.Single(e => e.Id == franchiseId && e.OwnerId == _userId);
                ctx.Franchises.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
