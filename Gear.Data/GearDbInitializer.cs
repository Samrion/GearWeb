using Gear.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gear.Data
{
    public static class GearDbInitializer
    {
        public static void Initialize(GearContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.Pages.Any()) return;           

            //user models

            var userModels = new UserModel[]
            {
                new UserModel { Name = "HomePageModel" }
            };
            foreach (var userModel in userModels)
            {
                context.UserModels.Add(userModel);
            }
            context.SaveChanges();

            //user properties

            //HomePageModel
            var userModelProperties = new UserModelProperty[]
            {
                new UserModelProperty { Name = "TestString", Value = "test", UserModelID = 1},
                new UserModelProperty { Name = "TestValue", Value = "777", UserModelID = 1}
            };

            foreach (var userModelProperty in userModelProperties)
            {
                context.UserProperties.Add(userModelProperty);
            }
            context.SaveChanges();

            //pages
            //homepage homepagemodel
            var gearPages = new GearPage[]
            {
                new GearPage {Name = "Home page", Url = @"/homepage", TemplateName = "HomePage", UserModelID = 1}
            };
            foreach (var page in gearPages)
            {
                context.Pages.Add(page);
            }
            context.SaveChanges();
        }
    }
}
