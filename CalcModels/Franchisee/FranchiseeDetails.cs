using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcModels.Franchisee
{
    public class FranchiseeDetails
    {
        public int FranchiseeId { get; set; }
        public string OwnerFirst { get; set; }
        public string OwnerLast { get; set; }
        public int FranchiseId { get; set; }
        public string FranchiseName { get; set; }
        public string State { get; set; }
        //public List<Franchise> FranchisesOwned { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
