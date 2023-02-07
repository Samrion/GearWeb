using Gear.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gear.Core
{
    internal class GearModelTypeResolver
    {
        public static object? CastGearPageModelGenericType(object userPageModel)
        {
            var genericPageModelType = typeof(GearPageModel<>).MakeGenericType(userPageModel.GetType());
            var genericPageModel = Activator.CreateInstance(genericPageModelType);
            var userPageModelProp = genericPageModelType.GetProperty("UserPageModel");
            if (userPageModelProp == null) return null;
            userPageModelProp.SetValue(genericPageModel, userPageModel);
            return genericPageModel;
        }
    }
}
