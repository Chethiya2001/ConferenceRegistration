using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfReg.Application.DTOs.Request
{
    public class CreateRegistrationRequest
    {
        public long PersonId { get; set; }
        public long ConferenceId { get; set; }
        public long MembershipId { get;set; }
    }
}
