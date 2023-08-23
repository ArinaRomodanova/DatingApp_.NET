using DatingApp.Dal.Models;
using DatingApp.Dal.Repos.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Dal.Repos.Interfaces
{
    public interface IPhotoRepo: IRepo<Photo>
    {
        public Photo? GetAvatarByAccountId(int? accountId);
        public IEnumerable<Photo>? GetPhotosByAccountId(int? accountId);
    }
}
