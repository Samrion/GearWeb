using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace Gear.UI.Controllers
{
    [Route("/gearCMS")]
    public class ManagementPanelController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return View("/Views/PagesDisplay.cshtml");
        }
	}
}
