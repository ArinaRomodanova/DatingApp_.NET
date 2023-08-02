using DatingApp.Dal.Repos.Base;
using DatingApp.Dal.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingApp.Dal.Models;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Dal.Repos
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        public UserRepo(DatabaseContext databaseContext) : base(databaseContext)
        {
            
        }

        public IEnumerable<User> GetAll()
        {
            return Table.Include(u => u.AccountNavigation).OrderBy(u => u.Id);
        }
    }
}
