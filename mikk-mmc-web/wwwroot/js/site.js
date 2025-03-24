// Utility functions for MikroTik Monitor Web Application

// Toggle loading spinner
function toggleLoading(show) {
    const spinner = document.getElementById('loadingSpinner');
    if (!spinner) return;
    
    if (show) {
        spinner.classList.remove('d-none');
    } else {
        spinner.classList.add('d-none');
    }
}

// Format bytes to human-readable format
function formatBytes(bytes, decimals = 2) {
    if (bytes === 0) return '0 Bytes';
    
    const k = 1024;
    const dm = decimals < 0 ? 0 : decimals;
    const sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB'];
    
    const i = Math.floor(Math.log(bytes) / Math.log(k));
    
    return parseFloat((bytes / Math.pow(k, i)).toFixed(dm)) + ' ' + sizes[i];
}

// Format uptime (seconds to days, hours, minutes, seconds)
function formatUptime(seconds) {
    if (seconds < 0) return 'Invalid uptime';
    
    const days = Math.floor(seconds / 86400);
    seconds %= 86400;
    const hours = Math.floor(seconds / 3600);
    seconds %= 3600;
    const minutes = Math.floor(seconds / 60);
    seconds %= 60;
    
    let result = '';
    if (days > 0) result += days + 'd ';
    if (hours > 0) result += hours + 'h ';
    if (minutes > 0) result += minutes + 'm ';
    result += seconds + 's';
    
    return result;
}

// Show notification
function showNotification(message, type = 'info') {
    // Check if the notification container exists, if not create it
    let container = document.getElementById('notificationContainer');
    if (!container) {
        container = document.createElement('div');
        container.id = 'notificationContainer';
        container.style.position = 'fixed';
        container.style.top = '20px';
        container.style.right = '20px';
        container.style.zIndex = '9999';
        document.body.appendChild(container);
    }
    
    // Create the notification element
    const notification = document.createElement('div');
    notification.classList.add('toast', 'show');
    
    // Add appropriate color based on type
    if (type === 'success') {
        notification.classList.add('bg-success', 'text-white');
    } else if (type === 'error') {
        notification.classList.add('bg-danger', 'text-white');
    } else if (type === 'warning') {
        notification.classList.add('bg-warning');
    } else {
        notification.classList.add('bg-info', 'text-white');
    }
    
    // Create the notification content
    notification.innerHTML = `
        <div class="toast-header">
            <strong class="me-auto">MikroTik Monitor</strong>
            <button type="button" class="btn-close btn-close-white" data-bs-dismiss="toast" aria-label="Close"></button>
        </div>
        <div class="toast-body">
            ${message}
        </div>
    `;
    
    // Add the notification to the container
    container.appendChild(notification);
    
    // Add event listener to close button
    const closeButton = notification.querySelector('.btn-close');
    closeButton.addEventListener('click', function() {
        notification.classList.remove('show');
        setTimeout(() => {
            notification.remove();
        }, 300);
    });
    
    // Automatically remove the notification after 5 seconds
    setTimeout(() => {
        notification.classList.remove('show');
        setTimeout(() => {
            notification.remove();
        }, 300);
    }, 5000);
}

// Generic API function for GET requests
async function fetchApi(url) {
    toggleLoading(true);
    try {
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error(`HTTP error ${response.status}`);
        }
        const data = await response.json();
        return data;
    } catch (error) {
        showNotification(`Error fetching data: ${error.message}`, 'error');
        console.error('API Error:', error);
        return null;
    } finally {
        toggleLoading(false);
    }
}

// Generic API function for POST requests
async function postApi(url, data) {
    toggleLoading(true);
    try {
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });
        
        if (!response.ok) {
            throw new Error(`HTTP error ${response.status}`);
        }
        
        const responseData = await response.json();
        return responseData;
    } catch (error) {
        showNotification(`Error posting data: ${error.message}`, 'error');
        console.error('API Error:', error);
        return null;
    } finally {
        toggleLoading(false);
    }
}

// Add a loading spinner to the page
document.addEventListener('DOMContentLoaded', function() {
    const loadingDiv = document.createElement('div');
    loadingDiv.id = 'loadingSpinner';
    loadingDiv.className = 'loading-overlay d-none';
    loadingDiv.innerHTML = '<div class="spinner"></div>';
    document.body.appendChild(loadingDiv);
});
