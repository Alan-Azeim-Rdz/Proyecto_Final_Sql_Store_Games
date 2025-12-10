using Microsoft.EntityFrameworkCore;
using Proyecto_Final_Sql_Store_Games.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication("Cookies") // Aquí definimos 'Cookies' como el esquema por defecto si no se especifica otro
    .AddCookie("Cookies", options => // Usamos el esquema de Cookies
    {
        // Configuramos la ruta de redirección si la autorización falla (el Challenge)
        options.LoginPath = "/Account/Login"; // <<-- RUTA A TU MÉTODO LOGIN (GET)

        // Configuramos otras opciones si es necesario:
        options.AccessDeniedPath = "/Account/AccessDenied"; // Opcional, si hay una página de acceso denegado
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20); // Tiempo de vida del cookie
        options.SlidingExpiration = true; // Refrescar el tiempo de vida en cada solicitud
    });
// Add services to the container.
builder.Services.AddControllersWithViews();

// 1. Obtener la cadena de conexión de la configuración (appsettings.json)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Registrar el DbContext (usando SQL Server y la cadena de conexión)
builder.Services.AddDbContext<Db_Contexto>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
//agregados
app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}")
    .WithStaticAssets();


app.Run();
