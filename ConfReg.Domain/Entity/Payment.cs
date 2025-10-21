using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfReg.Domain.Entity
{
    public class Payment:BaseEntity
    {

        public int RegistrationId { get; private set; }
        public decimal Amount { get; private set; }
        public bool IsSuccessful { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public bool Initialize(int registrationId, decimal amount, bool isSuccessful)
        {
            if (registrationId <= 0)
                throw new ArgumentException("Invalid registration ID.");
            if (amount <= 0)
                throw new ArgumentException("Payment amount must be greater than zero.");
          
            RegistrationId = registrationId;
            Amount = amount;
            IsSuccessful = isSuccessful;
            CreatedAt = DateTime.UtcNow;
            return true;
        }
        public bool UpdatePayment( decimal amount, bool isSuccessful)
        {
           
            if (amount <= 0)
                throw new ArgumentException("Payment amount must be greater than zero.");

           
            Amount = amount;
            IsSuccessful = isSuccessful;
           
            return true;
        }
    }
}
