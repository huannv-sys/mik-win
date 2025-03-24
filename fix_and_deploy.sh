#!/bin/bash

# Text formatting
BOLD='\033[1m'
GREEN='\033[0;32m'
YELLOW='\033[0;33m'
RED='\033[0;31m'
NC='\033[0m' # No Color

echo -e "${BOLD}Mikk-MMC Debugging and Deployment Tool${NC}"
echo "This script will help you debug, fix, and deploy the Mikk-MMC application."
echo ""

# Create necessary directories
mkdir -p logs

# Step 1: Clone the repository if it doesn't exist
if [ ! -d "mikk-mmc" ]; then
    echo -e "${YELLOW}Cloning the repository...${NC}"
    git clone https://github.com/huannv-sys/mikk-mmc.git
    if [ $? -ne 0 ]; then
        echo -e "${RED}Failed to clone repository. Please check the URL and your internet connection.${NC}"
        exit 1
    fi
    cd mikk-mmc
else
    echo -e "${YELLOW}Repository already exists. Using the existing one.${NC}"
    cd mikk-mmc
    echo -e "${YELLOW}Pulling the latest changes...${NC}"
    git pull
fi

# Step 2: Analyze the repository
echo -e "\n${BOLD}Analyzing Repository Structure...${NC}"
cd ..
bash scripts/analyze_repo.sh > logs/repo_analysis.log
if [ $? -ne 0 ]; then
    echo -e "${RED}Repository analysis failed. See logs/repo_analysis.log for details.${NC}"
else
    echo -e "${GREEN}Repository analysis complete. Results saved to logs/repo_analysis.log${NC}"
    cat logs/repo_analysis.log
fi
cd mikk-mmc

# Step 3: Detect and fix common issues
echo -e "\n${BOLD}Checking for Common Issues...${NC}"
cd ..
bash scripts/fix_common_issues.sh > logs/fix_issues.log
if [ $? -ne 0 ]; then
    echo -e "${RED}Some issues could not be fixed automatically. See logs/fix_issues.log for details.${NC}"
else
    echo -e "${GREEN}Fixed common issues. Results saved to logs/fix_issues.log${NC}"
    cat logs/fix_issues.log
fi
cd mikk-mmc

# Step 4: Deploy the application
echo -e "\n${BOLD}Deploying Application...${NC}"
cd ..
bash scripts/deploy_ubuntu.sh > logs/deployment.log
if [ $? -ne 0 ]; then
    echo -e "${RED}Deployment failed. See logs/deployment.log for details.${NC}"
else
    echo -e "${GREEN}Deployment completed successfully. Results saved to logs/deployment.log${NC}"
    cat logs/deployment.log
fi
cd mikk-mmc

echo -e "\n${BOLD}Process Complete${NC}"
echo "Please check the logs directory for detailed information about each step."
echo "If you encountered any issues, please refer to the documentation in the docs directory."
