using Microsoft.EntityFrameworkCore;
using Proyecto_Final_Sql_Store_Games.Models;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios de autenticación y autorización
builder.Services.AddAuthentication("Cookies") // Aquí definimos 'Cookies' como el esquema por defecto si no se especifica otro
    .AddCookie("Cookies", options => // Usamos el esquema de Cookies
    {
        options.LoginPath = "/Account/Login"; // Ruta de redirección para el login
        options.AccessDeniedPath = "/Account/AccessDenied"; // Ruta si hay acceso denegado
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20); // Tiempo de expiración del cookie
        options.SlidingExpiration = true; // Refrescar el tiempo de vida del cookie en cada solicitud
    });

// Habilitar servicios necesarios para MVC y sesión
builder.Services.AddControllersWithViews();

// Configurar el DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Db_Contexto>(options =>
    options.UseSqlServer(connectionString));

// Configuración de sesiones
builder.Services.AddDistributedMemoryCache(); // Almacén en memoria para sesiones
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Establecer tiempo de espera de sesión
    options.Cookie.HttpOnly = true; // Solo accesible desde el servidor
    options.Cookie.IsEssential = true; // Habilitar la cookie para el funcionamiento de la sesión
});

var app = builder.Build();

// Configuración de la canalización de peticiones
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Middleware para la autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

// Middleware de sesiones
app.UseSession();  // Este middleware debe estar antes de la ruta que accede a la sesión

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();