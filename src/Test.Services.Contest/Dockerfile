FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 46556
EXPOSE 44316

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/Test.Services.Contest/Test.Services.Contest.csproj src/Test.Services.Contest/
COPY src/Test.Common/Test.Common.csproj src/Test.Common/
RUN dotnet restore src/Test.Services.Contest/Test.Services.Contest.csproj
COPY . .
WORKDIR /src/src/Test.Services.Contest
RUN dotnet build Test.Services.Contest.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Test.Services.Contest.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Test.Services.SLMM.dll"]
