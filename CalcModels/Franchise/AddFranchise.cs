using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcModels.Franchise
{
    public class AddFranchise
    {
        public string FranchiseName { get; set; }
        public int FranchiseeId { get; set; }
        public string State { get; set; }
        public int Zips { get; set; }
        public int YearlySmashes { get; set; }
        public bool XferStation { get; set; }
        public int DistanceBetweenClients { get; set; }
        public int DistanceToLandfill { get; set; }
        public int DistanceToHauler { get; set; }
    }
}
