using mikk_mmc_web.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mikk_mmc_web.Services.Demo
{
    public class DhcpServiceDemo : IDhcpService
    {
        private readonly ILogger<DhcpServiceDemo> _logger;
        private readonly List<DhcpLease> _leases = new();
        private readonly Random _random = new Random();

        public DhcpServiceDemo(ILogger<DhcpServiceDemo> logger)
        {
            _logger = logger;
            InitializeDhcpLeases();
        }

        private void InitializeDhcpLeases()
        {
            _leases.Add(new DhcpLease
            {
                Id = "1",
                Address = "192.168.1.100",
                MacAddress = "00:11:22:33:44:55",
                ClientId = "1:00:11:22:33:44:55",
                HostName = "admin-pc",
                Comment = "Admin workstation",
                Dynamic = false,
                ExpiresAt = DateTime.Now.AddDays(7),
                Active = true
            });

            _leases.Add(new DhcpLease
            {
                Id = "2",
                Address = "192.168.1.101",
                MacAddress = "AA:BB:CC:11:22:33",
                ClientId = "1:AA:BB:CC:11:22:33",
                HostName = "employee1-laptop",
                Comment = "Employee 1",
                Dynamic = true,
                ExpiresAt = DateTime.Now.AddHours(22),
                Active = true
            });

            _leases.Add(new DhcpLease
            {
                Id = "3",
                Address = "192.168.1.102",
                MacAddress = "AA:BB:CC:44:55:66",
                ClientId = "1:AA:BB:CC:44:55:66",
                HostName = "employee2-laptop",
                Comment = "Employee 2",
                Dynamic = true,
                ExpiresAt = DateTime.Now.AddHours(18),
                Active = true
            });

            _leases.Add(new DhcpLease
            {
                Id = "4",
                Address = "192.168.1.110",
                MacAddress = "11:22:33:44:55:66",
                ClientId = "1:11:22:33:44:55:66",
                HostName = "printer",
                Comment = "Office printer",
                Dynamic = false,
                ExpiresAt = DateTime.Now.AddDays(30),
                Active = true
            });

            _leases.Add(new DhcpLease
            {
                Id = "5",
                Address = "192.168.1.150",
                MacAddress = "BB:CC:DD:EE:FF:AA",
                ClientId = "1:BB:CC:DD:EE:FF:AA",
                HostName = "guest-phone",
                Comment = "Guest phone",
                Dynamic = true,
                ExpiresAt = DateTime.Now.AddHours(6),
                Active = true
            });

            _leases.Add(new DhcpLease
            {
                Id = "6",
                Address = "192.168.1.151",
                MacAddress = "CC:DD:EE:FF:AA:BB",
                ClientId = "1:CC:DD:EE:FF:AA:BB",
                HostName = "guest-tablet",
                Comment = "Guest tablet",
                Dynamic = true,
                ExpiresAt = DateTime.Now.AddHours(5),
                Active = true
            });

            _leases.Add(new DhcpLease
            {
                Id = "7",
                Address = "192.168.1.120",
                MacAddress = "DD:EE:FF:AA:BB:CC",
                ClientId = "1:DD:EE:FF:AA:BB:CC",
                HostName = "smart-tv",
                Comment = "Meeting room TV",
                Dynamic = false,
                ExpiresAt = DateTime.Now.AddDays(14),
                Active = true
            });

            _leases.Add(new DhcpLease
            {
                Id = "8",
                Address = "192.168.1.130",
                MacAddress = "EE:FF:AA:BB:CC:DD",
                ClientId = "1:EE:FF:AA:BB:CC:DD",
                HostName = "network-camera",
                Comment = "IP Camera",
                Dynamic = false,
                ExpiresAt = DateTime.Now.AddDays(14),
                Active = true
            });

            _leases.Add(new DhcpLease
            {
                Id = "9",
                Address = "192.168.1.155",
                MacAddress = "FF:AA:BB:CC:DD:EE",
                ClientId = "1:FF:AA:BB:CC:DD:EE",
                HostName = "old-pc",
                Comment = "Legacy computer",
                Dynamic = true,
                ExpiresAt = DateTime.Now.AddDays(-2),
                Active = false
            });
        }

        public async Task<IEnumerable<DhcpLease>> GetDhcpLeasesAsync()
        {
            _logger.LogInformation("Đang lấy danh sách DHCP lease...");
            
            // Giả lập thời gian phản hồi
            await Task.Delay(200);
            
            // Thỉnh thoảng cập nhật trạng thái cho các lease động
            foreach (var lease in _leases.Where(l => l.Dynamic))
            {
                if (lease.ExpiresAt < DateTime.Now)
                {
                    lease.Active = false;
                }
                else if (!lease.Active && _random.Next(0, 10) > 8)  // 10% cơ hội kích hoạt lại
                {
                    lease.Active = true;
                    lease.ExpiresAt = DateTime.Now.AddHours(_random.Next(1, 24));
                }
            }
            
            _logger.LogInformation("Đã lấy danh sách DHCP lease thành công");
            
            return _leases.OrderBy(l => l.Address);
        }

        public async Task<DhcpLease> GetDhcpLeaseByMacAsync(string macAddress)
        {
            _logger.LogInformation("Đang lấy thông tin DHCP lease cho MAC {MacAddress}...", macAddress);
            
            // Giả lập thời gian phản hồi
            await Task.Delay(100);
            
            var lease = _leases.FirstOrDefault(l => l.MacAddress.Equals(macAddress, StringComparison.OrdinalIgnoreCase));
            
            if (lease == null)
            {
                _logger.LogWarning("Không tìm thấy DHCP lease với MAC {MacAddress}", macAddress);
                return null;
            }
            
            _logger.LogInformation("Đã lấy thông tin DHCP lease với MAC {MacAddress} thành công", macAddress);
            
            return lease;
        }
    }
}
