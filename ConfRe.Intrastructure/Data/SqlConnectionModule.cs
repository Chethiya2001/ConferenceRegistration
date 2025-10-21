using ConfRe.Intrastructure.Repositories;
using ConfReg.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfRe.Intrastructure.Data
{
    public static class MySqlModel
    {
        public static void SqlConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
               options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
               new MySqlServerVersion(new Version(8, 0, 29))
                ));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IConferenceRepository, ConferenceRepository>();
            services.AddScoped<IRegistrationRepository , RegistrationRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IMembershipRepository, MembershipRepository>();

        }
    }
    

}
