using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfReg.Application.DTOs.Response
{
    public class PaymentResponse
    {
        public long Id { get; set; }
        public int RegistrationId { get; set; }
        public decimal Amount { get; set; }
        public bool PaymentStatus { get; set; }
    }
}
