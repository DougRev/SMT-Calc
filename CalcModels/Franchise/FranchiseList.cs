using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcModels.Franchise
{
    public class FranchiseList
    {
        public int FranchiseId { get; set; }
        public int FranchiseeId { get; set; }
        public string FranchiseName { get; set; }
        public string OwnerFirst { get; set; }
        public string OwnerLast { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
