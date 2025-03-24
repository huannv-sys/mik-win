using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using mikk_mmc_web.Services;
using mikk_mmc_web.Services.Demo;
using System;

var builder = WebApplication.CreateBuilder(args);

// Tối ưu cho môi trường Replit
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Warning);

// Cấu hình cho môi trường Replit
builder.Services.Configure<HostOptions>(options =>
{
    options.ShutdownTimeout = TimeSpan.FromSeconds(10);
});

// Thêm các dịch vụ vào container
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
    try
    {
        // Kết nối tự động với cài đặt demo
        service.ConnectAsync(new mikk_mmc_web.Models.ConnectionSettings
        {
            IpAddress = "192.168.1.1",
            Username = "admin",
            Password = "demo-password",
            Protocol = "API"
        }).Wait();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Lỗi khi kết nối tới Router demo: {ex.Message}");
    }
    return service;
});

var app = builder.Build();

// Giản lược pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// Bỏ HTTPS trên Replit
// app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// In thông báo khi ứng dụng đã sẵn sàng
app.Lifetime.ApplicationStarted.Register(() =>
{
    Console.WriteLine("===== MikroTik Monitor Web =====");
    Console.WriteLine("Ứng dụng đã khởi động thành công!");
    Console.WriteLine("Truy cập: http://localhost:5000 hoặc http://0.0.0.0:5000");
});

try
{
    Console.WriteLine("Đang khởi động ứng dụng...");
    app.Run("http://0.0.0.0:5000");
}
catch (Exception ex)
{
    Console.WriteLine($"Lỗi khi khởi động ứng dụng: {ex.Message}");
}
