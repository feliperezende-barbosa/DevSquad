#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#WORKDIR /src/
#COPY ["DevSquad.Api.Squads/DevSquad.Api.Squads.csproj", "."]
COPY ["./DevSquad.Api.Squads/DevSquad.Api.Squads.csproj", "."]
RUN dotnet restore "./DevSquad.Api.Squads.csproj"
COPY . .
WORKDIR "/src/DevSquad.Api.Squads/"
RUN dotnet build "DevSquad.Api.Squads.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DevSquad.Api.Squads.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevSquad.Api.Squads.dll"]
