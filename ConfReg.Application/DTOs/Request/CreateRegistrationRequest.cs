using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfReg.Application.DTOs.Request
{
    public class CreateRegistrationRequest
    {
        public int PersonId { get; set; }
        public int ConferenceId { get; set; }
        public int MembershipId { get;set; }
    }
}
