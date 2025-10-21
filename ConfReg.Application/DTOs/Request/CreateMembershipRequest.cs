using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfReg.Application.DTOs.Request
{
    public class CreateMembershipRequest
    {
        public string Type { get;set; } =string.Empty;
        public decimal DiscountPercentage { get;set; } 
    }
}
