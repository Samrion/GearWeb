using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gear.Data.DataModels
{
    public class UserModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<GearPage> Pages { get; set; }
        public ICollection<UserModelProperty> Properties { get; set; }
    }
}
