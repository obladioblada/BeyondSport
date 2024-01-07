FROM mcr.microsoft.com/dotnet/aspnet:8.0 as base
WORKDIR /app

RUN echo "Building project"

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
COPY . /src
WORKDIR /src
RUN ls
RUN dotnet build "BeyondSport.csproj" -c Release -o /app/build

RUN echo "Publishing project"

FROM build AS publish
RUN dotnet publish "BeyondSport.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN echo "Starting application..."
ENTRYPOINT ["dotnet", "BeyondSport.dll"]