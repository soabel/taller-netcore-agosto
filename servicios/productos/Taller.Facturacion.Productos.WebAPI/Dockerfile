#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["servicios/productos/Taller.Facturacion.Productos.WebAPI/Taller.Facturacion.Productos.WebAPI.csproj", "servicios/productos/Taller.Facturacion.Productos.WebAPI/"]
COPY ["servicios/productos/Taller.Facturacion.Productos.Domain/Taller.Facturacion.Productos.Domain.csproj", "servicios/productos/Taller.Facturacion.Productos.Domain/"]
COPY ["servicios/productos/Taller.Facturacion.Productos.Application/Taller.Facturacion.Productos.Application.csproj", "servicios/productos/Taller.Facturacion.Productos.Application/"]
COPY ["servicios/productos/Taller.Factguracion.Productos.Infraestucture.Persistence/Taller.Facturacion.Productos.Infraestucture.Persistence.csproj", "servicios/productos/Taller.Factguracion.Productos.Infraestucture.Persistence/"]
COPY ["servicios/productos/Taller.Facturacion.Productos.Infraestructure.Core/Taller.Facturacion.Productos.Infraestructure.Core.csproj", "servicios/productos/Taller.Facturacion.Productos.Infraestructure.Core/"]
RUN dotnet restore "servicios/productos/Taller.Facturacion.Productos.WebAPI/Taller.Facturacion.Productos.WebAPI.csproj"
COPY . .
WORKDIR "/src/servicios/productos/Taller.Facturacion.Productos.WebAPI"
RUN dotnet build "Taller.Facturacion.Productos.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Taller.Facturacion.Productos.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Taller.Facturacion.Productos.WebAPI.dll"]
