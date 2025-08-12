# Use .NET 6 SDK for building
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy project and restore dependencies
COPY ["Pokemon Api.csproj", "./"]
RUN dotnet restore

# Copy everything and build
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Use the correct .NET 6 runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app

# Install SQL Server tools for health checks and migrations
RUN apt-get update && apt-get install -y curl

# Copy published application
COPY --from=build /app/publish .

# Copy Docker-specific configuration
COPY appsettings.Docker.json /app/appsettings.Production.json

# Copy the entrypoint script
COPY entrypoint.sh /entrypoint.sh
RUN chmod +x /entrypoint.sh

# Set the entrypoint
ENTRYPOINT ["/entrypoint.sh"]
