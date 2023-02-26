using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gear.Core
{
    public class TemplateInfo
    {
        public string Name { get; private set; }
        public string Path { get; private set; }
        public Type UserModelType { get; private set; }

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
