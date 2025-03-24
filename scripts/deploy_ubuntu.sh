#!/bin/bash

# This script deploys the mikk-mmc application on Ubuntu

echo "========== Deploying on Ubuntu =========="
echo "Starting deployment process..."

# Check if we're on Ubuntu
if [ -f /etc/lsb-release ]; then
    . /etc/lsb-release
    if [[ $DISTRIB_ID != "Ubuntu" ]]; then
        echo "WARNING: This doesn't appear to be Ubuntu. The deployment might not work as expected."
    else
        echo "Detected Ubuntu $DISTRIB_RELEASE"
    fi
else
    echo "WARNING: This doesn't appear to be Ubuntu. The deployment might not work as expected."
fi

# Check if we're in the right directory structure
if [ ! -d "mikk-mmc" ]; then
    echo "ERROR: mikk-mmc directory not found. Make sure you're in the parent directory."
    exit 1
fi

cd mikk-mmc

# Variables for deployment
APP_DIR=$(pwd)
echo "Deploying from: $APP_DIR"

# Function to detect application type and deploy accordingly
deploy_application() {
    echo -e "\n----- Detecting Application Type -----"
    
    # Check if it's a Django application
    if [ -f "manage.py" ]; then
        echo "Detected Django application"
        deploy_django
        return
    fi
    
    # Check if it's a Flask/Python application
    if [ -f "app.py" ] || [ -f "main.py" ] || [ -f "wsgi.py" ]; then
        echo "Detected Flask/Python application"
        deploy_flask
        return
    fi
    
    # Check if it's a Node.js application
    if [ -f "package.json" ]; then
        echo "Detected Node.js application"
        deploy_nodejs
        return
    fi
    
    # Check if it's a PHP application
    if ls *.php &> /dev/null || [ -d "public" ] && ls public/*.php &> /dev/null; then
        echo "Detected PHP application"
        deploy_php
        return
    fi
    
    # If we got here, we couldn't determine the type
    echo "Unable to determine application type. Please refer to the documentation for manual deployment."
    exit 1
}

# Function to deploy Django application
deploy_django() {
    echo -e "\n----- Deploying Django Application -----"
    
    # Install required packages
    echo "Installing required system packages..."
    sudo apt-get update
    sudo apt-get install -y python3 python3-pip python3-venv nginx
    
    # Create and activate virtual environment
    echo "Setting up Python virtual environment..."
    python3 -m venv venv
    source venv/bin/activate
    
    # Install dependencies
    echo "Installing Python dependencies..."
    pip install -r requirements.txt
    pip install gunicorn
    
    # Set up environment variables if needed
    if [ -f ".env" ]; then
        echo "Setting up environment variables..."
        set -a
        source .env
        set +a
    fi
    
    # Run migrations
    echo "Running database migrations..."
    python manage.py migrate
    
    # Collect static files
    echo "Collecting static files..."
    python manage.py collectstatic --noinput
    
    # Create systemd service file
    echo "Setting up systemd service..."
    
    # Detect the Django project name
    PROJECT_NAME=$(find . -type f -name "wsgi.py" | grep -v "venv" | head -1 | cut -d "/" -f 2)
    if [ -z "$PROJECT_NAME" ]; then
        PROJECT_NAME="django_project"  # Default name if we can't detect it
    fi
    
    sudo tee /etc/systemd/system/mikk-mmc.service > /dev/null <<EOL
[Unit]
Description=mikk-mmc Django Application
After=network.target

[Service]
User=$(whoami)
Group=$(whoami)
WorkingDirectory=$APP_DIR
ExecStart=$APP_DIR/venv/bin/gunicorn --workers 3 --bind 0.0.0.0:8000 $PROJECT_NAME.wsgi:application
Restart=always

[Install]
WantedBy=multi-user.target
EOL
    
    # Set up Nginx
    echo "Configuring Nginx..."
    sudo tee /etc/nginx/sites-available/mikk-mmc > /dev/null <<EOL
server {
    listen 80;
    server_name _;

    location /static/ {
        alias $APP_DIR/static/;
    }

    location /media/ {
        alias $APP_DIR/media/;
    }

    location / {
        proxy_pass http://0.0.0.0:8000;
        proxy_set_header Host \$host;
        proxy_set_header X-Real-IP \$remote_addr;
    }
}
EOL
    
    sudo ln -sf /etc/nginx/sites-available/mikk-mmc /etc/nginx/sites-enabled/
    sudo rm -f /etc/nginx/sites-enabled/default
    
    # Start services
    echo "Starting services..."
    sudo systemctl daemon-reload
    sudo systemctl enable mikk-mmc
    sudo systemctl start mikk-mmc
    sudo systemctl restart nginx
    
    echo -e "\n----- Django Deployment Complete -----"
    echo "Your application should now be running at http://localhost"
    echo "To check the status, run: sudo systemctl status mikk-mmc"
}

# Function to deploy Flask application
deploy_flask() {
    echo -e "\n----- Deploying Flask/Python Application -----"
    
    # Install required packages
    echo "Installing required system packages..."
    sudo apt-get update
    sudo apt-get install -y python3 python3-pip python3-venv nginx
    
    # Create and activate virtual environment
    echo "Setting up Python virtual environment..."
    python3 -m venv venv
    source venv/bin/activate
    
    # Install dependencies
    echo "Installing Python dependencies..."
    if [ -f "requirements.txt" ]; then
        pip install -r requirements.txt
    else
        # Install common Flask packages if no requirements.txt
        pip install flask gunicorn
    fi
    
    # Detect the entry point
    ENTRY_POINT=""
    for file in app.py main.py wsgi.py; do
        if [ -f "$file" ]; then
            ENTRY_POINT="$file"
            break
        fi
    done
    
    if [ -z "$ENTRY_POINT" ]; then
        echo "ERROR: Could not find a Python entry point (app.py, main.py, or wsgi.py)"
        exit 1
    fi
    
    # Find the Flask application instance
    APP_INSTANCE=$(grep -r "Flask(__name__)" --include="*.py" . | head -1 | cut -d "=" -f 1 | tr -d ' ')
    if [ -z "$APP_INSTANCE" ]; then
        APP_INSTANCE="app"  # Default Flask app variable name
    fi
    
    # Remove .py extension from entry point
    MODULE_NAME=$(basename $ENTRY_POINT .py)
    
    # Create systemd service file
    echo "Setting up systemd service..."
    sudo tee /etc/systemd/system/mikk-mmc.service > /dev/null <<EOL
[Unit]
Description=mikk-mmc Flask Application
After=network.target

[Service]
User=$(whoami)
Group=$(whoami)
WorkingDirectory=$APP_DIR
ExecStart=$APP_DIR/venv/bin/gunicorn --workers 3 --bind 0.0.0.0:8000 $MODULE_NAME:$APP_INSTANCE
Restart=always

[Install]
WantedBy=multi-user.target
EOL
    
    # Set up Nginx
    echo "Configuring Nginx..."
    sudo tee /etc/nginx/sites-available/mikk-mmc > /dev/null <<EOL
server {
    listen 80;
    server_name _;

    location /static/ {
        alias $APP_DIR/static/;
    }

    location / {
        proxy_pass http://0.0.0.0:8000;
        proxy_set_header Host \$host;
        proxy_set_header X-Real-IP \$remote_addr;
    }
}
EOL
    
    sudo ln -sf /etc/nginx/sites-available/mikk-mmc /etc/nginx/sites-enabled/
    sudo rm -f /etc/nginx/sites-enabled/default
    
    # Start services
    echo "Starting services..."
    sudo systemctl daemon-reload
    sudo systemctl enable mikk-mmc
    sudo systemctl start mikk-mmc
    sudo systemctl restart nginx
    
    echo -e "\n----- Flask Deployment Complete -----"
    echo "Your application should now be running at http://localhost"
    echo "To check the status, run: sudo systemctl status mikk-mmc"
}

# Function to deploy Node.js application
deploy_nodejs() {
    echo -e "\n----- Deploying Node.js Application -----"
    
    # Install required packages
    echo "Installing required system packages..."
    sudo apt-get update
    sudo apt-get install -y nodejs npm nginx
    
    # Check if we need a specific Node.js version
    if [ -f ".nvmrc" ]; then
        NODE_VERSION=$(cat .nvmrc)
        echo "Detected Node.js version requirement: $NODE_VERSION"
        
        # Install NVM if not already installed
        if ! command -v nvm &> /dev/null; then
            echo "Installing NVM..."
            curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v0.39.0/install.sh | bash
            export NVM_DIR="$HOME/.nvm"
            [ -s "$NVM_DIR/nvm.sh" ] && \. "$NVM_DIR/nvm.sh"
        fi
        
        # Install required Node.js version
        nvm install $NODE_VERSION
        nvm use $NODE_VERSION
    fi
    
    # Install dependencies
    echo "Installing Node.js dependencies..."
    npm install
    
    # Determine if this is a frontend or backend application
    if grep -q "react\|vue\|angular\|next" package.json; then
        echo "Detected frontend framework"
        deploy_nodejs_frontend
    else
        echo "Detected Node.js backend application"
        deploy_nodejs_backend
    fi
}

# Function to deploy Node.js frontend application
deploy_nodejs_frontend() {
    # Build the application
    echo "Building frontend application..."
    if grep -q "\"build\":" package.json; then
        npm run build
    elif grep -q "\"prod\":" package.json; then
        npm run prod
    else
        echo "WARNING: Could not find build script in package.json"
    fi
    
    # Determine the build output directory
    BUILD_DIR=""
    for dir in build dist public; do
        if [ -d "$dir" ]; then
            BUILD_DIR="$dir"
            break
        fi
    done
    
    if [ -z "$BUILD_DIR" ]; then
        echo "ERROR: Could not find build output directory (build, dist, or public)"
        exit 1
    fi
    
    # Set up Nginx
    echo "Configuring Nginx to serve static files..."
    sudo tee /etc/nginx/sites-available/mikk-mmc > /dev/null <<EOL
server {
    listen 80;
    server_name _;
    
    root $APP_DIR/$BUILD_DIR;
    index index.html;
    
    location / {
        try_files \$uri \$uri/ /index.html;
    }
}
EOL
    
    sudo ln -sf /etc/nginx/sites-available/mikk-mmc /etc/nginx/sites-enabled/
    sudo rm -f /etc/nginx/sites-enabled/default
    sudo systemctl restart nginx
    
    echo -e "\n----- Frontend Deployment Complete -----"
    echo "Your application should now be running at http://localhost"
}

# Function to deploy Node.js backend application
deploy_nodejs_backend() {
    # Install PM2 globally
    echo "Installing PM2 process manager..."
    npm install pm2 -g
    
    # Determine the entry point
    ENTRY_POINT=""
    for file in server.js index.js app.js main.js; do
        if [ -f "$file" ]; then
            ENTRY_POINT="$file"
            break
        fi
    done
    
    if [ -z "$ENTRY_POINT" ]; then
        # Check package.json for main entry
        ENTRY_POINT=$(grep -m 1 '"main":' package.json | cut -d '"' -f 4)
    fi
    
    if [ -z "$ENTRY_POINT" ]; then
        echo "ERROR: Could not find a Node.js entry point"
        exit 1
    fi
    
    # Start the application with PM2
    echo "Starting application with PM2..."
    pm2 start $ENTRY_POINT --name mikk-mmc
    pm2 save
    
    # Set up PM2 to start on boot
    echo "Setting up PM2 to start on boot..."
    pm2 startup
    sudo env PATH=$PATH:/usr/bin pm2 startup systemd -u $(whoami) --hp $HOME
    
    # Set up Nginx
    echo "Configuring Nginx..."
    sudo tee /etc/nginx/sites-available/mikk-mmc > /dev/null <<EOL
server {
    listen 80;
    server_name _;
    
    location / {
        proxy_pass http://0.0.0.0:8000;
        proxy_set_header Host \$host;
        proxy_set_header X-Real-IP \$remote_addr;
    }
}
EOL
    
    sudo ln -sf /etc/nginx/sites-available/mikk-mmc /etc/nginx/sites-enabled/
    sudo rm -f /etc/nginx/sites-enabled/default
    sudo systemctl restart nginx
    
    echo -e "\n----- Backend Deployment Complete -----"
    echo "Your application should now be running at http://localhost"
    echo "To check the status, run: pm2 status"
}

# Function to deploy PHP application
deploy_php() {
    echo -e "\n----- Deploying PHP Application -----"
    
    # Install required packages
    echo "Installing required system packages..."
    sudo apt-get update
    sudo apt-get install -y php php-fpm php-mysql nginx
    
    # Install Composer dependencies if composer.json exists
    if [ -f "composer.json" ]; then
        echo "Installing Composer dependencies..."
        if ! command -v composer &> /dev/null; then
            echo "Installing Composer..."
            curl -sS https://getcomposer.org/installer | php
            sudo mv composer.phar /usr/local/bin/composer
        fi
        composer install --no-dev
    fi
    
    # Determine the document root
    DOC_ROOT="."
    if [ -d "public" ]; then
        DOC_ROOT="$APP_DIR/public"
    elif [ -d "web" ]; then
        DOC_ROOT="$APP_DIR/web"
    else
        DOC_ROOT="$APP_DIR"
    fi
    
    # Set up Nginx
    echo "Configuring Nginx..."
    sudo tee /etc/nginx/sites-available/mikk-mmc > /dev/null <<EOL
server {
    listen 80;
    server_name _;
    
    root $DOC_ROOT;
    index index.php index.html;
    
    location / {
        try_files \$uri \$uri/ /index.php?\$query_string;
    }
    
    location ~ \.php$ {
        include snippets/fastcgi-php.conf;
        fastcgi_pass unix:/var/run/php/php7.4-fpm.sock;
    }
}
EOL
    
    sudo ln -sf /etc/nginx/sites-available/mikk-mmc /etc/nginx/sites-enabled/
    sudo rm -f /etc/nginx/sites-enabled/default
    sudo systemctl restart nginx
    
    echo -e "\n----- PHP Deployment Complete -----"
    echo "Your application should now be running at http://localhost"
}

# Start the deployment process
deploy_application

echo -e "\n----- Post-Deployment Steps -----"
echo "1. Make sure your firewall allows HTTP traffic (port 80)"
echo "   You can use: sudo ufw allow 'Nginx Full'"
echo "2. Configure your domain name by updating the Nginx configuration"
echo "3. Consider setting up HTTPS with Let's Encrypt"
echo "4. Set up monitoring for your application"

echo -e "\n========== Deployment Complete =========="
echo "If you encountered any issues, please refer to the logs and documentation."
