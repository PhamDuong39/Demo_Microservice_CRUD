#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Product.CoreAPI/Product.CoreAPI.csproj", "Product.CoreAPI/"]
COPY ["Product.Application/Product.Application.csproj", "Product.Application/"]
COPY ["Product.Common/Product.Common.csproj", "Product.Common/"]
COPY ["Product.Model/Product.Model.csproj", "Product.Model/"]
COPY ["Product.Domain/Product.Domain.csproj", "Product.Domain/"]
COPY ["Product.Infragstructure/Product.Infragstructure.csproj", "Product.Infragstructure/"]
RUN dotnet restore "Product.CoreAPI/Product.CoreAPI.csproj"
COPY . .
WORKDIR "/src/Product.CoreAPI"
RUN dotnet build "Product.CoreAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Product.CoreAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Product.CoreAPI.dll"]