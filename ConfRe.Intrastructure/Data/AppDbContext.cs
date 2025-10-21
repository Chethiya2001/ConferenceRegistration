using ConfRe.Intrastructure.Configs;
using ConfReg.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfRe.Intrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options ) : base(options)
        {
            
        }
        public new virtual DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserConfig(modelBuilder.Entity<User>());
            new ConferenceConfig(modelBuilder.Entity<Conference>());
            new RegistrationConfig(modelBuilder.Entity<Registration>());
            new PaymentConfig(modelBuilder.Entity<Payment>());
            new MembershipConfig(modelBuilder.Entity<Membership>());
        }
    }
}
