using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PRONIA_DAL.Contexts;

var builder = WebApplication.CreateBuilder(args);
var ConnectionStrings = builder.Configuration.GetConnectionString("MSSql");
builder.Services.AddDbContext<ProniaDbContext>(option => option.UseSqlServer(ConnectionStrings));
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern:"{controller=Home}/{action=Index}/{id?}"
    );



app.Run();
