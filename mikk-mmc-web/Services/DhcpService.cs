using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using mikk_mmc_web.Models;

namespace mikk_mmc_web.Services
{
    public class DhcpService : IDhcpService
    {
        private readonly ILogger<DhcpService> _logger;
        private readonly IRouterService _routerService;
        private readonly Random _random = new Random(); // Chỉ để demo trong môi trường phát triển

        // Dữ liệu mẫu cho phát triển
        private List<DhcpLease> _demoLeases = new List<DhcpLease>();

        public DhcpService(ILogger<DhcpService> logger, IRouterService routerService)
        {
            _logger = logger;
            _routerService = routerService;
            InitializeDemoLeases();
        }

        private void InitializeDemoLeases()
        {
            _demoLeases = new List<DhcpLease>
            {
                new DhcpLease
                {
                    Id = "1",
                    Address = "192.168.1.100",
                    MacAddress = "00:1A:2B:3C:4D:5E",
                    ClientId = "1:00:1a:2b:3c:4d:5e",
                    HostName = "desktop-pc",
                    Comment = "Desktop PC",
                    ExpiresAfter = DateTime.Now.AddDays(1),
                    LastSeen = DateTime.Now.AddMinutes(-5),
                    Status = "bound",
                    Dynamic = true,
                    Blocked = false
                },
                new DhcpLease
                {
                    Id = "2",
                    Address = "192.168.1.101",
                    MacAddress = "00:2C:3D:4E:5F:6G",
                    ClientId = "1:00:2c:3d:4e:5f:6g",
                    HostName = "laptop-device",
                    Comment = "Personal Laptop",
                    ExpiresAfter = DateTime.Now.AddDays(1),
                    LastSeen = DateTime.Now.AddMinutes(-10),
                    Status = "bound",
                    Dynamic = true,
                    Blocked = false
                },
                new DhcpLease
                {
                    Id = "3",
                    Address = "192.168.1.102",
                    MacAddress = "00:3D:4E:5F:6G:7H",
                    ClientId = "1:00:3d:4e:5f:6g:7h",
                    HostName = "mobile-phone",
                    Comment = "Mobile Phone",
                    ExpiresAfter = DateTime.Now.AddDays(1),
                    LastSeen = DateTime.Now.AddMinutes(-15),
                    Status = "bound",
                    Dynamic = true,
                    Blocked = false
                },
                new DhcpLease
                {
                    Id = "4",
                    Address = "192.168.1.103",
                    MacAddress = "00:4E:5F:6G:7H:8I",
                    ClientId = "1:00:4e:5f:6g:7h:8i",
                    HostName = "tablet-device",
                    Comment = "Tablet",
                    ExpiresAfter = DateTime.Now.AddDays(1),
                    LastSeen = DateTime.Now.AddMinutes(-20),
                    Status = "bound",
                    Dynamic = true,
                    Blocked = false
                },
                new DhcpLease
                {
                    Id = "5",
                    Address = "192.168.1.104",
                    MacAddress = "00:5F:6G:7H:8I:9J",
                    ClientId = "1:00:5f:6g:7h:8i:9j",
                    HostName = "smart-tv",
                    Comment = "Living Room TV",
                    ExpiresAfter = DateTime.Now.AddHours(-1),
                    LastSeen = DateTime.Now.AddHours(-1),
                    Status = "expired",
                    Dynamic = true,
                    Blocked = false
                },
                new DhcpLease
                {
                    Id = "6",
                    Address = "192.168.1.200",
                    MacAddress = "00:6G:7H:8I:9J:0K",
                    ClientId = "1:00:6g:7h:8i:9j:0k",
                    HostName = "printer",
                    Comment = "Network Printer",
                    ExpiresAfter = DateTime.Now.AddDays(7),
                    LastSeen = DateTime.Now.AddMinutes(-30),
                    Status = "bound",
                    Dynamic = false,
                    Blocked = false
                },
                new DhcpLease
                {
                    Id = "7",
                    Address = "192.168.1.201",
                    MacAddress = "00:7H:8I:9J:0K:1L",
                    ClientId = "1:00:7h:8i:9j:0k:1l",
                    HostName = "security-camera",
                    Comment = "Front Door Camera",
                    ExpiresAfter = DateTime.Now.AddDays(7),
                    LastSeen = DateTime.Now.AddMinutes(-40),
                    Status = "bound",
                    Dynamic = false,
                    Blocked = false
                },
                new DhcpLease
                {
                    Id = "8",
                    Address = "192.168.1.250",
                    MacAddress = "00:8I:9J:0K:1L:2M",
                    ClientId = "1:00:8i:9j:0k:1l:2m",
                    HostName = "unknown-device",
                    Comment = "Suspicious Device",
                    ExpiresAfter = DateTime.Now.AddDays(1),
                    LastSeen = DateTime.Now.AddHours(-2),
                    Status = "bound",
                    Dynamic = true,
                    Blocked = true
                }
            };
        }

        public async Task<List<DhcpLease>> GetAllLeasesAsync()
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể lấy danh sách DHCP lease: Chưa kết nối");
                throw new InvalidOperationException("Chưa kết nối đến Router");
            }

