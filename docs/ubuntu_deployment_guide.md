# Hướng dẫn triển khai MikroTik Monitor trên Ubuntu

## Tổng quan

Do MikroTik Monitor ban đầu được phát triển bằng WPF (Windows Presentation Foundation) - một công nghệ chỉ tương thích với Windows, chúng tôi đã tạo một phiên bản console đặc biệt để chạy trên Ubuntu và các môi trường Linux khác.

Phiên bản này cung cấp hầu hết các chức năng chính của ứng dụng gốc nhưng thông qua giao diện dòng lệnh hoàn chỉnh.

## Yêu cầu hệ thống

- Ubuntu 20.04 LTS hoặc cao hơn
- .NET 8.0 SDK hoặc cao hơn
- Kết nối mạng để tương tác với bộ định tuyến MikroTik

## Cài đặt .NET SDK trên Ubuntu

```bash
# Cài đặt các dependencies
sudo apt-get update
sudo apt-get install -y apt-transport-https

# Thêm Microsoft package repository
wget https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb

# Cài đặt .NET SDK
sudo apt-get update
sudo apt-get install -y dotnet-sdk-8.0
```

## Triển khai ứng dụng

1. Sao chép thư mục `mikk-mmc-ubuntu` đến máy chủ Ubuntu của bạn
2. Chuyển đến thư mục `mikk-mmc-ubuntu`
3. Xây dựng ứng dụng với lệnh: `dotnet build`
4. Chạy ứng dụng với lệnh: `dotnet run`

Hoặc sử dụng script `run_ubuntu_app.sh` để tự động hóa các bước trên:

```bash
chmod +x run_ubuntu_app.sh
./run_ubuntu_app.sh
```

## Sử dụng ứng dụng

Sau khi chạy, ứng dụng sẽ hiển thị menu chính với các lựa chọn sau:

1. **Connect to Router** - Kết nối đến bộ định tuyến MikroTik
2. **View Router Status** - Xem trạng thái bộ định tuyến
3. **View Network Interfaces** - Xem thông tin giao diện mạng
4. **View Firewall Rules** - Xem các quy tắc tường lửa
5. **View DHCP Leases** - Xem thông tin cấp phát DHCP
6. **View Logs** - Xem nhật ký hệ thống
7. **Settings** - Cấu hình thiết lập
8. **Exit** - Thoát ứng dụng

Sử dụng phím mũi tên để điều hướng và Enter để chọn.

## Khắc phục sự cố

Nếu gặp vấn đề khi chạy ứng dụng, hãy đảm bảo:

1. .NET SDK 8.0 đã được cài đặt đúng cách
2. Ứng dụng đã được xây dựng thành công bằng lệnh `dotnet build`
3. Người dùng có quyền truy cập vào thư mục ứng dụng

## Mở rộng và tùy chỉnh

Phiên bản console có thể được mở rộng bằng cách thêm chức năng vào file `Program.cs`. Ứng dụng sử dụng:

- **Spectre.Console** cho giao diện console tương tác
- **SSH.NET** để giao tiếp với các bộ định tuyến MikroTik qua SSH
- **Lextm.SharpSnmpLib** cho giám sát thông qua SNMP
- **Microsoft.Extensions.Logging** cho hệ thống nhật ký