using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gear.Models
{
    public class UserModelPropertyInfo
    {
        public UserModelPropertyInfo(string name, Type type)
        {
            Name = name;
            Type = type;
        }
        public string Name { get; }
        public Type Type { get; }
    }
}
