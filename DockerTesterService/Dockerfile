#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 443
EXPOSE 80


FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["DockerTesterService/DockerTesterService.csproj", "DockerTesterService/"]
RUN dotnet restore "DockerTesterService/DockerTesterService.csproj"
COPY . .
WORKDIR "/src/DockerTesterService"
RUN dotnet build "DockerTesterService.csproj" -c Release -o /app/build
EXPOSE 443
EXPOSE 80

FROM build AS publish
RUN dotnet publish "DockerTesterService.csproj" -c Release -o /app/publish
EXPOSE 443
EXPOSE 80

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerTesterService.dll", "--environment=Development"]
EXPOSE 443
EXPOSE 80