using System;

namespace mikk_mmc_web.Models
{
    public class TrafficData
    {
        public DateTime Timestamp { get; set; }
        public long RxBytes { get; set; }
        public long TxBytes { get; set; }
    }
}
