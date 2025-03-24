#!/bin/bash

echo "========================================="
echo "MikroTik Monitor - Web App (Phiên bản tối ưu)"
echo "========================================="

cd mikk-mmc-web

echo "Đang build ứng dụng (bản phát hành)..."
dotnet publish -c Release -o ../publish --nologo

if [ $? -eq 0 ]; then
  echo "Build thành công! Đang chạy ứng dụng..."
  
  cd ../publish
  
  # Chạy ứng dụng ở chế độ không sử dụng Watch để tiết kiệm tài nguyên
  dotnet mikk-mmc-web.dll --urls=http://0.0.0.0:5000
else
  echo "Lỗi khi build ứng dụng!"
  exit 1
fi
