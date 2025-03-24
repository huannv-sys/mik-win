using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mikk_mmc_web.Models;
using mikk_mmc_web.Services;

namespace mikk_mmc_web.Controllers
{
    public class DhcpController : Controller
    {
        private readonly ILogger<DhcpController> _logger;
        private readonly IRouterService _routerService;
        private readonly IDhcpService _dhcpService;

        public DhcpController(
            ILogger<DhcpController> logger,
            IRouterService routerService,
            IDhcpService dhcpService)
        {
            _logger = logger;
            _routerService = routerService;
            _dhcpService = dhcpService;
        }

        // Hiển thị danh sách DHCP leases
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

                // Lấy danh sách DHCP leases
                var leases = await _dhcpService.GetAllLeasesAsync();
                return View(leases);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi hiển thị danh sách DHCP leases");
                TempData["ErrorMessage"] = $"Lỗi: {ex.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        // Hiển thị chi tiết DHCP lease
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

                // Lấy thông tin DHCP lease
                var lease = await _dhcpService.GetLeaseByIdAsync(id);
                return View(lease);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi hiển thị chi tiết DHCP lease ID {id}");
                TempData["ErrorMessage"] = $"Lỗi: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // Hiển thị form tạo DHCP lease mới
        public IActionResult Create()
        {
            // Kiểm tra kết nối
            if (!_routerService.IsConnected)
            {
                TempData["WarningMessage"] = "Chưa kết nối tới Router. Vui lòng kết nối trước.";
                return RedirectToAction("Settings", "Home");
            }

            // Khởi tạo một mẫu trống
            var lease = new DhcpLease
            {
                Address = "192.168.1.",
                MacAddress = "00:00:00:00:00:00",
                ExpiresAfter = DateTime.Now.AddDays(1),
                Dynamic = false
            };

            return View(lease);
        }

        // Xử lý tạo DHCP lease mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DhcpLease lease)
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
                    bool success = await _dhcpService.CreateLeaseAsync(lease);
                    
                    if (success)
                    {
                        _logger.LogInformation("Tạo DHCP lease mới thành công");
                        TempData["SuccessMessage"] = "Đã tạo DHCP lease mới thành công";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        _logger.LogWarning("Tạo DHCP lease mới thất bại");
                        ModelState.AddModelError("", "Không thể tạo DHCP lease mới");
                    }
                }
                
