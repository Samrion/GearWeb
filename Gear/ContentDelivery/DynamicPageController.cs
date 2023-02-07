using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gear.Core;
using Gear.DAO;
using Gear.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Gear.ContentDelivery
{
    [Route("/{**slug}")]
    public class DynamicPageController : Controller
    {
        private readonly IContentDAO ContentDAO;
        private readonly ViewInfoProvider ContentInfoProvider;
        public DynamicPageController(IContentDAO contentDAO, ViewInfoProvider contentInfoProvider)
        {
            ContentDAO = contentDAO;
            ContentInfoProvider = contentInfoProvider;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var url = HttpContext.Request.Path;
            var pageModel = ContentDAO.GetPageModelForUrl(url);
            if (pageModel == null) return NotFound();
            var viewPath = ContentInfoProvider.GetViewPathByName(pageModel.PageViewName);
            if (viewPath == null) return NotFound();

            var x = GearModelTypeResolver.CastGearPageModelGenericType(pageModel.UserPageModel);
            Debug.WriteLine(x.GetType());
            if(x == null) return NotFound();
            return View(viewPath, x);
        }
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var url = HttpContext.Request.Path;
        //    var pageModel = ContentDAO.GetPageForUrl(url);
        //    if (pageModel == null) return NotFound();
        //    var viewPath = ContentInfoProvider.GetViewPathByName(pageModel.PageViewName);
        //    if (viewPath == null) return NotFound();

        //    var x = GearModelTypeResolver.CastGearPageModelGenericType(pageModel.UserPageModel);
        //    Debug.WriteLine(x.GetType());
        //    return NotFound();
        //    return View(viewPath, x);
        //}
    }
}
