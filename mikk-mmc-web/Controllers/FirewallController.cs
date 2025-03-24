using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mikk_mmc_web.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace mikk_mmc_web.Controllers
{
    public class FirewallController : Controller
    {
        private readonly ILogger<FirewallController> _logger;
        private readonly IFirewallService _firewallService;
        private readonly IRouterService _routerService;

        public FirewallController(
            ILogger<FirewallController> logger,
            IFirewallService firewallService,
            IRouterService routerService)
        {
            _logger = logger;
            _firewallService = firewallService;
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

                var rules = await _firewallService.GetFirewallRulesAsync();
                
                // Nhóm theo chain để hiển thị
                var groupedRules = rules
                    .GroupBy(r => r.Chain)
                    .Select(g => new {
                        Chain = g.Key,
                        Rules = g.ToList()
                    })
                    .ToList();
                
                ViewBag.GroupedRules = groupedRules;
                
                return View(rules);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách luật tường lửa");
                ViewBag.ErrorMessage = "Có lỗi xảy ra khi tải danh sách luật tường lửa. Chi tiết: " + ex.Message;
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
                    return BadRequest("ID luật tường lửa không được để trống");
                }

                var rule = await _firewallService.GetFirewallRuleByIdAsync(id);
                if (rule == null)
                {
                    return NotFound($"Không tìm thấy luật tường lửa với ID '{id}'");
                }

                return View(rule);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy thông tin luật tường lửa {Id}", id);
                ViewBag.ErrorMessage = "Có lỗi xảy ra khi tải thông tin luật tường lửa. Chi tiết: " + ex.Message;
                return View("Error");
            }
        }
    }
}
