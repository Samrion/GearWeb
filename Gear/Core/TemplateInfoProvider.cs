using Gear.Models;
using Gear.Views;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gear.Core
{
    public class TemplateInfoProvider
    {
        public IEnumerable<TemplateInfo> GearPageTemplatesInfo { get; }

        public TemplateInfoProvider(Assembly userAssembly)
        {
            var viewsTypes = userAssembly.GetTypes()
                .Where(x => x.IsAssignableTo(typeof(RazorPageBase)) && x.BaseType.IsGenericType);

            GearPageTemplatesInfo = viewsTypes
                .Where(x => x.BaseType.GenericTypeArguments[0].BaseType == (typeof(GearPageModel)))
                .Select(x =>
                {
                    var name = x.Name[(x.Name.LastIndexOf('_') + 1)..];
                    var path = @"/" + x.Name.Replace('_', '/');
                    var userModelType = x.BaseType.GenericTypeArguments.ElementAt(0);
                    var userModelProperties = userModelType.GetProperties();
                    return new TemplateInfo(name, path, userModelType);
                });

            foreach (var x in GearPageTemplatesInfo)
            {
                Debug.WriteLine("\nRegistered template:");
                Debug.WriteLine(x.ToString());
            }
            Debug.WriteLine("Template info end");
        }
    }
}
