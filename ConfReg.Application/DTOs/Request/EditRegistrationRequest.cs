using ConfReg.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfReg.Application.DTOs.Request
{
    public class EditRegistrationRequest : BaseEntityModel
    {
        public int ConferenceId { get; set; }
        public int MembershipId { get;set; }
        public DateTime UpdatedAt { get; set; }
        public RegistrationStatus Status { get; set; }
    }
}
