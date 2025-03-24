#!/bin/bash

echo "========================================="
echo "MikroTik Monitor - Web App Runner"
echo "========================================="

# Kiểm tra dotnet được cài đặt
if ! command -v dotnet &> /dev/null
then
    echo "dotnet không được cài đặt. Đang cài đặt..."
    mkdir -p $HOME/.dotnet
    curl -L https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --install-dir $HOME/.dotnet --channel 8.0
    export DOTNET_ROOT=$HOME/.dotnet
    export PATH=$PATH:$HOME/.dotnet
fi

# Kiểm tra thư mục ứng dụng web
if [ ! -d "./mikk-mmc-web" ]; then
    echo "Thư mục ứng dụng web không tồn tại!"
    exit 1
fi

# Khởi động ứng dụng web
cd ./mikk-mmc-web && dotnet run --urls=http://0.0.0.0:5000
