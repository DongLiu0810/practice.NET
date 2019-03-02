FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY TodoList.Web/TodoList.Web.csproj TodoList.Web/
COPY TodoList.Service/TodoList.Service.csproj TodoList.Service/
COPY ClassLibrary2/TodoList.Repository.csproj ClassLibrary2/
RUN dotnet restore TodoList.Web/TodoList.Web.csproj
COPY . .
WORKDIR /src/TodoList.Web
RUN dotnet build TodoList.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish TodoList.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TodoList.Web.dll"]
