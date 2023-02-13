using Gear.Models;
using Microsoft.AspNetCore.Mvc.Razor;
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
        public IEnumerable<TemplateInfo> PageTemplatesInfo { get; }

        public TemplateInfoProvider()
        {
            var entryAssembly = Assembly.GetCallingAssembly();
            var viewsTypes = entryAssembly.GetTypes()
                .Where(x => x.IsAssignableTo(typeof(RazorPageBase)) && x.BaseType.IsGenericType);

            PageTemplatesInfo = viewsTypes
                .Where(x => x.BaseType.GenericTypeArguments[0].BaseType == (typeof(GearPageModel)))
                .Select(x =>
                {
                    var name = x.Name[(x.Name.LastIndexOf('_')+1)..];
                    var path = @"/"+x.Name.Replace('_', '/');
                    var userModelType = x.BaseType.GenericTypeArguments.ElementAt(0);
                    var userModelProperties = userModelType.GetProperties();
                    return new TemplateInfo(name, path, userModelType);
                });

            foreach(var x in PageTemplatesInfo)
            {
                Debug.WriteLine("\nRegistered template:");
                Debug.WriteLine(x.ToString());
            }
            Debug.WriteLine("Template info end");
        }

        //public TemplateInfo GetPageTemplateInfoByTypeName()
        //{
        //    return PageTemplatesInfo
        //}


        //private List<string> MapViewsPathes()
        //{
        //    var currentDirectory = Directory.GetCurrentDirectory();
        //    return Directory.GetFiles(string.Format($"{currentDirectory}\\Views"), "*.cshtml", SearchOption.AllDirectories)
        //        .Select(x => x[(currentDirectory.Length)..]).ToList();
        //}
    }
}
