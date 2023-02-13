using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gear.Models
{
    public class UserModelProperty
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
    }
}
