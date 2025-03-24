using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mikk_mmc.Models;
using mikk_mmc_web.Services;
using mikk_mmc_web.ViewModels;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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
                var viewModel = new DashboardViewModel();
                
                // Lấy thông tin Router và tài nguyên
                if (_routerService.IsConnected)
                {
                    viewModel.Router = await _routerService.GetRouterInfoAsync() as RouterDevice;
                    viewModel.Resources = await _routerService.GetSystemResourcesAsync();
                }
                
                // Lấy danh sách interface
                var interfaces = await _interfaceService.GetInterfacesAsync();
                viewModel.Interfaces = interfaces.Take(5).ToList();
                
                // Lấy luật tường lửa gần đây nhất
                var firewallRules = await _firewallService.GetFirewallRulesAsync();
                viewModel.RecentFirewallRules = firewallRules
                    .OrderByDescending(r => r.LastHit)
                    .Take(5)
                    .ToList();
                
                // Lấy log gần đây nhất
                var logs = await _logService.GetLogsAsync(10);
                viewModel.RecentLogs = logs.ToList();
                
                // Lấy DHCP lease
                var dhcpLeases = await _dhcpService.GetDhcpLeasesAsync();
                viewModel.DhcpLeases = dhcpLeases
                    .Where(l => l.Active)
                    .Take(5)
                    .ToList();
                
                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy dữ liệu cho trang Dashboard");
                ViewBag.ErrorMessage = "Có lỗi xảy ra khi tải dữ liệu. Chi tiết: " + ex.Message;
                return View(new DashboardViewModel());
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
