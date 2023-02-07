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
    public class ViewInfoProvider
    {
        private List<string> ViewsPathes { get; set; }
        public ViewInfoProvider()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            ViewsPathes = Directory.GetFiles(string.Format($"{currentDirectory}\\Views"), "*.cshtml", SearchOption.AllDirectories)
                .Select(x => x[(currentDirectory.Length)..]).ToList();
        }

        public string GetViewPathByName(string viewName)
        {
            var contentInfo = ViewsPathes.Where(x => x.EndsWith($"{viewName}.cshtml")).FirstOrDefault();

            return contentInfo;
        }
    }
}
