using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfReg.Application.DTOs.Request
{
    public class CreatePaymentRequest
    {
        public long RegistrationId { get; set; }
        public decimal Amount { get; set; }
       
    }
}
