FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Fase1.Contatos.Api/Fase1.Contatos.Api.csproj", "src/Fase1.Contatos.Api/"]
COPY ["src/Fase1.Contatos.Application/Fase1.Contatos.Application.csproj", "src/Fase1.Contatos.Application/"]
COPY ["src/Fase1.Contatos.Domain/Fase1.Contatos.Domain.csproj", "src/Fase1.Contatos.Domain/"]
COPY ["src/Fase1.Infra.CrossCutting/Fase1.Infra.CrossCutting.csproj", "src/Fase1.Infra.CrossCutting/"]
COPY ["src/Fase1.Commons.Domain/Fase1.Commons.Domain.csproj", "src/Fase1.Commons.Domain/"]
COPY ["src/Fase1.Contatos.Infra.Data/Fase1.Contatos.Infra.Data.csproj", "src/Fase1.Contatos.Infra.Data/"]
RUN dotnet restore "src/Fase1.Contatos.Api/Fase1.Contatos.Api.csproj"
COPY . .
WORKDIR "/src/src/Fase1.Contatos.Api"
RUN dotnet build "Fase1.Contatos.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Fase1.Contatos.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fase1.Contatos.Api.dll"]
