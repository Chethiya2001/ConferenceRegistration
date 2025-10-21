using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfReg.Application.DTOs.Request
{
    public class EditPaymentRequest:BaseEntityModel
    {
        public decimal Amount { get; set; }
        public bool IsSuccessful { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
