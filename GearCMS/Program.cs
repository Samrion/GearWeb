using System.Reflection;
using Gear.ContentManagement.ManagementControllers;
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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews().AddApplicationPart(typeof(ManagementPanelController).Assembly);
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