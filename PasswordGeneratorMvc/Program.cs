var builder = WebApplication.CreateBuilder(args);

// Додаємо сервіс PasswordService
builder.Services.AddSingleton<PasswordGeneratorMvc.Services.PasswordService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Маршрут до PasswordController
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Password}/{action=Index}/{id?}");

app.Run();