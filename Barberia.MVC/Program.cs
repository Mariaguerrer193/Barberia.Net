using API.Consumer;
using API_Consumer;
using Barberia.Modelos;
using Barberia.Servicios;
using Barberia.Servicios.Interfaces;

Crud<Barbero>.EndPoint = "https://barberia-net.onrender.com/api/Barberos";
Crud<Cliente>.EndPoint = "https://barberia-net.onrender.com/api/Clientes";
Crud<Servicio>.EndPoint = "https://barberia-net.onrender.com/api/Servicios";
Crud<Horario>.EndPoint = "https://barberia-net.onrender.com/api/Horarios";
Crud<Cita>.EndPoint = "https://barberia-net.onrender.com/api/Citas";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 1. AGREGAR ESTO: Configuración de Sesiones
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // La sesión dura 30 minutos
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddAuthentication("Cookies")
                .AddCookie("Cookies", options =>
                {
                    options.LoginPath = "/Account/Index";
                });

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 2. AGREGAR ESTO: Activar el uso de sesiones (IMPORTANTE: después de Routing)
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();