#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BookCatalogAPI/BookCatalogAPI.csproj", "BookCatalogAPI/"]
COPY ["BookCatalogAPI_Domains/BookCatalogAPI_Domains.csproj", "BookCatalogAPI_Domains/"]
COPY ["BookCatalogAPI_Infraestructure/BookCatalogAPI_Infraestructure.csproj", "BookCatalogAPI_Infraestructure/"]
COPY ["BookCatalogAPI_Services/BookCatalogAPI_Services.csproj", "BookCatalogAPI_Services/"]
RUN dotnet restore "BookCatalogAPI/BookCatalogAPI.csproj"
COPY . .
WORKDIR "/src/BookCatalogAPI"
RUN dotnet build "BookCatalogAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookCatalogAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "BookCatalogAPI.dll"]
# Usa porta dinâmica do heroku
CMD ASPNETCORE_URLS="http://*:$PORT" dotnet BookCatalogAPI.dll