using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gear.Management
{
    internal static class ResourceProvider
    {
        private const string ScriptBasePath = "Gear.Management.Scripts.";
        private const string StyleBasePath = "Gear.Management.Styles.";


        public async static Task<string> GetEmbeddedScript(string scriptName)
        {
            return await GetResource(ScriptBasePath+ scriptName);
        }
        public async static Task<string> GetEmbeddedStyle(string styleName)
        {
            return await GetResource(StyleBasePath + styleName);
        }
        private async static Task<string> GetResource(string resourcePath)
        {
            try
            {
                var file = Assembly.GetExecutingAssembly()?.GetManifestResourceStream(resourcePath);
                if (file == null) return "";
                StreamReader sr = new(file);
                return await sr.ReadToEndAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return "";
            }
        }

    }
}
