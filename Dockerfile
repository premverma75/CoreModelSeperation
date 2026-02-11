# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["CoreModelSeperation.csproj", "."]
RUN dotnet restore "CoreModelSeperation.csproj"

# Copy everything else and build
COPY . .
RUN dotnet build "CoreModelSeperation.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "CoreModelSeperation.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Install curl for health checks and debugging
RUN apt-get update && \
    apt-get install -y curl && \
    rm -rf /var/lib/apt/lists/*

# Create logs directory with proper permissions
RUN mkdir -p /app/Logs && \
    chmod 777 /app/Logs

# Copy published application
COPY --from=publish /app/publish .

# Expose ports
EXPOSE 80
EXPOSE 443

# Set environment variables
ENV ASPNETCORE_URLS=http://+:80;https://+:443
ENV ASPNETCORE_ENVIRONMENT=Development

# Entry point
ENTRYPOINT ["dotnet", "CoreModelSeperation.dll"]