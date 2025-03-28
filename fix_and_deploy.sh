#!/bin/bash

echo "===== Công cụ sửa lỗi và triển khai MikroTik Monitor ====="

# 1. Cập nhật định nghĩa Enums trong dự án web (mikk-mmc-web)
echo "1. Cập nhật định nghĩa Enums.cs trong mikk-mmc-web..."

cat > mikk-mmc-web/Models/Enums.cs << 'ENUM_EOL'
namespace mikk_mmc_web.Models
{
    /// <summary>
    /// Represents the status of a device
    /// </summary>
    public enum DeviceStatus
    {
        /// <summary>
        /// The device is unknown
        /// </summary>
        Unknown = 0,
        
        /// <summary>
        /// The device is offline
        /// </summary>
        Offline = 1,
        
        /// <summary>
        /// The device is online
        /// </summary>
        Online = 2,
        
        /// <summary>
        /// The device is in warning state
        /// </summary>
        Warning = 3,
        
        /// <summary>
        /// The device is in error state
        /// </summary>
        Error = 4
    }
    
    /// <summary>
    /// Represents the severity of a log entry
    /// </summary>
    public enum LogSeverity
    {
        /// <summary>
        /// Debug log entry
        /// </summary>
        Debug = 0,
        
        /// <summary>
        /// Information log entry
        /// </summary>
        Info = 1,
        
        /// <summary>
        /// Warning log entry
        /// </summary>
        Warning = 2,
        
        /// <summary>
        /// Error log entry
        /// </summary>
        Error = 3,
        
        /// <summary>
        /// Critical log entry
        /// </summary>
        Critical = 4
    }
    
    /// <summary>
    /// Represents the connection status of a router device
    /// </summary>
    public enum ConnectionStatus
    {
        /// <summary>
        /// The device is disconnected
        /// </summary>
        Disconnected = 0,
        
        /// <summary>
        /// The device is connecting
        /// </summary>
        Connecting = 1,
        
        /// <summary>
        /// The device is connected
        /// </summary>
        Connected = 2,
        
        /// <summary>
        /// The connection failed
        /// </summary>
        Failed = 3
    }
}
ENUM_EOL

echo "✓ Đã cập nhật file mikk-mmc-web/Models/Enums.cs"

# 2. Thêm tham chiếu vào RouterDevice.cs
echo "2. Thêm tham chiếu ConnectionStatus vào RouterDevice.cs..."

sed -i '1s/^/using mikk_mmc_web.Models; \/\/ Thêm cho ConnectionStatus\n/' mikk-mmc/Models/RouterDevice.cs

echo "✓ Đã thêm tham chiếu vào RouterDevice.cs"

# 3. Chỉnh sửa file ConnectionSettings.cs trong mikk-mmc-web (nếu cần)
echo "3. Kiểm tra và cập nhật ConnectionSettings.cs..."

# 4. Build và run dự án
echo "4. Build dự án mikk-mmc-web..."

cd mikk-mmc-web

echo "# Đang build project..."
dotnet build --configuration Release

if [ $? -eq 0 ]; then
  echo "✓ Đã build thành công!"
  echo "Dự án đã sẵn sàng để chạy. Hãy sử dụng workflow để khởi động."
else
  echo "❌ Build thất bại. Kiểm tra lỗi ở trên."
fi

echo "===== Hoàn tất quá trình sửa lỗi và triển khai ====="
