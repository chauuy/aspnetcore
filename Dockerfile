FROM mcr.microsoft.com/dotnet/core/runtime:3.1-alpine3.11
#MAJ cert pour wget
RUN apk update && apk add ca-certificates && update-ca-certificates && apk add openssl

# Install ASP.NET Core
RUN wget -O aspnetcore.tar.gz https://download.visualstudio.microsoft.com/download/pr/68df043e-52ef-414c-99bf-35dfe2c83759/ea6c41fb0ec443a01fbeccf348d64775/aspnetcore-runtime-3.1.4-linux-musl-x64.tar.gz \
    && aspnetcore_sha512='f60e9226a5b399470479fd6fdebd03442b0440128be1090adcbe473dba46a3e7a57a9e59b4abff96214e0dd0b1123c67fe764b74c61de1cb35c8b8ac45767eb9' \
    && echo "$aspnetcore_sha512  aspnetcore.tar.gz" | sha512sum -c - \
    && tar -ozxf aspnetcore.tar.gz -C /usr/share/dotnet ./shared/Microsoft.AspNetCore.App \
    && rm aspnetcore.tar.gz


# Install .NET Core SDK v3.1.104 
RUN wget -O dotnet-sdk.tar.gz https://download.visualstudio.microsoft.com/download/pr/6fc7ce85-b14f-4718-9a9e-cdcf3c74f1ed/312edf594fe97da6ccdede646e18d479/dotnet-sdk-3.1.104-linux-musl-x64.tar.gz \
&& dotnetSDK_sha512='d4d39a46405d442d90e43c75c28ca2b4464a487dca5f48aa94e02872820af3e50b28ee3fe836dc6d2a7f2063730e08716dfc6281d78f04720144c99ab4c4ccd1' \
&& echo "$dotnetSDK_sha512  dotnet-sdk.tar.gz" | sha512sum -c - \
&& tar -zxf dotnet-sdk.tar.gz -C /usr/share/dotnet \
&& export DOTNET_ROOT=/usr/share/dotnet \
&& export PATH=$PATH:/usr/share/dotnet \
&& rm dotnet-sdk.tar.gz 

#RUN mkdir /webapp

COPY hello-world.csproj /webapp/hello-world.csproj
COPY appsettings.json /webapp/appsettings.json
COPY /src/Program.cs /webapp/src/Program.cs
#COPY launchSettings.json /webapp/Properties/launchSettings.json

RUN dotnet build /webapp/hello-world.csproj -c Release -o /webapp/bin

WORKDIR /webapp
#ENV replace appsettings.json
#ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

#ENTRYPOINT ["dotnet", "hello-world.dll"]
RUN dotnet run /webapp/bin/hello-world.dll &
