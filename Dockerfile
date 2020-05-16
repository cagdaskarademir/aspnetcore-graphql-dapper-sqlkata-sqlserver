# create the build instance
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

# set workdir for build
WORKDIR /app
COPY /src/. ./

#restore
RUN dotnet restore

# build with configuration
RUN dotnet build ./Smoothie.Web/Smoothie.Web.csproj -c Release

RUN dotnet publish ./Smoothie.Web/Smoothie.Web.csproj -c Release -o /output

# create the runtime instance
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS runtime

COPY --from=build /output .

ENTRYPOINT ["dotnet", "Smoothie.Web.dll"]