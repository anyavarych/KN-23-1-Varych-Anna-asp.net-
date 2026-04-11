var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<PasswordGeneratorMvc.Services.PasswordService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Password}/{action=Index}/{id?}");

app.Run();