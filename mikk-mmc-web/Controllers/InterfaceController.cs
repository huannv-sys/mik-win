using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mikk_mmc_web.Services;
using System;
using System.Threading.Tasks;

namespace mikk_mmc_web.Controllers
{
    public class InterfaceController : Controller
    {
        private readonly ILogger<InterfaceController> _logger;
        private readonly IInterfaceService _interfaceService;
        private readonly IRouterService _routerService;

        public InterfaceController(
            ILogger<InterfaceController> logger,
            IInterfaceService interfaceService,
            IRouterService routerService)
        {
            _logger = logger;
            _interfaceService = interfaceService;
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

                var interfaces = await _interfaceService.GetInterfacesAsync();
                return View(interfaces);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách giao diện mạng");
                ViewBag.ErrorMessage = "Có lỗi xảy ra khi tải danh sách giao diện mạng. Chi tiết: " + ex.Message;
                return View("Error");
            }
        }

        public async Task<IActionResult> Details(string name)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return View("NotConnected");
                }

                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest("Tên giao diện không được để trống");
                }

                var networkInterface = await _interfaceService.GetInterfaceByNameAsync(name);
                if (networkInterface == null)
                {
                    return NotFound($"Không tìm thấy giao diện '{name}'");
                }

                var traffic = await _interfaceService.GetInterfaceTrafficAsync(name);
                ViewBag.Traffic = traffic;

                return View(networkInterface);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy thông tin giao diện {Name}", name);
                ViewBag.ErrorMessage = "Có lỗi xảy ra khi tải thông tin giao diện. Chi tiết: " + ex.Message;
                return View("Error");
            }
        }

        public async Task<IActionResult> Traffic(string name)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return Json(new { success = false, message = "Chưa kết nối đến Router" });
                }

                if (string.IsNullOrEmpty(name))
                {
                    return Json(new { success = false, message = "Tên giao diện không được để trống" });
                }

                var traffic = await _interfaceService.GetInterfaceTrafficAsync(name);
                if (traffic == null)
                {
                    return Json(new { success = false, message = $"Không tìm thấy dữ liệu lưu lượng cho giao diện '{name}'" });
                }

                return Json(new
                {
                    success = true,
                    data = new
                    {
                        name = traffic.InterfaceName,
                        rxPoints = traffic.RxPoints,
                        txPoints = traffic.TxPoints
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy dữ liệu lưu lượng cho giao diện {Name}", name);
                return Json(new { success = false, message = "Lỗi: " + ex.Message });
            }
        }
    }
}
