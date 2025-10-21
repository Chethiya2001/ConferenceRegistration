using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfReg.Application.DTOs.Request
{
    public class EditConferenceRequest:BaseEntityModel
    {
        public string Title { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RegistrationFee { get; set; }

                public DateTime UpdatedAt { get; set; } 
    }
}
