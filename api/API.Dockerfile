FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5218

ENV ASPNETCORE_URLS=http://+:5218



FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG configuration=Release
RUN apt-get update && apt-get install iputils-ping -y
WORKDIR /app/src
COPY . .
# COPY ["Dnd.API.Main", "/app/server/Dnd.API.Main/"]
# COPY ["Dnd.Application.Main", "/app/server/Dnd.Application.Main/"]
# COPY ["Dnd.Application.Auth", "/app/server/Dnd.Application.Auth/"]
# COPY ["Dnd.Application.Logging", "/app/server/Dnd.Application.Logging/"]
# COPY ["Dnd.Application.Abstractions", "/app/server/Dnd.Application.Abstractions/"]
# COPY ["Dnd.Core.Main", "/app/server/Dnd.Core.Main/"]

RUN dotnet restore "/app/src/Dnd.API.Main/Dnd.API.Main.csproj"

RUN chown -R app /app
RUN chmod -R 777 /app
USER app
WORKDIR "/app/src/Dnd.API.Main"
RUN dotnet build "Dnd.API.Main.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Dnd.API.Main.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app/src
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dnd.API.Main.dll"]
