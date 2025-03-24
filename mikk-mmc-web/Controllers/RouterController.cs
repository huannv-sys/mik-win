using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mikk_mmc_web.Models;
using mikk_mmc_web.Services;
using System;
using System.Threading.Tasks;

namespace mikk_mmc_web.Controllers
{
    public class RouterController : Controller
    {
        private readonly ILogger<RouterController> _logger;
        private readonly IRouterService _routerService;

        public RouterController(ILogger<RouterController> logger, IRouterService routerService)
        {
            _logger = logger;
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

                var routerInfo = await _routerService.GetRouterInfoAsync();
                var resources = await _routerService.GetSystemResourcesAsync();

                ViewBag.SystemResources = resources;
                return View(routerInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy thông tin Router");
                ViewBag.ErrorMessage = "Có lỗi xảy ra khi tải thông tin Router. Chi tiết: " + ex.Message;
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult Connect()
        {
            return View(new ConnectionSettings());
        }

        [HttpPost]
        public async Task<IActionResult> Connect(ConnectionSettings settings)
        {
            if (!ModelState.IsValid)
            {
                return View(settings);
            }

            try
            {
                var success = await _routerService.ConnectAsync(settings);
                if (success)
                {
                    _logger.LogInformation("Đã kết nối thành công đến Router {IpAddress}", settings.IpAddress);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Không thể kết nối đến Router. Vui lòng kiểm tra lại thông tin đăng nhập.");
                    return View(settings);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi kết nối đến Router {IpAddress}", settings.IpAddress);
                ModelState.AddModelError("", "Lỗi khi kết nối: " + ex.Message);
                return View(settings);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Disconnect()
        {
            try
            {
                await _routerService.DisconnectAsync();
                return RedirectToAction("Connect");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi ngắt kết nối Router");
                ViewBag.ErrorMessage = "Có lỗi xảy ra khi ngắt kết nối Router. Chi tiết: " + ex.Message;
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> SystemResources()
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return View("NotConnected");
                }

                var resources = await _routerService.GetSystemResourcesAsync();
                return View(resources);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy tài nguyên hệ thống");
                ViewBag.ErrorMessage = "Có lỗi xảy ra khi tải tài nguyên hệ thống. Chi tiết: " + ex.Message;
                return View("Error");
            }
        }
    }
}
