FROM mcr.microsoft.com/dotnet/core/sdk:5.0.100-preview-alpine
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1.411-alpine3.13
#RUN apk update && apk add ca-certificates && update-ca-certificates && apk add openssl

RUN export DOTNET_ROOT=/usr/share/dotnet && export PATH=$PATH:/usr/share/dotnet 

COPY sysinfo.csproj /webapp/sysinfo.csproj
COPY appsettings.json /webapp/appsettings.json
COPY /src/Program.cs /webapp/src/Program.cs
COPY /properties/launchSettings.json /webapp/properties/launchSettings.json

RUN dotnet build /webapp/sysinfo.csproj -c Release -o /webapp/bin

WORKDIR /webapp/bin
#ENV replace TCP PORT 5000 by 8080 launchSettings.json
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "sysinfo.dll"]
