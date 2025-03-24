using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mikk_mmc_web.Models;
using mikk_mmc_web.Services;
using mikk_mmc_web.ViewModels;

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
                if (!_routerService.IsConnected)
                {
                    TempData["InfoMessage"] = "Vui lòng kết nối tới Router để sử dụng ứng dụng.";
                    return RedirectToAction(nameof(Settings));
                }

                var routerInfo = await _routerService.GetRouterInfoAsync();
                var systemResources = await _routerService.GetSystemResourcesAsync();
                var interfaces = await _interfaceService.GetAllInterfacesAsync();
                var firewallRules = await _firewallService.GetAllRulesAsync();
                var dhcpLeases = await _dhcpService.GetAllLeasesAsync();
                var logs = await _logService.GetAllLogsAsync(10);

                var viewModel = new DashboardViewModel
                {
                    RouterInfo = routerInfo,
                    SystemResources = systemResources,
                    TopInterfaces = interfaces.GetRange(0, Math.Min(interfaces.Count, 3)),
                    RecentRules = firewallRules.GetRange(0, Math.Min(firewallRules.Count, 5)),
                    RecentLeases = dhcpLeases.GetRange(0, Math.Min(dhcpLeases.Count, 5)),
                    RecentLogs = logs,
                    LastUpdated = DateTime.Now
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi hiển thị trang Dashboard");
                TempData["ErrorMessage"] = $"Lỗi: {ex.Message}";
                return View(new DashboardViewModel());
            }
        }

        public IActionResult Settings()
        {
            var viewModel = new ConnectionSettings();
            
            // Nếu đã kết nối, sử dụng cài đặt hiện tại
            if (_routerService.IsConnected)
            {
                viewModel = _routerService.CurrentSettings;
                ViewBag.IsConnected = true;
            }
            else
            {
                ViewBag.IsConnected = false;
            }
            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Connect(ConnectionSettings model)
        {
            if (!ModelState.IsValid)
            {
                return View("Settings", model);
            }

            try
            {
                // Thử kết nối tới Router
                var success = await _routerService.ConnectAsync(model);
                
                if (success)
                {
                    _logger.LogInformation($"Kết nối thành công tới Router {model.IpAddress}");
                    TempData["SuccessMessage"] = "Kết nối thành công tới Router!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _logger.LogWarning($"Kết nối thất bại tới Router {model.IpAddress}");
                    ModelState.AddModelError(string.Empty, "Kết nối thất bại. Vui lòng kiểm tra thông tin kết nối và thử lại.");
                    return View("Settings", model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi kết nối tới Router {model.IpAddress}");
                ModelState.AddModelError(string.Empty, $"Lỗi: {ex.Message}");
                return View("Settings", model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Disconnect()
        {
            try
            {
                // Ngắt kết nối
                var success = await _routerService.DisconnectAsync();
                
                if (success)
                {
                    _logger.LogInformation("Ngắt kết nối từ Router thành công");
                    TempData["InfoMessage"] = "Đã ngắt kết nối từ Router.";
                }
                else
                {
                    _logger.LogWarning("Ngắt kết nối từ Router thất bại");
                    TempData["WarningMessage"] = "Ngắt kết nối thất bại.";
                }
                
                return RedirectToAction(nameof(Settings));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi ngắt kết nối từ Router");
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
}
