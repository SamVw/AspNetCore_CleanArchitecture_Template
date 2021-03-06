FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Src/WebUI/WebUI.csproj", "Src/WebUI/"]
COPY ["Src/WebUI/Src/Persistence/Persistence.csproj", "Src/WebUI/Src/Persistence/"]
COPY ["Src/WebUI/Src/Application/Application.csproj", "Src/WebUI/Src/Application/"]
COPY ["Src/WebUI/Src/Domain/Domain.csproj", "Src/WebUI/Src/Domain/"]
COPY ["Src/WebUI/Src/Common/Common.csproj", "Src/WebUI/Src/Common/"]
COPY ["Src/WebUI/Src/Infrastructure/Infrastructure.csproj", "Src/WebUI/Src/Infrastructure/"]
RUN dotnet restore "Src/WebUI/WebUI.csproj"
COPY . .
WORKDIR "/src/Src/WebUI"
RUN dotnet build "WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebUI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebUI.dll"]
