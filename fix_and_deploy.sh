#!/bin/bash

echo "Mikk-MMC Debugging and Deployment Tool"
echo "This script will help you debug, fix, and deploy the Mikk-MMC application."

# Tạo thư mục logs nếu chưa tồn tại
mkdir -p logs

# Clone repository nếu thư mục mikk-mmc chưa tồn tại
if [ ! -d "mikk-mmc" ]; then
    echo "Cloning repository..."
    git clone https://github.com/yourusername/mikk-mmc.git
    cd mikk-mmc || exit 1
else
    echo "Repository already exists. Using the existing one."
    cd mikk-mmc || exit 1
    echo "Pulling the latest changes..."
    git pull
    cd ..
fi

# Phân tích cấu trúc repository
echo "Analyzing Repository Structure..."
bash scripts/analyze_repo.sh > logs/repo_analysis.log
cat logs/repo_analysis.log

# Kiểm tra các vấn đề phổ biến
echo "Checking for Common Issues..."
bash scripts/fix_common_issues.sh > logs/fix_issues.log
cat logs/fix_issues.log

# Kiểm tra và thêm enum ConnectionStatus nếu cần
if ! grep -q "public enum ConnectionStatus" mikk-mmc/Models/Enums.cs; then
    echo "Adding missing ConnectionStatus enum..."
    cat >> mikk-mmc/Models/Enums.cs << 'EOL'
    
    /// <summary>
    /// Represents the connection status of a router device
    /// </summary>
    public enum ConnectionStatus
    {
        /// <summary>
        /// The device is disconnected
        /// </summary>
        Disconnected = 0,
        
        /// <summary>
        /// The device is connecting
        /// </summary>
        Connecting = 1,
        
        /// <summary>
        /// The device is connected
        /// </summary>
        Connected = 2,
        
        /// <summary>
        /// The connection failed
        /// </summary>
        Failed = 3
    }
EOL
    echo "Added ConnectionStatus enum successfully."
fi

# Triển khai ứng dụng
echo "Deploying Application..."
# Build phiên bản Windows
bash scripts/deploy_ubuntu.sh > logs/deployment.log

# Build phiên bản Ubuntu console
cd mikk-mmc-ubuntu || {
    echo "Creating Ubuntu console version..."
    mkdir -p mikk-mmc-ubuntu
    cd mikk-mmc-ubuntu
    if [ ! -f "mikk-mmc-ubuntu.csproj" ]; then
        dotnet new console
        # Cập nhật file .csproj với các thư viện cần thiết
        sed -i 's|<RootNamespace>mikk_mmc_ubuntu</RootNamespace>|<RootNamespace>MikroTikMonitor.Console</RootNamespace>|g' mikk-mmc-ubuntu.csproj
        sed -i 's|</PropertyGroup>|<AssemblyName>MikroTikMonitor.Console</AssemblyName>\n  </PropertyGroup>\n\n  <ItemGroup>\n    <PackageReference Include="SSH.NET" Version="2023.0.0" />\n    <PackageReference Include="Newtonsoft.Json" Version="13.0.3" />\n    <PackageReference Include="Lextm.SharpSnmpLib" Version="12.5.2" />\n    <PackageReference Include="Spectre.Console" Version="0.48.0" />\n    <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="8.0.0" />\n    <PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="8.0.0" />\n    <PackageReference Include="Microsoft.Extensions.Logging" Version="8.0.0" />\n    <PackageReference Include="Microsoft.Extensions.Logging.Console" Version="8.0.0" />\n  </ItemGroup>|g' mikk-mmc-ubuntu.csproj
    fi
}

# Build ứng dụng Ubuntu
echo "Building Ubuntu console application..."
dotnet build
cd ..

echo "Process Complete"
echo "Please check the logs directory for detailed information about each step."
echo "If you encountered any issues, please refer to the documentation in the docs directory."

# Hướng dẫn chạy ứng dụng
echo -e "\nTo run the Ubuntu console application, use:"
echo "bash run_ubuntu_app.sh"