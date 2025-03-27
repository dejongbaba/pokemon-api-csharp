# Use an official .NET runtime as base
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base

# Use an official .NET SDK for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy project files
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application and build
COPY . ./
RUN dotnet publish -c Release -o /publish

# Build runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "Pokemon Api.dll"]
