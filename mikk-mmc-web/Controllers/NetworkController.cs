using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mikk_mmc_web.Services;

namespace mikk_mmc_web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NetworkController : ControllerBase
    {
        private readonly IInterfaceService _interfaceService;
        private readonly ILogger<NetworkController> _logger;

        public NetworkController(IInterfaceService interfaceService, ILogger<NetworkController> logger)
        {
            _interfaceService = interfaceService;
            _logger = logger;
        }

        [HttpGet("interfaces")]
        public async Task<IActionResult> GetNetworkInterfaces()
        {
            try
            {
                var interfaces = await _interfaceService.GetNetworkInterfacesAsync();
                return Ok(interfaces);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting network interfaces");
                return StatusCode(500, "Internal server error occurred while retrieving network interfaces");
            }
        }

        [HttpGet("traffic/{interfaceName}")]
        public async Task<IActionResult> GetInterfaceTraffic(string interfaceName)
        {
            if (string.IsNullOrEmpty(interfaceName))
            {
                return BadRequest("Interface name is required");
            }

            try
            {
                var traffic = await _interfaceService.GetInterfaceTrafficAsync(interfaceName);
                return Ok(traffic);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting interface traffic");
                return StatusCode(500, "Internal server error occurred while retrieving interface traffic");
            }
        }
    }
}
