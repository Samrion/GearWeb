
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gear
{
	public class GearAppBuilder
	{
		private Assembly UserAssembly { get; set; }
		public WebApplicationBuilder DefaultBuilder { get; private set; }
		public GearAppBuilder(string[] args)
		{
			UserAssembly = Assembly.GetCallingAssembly();
			DefaultBuilder = WebApplication.CreateBuilder(args);
			DefaultBuilder.Services
				.AddControllersWithViews()
				.AddApplicationPart(GetType().Assembly)
				.AddRazorRuntimeCompilation();
		}

		public GearAppBuilder AddGearUI()
		{
			//DefaultBuilder.Services
			//	.AddControllersWithViews()
			//	.AddApplicationPart(typeof(ManagementPanelController).Assembly);
			return this;
		}
	}
}
