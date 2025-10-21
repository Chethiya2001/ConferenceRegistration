using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfReg.Domain.Entity
{
    public class Conference : BaseEntity
    {
        
        public string Title { get; private  set; }  = string.Empty;
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get;private set; }
        public decimal RegistrationFee { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public bool Initalize( string title, DateTime startDate, DateTime endDate, decimal registrationFee)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty");
            if (endDate <= startDate)
                throw new ArgumentException("End date must be after start date");
            if (registrationFee < 0)
                throw new ArgumentException("Registration fee cannot be negative");
            
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            RegistrationFee = registrationFee;
            return true;
        }
       
    }
}
