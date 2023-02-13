using System.Reflection;
using Gear.ContentManagement.Controllers;
using Gear.Core;
using Gear.DAO;
using Gear.DAO.Interfaces;
using Gear.Models;
using GearCMS;
using GearCMS.Models.PageModels;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var gearAssembly = typeof(ManagementPanelController).Assembly;
builder.Services.AddControllersWithViews()
    .AddApplicationPart(gearAssembly)
    .AddRazorRuntimeCompilation();

builder.Services.Configure<MvcRazorRuntimeCompilationOptions>(options =>
{
    options.FileProviders.Add(new EmbeddedFileProvider(gearAssembly));
});

builder.Services.AddSingleton<IContentDAO>(new MockContentPageDAO());
builder.Services.AddSingleton<IContentRouteProvider>(new MockContentRouteDAO());
builder.Services.AddSingleton(new TemplateInfoProvider());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "config",
//    pattern: "{controller=ManagementPanel}/{action=Get}");
app.MapControllers();
app.Run();



//app.MapDynamicControllerRoute