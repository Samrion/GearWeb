using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gear.Management.Controllers.UI
{
    [Route("/gearCMS/resources")]
    public class GearResourceController : Controller
    {
        [HttpGet("scripts/{filename}")]
        public async Task<string> GetScript(string filename)
        {
            return await ResourceProvider.GetEmbeddedScript(filename);
        }
        [HttpGet("styles/{filename}")]
        public async Task<string> GetStyle(string filename)
        {
            return await ResourceProvider.GetEmbeddedStyle(filename);
        }
    }
}
