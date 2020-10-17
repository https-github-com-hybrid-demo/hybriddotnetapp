FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base

WORKDIR /app
ENV ASPNETCORE_URLS http://+:8000
EXPOSE 8000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["webapi.dotnet.csproj", ""]
RUN dotnet restore "./webapi.dotnet.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "webapi.dotnet.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "webapi.dotnet.csproj" -c Release -o /app/publish

# REMOVE: to test snyk cve scanning
ENV SECRET_KEY JHGKJHG23123%^$%JKHDFKHSDKJFASJKD

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "webapi.dotnet.dll"]