FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy project file and restore
COPY ["CargoHub.csproj", "./"]
RUN dotnet restore "CargoHub.csproj"

# Copy everything else and publish
COPY . .
RUN dotnet publish "CargoHub.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime image (ASP.NET Core)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "CargoHub.dll"]
