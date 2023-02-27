using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Gear.Core;
using Gear.Data;
using Microsoft.EntityFrameworkCore;

namespace Gear.Management.Controllers.UI
{
    [Route("/gearCMS")]
    public class ManagementPanelController : Controller
    {
        private readonly GearContext Context;
        public ManagementPanelController(GearContext gearContext)
        {
            Context = gearContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return View("/Management/Views/GearConfigPanel.cshtml");
        }

        [Route("pages")]
        public IActionResult GetPages()
        {
            return View("/Management/Views/PagesDisplay.cshtml", Context.Pages.Select(x => new Tuple<int, string>(x.ID,x.Name)).ToList());
        }
        [Route("pages/{pageId}")]
		public IActionResult GetPage(int pageId)
		{
            var page = Context.Pages.Include(x => x.UserModel)
                .Include(x => x.UserModel.Properties)
                .FirstOrDefault(x => x.ID == pageId);

			if (page == null) return NotFound();

            return View("/Management/Views/PageConfig.cshtml",page);
		}
	}
}
