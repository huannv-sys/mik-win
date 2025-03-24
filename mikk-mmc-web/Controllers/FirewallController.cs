using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mikk_mmc_web.Models;
using mikk_mmc_web.Services;

namespace mikk_mmc_web.Controllers
{
    public class FirewallController : Controller
    {
        private readonly ILogger<FirewallController> _logger;
        private readonly IRouterService _routerService;
        private readonly IFirewallService _firewallService;

        public FirewallController(
            ILogger<FirewallController> logger,
            IRouterService routerService,
            IFirewallService firewallService)
        {
            _logger = logger;
            _routerService = routerService;
            _firewallService = firewallService;
        }

        // Hiển thị danh sách luật tường lửa
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

                // Lấy danh sách luật tường lửa
                var rules = await _firewallService.GetAllRulesAsync();
                return View(rules);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi hiển thị danh sách luật tường lửa");
                TempData["ErrorMessage"] = $"Lỗi: {ex.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        // Hiển thị chi tiết luật tường lửa
        public async Task<IActionResult> Details(string id)
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
                if (string.IsNullOrEmpty(id))
                {
                    return RedirectToAction(nameof(Index));
                }

                // Lấy thông tin luật tường lửa
                var rule = await _firewallService.GetRuleByIdAsync(id);
                return View(rule);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi hiển thị chi tiết luật tường lửa ID {id}");
                TempData["ErrorMessage"] = $"Lỗi: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // Hiển thị form tạo luật tường lửa mới
        public IActionResult Create()
        {
            // Kiểm tra kết nối
            if (!_routerService.IsConnected)
            {
                TempData["WarningMessage"] = "Chưa kết nối tới Router. Vui lòng kết nối trước.";
                return RedirectToAction("Settings", "Home");
            }

            // Khởi tạo một mẫu trống
            var rule = new FirewallRule
            {
                Chain = "forward",
                Action = "accept",
                Protocol = "tcp",
                SrcAddress = "0.0.0.0/0",
                DstAddress = "0.0.0.0/0",
                Disabled = false
            };

            return View(rule);
        }

        // Xử lý tạo luật tường lửa mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FirewallRule rule)
        {
            try
            {
                // Kiểm tra kết nối
                if (!_routerService.IsConnected)
                {
                    TempData["WarningMessage"] = "Chưa kết nối tới Router. Vui lòng kết nối trước.";
                    return RedirectToAction("Settings", "Home");
                }

                if (ModelState.IsValid)
                {
                    bool success = await _firewallService.CreateRuleAsync(rule);
                    
                    if (success)
                    {
                        _logger.LogInformation("Tạo luật tường lửa mới thành công");
                        TempData["SuccessMessage"] = "Đã tạo luật tường lửa mới thành công";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        _logger.LogWarning("Tạo luật tường lửa mới thất bại");
                        ModelState.AddModelError("", "Không thể tạo luật tường lửa mới");
                    }
                }
                
                return View(rule);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi tạo luật tường lửa mới");
                ModelState.AddModelError("", $"Lỗi: {ex.Message}");
                return View(rule);
            }
        }

        // Hiển thị form chỉnh sửa luật tường lửa
        public async Task<IActionResult> Edit(string id)
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
                if (string.IsNullOrEmpty(id))
                {
                    return RedirectToAction(nameof(Index));
                }

                // Lấy thông tin luật tường lửa
                var rule = await _firewallService.GetRuleByIdAsync(id);
                return View(rule);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi hiển thị form chỉnh sửa luật tường lửa ID {id}");
                TempData["ErrorMessage"] = $"Lỗi: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // Xử lý chỉnh sửa luật tường lửa
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FirewallRule rule)
        {
            try
            {
                // Kiểm tra kết nối
                if (!_routerService.IsConnected)
                {
                    TempData["WarningMessage"] = "Chưa kết nối tới Router. Vui lòng kết nối trước.";
                    return RedirectToAction("Settings", "Home");
                }

                if (ModelState.IsValid)
                {
                    bool success = await _firewallService.UpdateRuleAsync(rule);
                    
                    if (success)
                    {
                        _logger.LogInformation($"Cập nhật luật tường lửa ID {rule.Id} thành công");
                        TempData["SuccessMessage"] = "Đã cập nhật luật tường lửa thành công";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        _logger.LogWarning($"Cập nhật luật tường lửa ID {rule.Id} thất bại");
                        ModelState.AddModelError("", "Không thể cập nhật luật tường lửa");
                    }
                }
                
                return View(rule);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi cập nhật luật tường lửa ID {rule.Id}");
                ModelState.AddModelError("", $"Lỗi: {ex.Message}");
                return View(rule);
            }
        }

