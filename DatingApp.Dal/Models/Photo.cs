using DatingApp.Dal.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DatingApp.Dal.Models
{
    public class Photo: BaseModel
    {
        public int AccountId { get; set; }
        public byte[] Avatar { get; set; }

        [DefaultValue(false)]
        public bool IsAnAvatar { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(AccountId))]
        [InverseProperty(nameof(Account.PhotoNavigation))]
        public Account? AccountNavigation { get; set; }

    }
}
