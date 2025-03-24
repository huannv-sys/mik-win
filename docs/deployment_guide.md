# Mikk-MMC Deployment Guide

Hướng dẫn này sẽ giúp bạn triển khai ứng dụng MikroTik Monitor trên môi trường Ubuntu và Replit.

## Yêu cầu hệ thống

- .NET SDK 8.0 trở lên
- Không gian đĩa ít nhất 1GB
- Quyền quản trị (nếu triển khai trên máy chủ Ubuntu)

## Triển khai trên Ubuntu

### Bước 1: Chuẩn bị môi trường

```bash
# Cài đặt .NET SDK
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update
sudo apt-get install -y dotnet-sdk-8.0
```

### Bước 2: Build ứng dụng

```bash
cd mikk-mmc
dotnet restore
dotnet publish -c Release -o ./publish
```

### Bước 3: Chạy ứng dụng Desktop

```bash
cd publish
dotnet MikroTikMonitor.dll
```

## Triển khai trên Replit

### Bước 1: Cài đặt .NET SDK thông qua công cụ Replit

- Sử dụng công cụ "Packages" trong Replit để cài đặt .NET 8.0

### Bước 2: Build ứng dụng

```bash
cd mikk-mmc
dotnet restore MikroTikMonitor.csproj
dotnet publish MikroTikMonitor.csproj -c Release -o ./publish
```

### Bước 3: Chạy ứng dụng

```bash
cd publish
dotnet MikroTikMonitor.dll
```

## Xử lý sự cố

### Lỗi thiếu thư viện

Nếu gặp lỗi thiếu thư viện, hãy cài đặt các gói NuGet cần thiết:

```bash
dotnet add package <package-name>
```

### Lỗi khi build

Kiểm tra phiên bản .NET SDK đã cài đặt:

```bash
dotnet --version
```

### Lỗi khi chạy ứng dụng

Kiểm tra file log trong thư mục logs để tìm nguyên nhân của lỗi.

## Liên hệ Hỗ trợ

Nếu gặp vấn đề khi triển khai, vui lòng liên hệ qua email: support@mikk-mmc.com hoặc mở issue trên GitHub repository.