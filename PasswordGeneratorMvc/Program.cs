using PasswordGeneratorMvc.Filters;
using PasswordGeneratorMvc.Middleware;
using PasswordGeneratorMvc.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<PasswordService>();

// Реєстрація фільтрів у DI — потрібна для ServiceFilter
builder.Services.AddScoped<GlobalLoggingFilter>();
builder.Services.AddScoped<ControllerLoggingFilter>();

builder.Services.AddControllersWithViews(options =>
{
    // Глобальний фільтр через ServiceFilter
    options.Filters.AddService<GlobalLoggingFilter>();
});

var app = builder.Build();

// ?? 1. app.Use ?? проміжний компонент (не термінальний) ??????????????????
app.Use(async (context, next) =>
{
    var logger = context.RequestServices
        .GetRequiredService<ILogger<Program>>();
    logger.LogInformation(
        "[app.Use] ? Before next ? {Path}", context.Request.Path);
    await next();
    logger.LogInformation(
        "[app.Use] ? After next ? {Path}", context.Request.Path);
});

// ?? 2. Кастомний middleware ???????????????????????????????????????????????
app.UseRequestLogging();

app.UseStaticFiles();

// ?? 3. app.Map ?? розгалуження на окремий підпайплайн ????????????????????
app.Map("/info", infoApp =>
{
    infoApp.Run(async context =>
    {
        var logger = context.RequestServices
            .GetRequiredService<ILogger<Program>>();
        logger.LogInformation("[app.Map /info] Окремий підпайплайн");
        await context.Response.WriteAsync(
            "INFO: це окремий підпайплайн (app.Map + app.Run)");
    });
});

// ?? 4. app.Map + app.Run ?? термінальний обробник ????????????????????????
app.Map("/terminal", terminalApp =>
{
    terminalApp.Run(async context =>
    {
        var logger = context.RequestServices
            .GetRequiredService<ILogger<Program>>();
        logger.LogInformation("[app.Run /terminal] Термінальний обробник");
        await context.Response.WriteAsync(
            "TERMINAL: app.Run — термінальний обробник, далі нічого не виконується");
    });
});

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Password}/{action=Index}/{id?}");

app.Run();