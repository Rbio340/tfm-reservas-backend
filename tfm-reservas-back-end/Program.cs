using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Reserva.Core.Interfaces.Repository.MySql;
using Reserva.Repository.Context;
using Reserva.Repository.Data.MySql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ReservaContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("Default"))
           .EnableSensitiveDataLogging());

// Repository
builder.Services.AddScoped<IAreaComunRepository, AreaComunRepository>();
builder.Services.AddScoped<ICatalogoAreaComunRepository, CatalogoAreaComunRepository>();
builder.Services.AddScoped<IEstadoRepository, EstadoRepository>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IConfiguracionRepository, ConfiguracionRepository>();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Reserva API",
        Description = "An ASP.NET Core Web API for managing reservations",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});

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

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reserva API V1");
    c.RoutePrefix = string.Empty; // para que Swagger UI esté en la raíz (opcional)
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
