using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DatingApp.Dal.Models.Base;

namespace DatingApp.Dal.Models
{
    
    public class User: BaseModel
    {
        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        public int AccountId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(AccountId))]
        [InverseProperty(nameof(Account.UserNavigation))]
        public Account? AccountNavigation { get; set; }
    }
}
