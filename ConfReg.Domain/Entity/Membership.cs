using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfReg.Domain.Entity
{
    public class Membership:BaseEntity
    {

        public string Type { get; private set; } = "Regular"; 
        public decimal DiscountPercentage { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public bool  Initialize( string type, decimal discountPercentage)
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("Membership type cannot be empty");
            if (discountPercentage < 0 || discountPercentage > 100)
                throw new ArgumentException("Discount must be between 0 and 100");
          
            Type = type;
            DiscountPercentage = discountPercentage;
            return true;
        }

       
    }
}
