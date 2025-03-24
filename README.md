# Công cụ debug và triển khai MikroTik Monitor

Dự án này giúp bạn debug, sửa lỗi và triển khai ứng dụng MikroTik Monitor (mikk-mmc) trên môi trường Ubuntu.

## Tổng quan

Ứng dụng MikroTik Monitor là một công cụ giám sát toàn diện cho các bộ định tuyến MikroTik. Dự án này cung cấp các scripts và hướng dẫn để:

1. Clone repository từ GitHub
2. Phân tích cấu trúc và dependencies của repository
3. Sửa các lỗi phổ biến trong mã nguồn
4. Build và triển khai ứng dụng trên Ubuntu

## Hướng dẫn sử dụng

### Bước 1: Clone repository

```bash
git clone https://github.com/huannv-sys/mikk-mmc.git
```

### Bước 2: Chạy script tự động

```bash
bash fix_and_deploy.sh
```

Script này sẽ tự động thực hiện các công việc sau:
- Clone repository nếu chưa tồn tại
- Phân tích cấu trúc repository
- Sửa các lỗi phổ biến
- Build và triển khai ứng dụng

### Bước 3: Chạy ứng dụng

Sau khi triển khai thành công, bạn có thể chạy ứng dụng bằng cách:

```bash
bash run_dotnet_app.sh
```

## Cấu trúc dự án

- `fix_and_deploy.sh`: Script chính để debug và triển khai
- `scripts/`: Thư mục chứa các script con
  - `analyze_repo.sh`: Phân tích cấu trúc repository
  - `fix_common_issues.sh`: Sửa các lỗi phổ biến
  - `deploy_ubuntu.sh`: Triển khai ứng dụng trên Ubuntu
- `docs/`: Tài liệu hướng dẫn
  - `deployment_guide.md`: Hướng dẫn triển khai chi tiết
  - `common_issues.md`: Danh sách các vấn đề thường gặp và cách khắc phục
- `logs/`: Lưu trữ các file log
- `mikk-mmc/`: Repository gốc của ứng dụng MikroTik Monitor

## Xử lý sự cố

Nếu bạn gặp vấn đề trong quá trình debug hoặc triển khai, vui lòng tham khảo file `docs/common_issues.md` để tìm giải pháp.

## Yêu cầu hệ thống

- Ubuntu 20.04 hoặc mới hơn
- .NET SDK 8.0 trở lên
- Git

## Liên hệ

Nếu bạn cần hỗ trợ thêm, vui lòng tạo issue trên GitHub repository hoặc liên hệ với đội phát triển.