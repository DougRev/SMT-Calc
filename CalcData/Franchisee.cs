using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcData
{
    public class Franchisee
    {
        [Key]
        public int FranchiseeId { get; set; }
        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(Franchise))]
        public int FranchiseId { get; set; }
        public virtual Franchise Franchise { get; set; }
        public string OwnerFirst { get; set; }
        public string OwnerLast { get; set; }
        public List<Franchise> FranchisesOwned {get; set;} 
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
