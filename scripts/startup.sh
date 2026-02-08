#!/bin/bash

echo "🚀 Starting CoreModelSeperation API..."

# Wait for SQL Server to be ready
echo "⏳ Waiting for SQL Server..."
for i in {1..30}; do
    if /opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P "Passw0rd@123" -Q "SELECT 1" &> /dev/null; then
        echo "✅ SQL Server is ready"
        break
    else
        echo "⏳ Waiting for SQL Server... ($i/30)"
        sleep 2
    fi
done

# Wait for Redis to be ready
echo "⏳ Waiting for Redis..."
for i in {1..10}; do
    if redis-cli -h redis ping &> /dev/null; then
        echo "✅ Redis is ready"
        break
    else
        echo "⏳ Waiting for Redis... ($i/10)"
        sleep 2
    fi
done

# Run database migrations (if using EF Core)
# echo "🔄 Running database migrations..."
# dotnet ef database update

# Start the application
echo "🚀 Starting .NET Core application..."
exec dotnet CoreModelSeperation.dll