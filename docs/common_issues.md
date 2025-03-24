# Các vấn đề thường gặp và cách khắc phục

Tài liệu này liệt kê các vấn đề thường gặp khi làm việc với ứng dụng MikroTik Monitor và cách khắc phục.

## Lỗi phổ biến trong .NET

### 1. Lỗi MSB1011: Không tìm thấy file project hoặc solution

**Lỗi:** `MSBUILD : error MSB1011: Specify which project or solution file to use because this folder contains more than one project or solution file.`

**Nguyên nhân:** Thư mục chứa nhiều file .csproj hoặc .sln, và dotnet command không biết phải sử dụng file nào.

**Cách khắc phục:** 
- Chỉ định tên file project cụ thể:
```bash
dotnet restore MikroTikMonitor.csproj
dotnet build MikroTikMonitor.csproj
```

### 2. Lỗi thiếu NuGet packages

**Lỗi:** `NU1101: Unable to find package X. No packages exist with this id in source(s) ...`

**Nguyên nhân:** Thiếu các thư viện dependencies

**Cách khắc phục:** 
- Khôi phục packages từ NuGet:
```bash
dotnet restore --source https://api.nuget.org/v3/index.json
```

### 3. Lỗi thiếu các thành phần của WPF

**Lỗi:** `Could not load file or assembly 'PresentationFramework...`

**Nguyên nhân:** Thiếu các thành phần cần thiết cho WPF trên môi trường không phải Windows

**Cách khắc phục:** 
- WPF chỉ hoạt động trên Windows. Cân nhắc chuyển sang ứng dụng web hoặc console để sử dụng trên Linux.

## Lỗi trên môi trường Replit

### 1. Lỗi không thể cài đặt packages hệ thống

**Lỗi:** `sudo: command not found` hoặc `apt-get: command not found`

**Nguyên nhân:** Replit không cho phép sử dụng các lệnh sudo hoặc cài đặt gói trực tiếp

**Cách khắc phục:** 
- Sử dụng công cụ "Packages" của Replit để cài đặt dependencies

### 2. Lỗi khi chạy ứng dụng GUI

**Lỗi:** `No usable version of the libssl was found`

**Nguyên nhân:** Thiếu thư viện SSL hoặc xung đột phiên bản

**Cách khắc phục:** 
- Cài đặt libssl qua công cụ Packages của Replit

### 3. Lỗi port bị chiếm dụng

**Lỗi:** `System.Net.Sockets.SocketException: Address already in use`

**Nguyên nhân:** Port đã được sử dụng bởi một ứng dụng khác

**Cách khắc phục:** 
- Thay đổi port trong file cấu hình
- Dừng các ứng dụng khác đang sử dụng port đó

## Lỗi liên quan đến MikroTik API

### 1. Lỗi kết nối

**Lỗi:** `Connection refused` hoặc `Unable to connect to router`

**Nguyên nhân:** Không thể kết nối tới bộ định tuyến MikroTik

**Cách khắc phục:** 
- Kiểm tra địa chỉ IP và cổng kết nối
- Xác nhận bộ định tuyến đang hoạt động và có thể kết nối từ mạng của bạn
- Kiểm tra tường lửa và các quy tắc mạng

### 2. Lỗi xác thực

**Lỗi:** `Authentication failed` hoặc `Access denied`

**Nguyên nhân:** Thông tin đăng nhập không chính xác

**Cách khắc phục:** 
- Kiểm tra lại tên người dùng và mật khẩu
- Xác nhận người dùng có quyền API trên bộ định tuyến

## Quy trình debug

1. Kiểm tra logs ứng dụng trong thư mục `logs`
2. Kiểm tra file log của RouterOS trên bộ định tuyến MikroTik
3. Sử dụng Wireshark để theo dõi lưu lượng mạng giữa ứng dụng và bộ định tuyến
4. Bật chế độ debug trong ứng dụng bằng cách chỉnh sửa file cấu hình

Nếu bạn gặp vấn đề không được liệt kê ở đây, vui lòng mở issue trên GitHub repository hoặc liên hệ với đội hỗ trợ.