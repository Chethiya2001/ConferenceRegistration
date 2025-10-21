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
    public class MembershipConfig
    {
        public MembershipConfig(EntityTypeBuilder<Membership> entityTypeBuilder) {
            entityTypeBuilder.Property(c=>c.Type).IsRequired();
            entityTypeBuilder.Property(c=>c.DiscountPercentage).IsRequired();
          
            entityTypeBuilder.ToTable("Membership");
        }
    }
}