                return View(lease);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi tạo DHCP lease mới");
                ModelState.AddModelError("", $"Lỗi: {ex.Message}");
                return View(lease);
            }
        }

        // Hiển thị form chỉnh sửa DHCP lease
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

                // Lấy thông tin DHCP lease
                var lease = await _dhcpService.GetLeaseByIdAsync(id);
                return View(lease);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi hiển thị form chỉnh sửa DHCP lease ID {id}");
                TempData["ErrorMessage"] = $"Lỗi: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // Xử lý chỉnh sửa DHCP lease
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DhcpLease lease)
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
                    bool success = await _dhcpService.UpdateLeaseAsync(lease);
                    
                    if (success)
                    {
                        _logger.LogInformation($"Cập nhật DHCP lease ID {lease.Id} thành công");
                        TempData["SuccessMessage"] = "Đã cập nhật DHCP lease thành công";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        _logger.LogWarning($"Cập nhật DHCP lease ID {lease.Id} thất bại");
                        ModelState.AddModelError("", "Không thể cập nhật DHCP lease");
                    }
                }
                
                return View(lease);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi cập nhật DHCP lease ID {lease.Id}");
                ModelState.AddModelError("", $"Lỗi: {ex.Message}");
                return View(lease);
            }
        }

        // API để lấy danh sách DHCP leases
        [HttpGet]
        [Route("api/dhcp/leases")]
        public async Task<IActionResult> GetAllLeases()
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                var leases = await _dhcpService.GetAllLeasesAsync();
                return Json(leases);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách DHCP leases qua API");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // API để lấy chi tiết DHCP lease
        [HttpGet]
        [Route("api/dhcp/leases/{id}")]
        public async Task<IActionResult> GetLeaseById(string id)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest(new { error = "ID DHCP lease không được để trống" });
                }

                var lease = await _dhcpService.GetLeaseByIdAsync(id);
                return Json(lease);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi lấy chi tiết DHCP lease ID {id} qua API");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // API để chuyển DHCP lease thành static
        [HttpPost]
        [Route("api/dhcp/leases/{id}/make-static")]
        public async Task<IActionResult> MakeStatic(string id)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest(new { error = "ID DHCP lease không được để trống" });
                }

                bool success = await _dhcpService.MakeStaticAsync(id);
                
                if (success)
                {
                    _logger.LogInformation($"Chuyển DHCP lease ID {id} thành static thành công");
                    return Json(new { success = true, message = $"Đã chuyển DHCP lease ID {id} thành static" });
                }
                else
                {
                    _logger.LogWarning($"Chuyển DHCP lease ID {id} thành static thất bại");
                    return StatusCode(500, new { error = $"Không thể chuyển DHCP lease ID {id} thành static" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi chuyển DHCP lease ID {id} thành static");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // API để chặn một client dựa trên địa chỉ MAC
        [HttpPost]
        [Route("api/dhcp/block/{macAddress}")]
        public async Task<IActionResult> BlockClient(string macAddress)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                if (string.IsNullOrEmpty(macAddress))
                {
                    return BadRequest(new { error = "Địa chỉ MAC không được để trống" });
                }

                bool success = await _dhcpService.BlockClientAsync(macAddress);
                
                if (success)
                {
                    _logger.LogInformation($"Chặn client có địa chỉ MAC {macAddress} thành công");
                    return Json(new { success = true, message = $"Đã chặn client có địa chỉ MAC {macAddress}" });
                }
                else
                {
                    _logger.LogWarning($"Chặn client có địa chỉ MAC {macAddress} thất bại");
                    return StatusCode(500, new { error = $"Không thể chặn client có địa chỉ MAC {macAddress}" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi chặn client có địa chỉ MAC {macAddress}");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // API để bỏ chặn một client dựa trên địa chỉ MAC
        [HttpPost]
        [Route("api/dhcp/unblock/{macAddress}")]
        public async Task<IActionResult> UnblockClient(string macAddress)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                if (string.IsNullOrEmpty(macAddress))
                {
                    return BadRequest(new { error = "Địa chỉ MAC không được để trống" });
                }

                bool success = await _dhcpService.UnblockClientAsync(macAddress);
                
                if (success)
                {
                    _logger.LogInformation($"Bỏ chặn client có địa chỉ MAC {macAddress} thành công");
                    return Json(new { success = true, message = $"Đã bỏ chặn client có địa chỉ MAC {macAddress}" });
                }
                else
                {
                    _logger.LogWarning($"Bỏ chặn client có địa chỉ MAC {macAddress} thất bại");
                    return StatusCode(500, new { error = $"Không thể bỏ chặn client có địa chỉ MAC {macAddress}" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi bỏ chặn client có địa chỉ MAC {macAddress}");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // API để xóa DHCP lease
        [HttpDelete]
        [Route("api/dhcp/leases/{id}")]
        public async Task<IActionResult> DeleteLease(string id)
        {
            try
            {
                if (!_routerService.IsConnected)
                {
                    return StatusCode(503, new { error = "Chưa kết nối tới Router" });
                }

                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest(new { error = "ID DHCP lease không được để trống" });
                }

                bool success = await _dhcpService.DeleteLeaseAsync(id);
                
                if (success)
                {
                    _logger.LogInformation($"Xóa DHCP lease ID {id} thành công");
                    return Json(new { success = true, message = $"Đã xóa DHCP lease ID {id}" });
                }
                else
                {
                    _logger.LogWarning($"Xóa DHCP lease ID {id} thất bại");
                    return StatusCode(500, new { error = $"Không thể xóa DHCP lease ID {id}" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi xóa DHCP lease ID {id}");
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
