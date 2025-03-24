using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mikk_mmc_web.Models;
using mikk_mmc_web.Services;

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

        // Hiển thị trạng thái Router
        public async Task<IActionResult> Status()
        {
            try
            {
                // Kiểm tra kết nối
                if (!_routerService.IsConnected)
                {
                    TempData["WarningMessage"] = "Chưa kết nối tới Router. Vui lòng kết nối trước.";
                    return RedirectToAction("Settings", "Home");
                }

                // Lấy thông tin Router
                var routerInfo = await _routerService.GetRouterInfoAsync();
                var systemResources = await _routerService.GetSystemResourcesAsync();

                // Tạo model 
                var viewModel = new RouterStatusViewModel
                {
                    RouterInfo = routerInfo,
                    SystemResources = systemResources
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi hiển thị trạng thái Router");
                TempData["ErrorMessage"] = $"Lỗi: {ex.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        // API để lấy thông tin Router
        [HttpGet]
        [Route("api/router/info")]
        public async Task<IActionResult> GetRouterInfo()
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                var routerInfo = await _routerService.GetRouterInfoAsync();
                return Json(routerInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy thông tin Router qua API");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // API để lấy thông tin tài nguyên hệ thống
        [HttpGet]
        [Route("api/router/resources")]
        public async Task<IActionResult> GetSystemResources()
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                var resources = await _routerService.GetSystemResourcesAsync();
                return Json(resources);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy thông tin tài nguyên hệ thống qua API");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // Khởi động lại Router
        [HttpPost]
        [Route("api/router/reboot")]
        public async Task<IActionResult> RebootRouter()
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                bool success = await _routerService.RebootRouterAsync();
                
                if (success)
                {
                    _logger.LogInformation("Khởi động lại Router thành công");
                    return Json(new { success = true, message = "Khởi động lại Router thành công" });
                }
                else
                {
                    _logger.LogWarning("Khởi động lại Router thất bại");
                    return StatusCode(500, new { error = "Không thể khởi động lại Router" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi khởi động lại Router");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // Sao lưu cấu hình
        [HttpPost]
        [Route("api/router/backup")]
        public async Task<IActionResult> BackupConfiguration(string filename)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                if (string.IsNullOrWhiteSpace(filename))
                {
                    filename = $"backup_{DateTime.Now:yyyyMMdd_HHmmss}.rsc";
                }

                bool success = await _routerService.BackupConfigurationAsync(filename);
                
                if (success)
                {
                    _logger.LogInformation($"Sao lưu cấu hình thành công: {filename}");
                    return Json(new { success = true, message = $"Sao lưu cấu hình thành công: {filename}" });
                }
                else
                {
                    _logger.LogWarning($"Sao lưu cấu hình thất bại: {filename}");
                    return StatusCode(500, new { error = "Không thể sao lưu cấu hình" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi sao lưu cấu hình");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // Khôi phục cấu hình
        [HttpPost]
        [Route("api/router/restore")]
        public async Task<IActionResult> RestoreConfiguration(string filename)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                if (string.IsNullOrWhiteSpace(filename))
                {
                    return BadRequest(new { error = "Tên file không được để trống" });
                }

                bool success = await _routerService.RestoreConfigurationAsync(filename);
                
                if (success)
                {
                    _logger.LogInformation($"Khôi phục cấu hình thành công từ: {filename}");
                    return Json(new { success = true, message = $"Khôi phục cấu hình thành công từ: {filename}" });
                }
                else
                {
                    _logger.LogWarning($"Khôi phục cấu hình thất bại từ: {filename}");
                    return StatusCode(500, new { error = "Không thể khôi phục cấu hình" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi khôi phục cấu hình");
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }

    public class RouterStatusViewModel
    {
        public RouterInfo RouterInfo { get; set; }
        public SystemResources SystemResources { get; set; }
    }
}
