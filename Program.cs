using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Dodajemy konfigurację CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000")  // Frontend na porcie 3000
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Rejestrujemy usługę IHttpContextAccessor
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Rejestrujemy DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=your_database_path_here.db"));

// Rejestrujemy CarService
builder.Services.AddScoped<CarService>();
builder.Services.AddScoped<ReviewService>();
// Rejestrujemy kontrolery
builder.Services.AddControllers();

// Dodajemy Swagger (opcjonalnie, do testowania API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Konfiguracja JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
        };
    });

// Dodajemy Swagger (opcjonalnie, do testowania API)
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Używamy CORS
app.UseCors("AllowFrontend");

// Używamy autentykacji i autoryzacji
app.UseAuthentication();
app.UseAuthorization();

// Używamy Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Mapowanie kontrolerów
app.MapControllers();

app.Run();
