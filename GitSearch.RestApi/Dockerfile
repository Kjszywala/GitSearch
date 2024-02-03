FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GitSearch.RestApi/GitSearch.RestApi.csproj", "GitSearch.RestApi/"]
RUN dotnet restore "GitSearch.RestApi/GitSearch.RestApi.csproj"
COPY . .
WORKDIR "/src/GitSearch.RestApi"
RUN dotnet build "GitSearch.RestApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GitSearch.RestApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GitSearch.RestApi.dll"]
