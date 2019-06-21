FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["FeatureToggle/FeatureToggle.csproj", "FeatureToggle/"]
RUN dotnet restore "FeatureToggle/FeatureToggle.csproj"
COPY . .
WORKDIR "/src/FeatureToggle"
RUN dotnet build "FeatureToggle.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "FeatureToggle.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FeatureToggle.dll"]