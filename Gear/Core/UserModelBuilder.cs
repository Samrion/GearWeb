using Gear.Data.DataModels;
using Gear.Models;
using Gear.Models.Editors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gear.Core
{
	internal class UserModelBuilder
	{
		private readonly object? GearModel;
		public UserModelBuilder(Type userModelType)
		{
			GearModel = Activator.CreateInstance(userModelType);
		}

		public void AddPropertyValue(string name, Type type, string sourceValue)
		{
			try
			{
				var property = GearModel?.GetType().GetProperty(name);
				var value = Convert.ChangeType(sourceValue, type);
				property?.SetValue(GearModel, value);
			}
			catch(Exception e)
			{
				Debug.WriteLine(e);
			}
		}

		public object? Build()
		{
			return GearModel;
		}
	
		//internal static GearPageModel? CreateUserPageModel(Type userModelType, GearPageModel baseModel, IEnumerable<UserModelProperty> userProperties)
		//{
		//	var userModel = Activator.CreateInstance(userModelType);
		//	var baseProperties = baseModel.GetType().GetProperties();
		//	foreach (var property in baseProperties)
		//	{
		//		property.SetValue(userModel, property.GetValue(baseModel));
		//	}


		//	foreach (var userProperty in userProperties)
		//	{
		//		userModelType.GetProperty(userProperty.Name).SetValue(userModel, userProperty.Value);
		//	}

		//	return userModel as GearPageModel;

		//}
	}
}
