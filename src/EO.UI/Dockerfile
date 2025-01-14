#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["EO.UI/EO.UI.csproj", "EO.UI/"]
COPY ["EO.Domain/EO.Domain.csproj", "EO.Domain/"]
COPY ["EO.Application/EO.Application.csproj", "EO.Application/"]
COPY ["EO.Infra/EO.Infra.csproj", "EO.Infra/"]
RUN dotnet restore "EO.UI/EO.UI.csproj"
COPY . .
WORKDIR "/src/EO.UI"
RUN dotnet build "EO.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EO.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EO.UI.dll"]