using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gear.Core;
using Gear.Data;
using Gear.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
namespace Gear.ContentDelivery
{
    [Route("/{**slug}")]
    public class GearPageController : Controller
    {
        private readonly GearContext Context;
        public GearPageController(GearContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            
            return NotFound();
        }

    }
}
