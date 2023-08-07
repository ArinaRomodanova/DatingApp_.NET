using DatingApp.Dal.Models;
using DatingApp.Dal.Repos.Base;
using DatingApp.Dal.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Dal.Repos
{
    public class AccountRepo : BaseRepo<Account>, IAccountRepo
    {
        public AccountRepo(DatabaseContext databaseContext) : base(databaseContext)
        {
            
        }

        public IEnumerable<Account> GetAll()
        {
            return Table.OrderBy(c => c.Id);
        }

    }
}
