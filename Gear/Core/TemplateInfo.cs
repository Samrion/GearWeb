using Gear.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gear.Core
{
	public class TemplateInfo
	{
		public string Name { get; }
		public string Path { get; }
		public Type UserModelType { get; }
		public IEnumerable<UserModelPropertyInfo> Properties { get; }
		public TemplateInfo(string name, string path, Type userModelType, IEnumerable<UserModelPropertyInfo> properties)
		{
			Name = name;
			Path = path + ".cshtml";
			UserModelType = userModelType;
			Properties = properties;
		}

		public override string ToString()
		{
			return $"Name:{Name}\nPath:{Path}\nUserModel:{UserModelType.Name}\nGearModel:{UserModelType.BaseType.Name}";
		}
	}
}
