FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MetaFormsBuilder.Web/MetaFormsBuilder.Web.csproj", "MetaFormsBuilder.Web/"]
COPY ["MetaFormsBuilder.Data/MetaFormsBuilder.Data.csproj", "MetaFormsBuilder.Data/"]
COPY ["MetaFormsBuilder.Domain/MetaFormsBuilder.Domain.csproj", "MetaFormsBuilder.Domain/"]
RUN dotnet restore "MetaFormsBuilder.Web/MetaFormsBuilder.Web.csproj"
COPY . .
WORKDIR "/src/MetaFormsBuilder.Web"
RUN dotnet build "MetaFormsBuilder.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MetaFormsBuilder.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MetaFormsBuilder.Web.dll"]
