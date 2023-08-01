using DatingApp.Dal.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Dal.Models
{
    public class Like: BaseModel
    {
        public int FromAccountId { get; set; }
        public int AccountId { get; set; }

        public IEnumerable<Account>? FromAccount { get; set; }
        public IEnumerable<Account>? ToAccount { get; set; }
    }
}
