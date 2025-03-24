// Site JavaScript
$(document).ready(function() {
    // Khởi tạo tooltips
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });
    
    // Hiệu ứng cho bảng
    $(".table-hover tbody tr").click(function() {
        var href = $(this).find("a").attr("href");
        if (href) {
            window.location = href;
        }
    });
    
    // Cập nhật dữ liệu theo thời gian thực
    setupAutoRefresh();
});

// Hiển thị biểu đồ traffic
function setupTrafficChart(elementId, data) {
    var ctx = document.getElementById(elementId);
    if (!ctx) return;
    
    var rxData = data.rxPoints || [];
    var txData = data.txPoints || [];
    
    var labels = rxData.map(function(point) {
        var date = new Date(point.timestamp);
        return date.getHours() + ':' + (date.getMinutes() < 10 ? '0' : '') + date.getMinutes();
    });
    
    var rxValues = rxData.map(function(point) { 
        return point.value / 1024; // Convert to KB
    });
    
    var txValues = txData.map(function(point) { 
        return point.value / 1024; // Convert to KB
    });
    
    if (window.trafficChart) {
        window.trafficChart.destroy();
    }
    
    window.trafficChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [
                {
                    label: 'Tải xuống (KB/s)',
                    data: rxValues,
                    borderColor: 'rgba(75, 192, 192, 1)',
                    backgroundColor: 'rgba(75, 192, 192, 0.2)',
                    tension: 0.4,
                    fill: true
                },
                {
                    label: 'Tải lên (KB/s)',
                    data: txValues,
                    borderColor: 'rgba(255, 99, 132, 1)',
                    backgroundColor: 'rgba(255, 99, 132, 0.2)',
                    tension: 0.4,
                    fill: true
                }
            ]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                y: {
                    beginAtZero: true,
                    title: {
                        display: true,
                        text: 'KB/s'
                    }
                },
                x: {
                    title: {
                        display: true,
                        text: 'Thời gian'
                    }
                }
            },
            interaction: {
                intersect: false,
                mode: 'index'
            },
            plugins: {
                tooltip: {
                    callbacks: {
                        label: function(context) {
                            var label = context.dataset.label || '';
                            var value = context.parsed.y || 0;
                            
                            if (value >= 1024) {
                                return label + ': ' + (value / 1024).toFixed(2) + ' MB/s';
                            } else {
                                return label + ': ' + value.toFixed(2) + ' KB/s';
                            }
                        }
                    }
                }
            }
        }
    });
}

// Hiển thị biểu đồ tài nguyên
function setupResourceChart(elementId, data) {
    var ctx = document.getElementById(elementId);
    if (!ctx) return;
    
    if (window.resourceChart) {
        window.resourceChart.destroy();
    }
    
    window.resourceChart = new Chart(ctx, {
        type: 'doughnut',
        data: {
            labels: ['Đã sử dụng', 'Còn trống'],
            datasets: [{
                data: [data.used, data.total - data.used],
                backgroundColor: [
                    'rgba(255, 99, 132, 0.8)',
                    'rgba(54, 162, 235, 0.8)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(54, 162, 235, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    position: 'bottom'
                },
                tooltip: {
                    callbacks: {
                        label: function(context) {
                            var label = context.label || '';
                            var value = context.raw || 0;
                            
                            if (data.type === 'memory' || data.type === 'disk') {
                                return label + ': ' + formatBytes(value);
                            } else {
                                return label + ': ' + value.toFixed(2) + '%';
                            }
                        }
                    }
                }
            }
        }
    });
}

// Cập nhật dữ liệu tự động
function setupAutoRefresh() {
    // Thiết lập tự động làm mới dữ liệu
    var autoRefreshElements = document.querySelectorAll('[data-auto-refresh]');
    autoRefreshElements.forEach(function(element) {
        var url = element.getAttribute('data-auto-refresh');
        var interval = element.getAttribute('data-refresh-interval') || 10000; // 10 giây mặc định
        
        if (url) {
            // Cập nhật ban đầu
            refreshData(element, url);
            
            // Thiết lập cập nhật định kỳ
            setInterval(function() {
                refreshData(element, url);
            }, parseInt(interval));
        }
    });
}

// Gọi API để lấy dữ liệu mới
function refreshData(element, url) {
    $(element).find('.loading-indicator').show();
    
    fetchApi(url)
        .then(function(data) {
            if (data.success) {
                var template = element.getAttribute('data-template');
                if (template && window[template]) {
                    window[template](element, data.data);
                } else {
                    $(element).html(JSON.stringify(data.data));
                }
            } else {
                console.error('Error refreshing data:', data.message);
            }
        })
        .catch(function(error) {
            console.error('Error refreshing data:', error);
        })
        .finally(function() {
            $(element).find('.loading-indicator').hide();
        });
}

// Bật/tắt trạng thái loading
function toggleLoading(show) {
    if (show) {
        $('#loading-overlay').show();
    } else {
        $('#loading-overlay').hide();
    }
}

// Format bytes
function formatBytes(bytes, decimals = 2) {
    if (bytes === 0) return '0 Bytes';
    
    const k = 1024;
    const dm = decimals < 0 ? 0 : decimals;
    const sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB'];
    
    const i = Math.floor(Math.log(bytes) / Math.log(k));
    
    return parseFloat((bytes / Math.pow(k, i)).toFixed(dm)) + ' ' + sizes[i];
}

// Format uptime
function formatUptime(seconds) {
    if (!seconds) return 'N/A';
    
    seconds = parseInt(seconds);
    var days = Math.floor(seconds / (3600 * 24));
    var hours = Math.floor((seconds % (3600 * 24)) / 3600);
    var minutes = Math.floor((seconds % 3600) / 60);
    
    var result = '';
    if (days > 0) result += days + ' ngày ';
    if (hours > 0 || days > 0) result += hours + ' giờ ';
    result += minutes + ' phút';
    
    return result;
}

// Hiển thị thông báo
function showNotification(message, type = 'info') {
    var alertClass = 'alert-info';
    var icon = 'bi-info-circle';
    
    switch (type) {
        case 'success':
            alertClass = 'alert-success';
            icon = 'bi-check-circle';
            break;
        case 'warning':
            alertClass = 'alert-warning';
            icon = 'bi-exclamation-triangle';
            break;
        case 'error':
            alertClass = 'alert-danger';
            icon = 'bi-x-circle';
            break;
    }
    
    var notification = $('<div class="alert ' + alertClass + ' alert-dismissible fade show" role="alert">' +
                         '<i class="bi ' + icon + '"></i> ' + message +
                         '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>' +
                         '</div>');
    
    $('#notification-container').append(notification);
    
    setTimeout(function() {
        notification.alert('close');
    }, 5000);
}

// Fetch API wrapper
async function fetchApi(url) {
    try {
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error('Network response was not ok: ' + response.statusText);
        }
        return await response.json();
    } catch (error) {
        console.error('Error fetching data:', error);
        return { success: false, message: error.message };
    }
}

// Post API wrapper
async function postApi(url, data) {
    try {
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });
        
        if (!response.ok) {
            throw new Error('Network response was not ok: ' + response.statusText);
        }
        
        return await response.json();
    } catch (error) {
        console.error('Error posting data:', error);
        return { success: false, message: error.message };
    }
}
