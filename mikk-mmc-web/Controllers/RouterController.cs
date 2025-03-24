using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mikk_mmc_web.Models;
using mikk_mmc_web.Services;
using mikk_mmc_web.ViewModels;

namespace mikk_mmc_web.Controllers
{
    public class RouterController : Controller
    {
        private readonly ILogger<RouterController> _logger;
        private readonly IRouterService _routerService;

        public RouterController(
            ILogger<RouterController> logger,
            IRouterService routerService)
        {
            _logger = logger;
            _routerService = routerService;
        }

        // Trang trạng thái router
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

                // Lấy thông tin router
                var routerInfo = await _routerService.GetRouterInfoAsync();
                
                // Lấy thông tin tài nguyên hệ thống
                var systemResources = await _routerService.GetSystemResourcesAsync();
                
                // Tạo ViewModel
                var viewModel = new RouterStatusViewModel
                {
                    RouterInfo = routerInfo,
                    SystemResources = systemResources
                };
                
                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi hiển thị trang trạng thái router");
                TempData["ErrorMessage"] = $"Lỗi: {ex.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        // API để khởi động lại router
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
                    _logger.LogInformation("Khởi động lại router thành công");
                    return Json(new { success = true, message = "Đã gửi lệnh khởi động lại router" });
                }
                else
                {
                    _logger.LogWarning("Khởi động lại router thất bại");
                    return StatusCode(500, new { error = "Không thể khởi động lại router" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi khởi động lại router");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // API để sao lưu cấu hình
        [HttpPost]
        [Route("api/router/backup")]
        public async Task<IActionResult> BackupConfiguration([FromBody] BackupRequest request)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                if (request == null || string.IsNullOrEmpty(request.Filename))
                {
                    request = new BackupRequest
                    {
                        Filename = $"backup_{DateTime.Now:yyyyMMdd_HHmmss}.rsc"
                    };
                }

                bool success = await _routerService.BackupConfigurationAsync(request.Filename);
                
                if (success)
                {
                    _logger.LogInformation($"Sao lưu cấu hình vào file {request.Filename} thành công");
                    return Json(new { success = true, message = $"Đã sao lưu cấu hình vào file {request.Filename}" });
                }
                else
                {
                    _logger.LogWarning($"Sao lưu cấu hình vào file {request.Filename} thất bại");
                    return StatusCode(500, new { error = "Không thể sao lưu cấu hình" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi sao lưu cấu hình");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // API để khôi phục cấu hình
        [HttpPost]
        [Route("api/router/restore")]
        public async Task<IActionResult> RestoreConfiguration([FromBody] RestoreRequest request)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                if (request == null || string.IsNullOrEmpty(request.Filename))
                {
                    return BadRequest(new { error = "Tên file không được để trống" });
                }

                bool success = await _routerService.RestoreConfigurationAsync(request.Filename);
                
                if (success)
                {
                    _logger.LogInformation($"Khôi phục cấu hình từ file {request.Filename} thành công");
                    return Json(new { success = true, message = $"Đã khôi phục cấu hình từ file {request.Filename}" });
                }
                else
                {
                    _logger.LogWarning($"Khôi phục cấu hình từ file {request.Filename} thất bại");
                    return StatusCode(500, new { error = "Không thể khôi phục cấu hình" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi khôi phục cấu hình");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // API để lấy thông tin router
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
                _logger.LogError(ex, "Lỗi khi lấy thông tin router qua API");
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

                var systemResources = await _routerService.GetSystemResourcesAsync();
                return Json(systemResources);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy thông tin tài nguyên hệ thống qua API");
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }

    // Lớp để nhận request sao lưu
    public class BackupRequest
    {
        public string Filename { get; set; } = string.Empty;
    }

    // Lớp để nhận request khôi phục
    public class RestoreRequest
    {
        public string Filename { get; set; } = string.Empty;
    }
}
