using System.Reflection;
using Gear.Core;
using Gear.DAO;
using Gear.Models;
using GearCMS.Models.PageModels;

//Mock
var pageModels = new List<GearPageModel<object>>()
            {
                new GearPageModel<object>()
                {
                    Url = "/testPage1",
                    Title="testPage1",
                    PageViewName="HomePage",
                    UserPageModel = new HomePageModel()
                    {
                        TestVariable = "test1"
                    }
                },
                new GearPageModel<object>()
                {
                    Url = "/testPage2",
                    Title="testPage2",
                    PageViewName="HomePage",
                    UserPageModel = new HomePageModel()
                    {
                        TestVariable = "test2"
                    }
                },
                new GearPageModel<object>()
                {
                    Url = "/testPage1/subpage",
                    Title="testPage2",
                    PageViewName="Subpage",
                    UserPageModel = new SubpageModel()
                    {
                        SubpageTestVariable = "testsubpage"
                    }
                }
            };


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IContentDAO>(new ContentDAOMock(pageModels));
builder.Services.AddSingleton(new ViewInfoProvider());
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
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}");
app.MapControllers();
app.Run();



//app.MapDynamicControllerRoute