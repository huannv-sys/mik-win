using mikk_mmc_web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register services
builder.Services.AddSingleton<IRouterService, RouterService>();
builder.Services.AddSingleton<IInterfaceService, InterfaceService>();
builder.Services.AddSingleton<IFirewallService, FirewallService>();
builder.Services.AddSingleton<IDhcpService, DhcpService>();
builder.Services.AddSingleton<ILogService, LogService>();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Thông báo khi ứng dụng khởi động
var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("MikroTik Monitor Web Application started");

app.Run();
