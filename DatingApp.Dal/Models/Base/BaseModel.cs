using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Dal.Models.Base
{
    public class BaseModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}
