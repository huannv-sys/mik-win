#!/bin/bash

# This script attempts to fix common issues in the mikk-mmc repository

echo "========== Fixing Common Issues =========="
echo "Attempting to fix common issues in the repository..."

# Check if mikk-mmc directory exists
if [ ! -d "mikk-mmc" ]; then
    echo "ERROR: mikk-mmc directory not found. Make sure you're in the right directory."
    exit 1
fi

# Change to mikk-mmc directory for fixes
cd mikk-mmc

# Counter for fixed issues
fixed_issues=0
failed_fixes=0

# Function to log successful fixes
log_fix() {
    echo "✓ FIXED: $1"
    fixed_issues=$((fixed_issues+1))
}

# Function to log failed fixes
log_fail() {
    echo "✗ FAILED TO FIX: $1"
    failed_fixes=$((failed_fixes+1))
}

echo -e "\n----- Fixing dependency issues -----"

# Fix Python dependencies
if [ -f "requirements.txt" ]; then
    echo "Installing Python dependencies..."
    pip install -r requirements.txt 2>/dev/null
    if [ $? -eq 0 ]; then
        log_fix "Installed Python dependencies"
    else
        log_fail "Unable to install Python dependencies"
        echo "You may need to run: pip install -r requirements.txt"
    fi
else
    # If we find Python files but no requirements.txt, create one with common packages
    if ls *.py &> /dev/null && [ ! -f "requirements.txt" ]; then
        echo "Creating requirements.txt with common packages..."
        echo "# Auto-generated requirements.txt" > requirements.txt
        
        # Check for Django files
        if [ -f "manage.py" ] || [ -d "*/migrations" ]; then
            echo "django>=3.2,<4.0" >> requirements.txt
        fi
        
        # Check for Flask files
        if grep -r "from flask import" --include="*.py" . &> /dev/null; then
            echo "flask>=2.0,<3.0" >> requirements.txt
        fi
        
        # Common packages
        echo "requests>=2.25.1" >> requirements.txt
        echo "python-dotenv>=0.15.0" >> requirements.txt
        
        # Install the dependencies
        pip install -r requirements.txt 2>/dev/null
        if [ $? -eq 0 ]; then
            log_fix "Created and installed requirements.txt with common packages"
        else
            log_fail "Created requirements.txt but failed to install packages"
        fi
    fi
fi

# Fix Node.js dependencies
if [ -f "package.json" ]; then
    if [ ! -d "node_modules" ]; then
        echo "Installing Node.js dependencies..."
        npm install 2>/dev/null
        if [ $? -eq 0 ]; then
            log_fix "Installed Node.js dependencies"
        else
            # Try with Yarn if npm fails
            yarn install 2>/dev/null
            if [ $? -eq 0 ]; then
                log_fix "Installed Node.js dependencies using Yarn"
            else
                log_fail "Unable to install Node.js dependencies"
                echo "You may need to run: npm install or yarn install"
            fi
        fi
    fi
fi

echo -e "\n----- Fixing configuration issues -----"

# Check and create .env file if needed
if [ -f ".env.example" ] && [ ! -f ".env" ]; then
    echo "Creating .env file from .env.example..."
    cp .env.example .env
    log_fix "Created .env file from .env.example"
elif [ ! -f ".env" ] && [ ! -f ".env.example" ]; then
    # Look for environment variables in the code
    env_vars=$(grep -r "os.getenv\|process.env" --include="*.{py,js,ts}" . 2>/dev/null | grep -o '[A-Z_]\+' | sort -u)
    
    if [ ! -z "$env_vars" ]; then
        echo "Creating .env file with detected environment variables..."
        echo "# Auto-generated .env file" > .env
        echo "# Please update these values with your actual credentials" >> .env
        
        for var in $env_vars; do
            echo "$var=your_$var_value" >> .env
        done
        
        log_fix "Created .env file with detected environment variables"
    fi
fi

echo -e "\n----- Fixing file permissions -----"

