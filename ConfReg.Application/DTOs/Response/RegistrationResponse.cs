using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfReg.Application.DTOs.Response
{
    public class RegistrationResponse
    {
        public long Id { get; set; }
        public long PersonId { get; set; }
        public string PersonName { get; set; } = string.Empty;
        public string PersonEmail { get; set; } = string.Empty;
        public long ConferenceId { get; set; }
        public string ConsferenceTitle { get; set; } = string.Empty;
        public long MembershipId { get;set; }
        public string MembershipTypeName { get;set; } = string.Empty;
    }
}
