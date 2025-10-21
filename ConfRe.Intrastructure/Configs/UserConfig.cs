using ConfReg.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfRe.Intrastructure.Configs
{
    public class UserConfig
    {
        public UserConfig(EntityTypeBuilder<User> entityTypeBuilder) {
        
            entityTypeBuilder.Property(u=>u.Name).IsRequired();
            entityTypeBuilder.Property(u => u.Email).IsRequired();

            entityTypeBuilder.ToTable("User");

        }
    }
}
