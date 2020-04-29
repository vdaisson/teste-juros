#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/TaxaJuros/TaxaJuros.Api.csproj", "src/TaxaJuros/"]
COPY ["src/TaxaJuros.Infrastructure.Data/TaxaJuros.Infrastructure.Data.csproj", "src/TaxaJuros.Infrastructure.Data/"]
COPY ["src/TaxaJuros.Domain/TaxaJuros.Domain.csproj", "src/TaxaJuros.Domain/"]
COPY ["src/TaxaJuros.Domain.Service/TaxaJuros.Domain.Service.csproj", "src/TaxaJuros.Domain.Service/"]
RUN dotnet restore "src/TaxaJuros/TaxaJuros.Api.csproj"
COPY . .
WORKDIR "/src/src/TaxaJuros"
RUN dotnet build "TaxaJuros.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaxaJuros.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaxaJuros.Api.dll"]
