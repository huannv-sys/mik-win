#!/bin/bash
echo "===== MikroTik Monitor Web App ====="

# Định nghĩa thư mục ứng dụng
APP_DIR="mikk-mmc-web"
PUBLIC_DIR="publish"
STATIC_DIR="simple_app"

# Kiểm tra thư mục static fallback
if [ ! -d "$STATIC_DIR" ]; then
  echo "Không tìm thấy thư mục $STATIC_DIR cho phiên bản dự phòng!"
  exit 1
fi

echo "Chuyển sang sử dụng phiên bản tĩnh với Python..."

# Sử dụng Python HTTP server để phục vụ phiên bản tĩnh
echo "Đang khởi động Python HTTP Server với thư mục $STATIC_DIR..."
python3 -m http.server 5000 --directory "$STATIC_DIR"
