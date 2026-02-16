# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy entire solution (because context: .)
COPY . .

# Go into Web API project
WORKDIR /src/Test_REST_Service

RUN dotnet restore Test_REST_Service.csproj
RUN dotnet publish Test_REST_Service.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "Test_REST_Service.dll"]
