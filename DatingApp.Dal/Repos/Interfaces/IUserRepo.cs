﻿using DatingApp.Dal.Models;
using DatingApp.Dal.Repos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Dal.Repos.Interfaces
{
    public interface IUserRepo: IRepo<User>
    {
        public IEnumerable<User> GetAll();
        public User GetUserByLogin(string login);
    }
}
