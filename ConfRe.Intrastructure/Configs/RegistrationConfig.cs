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
    public class RegistrationConfig
    {
        public RegistrationConfig(EntityTypeBuilder<Registration> entityTypeBuilder)
        {
            entityTypeBuilder.Property(r=>r.ConferenceId).IsRequired();
            entityTypeBuilder.Property(r=>r.MembershipId).IsRequired();
            entityTypeBuilder.Property(r=>r.RowVersion).IsRowVersion();

            entityTypeBuilder.ToTable("Registration");

        }
    }
}
