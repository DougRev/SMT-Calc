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
                ctx.Franchisee.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public FranchiseeDetails GetFranchiseeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Franchisee.Single(e => e.FranchiseeId == id && e.OwnerId == _userId);
                return new FranchiseeDetails
                {
                    FranchiseeId = entity.FranchiseeId,
                    OwnerFirst = entity.OwnerFirst,
                    OwnerLast = entity.OwnerLast,
                    ModifiedUtc = entity.ModifiedUtc
                };
            }
        }

        public IEnumerable<FranchiseeList> GetFranchisees()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Franchisee.Where(e => e.OwnerId == _userId)
                    .Select(e => new FranchiseeList
                    {
                        FranchiseeId = e.FranchiseeId,
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
                var entity = ctx.Franchisee.Single(e => e.FranchiseeId == model.FranchiseeId);
                entity.OwnerFirst = model.OwnerFirst;
                entity.OwnerLast = model.OwnerLast;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteFranchisee(int franchiseeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Franchisee.Single(e => e.FranchiseeId == franchiseeId && e.OwnerId == _userId);
                ctx.Franchisee.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }
    }
}
