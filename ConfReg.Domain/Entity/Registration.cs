using ConfReg.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfReg.Domain.Entity
{
    public class Registration:BaseEntity

    {
        public int PersonId { get; private set; }
        public int ConferenceId { get; private set; }
        public int MembershipId { get; private set; }
        public RegistrationStatus Status { get; private set; }

        public long RowVersion {  get; private set; } = 1;

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Registration(int personId, int conferenceId, int membershipId)
        {
            if (personId <= 0)
                throw new ArgumentException("Invalid person ID.");
            if (conferenceId <= 0)
                throw new ArgumentException("Invalid conference ID.");
            if (membershipId <= 0)
                throw new ArgumentException("Invalid membership ID.");

            PersonId = personId;
            ConferenceId = conferenceId;
            MembershipId = membershipId;
            Status = RegistrationStatus.Pending;
        }
        //Behavs

        public void MarkAsPaid()
        {
            if (Status != RegistrationStatus.Pending)
                throw new InvalidOperationException("Only pending registrations can be confirmed.");
            Status = RegistrationStatus.Confirmed;
            UpdatedAt = DateTime.UtcNow;
        }
      
        public void Cancelled()
        {
            if (Status != RegistrationStatus.Cancelled)
                throw new InvalidOperationException("Already Cancelled.");
            Status = RegistrationStatus.Cancelled;
            UpdatedAt = DateTime.UtcNow;
        }

        protected Registration() { }

    }
}
