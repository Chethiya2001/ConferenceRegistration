using ConfRe.Intrastructure.Data;
using ConfReg.Domain.Abstractions;
using ConfReg.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfRe.Intrastructure.Repositories
{
    public class UserRepository(AppDbContext context) : Repository<User>(context),IUserRepository
    {
    }
}
