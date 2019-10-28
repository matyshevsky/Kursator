FROM mcr.microsoft.com/dotnet/core/runtime:2.1-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["./Kursator/Kursator.csproj", "./Kursator/"]
COPY ["./Library/Library.csproj", "./Library/"]
COPY ["./Domain/Domain.csproj", "./Domain/"]
COPY ["./Repositories/Repositories.csproj", "./Repositories/"]
RUN dotnet restore "Kursator/Kursator.csproj"
COPY . .
WORKDIR "/src/Kursator"
RUN dotnet build "Kursator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kursator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kursator.dll"]