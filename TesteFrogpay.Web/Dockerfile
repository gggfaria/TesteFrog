FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TesteFrogpay.Web/TesteFrogpay.Web.csproj", "TesteFrogpay.Web/"]
COPY ["TesteFrogpay.Domain/TesteFrogpay.Domain.csproj", "TesteFrogpay.Domain/"]
COPY ["TesteFrogpay.Infra/TesteFrogpay.Infra.csproj", "TesteFrogpay.Infra/"]
COPY ["TesteFrogpay.Services/TesteFrogpay.Services.csproj", "TesteFrogpay.Services/"]
RUN dotnet restore "TesteFrogpay.Web/TesteFrogpay.Web.csproj"
COPY . .
WORKDIR "/src/TesteFrogpay.Web"
RUN dotnet build "TesteFrogpay.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TesteFrogpay.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TesteFrogpay.Web.dll"]
