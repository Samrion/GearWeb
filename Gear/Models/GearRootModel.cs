using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gear.Models
{
    public class GearRootModel
    {
        public string ?HostName { get; set; }
        public List<GearPageModel> ?Pages { get; set; }
    }
}
