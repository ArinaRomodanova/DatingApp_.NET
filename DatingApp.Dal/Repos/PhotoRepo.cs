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
    public class PhotoRepo : BaseRepo<Photo>, IPhotoRepo
    {
        public PhotoRepo(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public Photo GetPhotoByAccountId(int? accountId)
        {
            if (accountId != null && accountId.HasValue)
            {
                return Table
                    .Where(x => x.AccountId == accountId.Value)
                    .First();
            }
            return null;
        }
    }
}
