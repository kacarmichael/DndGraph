FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore "/app/Dnd.API.Main/Dnd.API.Main.csproj"
RUN dotnet build  "/app/Dnd.API.Main/Dnd.API.Main.csproj" -c Release

