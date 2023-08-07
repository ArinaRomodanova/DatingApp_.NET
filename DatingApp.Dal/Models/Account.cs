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
    public class Account: BaseModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(150)]
        public string? Caption { get; set; }

        [Required]
        public int Age { get; set; }

        [JsonIgnore]
        [InverseProperty(nameof(User.AccountNavigation))]
        public User? UserNavigation { get; set; }

        [JsonIgnore]
        public IEnumerable<Like>? LikeNavigation { get; set; }

        [JsonIgnore]
        [InverseProperty(nameof(Photo.AccountNavigation))]
        public IEnumerable<Photo>? PhotoNavigation { get; set; }
    }
}
