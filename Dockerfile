#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/ImageViewer.Api/ImageViewer.Api.csproj", "src/ImageViewer.Api/"]
COPY ["src/ImageViewer.Api.Model/ImageViewer.Api.Model.csproj", "src/ImageViewer.Api.Model/"]
COPY ["src/ImageViewer.AutoMapper/ImageViewer.AutoMapper.csproj", "src/ImageViewer.AutoMapper/"]
COPY ["src/ImageViewer.DataAccess/ImageViewer.DataAccess.csproj", "src/ImageViewer.DataAccess/"]
COPY ["src/ImageViewer.Domain/ImageViewer.Domain.csproj", "src/ImageViewer.Domain/"]
COPY ["src/ImageViewer.Infrastructure/ImageViewer.Infrastructure.csproj", "src/ImageViewer.Infrastructure/"]
COPY ["src/ImageViewer.UseCases/ImageViewer.UseCases.csproj", "src/ImageViewer.UseCases/"]
COPY ["src/ImageViewer.Validation/ImageViewer.Validation.csproj", "src/ImageViewer.Validation/"]
RUN dotnet restore "src/ImageViewer.Api/ImageViewer.Api.csproj"
COPY . .
WORKDIR "/src/src/ImageViewer.Api"
RUN dotnet build "ImageViewer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ImageViewer.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ImageViewer.Api.dll"]