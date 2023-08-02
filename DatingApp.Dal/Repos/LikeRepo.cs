using DatingApp.Dal.Models;
using DatingApp.Dal.Repos.Base;
using DatingApp.Dal.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Dal.Repos
{
    public class LikeRepo : BaseRepo<Like>, ILikeRepo
    {
        public LikeRepo(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
