#!/bin/bash

echo "========================================="
echo "MikroTik Monitor - Web Edition Launcher"
echo "========================================="

# Kiểm tra dotnet được cài đặt
if ! command -v dotnet &> /dev/null
then
    echo "dotnet không được cài đặt. Đang cài đặt..."
    curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel LTS
    export PATH="$PATH:$HOME/.dotnet"
fi

# Đường dẫn đến thư mục ứng dụng web
APP_DIR="./mikk-mmc-web"

# Di chuyển đến thư mục
cd "$APP_DIR" || { echo "Không tìm thấy thư mục $APP_DIR!"; exit 1; }

echo "Đang khởi động ứng dụng web MikroTik Monitor..."

# Khởi động ứng dụng web
dotnet watch run --urls=http://0.0.0.0:5000
