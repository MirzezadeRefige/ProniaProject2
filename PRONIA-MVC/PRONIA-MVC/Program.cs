using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PRONIA_BL.Services.Abstractions;
using PRONIA_BL.Services.Concretes;
using PRONIA_DAL.Contexts;

var builder = WebApplication.CreateBuilder(args);
var ConnectionStrings = builder.Configuration.GetConnectionString("MSSql");
builder.Services.AddDbContext<ProniaDbContext>(option => option.UseSqlServer(ConnectionStrings));
builder.Services.AddControllersWithViews();

builder.Services.AddScoped <ISliderItemService, SliderItemService>();
var app = builder.Build();


app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern:"{controller=Home}/{action=Index}/{id?}"
    );
app.UseStaticFiles();

app.Run();
