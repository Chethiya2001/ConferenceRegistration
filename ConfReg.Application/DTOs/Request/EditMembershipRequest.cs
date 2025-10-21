using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfReg.Application.DTOs.Request
{
    public class EditMembershipRequest:BaseEntityModel
    {
        public string Type { get; set; } = string.Empty;
        public decimal? DiscountPercentage { get; set; }
        public DateTime UpdatedAt { get; set; } 
    }
}
