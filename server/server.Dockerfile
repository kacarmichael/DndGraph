FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

RUN mkdir -p /server
WORKDIR /server

COPY ./Dnd.API.Main /server/Dnd.API.Main
COPY ./Dnd.Application.Abstractions /server/Dnd.Application.Abstractions 
COPY ./Dnd.Application.Auth /server/Dnd.Application.Auth
COPY ./Dnd.Application.Logging /server/Dnd.Application.Logging
COPY ./Dnd.Application.Main /server/Dnd.Application.Main
COPY ./Dnd.Core.Main /server/Dnd.Core.Main

#WORKDIR /server/Dnd.API.Main

RUN dotnet restore ./Dnd.API.Main

RUN dotnet publish -o out ./Dnd.API.Main

FROM mcr.microsoft.com/dotnet/aspnet:9.0

WORKDIR /server

COPY --from=build /server/out .

ENTRYPOINT ["./Dnd.API.Main"]