using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PasswordGeneratorMvc.Data;
using PasswordGeneratorMvc.Filters;
using PasswordGeneratorMvc.Middleware;
using PasswordGeneratorMvc.Models;
using PasswordGeneratorMvc.Services;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration
        .GetConnectionString("DefaultConnection")));

// Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// Cookie налаштування
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

// Сервіси
builder.Services.AddSingleton<PasswordService>();
builder.Services.AddScoped<GlobalLoggingFilter>();
builder.Services.AddScoped<ControllerLoggingFilter>();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.AddService<GlobalLoggingFilter>();
});

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseRequestLogging(); // middleware
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Password}/{action=Register}/{id?}");
app.MapRazorPages();

// Seed Admin
await SeedData.InitializeAsync(app.Services);

app.Run();