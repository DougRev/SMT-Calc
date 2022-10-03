using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcData
{
    public class Franchise
    {
        [Key]
        public int Id { get; set; }
        public Guid OwnerId { get; set; }

        [ForeignKey("Franchisee")]
        public int FranchiseeId { get; set; }
        public virtual Franchisee Franchisee { get; set; }

       // public Franchisee Franchisee { get; set; }
       // public virtual ICollection<Franchisee> Franchisees { get; set; }
        public string FranchiseName { get; set; }
        public string State { get; set; }
        public int Zips { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
        public int YearlySmashes { get; set; }
        public bool XferStation { get; set; }
        public int DistanceBetweenClients { get; set; }
        public int DistanceToLandfill { get; set; }
        public int DistanceToHauler { get; set; }

    }
}
