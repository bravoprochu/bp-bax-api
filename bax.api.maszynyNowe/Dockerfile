FROM mcr.microsoft.com/dotnet/core/sdk:2.2 as build
WORKDIR /app
COPY  ./bax.api.csproj .
RUN dotnet restore
COPY . ./
RUN dotnet build
RUN dotnet publish -o publish
RUN echo "ls: " && echo $(ls -1)

FROM mcr.microsoft.com/dotnet/core/runtime:2.2
WORKDIR /app
COPY --from=build /app/publish .
RUN echo "ls2: " && echo $(ls -1)
ENTRYPOINT ["dotnet", "bax.api.dll"]