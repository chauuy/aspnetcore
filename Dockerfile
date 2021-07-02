FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine3.11
#MAJ cert pour wget
RUN apk update && apk add ca-certificates && update-ca-certificates && apk add openssl

RUN export DOTNET_ROOT=/usr/share/dotnet && export PATH=$PATH:/usr/share/dotnet 

COPY hello-world.csproj /webapp/hello-world.csproj
COPY appsettings.json /webapp/appsettings.json
COPY /src/Program.cs /webapp/src/Program.cs
#COPY launchSettings.json /webapp/Properties/launchSettings.json

RUN dotnet build /webapp/hello-world.csproj -c Release -o /webapp/bin

WORKDIR /webapp/bin
#ENV replace appsettings.json
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "hello-world.dll"]
#RUN dotnet run /webapp/bin/hello-world.dll &
