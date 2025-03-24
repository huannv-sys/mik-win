#!/bin/bash
echo "===== MikroTik Monitor - Web App (Phiên bản tối ưu) ====="

# Thư mục ứng dụng
APP_DIR="mikk-mmc-web"
PUBLIC_DIR="publish"

# Kiểm tra thư mục ứng dụng
if [ ! -d "$APP_DIR" ]; then
  echo "Không tìm thấy thư mục $APP_DIR!"
  exit 1
fi

# Build ứng dụng
echo "Đang build ứng dụng ASP.NET Core..."
cd "$APP_DIR"

# Thử build với thời gian chờ tối đa
echo "Đang build với cấu hình Release..."
timeout 120s dotnet publish -c Release -o ../$PUBLIC_DIR --nologo

# Kiểm tra kết quả build
if [ $? -eq 0 ]; then
  echo "Build thành công! Đang chạy ứng dụng từ thư mục $PUBLIC_DIR..."
  cd "../$PUBLIC_DIR"
  
  # Khởi động ứng dụng
  echo "Khởi động ứng dụng ASP.NET Core..."
  dotnet mikk-mmc-web.dll --urls=http://0.0.0.0:5000
  
elif [ $? -eq 124 ]; then
  echo "Build timeout! Đang chuyển sang sử dụng phiên bản tĩnh..."
  
  # Tạo thư mục xuất bản
  mkdir -p "../$PUBLIC_DIR"
  cd "../$PUBLIC_DIR"
  
  # Tạo phiên bản HTML tĩnh
  cat > index.html << 'EOF'