# Fix executable permissions for scripts
if [ -d "scripts" ]; then
    echo "Setting executable permissions for scripts..."
    chmod +x scripts/*.sh 2>/dev/null
    log_fix "Set executable permissions for scripts"
fi

# Make sure manage.py is executable (for Django projects)
if [ -f "manage.py" ]; then
    echo "Setting executable permission for manage.py..."
    chmod +x manage.py
    log_fix "Set executable permission for manage.py"
fi

echo -e "\n----- Fixing database issues -----"

# For Django projects, run migrations
if [ -f "manage.py" ]; then
    echo "Checking if Django migrations are needed..."
    python manage.py showmigrations 2>/dev/null | grep -q "\[ \]"
    if [ $? -eq 0 ]; then
        echo "Running Django migrations..."
        python manage.py migrate 2>/dev/null
        if [ $? -eq 0 ]; then
            log_fix "Applied Django migrations"
        else
            log_fail "Failed to apply Django migrations"
            echo "You may need to run: python manage.py migrate"
        fi
    fi
fi

echo -e "\n----- Fixing code issues -----"

# Fix README.md git merge conflicts
if [ -f "README.md" ]; then
    if grep -q "<<<<<<< HEAD" README.md || grep -q ">>>>>>>" README.md; then
        echo "Fixing git merge conflicts in README.md..."
        sed -i '/<<<<<<< HEAD/,/>>>>>>>/d' README.md
        echo "# MikroTik Monitor (mikk-mmc)" > README.md
        echo "" >> README.md
        echo "Một ứng dụng giám sát toàn diện cho các bộ định tuyến MikroTik." >> README.md
        log_fix "Fixed git merge conflicts in README.md"
    fi
fi

# Check and fix C# files for merge conflicts
for file in $(find . -name "*.cs"); do
    if grep -q "<<<<<<< HEAD" "$file" || grep -q ">>>>>>>" "$file"; then
        echo "Fixing git merge conflicts in $file..."
        sed -i '/<<<<<<< HEAD/,/>>>>>>>/d' "$file"
        log_fix "Fixed git merge conflicts in $file"
    fi
done

# Check and fix XAML files for merge conflicts
for file in $(find . -name "*.xaml"); do
    if grep -q "<<<<<<< HEAD" "$file" || grep -q ">>>>>>>" "$file"; then
        echo "Fixing git merge conflicts in $file..."
        sed -i '/<<<<<<< HEAD/,/>>>>>>>/d' "$file"
        log_fix "Fixed git merge conflicts in $file"
    fi
done

# Fix common Python syntax errors
for file in $(find . -name "*.py"); do
    if ! python3 -m py_compile "$file" 2>/dev/null; then
        echo "Attempting to fix syntax errors in $file..."
        
        # Fix common issues
        
        # 1. Fix missing colons after if/for/def statements
        sed -i 's/^\(\s*\)\(if\|for\|def\|class\|while\|try\|except\|finally\) \(.*\)[^:)"]$/\1\2 \3:/' "$file"
        
        # 2. Fix indentation (replace tabs with 4 spaces)
        sed -i 's/\t/    /g' "$file"
        
        # 3. Fix missing parentheses in print statements (Python 2 to 3)
        sed -i 's/^\(\s*\)print \(.*\)/\1print(\2)/' "$file"
        
        # Check if fixes worked
        if python3 -m py_compile "$file" 2>/dev/null; then
            log_fix "Fixed syntax errors in $file"
        else
            log_fail "Unable to automatically fix all syntax errors in $file"
            echo "You may need to manually check $file for syntax errors"
        fi
    fi
done

# Fix common JavaScript syntax errors
if [ -f "package.json" ]; then
    if command -v eslint &> /dev/null; then
        for file in $(find . -name "*.js" -o -name "*.jsx" -o -name "*.ts" -o -name "*.tsx"); do
            echo "Attempting to fix JavaScript/TypeScript errors in $file..."
            eslint --fix "$file" 2>/dev/null
            if [ $? -eq 0 ]; then
                log_fix "Fixed JavaScript/TypeScript issues in $file"
            fi
        done
    fi
fi

echo -e "\n----- Summary -----"
echo "Fixed $fixed_issues issues"
if [ $failed_fixes -gt 0 ]; then
    echo "Failed to fix $failed_fixes issues"
    echo "Please refer to the documentation for manual fixes."
fi

if [ $fixed_issues -eq 0 ] && [ $failed_fixes -eq 0 ]; then
    echo "No issues were detected or fixed."
fi

if [ $failed_fixes -gt 0 ]; then
    exit 1
else
    exit 0
fi
