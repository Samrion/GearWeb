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
    public static class UserModelBuilder
    {
        internal static GearPageModel? CreateUserPageModel(Type userModelType, GearPageModel baseModel, IEnumerable<UserModelProperty> userProperties)
        {
            var userModel = Activator.CreateInstance(userModelType);
            var baseProperties = baseModel.GetType().GetProperties();
            foreach(var property in baseProperties)
            {
                property.SetValue(userModel,property.GetValue(baseModel));
            }
          

            foreach (var userProperty in userProperties)
            {
                userModelType.GetProperty(userProperty.Name).SetValue(userModel, userProperty.Value);
            }

            return userModel as GearPageModel;

        }
    }
}