        // API để lấy danh sách luật tường lửa
        [HttpGet]
        [Route("api/firewall/rules")]
        public async Task<IActionResult> GetAllRules()
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                var rules = await _firewallService.GetAllRulesAsync();
                return Json(rules);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách luật tường lửa qua API");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // API để lấy chi tiết luật tường lửa
        [HttpGet]
        [Route("api/firewall/rules/{id}")]
        public async Task<IActionResult> GetRuleById(string id)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest(new { error = "ID luật tường lửa không được để trống" });
                }

                var rule = await _firewallService.GetRuleByIdAsync(id);
                return Json(rule);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi lấy chi tiết luật tường lửa ID {id} qua API");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // API để bật luật tường lửa
        [HttpPost]
        [Route("api/firewall/rules/{id}/enable")]
        public async Task<IActionResult> EnableRule(string id)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest(new { error = "ID luật tường lửa không được để trống" });
                }

                bool success = await _firewallService.EnableRuleAsync(id);
                
                if (success)
                {
                    _logger.LogInformation($"Bật luật tường lửa ID {id} thành công");
                    return Json(new { success = true, message = $"Đã bật luật tường lửa ID {id}" });
                }
                else
                {
                    _logger.LogWarning($"Bật luật tường lửa ID {id} thất bại");
                    return StatusCode(500, new { error = $"Không thể bật luật tường lửa ID {id}" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi bật luật tường lửa ID {id}");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // API để tắt luật tường lửa
        [HttpPost]
        [Route("api/firewall/rules/{id}/disable")]
        public async Task<IActionResult> DisableRule(string id)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest(new { error = "ID luật tường lửa không được để trống" });
                }

                bool success = await _firewallService.DisableRuleAsync(id);
                
                if (success)
                {
                    _logger.LogInformation($"Tắt luật tường lửa ID {id} thành công");
                    return Json(new { success = true, message = $"Đã tắt luật tường lửa ID {id}" });
                }
                else
                {
                    _logger.LogWarning($"Tắt luật tường lửa ID {id} thất bại");
                    return StatusCode(500, new { error = $"Không thể tắt luật tường lửa ID {id}" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi tắt luật tường lửa ID {id}");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // API để di chuyển luật tường lửa lên trên
        [HttpPost]
        [Route("api/firewall/rules/{id}/move-up")]
        public async Task<IActionResult> MoveRuleUp(string id)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest(new { error = "ID luật tường lửa không được để trống" });
                }

                bool success = await _firewallService.MoveRuleUpAsync(id);
                
                if (success)
                {
                    _logger.LogInformation($"Di chuyển luật tường lửa ID {id} lên trên thành công");
                    return Json(new { success = true, message = $"Đã di chuyển luật tường lửa ID {id} lên trên" });
                }
                else
                {
                    _logger.LogWarning($"Di chuyển luật tường lửa ID {id} lên trên thất bại");
                    return StatusCode(500, new { error = $"Không thể di chuyển luật tường lửa ID {id} lên trên" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi di chuyển luật tường lửa ID {id} lên trên");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // API để di chuyển luật tường lửa xuống dưới
        [HttpPost]
        [Route("api/firewall/rules/{id}/move-down")]
        public async Task<IActionResult> MoveRuleDown(string id)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest(new { error = "ID luật tường lửa không được để trống" });
                }

                bool success = await _firewallService.MoveRuleDownAsync(id);
                
                if (success)
                {
                    _logger.LogInformation($"Di chuyển luật tường lửa ID {id} xuống dưới thành công");
                    return Json(new { success = true, message = $"Đã di chuyển luật tường lửa ID {id} xuống dưới" });
                }
                else
                {
                    _logger.LogWarning($"Di chuyển luật tường lửa ID {id} xuống dưới thất bại");
                    return StatusCode(500, new { error = $"Không thể di chuyển luật tường lửa ID {id} xuống dưới" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi di chuyển luật tường lửa ID {id} xuống dưới");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // API để xóa luật tường lửa
        [HttpDelete]
        [Route("api/firewall/rules/{id}")]
        public async Task<IActionResult> DeleteRule(string id)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest(new { error = "ID luật tường lửa không được để trống" });
                }

                bool success = await _firewallService.DeleteRuleAsync(id);
                
                if (success)
                {
                    _logger.LogInformation($"Xóa luật tường lửa ID {id} thành công");
                    return Json(new { success = true, message = $"Đã xóa luật tường lửa ID {id}" });
                }
                else
                {
                    _logger.LogWarning($"Xóa luật tường lửa ID {id} thất bại");
                    return StatusCode(500, new { error = $"Không thể xóa luật tường lửa ID {id}" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi xóa luật tường lửa ID {id}");
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
