# ─── STAGE 1: Build ───────────────────────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copia el archivo de proyecto y restaura dependencias (capa cacheada)
COPY ["persona-api/persona-api.csproj", "persona-api/"]
RUN dotnet restore "persona-api/persona-api.csproj"

# Copia el resto del código y compila
COPY . .
RUN dotnet build "persona-api/persona-api.csproj" -c Release -o /app/build

# ─── STAGE 2: Publish ─────────────────────────────────────────────────────────
FROM build AS publish
RUN dotnet publish "persona-api/persona-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# ─── STAGE 3: Runtime ─────────────────────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Puerto expuesto por defecto en ASP.NET Core
EXPOSE 8080

# Usuario no-root por seguridad
USER app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "persona-api.dll"]
