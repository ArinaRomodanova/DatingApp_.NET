using DatingApp.Dal.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DatingApp.Dal.Models
{
    public class Like: BaseModel
    {
        public int FromAccountId { get; set; }
        public int AccountId { get; set; }

        [JsonIgnore]
        public IEnumerable<Account>? FromAccount { get; set; }
        [JsonIgnore]
        public IEnumerable<Account>? ToAccount { get; set; }
    }
}
