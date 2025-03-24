using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mikk_mmc_web.Models;
using Microsoft.Extensions.Logging;

namespace mikk_mmc_web.Services.Demo
{
    // Triển khai Demo Interface Service
    public class InterfaceServiceDemo : IInterfaceService
    {
        private readonly ILogger<InterfaceServiceDemo> _logger;

        public InterfaceServiceDemo(ILogger<InterfaceServiceDemo> logger)
        {
            _logger = logger;
        }

        public async Task<List<NetworkInterface>> GetAllInterfacesAsync()
        {
            _logger.LogInformation("Getting network interfaces");
            await Task.Delay(800); // Mô phỏng độ trễ
            
            // Dữ liệu mẫu
            return new List<NetworkInterface>
            {
                new NetworkInterface {
                    Name = "ether1", 
                    Type = "Ethernet", 
                    Status = "up", 
                    MacAddress = "00:0C:29:AB:CD:EF", 
                    IpAddress = "192.168.1.1/24", 
                    Speed = "1Gbps", 
                    TxRx = "15.2 MB / 45.6 MB"
                },
                new NetworkInterface {
                    Name = "ether2", 
                    Type = "Ethernet", 
                    Status = "up", 
                    MacAddress = "00:0C:29:AB:CD:F0", 
                    IpAddress = "10.0.0.1/24", 
                    Speed = "1Gbps", 
                    TxRx = "5.1 MB / 12.3 MB"
                },
                new NetworkInterface {
                    Name = "wlan1", 
                    Type = "Wireless", 
                    Status = "up", 
                    MacAddress = "00:0C:29:AB:CD:F1", 
                    IpAddress = "172.16.0.1/24", 
                    Speed = "300Mbps", 
                    TxRx = "42.1 MB / 78.5 MB"
                },
                new NetworkInterface {
                    Name = "bridge1", 
                    Type = "Bridge", 
                    Status = "up", 
                    MacAddress = "00:0C:29:AB:CD:F2", 
                    IpAddress = "192.168.10.1/24", 
                    Speed = "-", 
                    TxRx = "10.5 MB / 25.1 MB"
                },
                new NetworkInterface {
                    Name = "vpn-out1", 
                    Type = "OVPN Client", 
                    Status = "down", 
                    MacAddress = "-", 
                    IpAddress = "-", 
                    Speed = "-", 
                    TxRx = "0B / 0B"
                }
            };
        }

        public async Task<NetworkInterface> GetInterfaceByNameAsync(string name)
        {
            _logger.LogInformation($"Getting interface details for {name}");
            var interfaces = await GetAllInterfacesAsync();
            return interfaces.Find(i => i.Name == name) ?? new NetworkInterface { Name = name, Status = "not found" };
        }

        public async Task<bool> EnableInterfaceAsync(string name)
        {
            _logger.LogInformation($"Enabling interface {name}");
            await Task.Delay(1000);
            return true;
        }

        public async Task<bool> DisableInterfaceAsync(string name)
        {
            _logger.LogInformation($"Disabling interface {name}");
            await Task.Delay(1000);
            return true;
        }

        public async Task<List<TrafficData>> GetTrafficHistoryAsync(string interfaceName, DateTime startTime, DateTime endTime)
        {
            _logger.LogInformation($"Getting traffic history for {interfaceName}");
            await Task.Delay(1500);
            
            // Mô phỏng dữ liệu lưu lượng
            var result = new List<TrafficData>();
            var rnd = new Random();
            var interval = (endTime - startTime).TotalMinutes / 30;
            
            for (int i = 0; i < 30; i++)
            {
                result.Add(new TrafficData
                {
                    Timestamp = startTime.AddMinutes(interval * i),
                    RxBytes = rnd.Next(10000, 1000000),
                    TxBytes = rnd.Next(5000, 500000)
                });
            }
            
            return result;
        }

        public async Task<bool> ResetInterfaceCountersAsync(string name)
        {
            _logger.LogInformation($"Resetting counters for interface {name}");
            await Task.Delay(800);
            return true;
        }
    }
}
