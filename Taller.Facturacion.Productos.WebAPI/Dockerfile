#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Taller.Facturacion.Productos.WebAPI/Taller.Facturacion.Productos.WebAPI.csproj", "Taller.Facturacion.Productos.WebAPI/"]
COPY ["Taller.Facturacion.Productos.Domain/Taller.Facturacion.Productos.Domain.csproj", "Taller.Facturacion.Productos.Domain/"]
COPY ["Taller.Facturacion.Productos.Application/Taller.Facturacion.Productos.Application.csproj", "Taller.Facturacion.Productos.Application/"]
COPY ["Taller.Factguracion.Productos.Infraestucture.Persistence/Taller.Facturacion.Productos.Infraestucture.Persistence.csproj", "Taller.Factguracion.Productos.Infraestucture.Persistence/"]
COPY ["Taller.Facturacion.Productos.Infraestructure.Core/Taller.Facturacion.Productos.Infraestructure.Core.csproj", "Taller.Facturacion.Productos.Infraestructure.Core/"]
RUN dotnet restore "Taller.Facturacion.Productos.WebAPI/Taller.Facturacion.Productos.WebAPI.csproj"
COPY . .
WORKDIR "/src/Taller.Facturacion.Productos.WebAPI"
RUN dotnet build "Taller.Facturacion.Productos.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Taller.Facturacion.Productos.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Taller.Facturacion.Productos.WebAPI.dll"]
