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
        public int Id { get; set; }
        public Guid OwnerId { get; set; }
        public virtual ICollection<Franchise> Franchises { get; set; }

        //[ForeignKey("Franchise")]
        //public int FranchiseId { get; set; }
        public virtual Franchise Franchise { get; set; }

        //public Franchise Franchise { get; set; }
        public string OwnerFirst { get; set; }
        public string OwnerLast { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
