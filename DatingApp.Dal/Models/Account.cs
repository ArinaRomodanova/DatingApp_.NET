using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingApp.Dal.Models.Base;

namespace DatingApp.Dal.Models
{
    public class Account: BaseModel
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Caption { get; set; }
        public int Age { get; set; }
    }
}
