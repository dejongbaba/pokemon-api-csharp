# Pokemon API Docker Setup

This project contains a Pokemon API with SQL Server database running in Docker containers.

## Prerequisites

- Docker Desktop installed and running
- Docker Compose

## Getting Started

### 1. Build and Run with Docker Compose

```bash
docker-compose up --build
```

This command will:
- Create a custom Docker network for the services
- Start SQL Server container with the Pokemon database
- Build and start the Pokemon API container
- Automatically run database migrations
- Seed the database with initial data

### 2. Access the Application

- **API**: http://localhost:5000
- **Swagger UI**: http://localhost:5000/swagger
- **HTTPS**: https://localhost:5001

### 3. Database Connection

- **Server**: localhost,1433
- **Database**: Pokemon
- **Username**: sa
- **Password**: YourStrong@Passw0rd

## Services

### SQL Server
- Container: `pokemon-sqlserver`
- Port: 1433
- Network: `pokemon-network`
- Health checks enabled

### Pokemon API
- Container: `pokemon-api`
- Ports: 5000 (HTTP), 5001 (HTTPS)
- Network: `pokemon-network`
- Depends on SQL Server health check

## Features

- **Automatic Database Migration**: The application automatically applies Entity Framework migrations on startup
- **Data Seeding**: Initial data is seeded if the database is empty
- **Health Checks**: SQL Server container includes health checks
- **Network Isolation**: Services communicate through a dedicated Docker network
- **Persistent Data**: SQL Server data is persisted using Docker volumes

## Stopping the Application

```bash
docker-compose down
```

To remove volumes (delete database data):
```bash
docker-compose down -v
```

## Troubleshooting

1. **SQL Server not ready**: The API container waits for SQL Server to be healthy before starting
2. **Migration issues**: Check the API container logs for migration errors
3. **Port conflicts**: Ensure ports 1433, 5000, and 5001 are not in use by other applications

## Development

For local development without Docker, use the original connection string in `appsettings.json` which points to LocalDB.