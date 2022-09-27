using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcModels.Franchisee
{
    public class AddFranchisee
    {
        public int FranchiseeId { get; set; }
        public string OwnerFirst { get; set; }
        public string OwnerLast { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
