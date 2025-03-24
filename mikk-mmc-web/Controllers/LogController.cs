using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mikk_mmc_web.Models;
using mikk_mmc_web.Services;
using mikk_mmc_web.ViewModels;

namespace mikk_mmc_web.Controllers
{
    public class LogController : Controller
    {
        private readonly ILogger<LogController> _logger;
        private readonly IRouterService _routerService;
        private readonly ILogService _logService;

        public LogController(
            ILogger<LogController> logger,
            IRouterService routerService,
            ILogService logService)
        {
            _logger = logger;
            _routerService = routerService;
            _logService = logService;
        }

        // Hiển thị danh sách logs
        public async Task<IActionResult> Index(string topic = "", string level = "", int maxEntries = 100)
        {
            try
            {
                // Kiểm tra kết nối
                if (!_routerService.IsConnected)
                {
                    TempData["WarningMessage"] = "Chưa kết nối tới Router. Vui lòng kết nối trước.";
                    return RedirectToAction("Settings", "Home");
                }

                // Lấy danh sách logs dựa trên bộ lọc
                List<LogEntry> logs;
                
                if (!string.IsNullOrEmpty(topic))
                {
                    logs = await _logService.GetLogsByTopicAsync(topic, maxEntries);
                    ViewBag.FilterType = "topic";
                    ViewBag.FilterValue = topic;
                }
                else if (!string.IsNullOrEmpty(level))
                {
                    logs = await _logService.GetLogsByLevelAsync(level, maxEntries);
                    ViewBag.FilterType = "level";
                    ViewBag.FilterValue = level;
                }
                else
                {
                    logs = await _logService.GetAllLogsAsync(maxEntries);
                    ViewBag.FilterType = "all";
                    ViewBag.FilterValue = "";
                }
                
                // Lấy danh sách chủ đề và mức độ để hiển thị bộ lọc
                var allLogs = await _logService.GetAllLogsAsync(1000);
                ViewBag.Topics = allLogs.Select(l => l.Topic).Distinct().OrderBy(t => t).ToList();
                ViewBag.Levels = allLogs.Select(l => l.Level).Distinct().OrderBy(l => l).ToList();
                ViewBag.MaxEntries = maxEntries;
                
                var viewModel = new LogViewModel
                {
                    Logs = logs,
                    Topic = topic,
                    Level = level,
                    StartDate = null,
                    EndDate = null
                };
                
                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi hiển thị danh sách logs");
                TempData["ErrorMessage"] = $"Lỗi: {ex.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        // Xem logs theo khoảng thời gian
        public async Task<IActionResult> DateRange(DateTime? startDate = null, DateTime? endDate = null, int maxEntries = 100)
        {
            try
            {
                // Kiểm tra kết nối
                if (!_routerService.IsConnected)
                {
                    TempData["WarningMessage"] = "Chưa kết nối tới Router. Vui lòng kết nối trước.";
                    return RedirectToAction("Settings", "Home");
                }

                // Mặc định nếu không cung cấp khoảng thời gian
                var start = startDate ?? DateTime.Now.AddDays(-1);
                var end = endDate ?? DateTime.Now;
                
                // Lấy logs theo khoảng thời gian
                var logs = await _logService.GetLogsByDateRangeAsync(start, end, maxEntries);
                
                var viewModel = new LogViewModel
                {
                    Logs = logs,
                    Topic = "",
                    Level = "",
                    StartDate = start,
                    EndDate = end
                };
                
                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi hiển thị logs theo khoảng thời gian");
                TempData["ErrorMessage"] = $"Lỗi: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // Xóa tất cả logs
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClearLogs()
        {
            try
            {
                // Kiểm tra kết nối
                if (!_routerService.IsConnected)
                {
                    TempData["WarningMessage"] = "Chưa kết nối tới Router. Vui lòng kết nối trước.";
                    return RedirectToAction("Settings", "Home");
                }

                bool success = await _logService.ClearLogsAsync();
                
                if (success)
                {
                    _logger.LogInformation("Xóa tất cả logs thành công");
                    TempData["SuccessMessage"] = "Đã xóa tất cả logs thành công";
                }
                else
                {
                    _logger.LogWarning("Xóa tất cả logs thất bại");
                    TempData["ErrorMessage"] = "Không thể xóa logs";
                }
                
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi xóa tất cả logs");
                TempData["ErrorMessage"] = $"Lỗi: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // Xuất logs
        public async Task<IActionResult> Export(string filename = "")
        {
            try
            {
                // Kiểm tra kết nối
                if (!_routerService.IsConnected)
                {
                    TempData["WarningMessage"] = "Chưa kết nối tới Router. Vui lòng kết nối trước.";
                    return RedirectToAction("Settings", "Home");
                }

                // Nếu không cung cấp tên file, tạo một tên mặc định
                if (string.IsNullOrEmpty(filename))
                {
                    filename = $"mikrotik_logs_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                }
                
                bool success = await _logService.ExportLogsAsync(filename);
                
                if (success)
                {
                    _logger.LogInformation($"Xuất logs ra file {filename} thành công");
                    TempData["SuccessMessage"] = $"Đã xuất logs ra file {filename} thành công";
                }
                else
                {
                    _logger.LogWarning($"Xuất logs ra file {filename} thất bại");
                    TempData["ErrorMessage"] = $"Không thể xuất logs ra file {filename}";
                }
                
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi xuất logs");
                TempData["ErrorMessage"] = $"Lỗi: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // API để lấy tất cả logs
        [HttpGet]
        [Route("api/logs")]
        public async Task<IActionResult> GetAllLogs(int maxEntries = 100)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                var logs = await _logService.GetAllLogsAsync(maxEntries);
                return Json(logs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy tất cả logs qua API");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // API để lấy logs theo chủ đề
        [HttpGet]
        [Route("api/logs/topic/{topic}")]
        public async Task<IActionResult> GetLogsByTopic(string topic, int maxEntries = 100)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                if (string.IsNullOrEmpty(topic))
                {
                    return BadRequest(new { error = "Chủ đề không được để trống" });
                }

                var logs = await _logService.GetLogsByTopicAsync(topic, maxEntries);
                return Json(logs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi lấy logs theo chủ đề {topic} qua API");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // API để lấy logs theo mức độ
        [HttpGet]
        [Route("api/logs/level/{level}")]
        public async Task<IActionResult> GetLogsByLevel(string level, int maxEntries = 100)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                if (string.IsNullOrEmpty(level))
                {
                    return BadRequest(new { error = "Mức độ không được để trống" });
                }

                var logs = await _logService.GetLogsByLevelAsync(level, maxEntries);
                return Json(logs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi lấy logs theo mức độ {level} qua API");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // API để lấy logs theo khoảng thời gian
        [HttpGet]
        [Route("api/logs/date-range")]
        public async Task<IActionResult> GetLogsByDateRange(
            [FromQuery] DateTime? startDate = null, 
            [FromQuery] DateTime? endDate = null, 
            [FromQuery] int maxEntries = 100)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                // Mặc định nếu không cung cấp khoảng thời gian
                var start = startDate ?? DateTime.Now.AddDays(-1);
                var end = endDate ?? DateTime.Now;

                var logs = await _logService.GetLogsByDateRangeAsync(start, end, maxEntries);
                return Json(logs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy logs theo khoảng thời gian qua API");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // API để xóa tất cả logs
        [HttpDelete]
        [Route("api/logs")]
        public async Task<IActionResult> ClearLogsApi()
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                bool success = await _logService.ClearLogsAsync();
                
                if (success)
                {
                    _logger.LogInformation("Xóa tất cả logs thành công qua API");
                    return Json(new { success = true, message = "Đã xóa tất cả logs thành công" });
                }
                else
                {
                    _logger.LogWarning("Xóa tất cả logs thất bại qua API");
                    return StatusCode(500, new { error = "Không thể xóa logs" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi xóa tất cả logs qua API");
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
