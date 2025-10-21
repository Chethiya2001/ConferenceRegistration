using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfReg.Application.DTOs.Response
{
    public class MembershipResponse
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public decimal? DiscountPercentage { get; set; }

    }
}
