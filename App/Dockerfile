# Use the SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./

# Restore as distinct layers
RUN dotnet restore

# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App

# Copy the published output from build stage
COPY --from=build-env /App/out .

# Specify the entry point for the application
ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]