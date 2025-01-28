# Usar uma imagem do .NET como base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "SbCredito.Api/SbCredito.Api.csproj"
RUN dotnet build "SbCredito.Api/SbCredito.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SbCredito.Api/SbCredito.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SbCredito.Api.dll"]
