using Microsoft.EntityFrameworkCore;
using Reserva.Core.Interfaces.Repository.MySql;
using Reserva.Repository.Context;
using Reserva.Repository.Data.MySql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ReservaContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Default"))
.EnableSensitiveDataLogging());

// Repository
builder.Services.AddScoped<IAreaComunRepository, AreaComunRepository>();
builder.Services.AddScoped<ICatalogoAreaComunRepository, CatalogoAreaComunRepository>();
builder.Services.AddScoped<IEstadoRepository, EstadoRepository>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
