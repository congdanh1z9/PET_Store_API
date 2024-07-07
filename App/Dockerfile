# Sử dụng image .NET SDK để build ứng dụng
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy mã nguồn vào container và restore các package
COPY . ./
RUN dotnet restore

# Build ứng dụng
RUN dotnet publish -c Release -o out

# Sử dụng image ASP.NET Core Runtime để chạy ứng dụng
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Expose cổng mà ứng dụng sẽ lắng nghe
EXPOSE 80

# Chạy ứng dụng khi container được khởi động
ENTRYPOINT ["dotnet", "Pet_Store_API.dll"]
