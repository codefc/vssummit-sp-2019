FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["FeatureToggle.csproj", "./"]
RUN dotnet restore "./FeatureToggle.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "FeatureToggle.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "FeatureToggle.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FeatureToggle.dll"]
