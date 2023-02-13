using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Gear.Core;
using Gear.DAO.Interfaces;
using Gear.Management.Models;

namespace Gear.ContentManagement.Controllers
{
    [Route("config")]
    public class ManagementPanelController : Controller
    {
        private readonly IContentDAO ContentDAO;
        private readonly TemplateInfoProvider TemplateInfoProvider;
        private readonly IContentRouteProvider ContentRouteProvider;
        public ManagementPanelController(IContentDAO contentDAO, TemplateInfoProvider contentInfoProvider, IContentRouteProvider contentRouteProvider)
        {
            ContentDAO = contentDAO;
            TemplateInfoProvider = contentInfoProvider;
            ContentRouteProvider = contentRouteProvider;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var configUserPageModels = new List<ConfigUserPageModel>();
            var pageModels = ContentDAO.GetPageModels();
            foreach (var page in pageModels)
            {
                Debug.WriteLine(page.Url);
                var templateInfo = TemplateInfoProvider.PageTemplatesInfo.Where(x => x.Name == page.TemplateName).FirstOrDefault();
                var configUserPageModel = new ConfigUserPageModel()
                {
                    Id = page.Id,
                    Url = page.Url,
                    Title = page.Title,

                    TemplateName = templateInfo.Name,
                    TemplateModelName = templateInfo.UserModelType.Name,

                };

                var properties = ContentDAO.GetUserModelPropertiesById(page.Id);
                var configUserModelProperties = new List<ConfigUserModelProperty>();
                foreach (var property in properties)
                {
                    configUserModelProperties.Add(new ConfigUserModelProperty()
                    {
                        Name = property.Name,
                        TypeName = property.Value.GetType().Name,
                        Value = property.Value.ToString()
                    });
                }
                configUserPageModel.UserProperties = configUserModelProperties;
                configUserPageModels.Add(configUserPageModel);
            }
            return View("/Management/Views/GearConfigPanel.cshtml", configUserPageModels);
        }

        [Route("config/modelEditor")]
        public IEnumerable<string> GetModelProperties()
        {
            return new string[] { "model prop" };
        }

    }
}
