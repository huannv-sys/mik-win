document.addEventListener('DOMContentLoaded', function() {
    // Simulate router data updates
    updateSystemResources();
    
    // Update router status every 5 seconds
    setInterval(updateSystemResources, 5000);
    
    // Setup buttons
    document.querySelectorAll('.btn-refresh').forEach(btn => {
        btn.addEventListener('click', function() {
            const card = this.closest('.card');
            if (card) {
                showCardLoading(card);
                setTimeout(() => {
                    hideCardLoading(card);
                }, 800);
            }
        });
    });
});

function updateSystemResources() {
    // CPU Usage
    const cpuUsage = getRandomValue(10, 35);
    updateProgressBar('cpu-usage', cpuUsage);
    document.getElementById('cpu-value').textContent = cpuUsage + '%';
    
    // Memory Usage
    const memoryUsage = getRandomValue(30, 50);
    updateProgressBar('memory-usage', memoryUsage);
    document.getElementById('memory-value').textContent = memoryUsage + '%';
    
    // Disk Usage
    const diskUsage = getRandomValue(20, 40);
    updateProgressBar('disk-usage', diskUsage);
    document.getElementById('disk-value').textContent = diskUsage + '%';
    
    // Temperature
    const temperature = getRandomValue(41, 44);
    document.getElementById('temperature-value').textContent = temperature + '°C';
    
    // Active Sessions
    const sessions = getRandomValue(2, 10);
    document.getElementById('sessions-value').textContent = sessions;
    
    // Last Updated
    document.getElementById('last-updated').textContent = new Date().toLocaleTimeString();
}

function updateProgressBar(id, value) {
    const progressBar = document.getElementById(id);
    if (progressBar) {
        progressBar.style.width = value + '%';
        
        // Update class based on value
        progressBar.className = 'progress-bar';
        if (value < 30) {
            progressBar.classList.add('progress-bar-success');
        } else if (value < 70) {
            progressBar.classList.add('progress-bar-warning');
        } else {
            progressBar.classList.add('progress-bar-danger');
        }
    }
}

function getRandomValue(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function showCardLoading(card) {
    const loader = document.createElement('div');
    loader.className = 'card-loader';
    loader.innerHTML = '<div class="spinner"></div>';
    loader.style.position = 'absolute';
    loader.style.top = '0';
    loader.style.left = '0';
    loader.style.width = '100%';
    loader.style.height = '100%';
    loader.style.backgroundColor = 'rgba(255,255,255,0.7)';
    loader.style.display = 'flex';
    loader.style.justifyContent = 'center';
    loader.style.alignItems = 'center';
    loader.style.zIndex = '10';
    
    const spinner = document.createElement('div');
    spinner.style.width = '30px';
    spinner.style.height = '30px';
    spinner.style.border = '3px solid #f3f3f3';
    spinner.style.borderTop = '3px solid #3498db';
    spinner.style.borderRadius = '50%';
    spinner.style.animation = 'spin 1s linear infinite';
    
    const styleElement = document.createElement('style');
    styleElement.textContent = `
        @keyframes spin {
            0% { transform: rotate(0deg); }
            100% { transform: rotate(360deg); }
        }
    `;
    document.head.appendChild(styleElement);
    
    loader.appendChild(spinner);
    card.style.position = 'relative';
    card.appendChild(loader);
}

function hideCardLoading(card) {
    const loader = card.querySelector('.card-loader');
    if (loader) {
        card.removeChild(loader);
    }
}
