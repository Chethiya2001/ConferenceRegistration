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
        public int PersonId { get; set; }
        public string? PersonName { get; set; }
        public string? PersonEmail {  get; set; }
        public int ConferenceId { get; set; }
        public string? ConsferenceTitle { get; set; }
        public int MembershipId { get;set; }
        public string? MembershipTypeName { get;set; }
    }
}
