using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using mikk_mmc_web.Services;
using mikk_mmc_web.Services.Demo;

var builder = WebApplication.CreateBuilder(args);

// Thêm các dịch vụ vào container.
builder.Services.AddControllersWithViews();

// Đăng ký các dịch vụ
builder.Services.AddSingleton<IRouterService, RouterServiceDemo>();
builder.Services.AddSingleton<IInterfaceService, InterfaceServiceDemo>();
builder.Services.AddSingleton<IFirewallService, FirewallServiceDemo>();
builder.Services.AddSingleton<IDhcpService, DhcpServiceDemo>();
builder.Services.AddSingleton<ILogService, LogServiceDemo>();

// Tạo lớp Router Demo được kết nối sẵn
builder.Services.AddSingleton<RouterServiceDemo>(provider =>
{
    var service = new RouterServiceDemo(provider.GetRequiredService<ILogger<RouterServiceDemo>>());
    // Kết nối tự động với cài đặt demo
    service.ConnectAsync(new mikk_mmc_web.Models.ConnectionSettings
    {
        IpAddress = "192.168.1.1",
        Username = "admin",
        Password = "demo-password",
        Protocol = "API"
    }).Wait();
    return service;
});

var app = builder.Build();

// Cấu hình HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // Mặc định HSTS là 30 ngày. 
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