<!DOCTYPE html>
<html>
<head>
    <title>MikroTik Monitor Web</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.8.1/font/bootstrap-icons.css" />
    <style>
        body { font-family: Arial, sans-serif; margin: 0; padding: 20px; }
        .navbar { margin-bottom: 20px; }
        .card { margin-bottom: 20px; }
        .status-item { display: flex; margin-bottom: 10px; }
        .status-label { min-width: 150px; font-weight: bold; }
        .progress { height: 20px; margin-bottom: 5px; }
    </style>
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
        <div class="container-fluid">
            <a class="navbar-brand" href="#">
                <i class="bi bi-router-fill"></i> MikroTik Monitor
            </a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link active" href="#">Trang chủ</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Trạng thái Router</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Giao diện mạng</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Tường lửa</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">DHCP</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Nhật ký</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>

    <div class="container">
        <div class="alert alert-warning">
            <h4><i class="bi bi-exclamation-triangle"></i> Chế độ Demo Tĩnh</h4>
            <p>ASP.NET Core app không thể build được trong môi trường hiện tại. Đây là phiên bản tĩnh của giao diện.</p>
        </div>

        <div class="card">
            <div class="card-header d-flex justify-content-between align-items-center">
                <h5 class="mb-0"><i class="bi bi-router"></i> Thông tin Router</h5>
                <span class="text-muted small">Cập nhật lần cuối: 10:30:15 24/03/2025</span>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-md-4">
                        <h6 class="border-bottom pb-2 mb-3">Thông tin cơ bản</h6>
                        <div class="status-item">
                            <div class="status-label">Tên Router:</div>
                            <div class="status-value">MikroTik Demo</div>
                        </div>
                        <div class="status-item">
                            <div class="status-label">Model:</div>
                            <div class="status-value">RouterBOARD 3011</div>
                        </div>
                        <div class="status-item">
                            <div class="status-label">Số Serial:</div>
                            <div class="status-value">44G70B7777AA</div>
                        </div>
                        <div class="status-item">
                            <div class="status-label">Phiên bản:</div>
                            <div class="status-value">RouterOS v7.10</div>
                        </div>
                        <div class="status-item">
                            <div class="status-label">Thời gian hoạt động:</div>
                            <div class="status-value">10 ngày 14 giờ 22 phút</div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <h6 class="border-bottom pb-2 mb-3">Tài nguyên hệ thống</h6>
                        <div class="status-item">
                            <div class="status-label">CPU:</div>
                            <div class="status-value" style="width: 100%;">
                                <div class="progress">
                                    <div class="progress-bar" role="progressbar" style="width: 25%;" 
                                        aria-valuenow="25" aria-valuemin="0" aria-valuemax="100">
                                        25%
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="status-item">
                            <div class="status-label">Bộ nhớ:</div>
                            <div class="status-value" style="width: 100%;">
                                <div class="progress">
                                    <div class="progress-bar" role="progressbar" style="width: 40%;" 
                                        aria-valuenow="40" aria-valuemin="0" aria-valuemax="100">
                                        40%
                                    </div>
                                </div>
                                <small class="text-muted">
                                    409.6 MB / 1024 MB
                                </small>
                            </div>
                        </div>
                        <div class="status-item">
                            <div class="status-label">Ổ đĩa:</div>
                            <div class="status-value" style="width: 100%;">
                                <div class="progress">
                                    <div class="progress-bar" role="progressbar" style="width: 30%;" 
                                        aria-valuenow="30" aria-valuemin="0" aria-valuemax="100">
                                        30%
                                    </div>
                                </div>
                                <small class="text-muted">
                                    60 MB / 200 MB
                                </small>
                            </div>
                        </div>
                        <div class="status-item">
                            <div class="status-label">Nhiệt độ:</div>
                            <div class="status-value">42 °C</div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <h6 class="border-bottom pb-2 mb-3">Kết nối mạng</h6>
                        <div class="status-item">
                            <div class="status-label">Địa chỉ IP:</div>
                            <div class="status-value">192.168.1.1</div>
                        </div>
                        <div class="status-item">
                            <div class="status-label">Địa chỉ MAC:</div>
                            <div class="status-value">AA:BB:CC:DD:EE:FF</div>
                        </div>
                        <div class="status-item">
                            <div class="status-label">License:</div>
                            <div class="status-value">Level 5</div>
                        </div>
                        <div class="status-item">
                            <div class="status-label">Cập nhật:</div>
                            <div class="status-value">
                                <span class="badge bg-success">Phiên bản mới nhất</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <div class="card h-100">
                    <div class="card-header d-flex justify-content-between align-items-center">
                        <h5 class="mb-0"><i class="bi bi-ethernet"></i> Giao diện mạng</h5>
                        <a href="#" class="btn btn-sm btn-outline-primary">Xem tất cả</a>
                    </div>
                    <div class="card-body">
                        <table class="table table-hover">
                            <thead>
                                <tr>
                                    <th>Tên</th>
                                    <th>Trạng thái</th>
                                    <th>Địa chỉ IP</th>
                                    <th>Tốc độ RX/TX</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td><a href="#">ether1</a></td>
                                    <td><span class="badge bg-success">Hoạt động</span></td>
                                    <td>192.168.1.1/24</td>
                                    <td>5.2 Mbps / 1.8 Mbps</td>
                                </tr>
                                <tr>
                                    <td><a href="#">ether2</a></td>
                                    <td><span class="badge bg-success">Hoạt động</span></td>
                                    <td>10.0.0.1/24</td>
                                    <td>1.5 Mbps / 0.8 Mbps</td>
                                </tr>
                                <tr>
                                    <td><a href="#">wlan1</a></td>
                                    <td><span class="badge bg-danger">Không hoạt động</span></td>
                                    <td>-</td>
                                    <td>0 Mbps / 0 Mbps</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="card h-100">
                    <div class="card-header d-flex justify-content-between align-items-center">
                        <h5 class="mb-0"><i class="bi bi-shield-check"></i> Luật tường lửa gần đây</h5>
                        <a href="#" class="btn btn-sm btn-outline-primary">Xem tất cả</a>
                    </div>
                    <div class="card-body">
                        <table class="table table-hover">
                            <thead>
                                <tr>
                                    <th>Chain</th>
                                    <th>Action</th>
                                    <th>Src/Dst Address</th>
                                    <th>Lần cuối</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>forward</td>
                                    <td><span class="badge bg-success">accept</span></td>
                                    <td>192.168.1.0/24 → 0.0.0.0/0</td>
                                    <td><span class="text-muted small">10:15:23 24/03/2025</span></td>
                                </tr>
                                <tr>
                                    <td>forward</td>
                                    <td><span class="badge bg-danger">drop</span></td>
                                    <td>0.0.0.0/0 → 192.168.1.10</td>
                                    <td><span class="text-muted small">10:10:45 24/03/2025</span></td>
                                </tr>
                                <tr>
                                    <td>input</td>
                                    <td><span class="badge bg-success">accept</span></td>
                                    <td>192.168.1.0/24 → 192.168.1.1</td>
                                    <td><span class="text-muted small">10:05:12 24/03/2025</span></td>
                                </tr>
                                <tr>
                                    <td>input</td>
                                    <td><span class="badge bg-danger">drop</span></td>
                                    <td>0.0.0.0/0 → 192.168.1.1:22</td>
                                    <td><span class="text-muted small">09:55:30 24/03/2025</span></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/jquery@3.6.0/dist/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
EOF
  
  python3 -m http.server 5000
  
else
  echo "Lỗi khi build ứng dụng! Mã lỗi: $?"
  exit 1
fi
