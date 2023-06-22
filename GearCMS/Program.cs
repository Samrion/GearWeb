using Gear;

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

app.MapControllers();
app.Run();
