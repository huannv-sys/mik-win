#!/bin/bash

# This script analyzes the structure of the mikk-mmc repository and identifies its tech stack

echo "========== Repository Analysis =========="
echo "Analyzing repository structure and dependencies..."

# Check if we're in the right directory
if [ ! -d ".git" ]; then
    echo "ERROR: This doesn't appear to be a git repository. Make sure you're in the mikk-mmc directory."
    exit 1
fi

# Detect language and frameworks
echo -e "\n----- Detecting Technology Stack -----"

# Check for common file extensions to detect programming languages
echo "Languages detected:"
if ls *.py &> /dev/null; then
    echo "- Python"
    # Check for Python frameworks
    if grep -q "django" requirements.txt 2>/dev/null; then
        echo "  - Django framework"
    fi
    if grep -q "flask" requirements.txt 2>/dev/null; then
        echo "  - Flask framework"
    fi
    if grep -q "fastapi" requirements.txt 2>/dev/null; then
        echo "  - FastAPI framework"
    fi
fi

if ls *.js *.jsx *.ts *.tsx &> /dev/null; then
    echo "- JavaScript/TypeScript"
    # Check for JS frameworks
    if [ -f "package.json" ]; then
        if grep -q "react" package.json; then
            echo "  - React framework"
        fi
        if grep -q "vue" package.json; then
            echo "  - Vue.js framework"
        fi
        if grep -q "angular" package.json; then
            echo "  - Angular framework"
        fi
        if grep -q "next" package.json; then
            echo "  - Next.js framework"
        fi
    fi
fi

if ls *.java &> /dev/null; then
    echo "- Java"
    if [ -f "pom.xml" ]; then
        echo "  - Maven build system"
    fi
    if [ -f "build.gradle" ]; then
        echo "  - Gradle build system"
    fi
fi

if ls *.php &> /dev/null; then
    echo "- PHP"
    if [ -f "composer.json" ]; then
        echo "  - Composer dependency manager"
    fi
fi

# Database detection
echo -e "\n----- Database Detection -----"
if grep -r "mysql" --include="*.{py,js,java,php,json,xml,yml}" . &> /dev/null; then
    echo "- MySQL database references found"
fi
if grep -r "postgresql\|postgres" --include="*.{py,js,java,php,json,xml,yml}" . &> /dev/null; then
    echo "- PostgreSQL database references found"
fi
if grep -r "mongodb" --include="*.{py,js,java,php,json,xml,yml}" . &> /dev/null; then
    echo "- MongoDB references found"
fi
if grep -r "sqlite" --include="*.{py,js,java,php,json,xml,yml}" . &> /dev/null; then
    echo "- SQLite references found"
fi

# Dependency files
echo -e "\n----- Dependency Files -----"
if [ -f "requirements.txt" ]; then
    echo "- Python requirements.txt found"
    echo "  Top dependencies:"
    head -5 requirements.txt
fi
if [ -f "package.json" ]; then
    echo "- Node.js package.json found"
    echo "  Project name: $(grep -m 1 '"name":' package.json | cut -d '"' -f 4)"
    echo "  Main dependencies:"
    grep -A 10 '"dependencies":' package.json | grep -v "dependencies" | grep -v "}" | head -5
fi
if [ -f "composer.json" ]; then
    echo "- PHP composer.json found"
fi
if [ -f "pom.xml" ]; then
    echo "- Java Maven pom.xml found"
fi
if [ -f "build.gradle" ]; then
    echo "- Java Gradle build.gradle found"
fi

# Configuration files
echo -e "\n----- Configuration Files -----"
if [ -f "Dockerfile" ]; then
    echo "- Dockerfile found"
fi
if [ -f "docker-compose.yml" ] || [ -f "docker-compose.yaml" ]; then
    echo "- Docker Compose configuration found"
fi
if [ -d ".github/workflows" ]; then
    echo "- GitHub Actions workflows found"
fi
if [ -f ".travis.yml" ]; then
    echo "- Travis CI configuration found"
fi
if [ -f ".gitlab-ci.yml" ]; then
    echo "- GitLab CI configuration found"
fi

# Directory structure
echo -e "\n----- Directory Structure -----"
echo "Top-level directories:"
ls -la | grep "^d" | awk '{print "- " $9}' | grep -v "^\.$" | grep -v "^\.\.$" | grep -v "^\.git$"

# Look for README
echo -e "\n----- Documentation -----"
if [ -f "README.md" ]; then
    echo "- README.md found"
    echo "  First 5 lines:"
    head -5 README.md
elif [ -f "README" ]; then
    echo "- README found"
    echo "  First 5 lines:"
    head -5 README
else
    echo "- No README found"
fi

# Check for common error patterns
echo -e "\n----- Potential Issues -----"
missing_deps=0
syntax_errors=0
config_issues=0

# Look for potential Python issues
if ls *.py &> /dev/null; then
    echo "Checking Python files..."
    # Check for syntax errors
    for file in $(find . -name "*.py"); do
        if ! python3 -m py_compile "$file" 2>/dev/null; then
            echo "  - Syntax error in $file"
            syntax_errors=$((syntax_errors+1))
        fi
    done
    
    # Check if requirements.txt exists
    if [ ! -f "requirements.txt" ]; then
        echo "  - Missing requirements.txt file"
        missing_deps=$((missing_deps+1))
    fi
fi

# Look for potential JavaScript issues
if [ -f "package.json" ]; then
    echo "Checking JavaScript/Node.js setup..."
    # Check if node_modules exists
    if [ ! -d "node_modules" ]; then
        echo "  - node_modules directory not found, dependencies need to be installed"
        missing_deps=$((missing_deps+1))
    fi
    
    # Check for package-lock.json or yarn.lock
    if [ ! -f "package-lock.json" ] && [ ! -f "yarn.lock" ]; then
        echo "  - Neither package-lock.json nor yarn.lock found, which might cause dependency issues"
        config_issues=$((config_issues+1))
    fi
fi

# Look for environment configuration
if [ -f ".env.example" ] && [ ! -f ".env" ]; then
    echo "  - .env file missing (but .env.example exists)"
    config_issues=$((config_issues+1))
fi

# Summary
echo -e "\n----- Analysis Summary -----"
echo "Potential issues found:"
echo "- Missing dependencies: $missing_deps"
echo "- Syntax errors: $syntax_errors"
echo "- Configuration issues: $config_issues"

echo -e "\nRecommended actions:"
if [ $missing_deps -gt 0 ]; then
    echo "- Install missing dependencies"
fi
if [ $syntax_errors -gt 0 ]; then
    echo "- Fix syntax errors in code files"
fi
if [ $config_issues -gt 0 ]; then
    echo "- Set up proper configuration files"
fi

echo -e "\nAnalysis complete. For more details, check the documentation in the docs directory."
