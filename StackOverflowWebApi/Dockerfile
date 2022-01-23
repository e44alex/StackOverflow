FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /src
COPY *.csproj ./
RUN dotnet restore "StackOverflowWebApi/StackOverflowWebApi.csproj"
COPY . .
WORKDIR "/src/StackOverflowWebApi"
RUN dotnet build "StackOverflowWebApi.csproj" -c Release -o /app/build
EXPOSE 80/tcp

FROM build-env AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StackOverflowWebApi.dll"]