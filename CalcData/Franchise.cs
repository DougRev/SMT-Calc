using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcData
{
    public class Franchise
    {
        public int FranchiseId { get; set; }
        public string FranchiseName { get; set; }
        public string State { get; set; }
        public int Zips { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
