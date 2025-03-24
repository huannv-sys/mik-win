using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mikk_mmc_web.Models;
using Microsoft.Extensions.Logging;

namespace mikk_mmc_web.Services.Demo
{
    // Triển khai Demo DHCP Service
    public class DhcpServiceDemo : IDhcpService
    {
        private readonly ILogger<DhcpServiceDemo> _logger;
        private List<DhcpLease> _leases;

        public DhcpServiceDemo(ILogger<DhcpServiceDemo> logger)
        {
            _logger = logger;
            _leases = InitializeLeases();
        }

        private List<DhcpLease> InitializeLeases()
        {
            return new List<DhcpLease>
            {
                new DhcpLease { 
                    Id = "1",
                    IpAddress = "192.168.1.100", 
                    MacAddress = "00:1A:2B:3C:4D:5E", 
                    Hostname = "laptop-user1", 
                    Status = "active", 
                    ExpiresIn = "23h 45m" 
                },
                new DhcpLease { 
                    Id = "2",
                    IpAddress = "192.168.1.101", 
                    MacAddress = "00:1A:2B:3C:4D:5F", 
                    Hostname = "desktop-user2", 
                    Status = "active", 
                    ExpiresIn = "23h 10m" 
                },
                new DhcpLease { 
                    Id = "3",
                    IpAddress = "192.168.1.102", 
                    MacAddress = "00:1A:2B:3C:4D:60", 
                    Hostname = "phone-user1", 
                    Status = "active", 
                    ExpiresIn = "22h 30m" 
                },
                new DhcpLease { 
                    Id = "4",
                    IpAddress = "192.168.1.103", 
                    MacAddress = "00:1A:2B:3C:4D:61", 
                    Hostname = "tablet-user3", 
                    Status = "active", 
                    ExpiresIn = "21h 55m" 
                },
                new DhcpLease { 
                    Id = "5",
                    IpAddress = "192.168.1.104", 
                    MacAddress = "00:1A:2B:3C:4D:62", 
                    Hostname = "iot-device1", 
                    Status = "expired", 
                    ExpiresIn = "0h 0m" 
                }
            };
        }

        public async Task<List<DhcpLease>> GetAllLeasesAsync()
        {
            _logger.LogInformation("Getting all DHCP leases");
            await Task.Delay(700); // Mô phỏng độ trễ
            return _leases;
        }

        public async Task<DhcpLease> GetLeaseByIdAsync(string id)
        {
            _logger.LogInformation($"Getting DHCP lease with ID {id}");
            await Task.Delay(300);
            return _leases.FirstOrDefault(l => l.Id == id) ?? new DhcpLease { Id = id, Status = "not found" };
        }

        public async Task<bool> MakeStaticAsync(string id)
        {
            _logger.LogInformation($"Making lease {id} static");
            await Task.Delay(800);
            var lease = _leases.FirstOrDefault(l => l.Id == id);
            if (lease != null)
            {
                lease.Status = "static";
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteLeaseAsync(string id)
        {
            _logger.LogInformation($"Deleting DHCP lease with ID {id}");
            await Task.Delay(800);
            var lease = _leases.FirstOrDefault(l => l.Id == id);
            if (lease != null)
            {
                _leases.Remove(lease);
                return true;
            }
            return false;
        }

        public async Task<bool> CreateLeaseAsync(DhcpLease lease)
        {
            _logger.LogInformation($"Creating new DHCP lease for {lease.MacAddress}");
            await Task.Delay(1000);
            
            // Assign a new ID
            var maxId = _leases.Max(l => int.Parse(l.Id));
            lease.Id = (maxId + 1).ToString();
            _leases.Add(lease);
            
            return true;
        }

        public async Task<bool> UpdateLeaseAsync(DhcpLease lease)
        {
            _logger.LogInformation($"Updating DHCP lease with ID {lease.Id}");
            await Task.Delay(800);
            
            var existingLease = _leases.FirstOrDefault(l => l.Id == lease.Id);
            if (existingLease != null)
            {
                _leases.Remove(existingLease);
                _leases.Add(lease);
                return true;
            }
            return false;
        }

        public async Task<bool> BlockClientAsync(string macAddress)
        {
            _logger.LogInformation($"Blocking client with MAC {macAddress}");
            await Task.Delay(800);
            return true;
        }

        public async Task<bool> UnblockClientAsync(string macAddress)
        {
            _logger.LogInformation($"Unblocking client with MAC {macAddress}");
            await Task.Delay(800);
            return true;
        }
    }
}
