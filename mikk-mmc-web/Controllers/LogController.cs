using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mikk_mmc_web.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace mikk_mmc_web.Controllers
{
    public class LogController : Controller
    {
        private readonly ILogger<LogController> _logger;
        private readonly ILogService _logService;
        private readonly IRouterService _routerService;

        public LogController(
            ILogger<LogController> logger,
            ILogService logService,
            IRouterService routerService)
        {
            _logger = logger;
            _logService = logService;
            _routerService = routerService;
        }

        public async Task<IActionResult> Index(int limit = 100)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return View("NotConnected");
                }

                var logs = await _logService.GetLogsAsync(limit);
                
                // Phân loại logs theo mức độ để hiển thị
                ViewBag.InfoLogs = logs.Where(l => l.Level.Equals("info", StringComparison.OrdinalIgnoreCase)).ToList();
                ViewBag.WarningLogs = logs.Where(l => l.Level.Equals("warning", StringComparison.OrdinalIgnoreCase)).ToList();
                ViewBag.ErrorLogs = logs.Where(l => l.Level.Equals("error", StringComparison.OrdinalIgnoreCase)).ToList();
                
                // Lấy danh sách các topics duy nhất
                ViewBag.Topics = logs
                    .Select(l => l.Topics)
                    .Distinct()
                    .OrderBy(t => t)
                    .ToList();
                
                return View(logs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách nhật ký");
                ViewBag.ErrorMessage = "Có lỗi xảy ra khi tải danh sách nhật ký. Chi tiết: " + ex.Message;
                return View("Error");
            }
        }

        public async Task<IActionResult> Details(string id)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return View("NotConnected");
                }

                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest("ID nhật ký không được để trống");
                }

                var log = await _logService.GetLogByIdAsync(id);
                if (log == null)
                {
                    return NotFound($"Không tìm thấy nhật ký với ID '{id}'");
                }

                return View(log);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy thông tin nhật ký {Id}", id);
                ViewBag.ErrorMessage = "Có lỗi xảy ra khi tải thông tin nhật ký. Chi tiết: " + ex.Message;
                return View("Error");
            }
        }
    }
}
