using Gear.Core;
using Gear.Data;
using Gear.Management.Controllers.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;

namespace Gear
{
    public static class GearApp
    {
        public static void ConfigureGearServices(WebApplicationBuilder builder, string connectionStringName)
        {
            //basic config
            var userAssembly = Assembly.GetCallingAssembly();
            var gearAssembly = typeof(ManagementPanelController).Assembly;
            builder.Services.AddControllersWithViews()
                .AddApplicationPart(gearAssembly)
                .AddRazorRuntimeCompilation();

            builder.Services.Configure<MvcRazorRuntimeCompilationOptions>(options =>
            {
                options.FileProviders.Add(new EmbeddedFileProvider(gearAssembly));
            });
            builder.Services.AddSingleton(new TemplateInfoProvider(userAssembly));

            //db connection
            var connectionsString = builder.Configuration.GetConnectionString(connectionStringName);
            builder.Services.AddDbContext<GearContext>(options => options.UseSqlServer(connectionsString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        }

        public static void CreateGearDbIfNotExist(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<GearContext>();
                    GearDbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }
    }
}
