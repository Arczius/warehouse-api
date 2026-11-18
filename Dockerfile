FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build
WORKDIR /src

# Copy project file and restore
COPY ["src/CargoHub.csproj", "src/"]
RUN dotnet restore "src/CargoHub.csproj"

# Copy everything else and publish
COPY . .
RUN dotnet publish "src/CargoHub.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime image (ASP.NET Core)
FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS runtime
WORKDIR /app

# installing dependencies
RUN apk add --no-cache krb5-libs

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "CargoHub.dll"]
