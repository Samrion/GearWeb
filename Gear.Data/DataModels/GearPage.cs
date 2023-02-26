using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gear.Data.DataModels
{
    public class GearPage
    {
        public int ID { get; set; }
        public string Route { get; set; }
        public string Name { get; set; }
        public string TemplateName { get; set; }
        public int UserModelID { get; set; }
        public UserModel UserModel { get; set; }
    }
}
