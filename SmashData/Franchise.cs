using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmashData
{
    public class Franchise
    {
        public int FranchiseId { get; set; }
        public Guid OwnerId { get; set; }
        public int FranchiseeId { get; set; }
        public string FranchiseName { get; set; }
        public string State { get; set; }
        public int Zips { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
        public enum Compaction
        {
            Low,
            Medium,
            High
        }
        public int YearlySmashes { get; set; }
        public bool XferStation { get; set; }
        public int DistanceBetweenClients { get; set; }
        public int DistanceToLandfill { get; set; }
        public int DistanceToHauler { get; set; }

    }
}
