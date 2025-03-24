using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mikk_mmc_web.Models;
using mikk_mmc_web.Services;

namespace mikk_mmc_web.Controllers
{
    public class InterfaceController : Controller
    {
        private readonly ILogger<InterfaceController> _logger;
        private readonly IRouterService _routerService;
        private readonly IInterfaceService _interfaceService;

        public InterfaceController(
            ILogger<InterfaceController> logger,
            IRouterService routerService,
            IInterfaceService interfaceService)
        {
            _logger = logger;
            _routerService = routerService;
            _interfaceService = interfaceService;
        }

        // Hiển thị danh sách giao diện mạng
        public async Task<IActionResult> Index()
        {
            try
            {
                // Kiểm tra kết nối
                if (!_routerService.IsConnected)
                {
                    TempData["WarningMessage"] = "Chưa kết nối tới Router. Vui lòng kết nối trước.";
                    return RedirectToAction("Settings", "Home");
                }

                // Lấy danh sách giao diện mạng
                var interfaces = await _interfaceService.GetAllInterfacesAsync();
                return View(interfaces);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi hiển thị danh sách giao diện mạng");
                TempData["ErrorMessage"] = $"Lỗi: {ex.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        // Hiển thị chi tiết giao diện mạng
        public async Task<IActionResult> Details(string name)
        {
            try
            {
                // Kiểm tra kết nối
                if (!_routerService.IsConnected)
                {
                    TempData["WarningMessage"] = "Chưa kết nối tới Router. Vui lòng kết nối trước.";
                    return RedirectToAction("Settings", "Home");
                }

                // Kiểm tra tham số đầu vào
                if (string.IsNullOrEmpty(name))
                {
                    return RedirectToAction(nameof(Index));
                }

                // Lấy thông tin giao diện mạng
                var networkInterface = await _interfaceService.GetInterfaceByNameAsync(name);
                
                // Lấy lịch sử lưu lượng gần đây (24 giờ qua)
                var endTime = DateTime.Now;
                var startTime = endTime.AddHours(-24);
                var trafficHistory = await _interfaceService.GetTrafficHistoryAsync(name, startTime, endTime);
                
                // Tạo model
                var viewModel = new InterfaceDetailsViewModel
                {
                    Interface = networkInterface,
                    TrafficHistory = trafficHistory
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi hiển thị chi tiết giao diện mạng {name}");
                TempData["ErrorMessage"] = $"Lỗi: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // API để lấy danh sách giao diện mạng
        [HttpGet]
        [Route("api/interfaces")]
        public async Task<IActionResult> GetAllInterfaces()
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                var interfaces = await _interfaceService.GetAllInterfacesAsync();
                return Json(interfaces);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách giao diện mạng qua API");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // API để lấy chi tiết giao diện mạng
        [HttpGet]
        [Route("api/interfaces/{name}")]
        public async Task<IActionResult> GetInterfaceByName(string name)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest(new { error = "Tên giao diện mạng không được để trống" });
                }

                var networkInterface = await _interfaceService.GetInterfaceByNameAsync(name);
                return Json(networkInterface);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi lấy chi tiết giao diện mạng {name} qua API");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // API để lấy lịch sử lưu lượng
        [HttpGet]
        [Route("api/interfaces/{name}/traffic")]
        public async Task<IActionResult> GetTrafficHistory(string name, DateTime? start, DateTime? end)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest(new { error = "Tên giao diện mạng không được để trống" });
                }

                // Mặc định lấy dữ liệu 24 giờ qua nếu không có tham số
                var endTime = end ?? DateTime.Now;
                var startTime = start ?? endTime.AddHours(-24);

                var trafficHistory = await _interfaceService.GetTrafficHistoryAsync(name, startTime, endTime);
                return Json(trafficHistory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi lấy lịch sử lưu lượng giao diện mạng {name} qua API");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // API để bật giao diện mạng
        [HttpPost]
        [Route("api/interfaces/{name}/enable")]
        public async Task<IActionResult> EnableInterface(string name)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest(new { error = "Tên giao diện mạng không được để trống" });
                }

                bool success = await _interfaceService.EnableInterfaceAsync(name);
                
                if (success)
                {
                    _logger.LogInformation($"Bật giao diện mạng {name} thành công");
                    return Json(new { success = true, message = $"Đã bật giao diện mạng {name}" });
                }
                else
                {
                    _logger.LogWarning($"Bật giao diện mạng {name} thất bại");
                    return StatusCode(500, new { error = $"Không thể bật giao diện mạng {name}" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi bật giao diện mạng {name}");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // API để tắt giao diện mạng
        [HttpPost]
        [Route("api/interfaces/{name}/disable")]
        public async Task<IActionResult> DisableInterface(string name)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest(new { error = "Tên giao diện mạng không được để trống" });
                }

                bool success = await _interfaceService.DisableInterfaceAsync(name);
                
                if (success)
                {
                    _logger.LogInformation($"Tắt giao diện mạng {name} thành công");
                    return Json(new { success = true, message = $"Đã tắt giao diện mạng {name}" });
                }
                else
                {
                    _logger.LogWarning($"Tắt giao diện mạng {name} thất bại");
                    return StatusCode(500, new { error = $"Không thể tắt giao diện mạng {name}" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi tắt giao diện mạng {name}");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // API để đặt lại bộ đếm
        [HttpPost]
        [Route("api/interfaces/{name}/reset-counters")]
        public async Task<IActionResult> ResetInterfaceCounters(string name)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest(new { error = "Tên giao diện mạng không được để trống" });
                }

                bool success = await _interfaceService.ResetInterfaceCountersAsync(name);
                
                if (success)
                {
                    _logger.LogInformation($"Đặt lại bộ đếm giao diện mạng {name} thành công");
                    return Json(new { success = true, message = $"Đã đặt lại bộ đếm giao diện mạng {name}" });
                }
                else
                {
                    _logger.LogWarning($"Đặt lại bộ đếm giao diện mạng {name} thất bại");
                    return StatusCode(500, new { error = $"Không thể đặt lại bộ đếm giao diện mạng {name}" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi đặt lại bộ đếm giao diện mạng {name}");
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }

    public class InterfaceDetailsViewModel
    {
        public NetworkInterface Interface { get; set; }
        public List<TrafficData> TrafficHistory { get; set; }
    }
}
