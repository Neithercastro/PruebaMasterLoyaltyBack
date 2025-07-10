using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PruebaMasterLoyalty.API.Providers;
using PruebaMasterLoyalty.Business.Interfaces;
using PruebaMasterLoyalty.Business.Services;
using PruebaMasterLoyalty.Data.Entities;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//SERVICIO PARA LA CONEXION A BASE DE DATOS
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//SERVICIOS DE PARA LOS CONTROLADORESW
builder.Services.AddScoped<IArticuloService, ArticuloService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICarritoService, CarritoService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IImagenService, ImagenService>();
builder.Services.AddScoped<IPathProvider, WebRootPathProvider>();
builder.Services.AddScoped<ITiendaService, TiendaService>();
builder.Services.AddScoped<IVentaService, VentaService>();



var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();// Esto permite exponer /wwwroot como accesible vía HTTP
app.MapControllers();

app.Run();
