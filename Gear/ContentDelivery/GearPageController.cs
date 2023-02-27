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
using Microsoft.EntityFrameworkCore;

namespace Gear.ContentDelivery
{
    [Route("/{**slug}")]
    public class GearPageController : Controller
    {
        private readonly GearContext Context;
        private readonly TemplateInfoProvider TemplateInfoProvider;
        public GearPageController(GearContext context, TemplateInfoProvider templateInfoProvider)
        {
            Context = context;
            TemplateInfoProvider = templateInfoProvider;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var path = HttpContext.Request.Path.Value;
            var page = Context.Pages
                .Where(x => x.Url == path)
                .Include(x => x.UserModel)
                .Include(x => x.UserModel.Properties)
                .FirstOrDefault();
            if (page == null) return NotFound();

            var templateInfo = TemplateInfoProvider.GearPageTemplatesInfo.Where(x => x.Name == page.TemplateName).FirstOrDefault();
            if (templateInfo == null) return NotFound();

            UserModelBuilder modelBuilder = new(templateInfo.UserModelType);
            var propertiesData = page.UserModel.Properties.ToList();
            foreach(var property in templateInfo.Properties)
            {
                var dataProperty = propertiesData.FirstOrDefault(x => x.Name == property.Name);
                if (dataProperty == null) continue;
                modelBuilder.AddPropertyValue(property.Name, property.Type, dataProperty.Value);
            }
            var userModel = modelBuilder.Build();
			return View(templateInfo.Path,userModel);
        }

    }
}
