using API.Consumer;
using API_Consumer;
using Barberia.Modelos;
using Barberia.Servicios;
using Barberia.Servicios.Interfaces;

Crud<Barbero>.EndPoint = "https://localhost:7238/api/Barberos";
Crud<Cliente>.EndPoint = "https://localhost:7238/api/Clientes";
Crud<Servicio>.EndPoint = "https://localhost:7238/api/Servicios";
Crud<Horario>.EndPoint = "https://localhost:7238/api/Horarios";
Crud<Cita>.EndPoint = "https://localhost:7238/api/Citas";


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAuthService, AuthService>();


builder.Services.AddAuthentication("Cookies") //cokies
                .AddCookie("Cookies", options =>
                {
                    options.LoginPath = "/Account/Index"; // Ruta de inicio de sesión


                });
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
