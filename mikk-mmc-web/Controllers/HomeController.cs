using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mikk_mmc_web.Models;
using mikk_mmc_web.Services;

namespace mikk_mmc_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRouterService _routerService;
        private readonly IInterfaceService _interfaceService;
        private readonly IFirewallService _firewallService;
        private readonly IDhcpService _dhcpService;
        private readonly ILogService _logService;

        public HomeController(
            ILogger<HomeController> logger,
            IRouterService routerService,
            IInterfaceService interfaceService,
            IFirewallService firewallService,
            IDhcpService dhcpService,
            ILogService logService)
        {
            _logger = logger;
            _routerService = routerService;
            _interfaceService = interfaceService;
            _firewallService = firewallService;
            _dhcpService = dhcpService;
            _logService = logService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                // Kiểm tra trạng thái kết nối
                if (!_routerService.IsConnected)
                {
                    // Nếu chưa kết nối, hãy kết nối với thông tin mặc định để demo
                    await _routerService.ConnectAsync(new ConnectionSettings
                    {
                        IpAddress = "192.168.1.1",
                        Username = "admin",
                        Password = "password", // Trong môi trường thực, mật khẩu này sẽ được nhập bởi người dùng
                        Port = 22,
                        ApiPort = "8728",
                        ConnectionMethod = "API"
                    });
                }

                // Tạo viewmodel cho Dashboard
                var viewModel = new DashboardViewModel();

                // Lấy thông tin Router
                viewModel.RouterInfo = await _routerService.GetRouterInfoAsync();

                // Lấy thông tin tài nguyên hệ thống
                viewModel.SystemResources = await _routerService.GetSystemResourcesAsync();

                // Lấy top 5 giao diện mạng
                var interfaces = await _interfaceService.GetAllInterfacesAsync();
                viewModel.TopInterfaces = interfaces.Take(5).ToList();

                // Lấy các luật tường lửa gần đây nhất
                var rules = await _firewallService.GetAllRulesAsync();
                viewModel.RecentRules = rules.Take(5).ToList();

                // Lấy các DHCP lease gần đây nhất
                var leases = await _dhcpService.GetAllLeasesAsync();
                viewModel.RecentLeases = leases.Take(5).ToList();

                // Lấy các log gần đây nhất
                viewModel.RecentLogs = await _logService.GetAllLogsAsync(5);

                // Cập nhật thời gian
                viewModel.LastUpdated = DateTime.Now;

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi tải trang Dashboard");
                ViewBag.ErrorMessage = ex.Message;
                return View(new DashboardViewModel());
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Settings()
        {
            var settings = _routerService.CurrentSettings;
            // Không hiển thị mật khẩu
            settings.Password = string.Empty;
            return View(settings);
        }

        [HttpPost]
        public async Task<IActionResult> Connect(ConnectionSettings settings)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation($"Đang kết nối tới Router tại {settings.IpAddress}");
                    
                    bool success = await _routerService.ConnectAsync(settings);
                    
                    if (success)
                    {
                        _logger.LogInformation("Kết nối thành công");
                        TempData["SuccessMessage"] = "Kết nối thành công tới Router";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        _logger.LogWarning("Kết nối thất bại");
                        ModelState.AddModelError("", "Không thể kết nối tới Router. Vui lòng kiểm tra thông tin đăng nhập.");
                    }
                }
                
                return View("Settings", settings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi kết nối");
                ModelState.AddModelError("", $"Lỗi: {ex.Message}");
                return View("Settings", settings);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Disconnect()
        {
            try
            {
                _logger.LogInformation("Đang ngắt kết nối từ Router");
                
                bool success = await _routerService.DisconnectAsync();
                
                if (success)
                {
                    _logger.LogInformation("Ngắt kết nối thành công");
                    TempData["SuccessMessage"] = "Đã ngắt kết nối từ Router";
                }
                else
                {
                    _logger.LogWarning("Ngắt kết nối thất bại");
                    TempData["ErrorMessage"] = "Không thể ngắt kết nối từ Router";
                }
                
                return RedirectToAction(nameof(Settings));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi ngắt kết nối");
                TempData["ErrorMessage"] = $"Lỗi: {ex.Message}";
                return RedirectToAction(nameof(Settings));
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
