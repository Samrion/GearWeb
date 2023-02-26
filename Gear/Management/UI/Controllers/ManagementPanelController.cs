using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Gear.Core;
using Gear.Management.Models;

namespace Gear.Management.UI.Controllers
{
    [Route("/gearCMS")]
    public class ManagementPanelController : Controller
    {

        public ManagementPanelController()
        {

        }
        [HttpGet]
        public IActionResult Get()
        {
            return View("/Management/UI/Views/GearConfigPanel.cshtml");
        }

        [Route("config/modelEditor")]
        public IEnumerable<string> GetModelProperties()
        {
            return new string[] { "model prop" };
        }

    }
}
