using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gear.Core;
using Gear.DAO.Interfaces;
using Gear.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Gear.ContentDelivery
{
    [Route("/{**slug}")]
    public class DynamicPageController : Controller
    {
        private readonly IContentDAO ContentDAO;
        private readonly TemplateInfoProvider TemplateInfoProvider;
        private readonly IContentRouteProvider ContentRouteProvider;

        public DynamicPageController(IContentDAO contentDAO, TemplateInfoProvider contentInfoProvider, IContentRouteProvider contentRouteProvider)
        {
            ContentDAO = contentDAO;
            TemplateInfoProvider = contentInfoProvider;
            ContentRouteProvider = contentRouteProvider;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var url = HttpContext.Request.Path;
            if(!ContentRouteProvider.RouteTable.TryGetValue(url, out var pageId))
            {
                Debug.WriteLine("Route not found");
                return NotFound();
            }// page id

            var pageModel = ContentDAO.GetPageModelById(pageId); // pagemodel
            if(pageModel == null)
            {
                Debug.WriteLine("model not found");
                return NotFound();
            }

            var templateInfo = TemplateInfoProvider.PageTemplatesInfo.Where(x => x.Name == pageModel.TemplateName).FirstOrDefault();
            if(templateInfo == null)
            {
                Debug.WriteLine("template not found");
                return NotFound();
            }

            var userModelProperties = ContentDAO.GetUserModelPropertiesById(pageModel.Id);
            var userModel = UserModelBuilder.CreateUserPageModel(templateInfo.UserModelType, pageModel, userModelProperties);

            return View(templateInfo.Path, userModel);
        }

    }
}
