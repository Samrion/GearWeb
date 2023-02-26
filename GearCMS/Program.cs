using System.Reflection;
using Gear.Core;
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
using Gear.GearConfiguration;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);
GearApp.ConfigureGearServices(builder, "GearConnection");
// Add services to the container.
var app = builder.Build();
GearApp.CreateGearDbIfNotExist(app);

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
