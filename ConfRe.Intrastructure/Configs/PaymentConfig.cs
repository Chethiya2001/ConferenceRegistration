using ConfReg.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfRe.Intrastructure.Configs
{
    public class PaymentConfig
    {
        public PaymentConfig(EntityTypeBuilder<Payment> entityTypeBuilder)
        {
            entityTypeBuilder.Property(c=>c.Amount).IsRequired();
            entityTypeBuilder.Property(c=>c.RegistrationId).IsRequired();
            entityTypeBuilder.ToTable("Payment");

        }
    }
}
