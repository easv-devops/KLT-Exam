# Stage 1: Build Angular application
FROM node:18 AS buildFrontend
WORKDIR /app
COPY ./Frontend /app
RUN npm install
RUN node_modules/.bin/ng build

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./backend/api/api.csproj", "api/"]
RUN dotnet restore "/api/api.csproj"
COPY . .
WORKDIR "/src/api"
RUN dotnet build "api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=buildFrontend /app/www ./www
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api.dll"]
