FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MTDocker.csproj", "MTDocker/"]
RUN dotnet restore "MTDocker/MTDocker.csproj"

COPY . MTDocker/.
RUN dotnet publish -c Release -o /app MTDocker/MTDocker.csproj 

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS publish
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "MTDocker.dll"]