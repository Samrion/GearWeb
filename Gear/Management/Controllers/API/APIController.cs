using Gear.Data;
using Gear.Data.DataModels;
using Gear.Models;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult SetPage(GearPage gearPage)
        {
            return new JsonResult(gearPage);
        }
    }
}
