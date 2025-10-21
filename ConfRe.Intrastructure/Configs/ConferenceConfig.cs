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
    public class ConferenceConfig
    {
        public ConferenceConfig(EntityTypeBuilder<Conference> entityTypeBuilder) {
            entityTypeBuilder.Property(c=>c.Title).IsRequired();
            entityTypeBuilder.Property(c => c.Title).IsRequired();
            entityTypeBuilder.Property(c => c.EndDate).IsRequired();
            entityTypeBuilder.Property(c => c.StartDate).IsRequired();
            entityTypeBuilder.Property(c => c.RegistrationFee).IsRequired();

            entityTypeBuilder.ToTable("Conference");
        }
    }
}
