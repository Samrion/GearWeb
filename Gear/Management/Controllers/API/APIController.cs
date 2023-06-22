using Gear.Data;
using Gear.Data.DataModels;
using Gear.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gear.Management.Controllers.API
{
    [Route("/gearCMS/API")]
    public class APIController : Controller
    {
        private readonly GearContext Context;
        public APIController(GearContext context) { Context = context; }

        [HttpPost("setPage")]
        public IActionResult SetPage(GearPage gearPage)
        {
            Context.Pages.Add(gearPage);
            Context.SaveChanges();

            return new JsonResult(gearPage);
        }

        [HttpPost("getPage")]
        public IActionResult GetPage(int pageId)
        {
            var pages = Context.Pages
                .Where(x => x.ID == pageId)
                .Include(x => x.UserModel)
                .Include(x => x.UserModel.Properties)
                .Select(x => new
                {
					x.ID,
					x.Name,
                    x.Url,
					x.UserModel.Properties
                })
                .FirstOrDefault();
                
            return new JsonResult(pages);
        }

		[HttpPost("getPages")]
		public IActionResult GetPages()
		{
            var pages = Context.Pages;
			return new JsonResult(pages);
		}
	}
}
