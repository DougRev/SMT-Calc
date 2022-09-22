using CalcData;
using CalcModels.Franchise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcServices
{
    public class FranchiseServices
    {
        public bool CreateFranchise(AddFranchise model)
        {
            var entity =
                new Franchise()
                {
                    OwnerId = model.OwnerId,
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
                ctx.Franchise.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
