#!/bin/bash

echo "========================================"
echo "MikroTik Monitor - Ubuntu Console Edition"
echo "========================================"

UBUNTU_APP_DIR="mikk-mmc-ubuntu"

# Kiểm tra xem đã cài đặt .NET SDK chưa
if ! command -v dotnet &> /dev/null; then
    echo "Không tìm thấy .NET SDK. Vui lòng cài đặt .NET SDK 8.0 hoặc cao hơn."
    exit 1
fi

# Chuyển đến thư mục ứng dụng
cd "$UBUNTU_APP_DIR" || {
    echo "Không tìm thấy thư mục $UBUNTU_APP_DIR. Đang tạo thư mục mới..."
    mkdir -p "$UBUNTU_APP_DIR"
    cd "$UBUNTU_APP_DIR" || exit 1
}

# Kiểm tra và xây dựng ứng dụng nếu cần
if [ ! -d "bin/Debug/net8.0" ] || [ ! -f "bin/Debug/net8.0/MikroTikMonitor.Console.dll" ]; then
    echo "Đang xây dựng ứng dụng..."
    dotnet build
    
    if [ $? -ne 0 ]; then
        echo "Lỗi khi xây dựng ứng dụng. Vui lòng kiểm tra lỗi và thử lại."
        exit 1
    fi
fi

# Chạy ứng dụng
echo "Đang khởi động MikroTik Monitor Console..."
dotnet run

echo "Ứng dụng đã đóng."