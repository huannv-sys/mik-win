#!/bin/bash

echo "========================================="
echo "MikroTik Monitor - Web App (Phiên bản nhẹ)"
echo "========================================="

# Di chuyển đến thư mục dự án 
cd mikk-mmc-web

# Chạy ứng dụng ở chế độ không sử dụng Watch để tiết kiệm tài nguyên
echo "Khởi động ứng dụng web với cấu hình đơn giản..."
dotnet run --urls=http://0.0.0.0:5000 --no-build

if [ $? -ne 0 ]; then
  echo "Lỗi khi chạy ứng dụng!"
  exit 1
fi
