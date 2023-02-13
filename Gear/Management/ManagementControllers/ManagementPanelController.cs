using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Gear.Core;

namespace Gear.ContentManagement.ManagementControllers
{
    [Route("config")]
    public class ManagementPanelController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return View(@"GearConfigPanel");
        }

        [Route("config/modelEditor")]
        public IEnumerable<string> GetModelProperties(string modelName)
        {
            return new string[] { "model prop" };
        }

    }
}
