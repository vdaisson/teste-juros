#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/CalculaJuros.Api/CalculaJuros.Api.csproj", "src/CalculaJuros.Api/"]
COPY ["src/CalculaJuros.Domain/CalculaJuros.Domain.csproj", "src/CalculaJuros.Domain/"]
COPY ["src/CalculaJuros.Domain.Service/CalculaJuros.Domain.Service.csproj", "src/CalculaJuros.Domain.Service/"]
RUN dotnet restore "src/CalculaJuros.Api/CalculaJuros.Api.csproj"
COPY . .
WORKDIR "/src/src/CalculaJuros.Api"
RUN dotnet build "CalculaJuros.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalculaJuros.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculaJuros.Api.dll"]
