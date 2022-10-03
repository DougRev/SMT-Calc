using CalcData;
using CalcModels.Franchisee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcServices
{
    public class FranchiseeServices
    {
        private readonly Guid _userId;
        public FranchiseeServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateFranchisee(AddFranchisee model)
        {
            var entity = new Franchisee()
            {
                OwnerId = _userId,
                OwnerFirst = model.OwnerFirst,
                OwnerLast = model.OwnerLast,
                CreatedUtc = DateTime.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Franchisees.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public FranchiseeDetails GetFranchiseeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Franchisees.Single(e => e.Id == id && e.OwnerId == _userId);
                return new FranchiseeDetails
                {
                    FranchiseeId = entity.Id,
                    OwnerFirst = entity.OwnerFirst,
                    OwnerLast = entity.OwnerLast,
                    FranchiseId = entity.Franchise.Id,
                    FranchiseName = entity.Franchise.FranchiseName,
                    State = entity.Franchise.State,
                    ModifiedUtc = entity.ModifiedUtc,
                    //FranchiseId = this.GetFranchiseeById(id).FranchiseId
                    
                };
            }
        }

        public IEnumerable<FranchiseeList> GetFranchisees()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Franchisees.Where(e => e.OwnerId == _userId)
                    .Select(e => new FranchiseeList
                    {
                        FranchiseeId = e.Id,
                        OwnerFirst = e.OwnerFirst,
                        OwnerLast = e.OwnerLast,

                    });
                return query.ToList();
            }
        }

        public bool UpdateFranchisee(FranchiseeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Franchisees.Single(e => e.Id == model.FranchiseeId);
                entity.OwnerFirst = model.OwnerFirst;
                entity.OwnerLast = model.OwnerLast;
                entity.Franchise.Id = model.FranchiseId;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteFranchisee(int franchiseeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Franchisees.Single(e => e.Id == franchiseeId && e.OwnerId == _userId);
                ctx.Franchisees.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }
    }
}
