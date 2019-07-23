FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-alpine AS build
WORKDIR /src
COPY src/MovieCup.Api/MovieCup.Api.csproj MovieCup.Api/
COPY src/MovieCup.Domain/MovieCup.Domain.csproj MovieCup.Domain/
COPY src/MovieCup.Infra.CrossCutting.IoC/MovieCup.Infra.CrossCutting.IoC.csproj MovieCup.Infra.CrossCutting.IoC/
COPY src/MovieCup.Infra.Data/MovieCup.Infra.Data.csproj MovieCup.Infra.Data/
COPY src/MovieCup.Shared/MovieCup.Shared.csproj MovieCup.Shared/

RUN dotnet restore MovieCup.Api/MovieCup.Api.csproj
COPY ./src .
WORKDIR /src/MovieCup.Api
RUN dotnet build MovieCup.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish MovieCup.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MovieCup.Api.dll"]