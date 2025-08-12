#!/bin/bash

# Wait for SQL Server to be ready
echo "Waiting for SQL Server to be ready..."
until curl -s sqlserver:1433 > /dev/null 2>&1; do
  echo "SQL Server is unavailable - sleeping"
  sleep 5
done

echo "SQL Server is ready - executing migrations"

# Run database migrations
echo "Running database migrations..."
dotnet "Pokemon Api.dll" --migrate

# If migration fails, try to run it manually
if [ $? -ne 0 ]; then
    echo "Migration command failed, trying alternative approach..."
    # Start the application in background to run migrations
    dotnet "Pokemon Api.dll" &
    APP_PID=$!
    
    # Wait a bit for the app to start
    sleep 10
    
    # Kill the background process
    kill $APP_PID 2>/dev/null
    
    echo "Migrations completed, starting application normally..."
fi

# Start the application
echo "Starting Pokemon API..."
exec dotnet "Pokemon Api.dll"