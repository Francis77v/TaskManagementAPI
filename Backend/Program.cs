using System.Text;
using Backend.Context;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Backend.Endpoints;
using Backend.Models;
using Backend.Services.Auth;
using Backend.Services.ProductServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Load .env variables
Env.Load();

// Build connection string from environment variables
var host = Environment.GetEnvironmentVariable("DB_HOST");
var port = Environment.GetEnvironmentVariable("DB_PORT");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var user = Environment.GetEnvironmentVariable("DB_USER");
var pass = Environment.GetEnvironmentVariable("DB_PASS");

var connectionString = $"Host={host};Port={port};Database={dbName};Username={user};Password={pass}";

// JWT Auth
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
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);
    // .AddGoogle(GoogleDefaults.AuthenticationScheme, googleOptions =>
    // {
    //     googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
    //     googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
    // });

// 3. Add Authorization
builder.Services.AddAuthorization();
//DI Services
builder.Services.AddScoped<AuthServices>();

// DbContext
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(connectionString));
//DI
builder.Services.AddScoped<ProjectCRUD>();

var app = builder.Build();

// Middleware order
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapEndpoint();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();

