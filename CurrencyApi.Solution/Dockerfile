# Build Stage


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base

ENV DOTNET_URLS=http://+:5000

WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./CurrencyApi/CurrencyApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./CurrencyApi/CurrencyApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./CurrencyApi/CurrencyApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CurrencyApi.dll"]