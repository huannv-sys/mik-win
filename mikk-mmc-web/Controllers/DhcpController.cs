using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mikk_mmc_web.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace mikk_mmc_web.Controllers
{
    public class DhcpController : Controller
    {
        private readonly ILogger<DhcpController> _logger;
        private readonly IDhcpService _dhcpService;
        private readonly IRouterService _routerService;

        public DhcpController(
            ILogger<DhcpController> logger,
            IDhcpService dhcpService,
            IRouterService routerService)
        {
            _logger = logger;
            _dhcpService = dhcpService;
            _routerService = routerService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return View("NotConnected");
                }

                var leases = await _dhcpService.GetDhcpLeasesAsync();
                
                // Phân loại các lease để hiển thị
                ViewBag.ActiveLeases = leases.Where(l => l.Active).ToList();
                ViewBag.InactiveLeases = leases.Where(l => !l.Active).ToList();
                ViewBag.DynamicLeases = leases.Where(l => l.Dynamic).ToList();
                ViewBag.StaticLeases = leases.Where(l => !l.Dynamic).ToList();
                
                return View(leases);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách DHCP lease");
                ViewBag.ErrorMessage = "Có lỗi xảy ra khi tải danh sách DHCP lease. Chi tiết: " + ex.Message;
                return View("Error");
            }
        }

        public async Task<IActionResult> Details(string macAddress)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return View("NotConnected");
                }

                if (string.IsNullOrEmpty(macAddress))
                {
                    return BadRequest("Địa chỉ MAC không được để trống");
                }

                var lease = await _dhcpService.GetDhcpLeaseByMacAsync(macAddress);
                if (lease == null)
                {
                    return NotFound($"Không tìm thấy DHCP lease với địa chỉ MAC '{macAddress}'");
                }

                return View(lease);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy thông tin DHCP lease {MacAddress}", macAddress);
                ViewBag.ErrorMessage = "Có lỗi xảy ra khi tải thông tin DHCP lease. Chi tiết: " + ex.Message;
                return View("Error");
            }
        }
    }
}
