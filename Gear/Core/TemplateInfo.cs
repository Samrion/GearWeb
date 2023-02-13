using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gear.Core
{
    public class TemplateInfo
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public Type UserModelType { get; set; }

        public TemplateInfo(string name, string path, Type userModelType)
        {
            Name = name;
            Path = path+".cshtml";
            UserModelType = userModelType;
        }

        public override string ToString()
        {
            return $"Name:{Name}\nPath:{Path}\nUserModel:{UserModelType.Name}\nGearModel:{UserModelType.BaseType.Name}";
        }
    }
}
