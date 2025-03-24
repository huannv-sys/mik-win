#!/bin/bash
echo "===== MikroTik Monitor - Chế độ Siêu Tối Giản ====="

# Tạo ứng dụng đơn giản để kiểm tra kết nối
mkdir -p simple_app
cd simple_app

cat > index.html << 'EOF'
<!DOCTYPE html>
<html>
<head>
    <title>MikroTik Monitor Web</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 0; padding: 20px; background-color: #f5f5f5; }
        .container { max-width: 800px; margin: 0 auto; background-color: #fff; padding: 20px; border-radius: 5px; box-shadow: 0 0 10px rgba(0,0,0,0.1); }
        h1 { color: #2c3e50; }
        .status { padding: 15px; margin-top: 20px; border-radius: 5px; background-color: #ecf0f1; }
        .success { color: #27ae60; }
        .error { color: #e74c3c; }
    </style>
</head>
<body>
    <div class="container">
        <h1>MikroTik Monitor - Web Version</h1>
        <div class="status">
            <h2>Trạng thái kết nối</h2>
            <p><b>Máy chủ web:</b> <span class="success">Đang chạy</span></p>
            <p><b>Demo Mode:</b> <span class="success">Hoạt động</span></p>
            <p><b>Thông tin:</b> Ứng dụng đơn giản này xác nhận rằng máy chủ web có thể chạy trên Replit.</p>
            <p>Khi cài đặt thành công, bạn sẽ thấy trang này thay vì ứng dụng ASP.NET MVC đầy đủ.</p>
        </div>
    </div>
</body>
</html>
EOF

# Kiểm tra xem có Python không
if command -v python3 &> /dev/null; then
    python3 -m http.server 5000
elif command -v python &> /dev/null; then
    python -m http.server 5000
else
    # Sử dụng node nếu có
    if command -v node &> /dev/null; then
        cat > server.js << 'EOS'
const http = require('http');
const fs = require('fs');
const path = require('path');

const server = http.createServer((req, res) => {
  const filePath = path.join(__dirname, 'index.html');
  fs.readFile(filePath, (err, content) => {
    if (err) {
      res.writeHead(500);
      res.end('Lỗi khi đọc file: ' + err.code);
    } else {
      res.writeHead(200, { 'Content-Type': 'text/html' });
      res.end(content, 'utf-8');
    }
  });
});

const PORT = 5000;
server.listen(PORT, '0.0.0.0', () => {
  console.log(`Máy chủ đang chạy tại http://0.0.0.0:${PORT}/`);
});
EOS
        node server.js
    else
        echo "Không tìm thấy Python hoặc Node.js. Không thể khởi động máy chủ web."
        
        # Tạo một tệp tĩnh để hiển thị thông báo
        cat > error.txt << 'EOF'
===== LỖI =====
Không thể khởi động máy chủ web vì không tìm thấy Python hoặc Node.js.
EOF
        cat error.txt
        # Keep process running for Replit
        tail -f /dev/null
    fi
fi