            try
            {
                _logger.LogInformation("Đang lấy danh sách DHCP lease");
                
                // Giả lập thời gian trễ
                await Task.Delay(1000);
                
                _logger.LogInformation($"Đã lấy {_demoLeases.Count} DHCP lease thành công");
                return _demoLeases;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi lấy danh sách DHCP lease: {ex.Message}");
                throw;
            }
        }

        public async Task<DhcpLease> GetLeaseByIdAsync(string id)
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể lấy thông tin DHCP lease: Chưa kết nối");
                throw new InvalidOperationException("Chưa kết nối đến Router");
            }

            try
            {
                _logger.LogInformation($"Đang lấy thông tin DHCP lease có ID {id}");
                
                // Giả lập thời gian trễ
                await Task.Delay(500);
                
                var lease = _demoLeases.FirstOrDefault(l => l.Id == id);
                if (lease == null)
                {
                    _logger.LogWarning($"Không tìm thấy DHCP lease có ID {id}");
                    throw new KeyNotFoundException($"Không tìm thấy DHCP lease có ID {id}");
                }
                
                _logger.LogInformation($"Đã lấy thông tin DHCP lease có ID {id} thành công");
                return lease;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi lấy thông tin DHCP lease: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> MakeStaticAsync(string id)
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể chuyển DHCP lease thành static: Chưa kết nối");
                return false;
            }

            try
            {
                _logger.LogInformation($"Đang chuyển DHCP lease có ID {id} thành static");
                
                // Giả lập thời gian xử lý
                await Task.Delay(1000);
                
                var lease = _demoLeases.FirstOrDefault(l => l.Id == id);
                if (lease == null)
                {
                    _logger.LogWarning($"Không tìm thấy DHCP lease có ID {id}");
                    return false;
                }
                
                lease.Dynamic = false;
                lease.ExpiresAfter = DateTime.Now.AddDays(7);
                
                _logger.LogInformation($"Đã chuyển DHCP lease có ID {id} thành static thành công");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi chuyển DHCP lease thành static: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteLeaseAsync(string id)
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể xóa DHCP lease: Chưa kết nối");
                return false;
            }

            try
            {
                _logger.LogInformation($"Đang xóa DHCP lease có ID {id}");
                
                // Giả lập thời gian xử lý
                await Task.Delay(800);
                
                var lease = _demoLeases.FirstOrDefault(l => l.Id == id);
                if (lease == null)
                {
                    _logger.LogWarning($"Không tìm thấy DHCP lease có ID {id}");
                    return false;
                }
                
                _demoLeases.Remove(lease);
                
                _logger.LogInformation($"Đã xóa DHCP lease có ID {id} thành công");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi xóa DHCP lease: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> CreateLeaseAsync(DhcpLease lease)
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể tạo DHCP lease: Chưa kết nối");
                return false;
            }

            try
            {
                _logger.LogInformation("Đang tạo DHCP lease mới");
                
                // Giả lập thời gian xử lý
                await Task.Delay(1200);
                
                // Gán ID mới
                lease.Id = (_demoLeases.Count + 1).ToString();
                
                _demoLeases.Add(lease);
                
                _logger.LogInformation($"Đã tạo DHCP lease mới có ID {lease.Id} thành công");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi tạo DHCP lease: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateLeaseAsync(DhcpLease lease)
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể cập nhật DHCP lease: Chưa kết nối");
                return false;
            }

            try
            {
                _logger.LogInformation($"Đang cập nhật DHCP lease có ID {lease.Id}");
                
                // Giả lập thời gian xử lý
                await Task.Delay(1000);
                
                var index = _demoLeases.FindIndex(l => l.Id == lease.Id);
                if (index < 0)
                {
                    _logger.LogWarning($"Không tìm thấy DHCP lease có ID {lease.Id}");
                    return false;
                }
                
                _demoLeases[index] = lease;
                
                _logger.LogInformation($"Đã cập nhật DHCP lease có ID {lease.Id} thành công");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi cập nhật DHCP lease: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> BlockClientAsync(string macAddress)
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể chặn client: Chưa kết nối");
                return false;
            }

            try
            {
                _logger.LogInformation($"Đang chặn client có địa chỉ MAC {macAddress}");
                
                // Giả lập thời gian xử lý
                await Task.Delay(1000);
                
                var leases = _demoLeases.Where(l => l.MacAddress.Equals(macAddress, StringComparison.OrdinalIgnoreCase)).ToList();
                if (leases.Count == 0)
                {
                    _logger.LogWarning($"Không tìm thấy lease nào có địa chỉ MAC {macAddress}");
                    return false;
                }
                
                foreach (var lease in leases)
                {
                    lease.Blocked = true;
                }
                
                _logger.LogInformation($"Đã chặn {leases.Count} clients có địa chỉ MAC {macAddress} thành công");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi chặn client: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UnblockClientAsync(string macAddress)
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể bỏ chặn client: Chưa kết nối");
                return false;
            }

            try
            {
                _logger.LogInformation($"Đang bỏ chặn client có địa chỉ MAC {macAddress}");
                
                // Giả lập thời gian xử lý
                await Task.Delay(1000);
                
                var leases = _demoLeases.Where(l => l.MacAddress.Equals(macAddress, StringComparison.OrdinalIgnoreCase)).ToList();
                if (leases.Count == 0)
                {
                    _logger.LogWarning($"Không tìm thấy lease nào có địa chỉ MAC {macAddress}");
                    return false;
                }
                
                foreach (var lease in leases)
                {
                    lease.Blocked = false;
                }
                
                _logger.LogInformation($"Đã bỏ chặn {leases.Count} clients có địa chỉ MAC {macAddress} thành công");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi bỏ chặn client: {ex.Message}");
                return false;
            }
        }
    }
}
