FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 65003
EXPOSE 44379

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/Test.Api/Test.Api.csproj src/Test.Api/
COPY src/Test.Common/Test.Common.csproj src/Test.Common/
RUN dotnet restore src/Test.Api/Test.Api.csproj
COPY . .
WORKDIR /src/src/Test.Api
RUN dotnet build Test.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Test.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Test.Api.dll"]
