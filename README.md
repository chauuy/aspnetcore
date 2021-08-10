# aspnetcore basic infosys sample

**Required** *DotNet Core 3.1*

```shell
git clone https://github.com/chauuy/aspnetcore.git

cd aspnetcore

dotnet build sys-info.csproj -c Release 

dotnet run /bin/Release/netcoreapp5.0/sys-info.dll

dotnet dev-certs https --trust (optionnal, only for Windows & MacOS)
```

Check application: http://localhost:5000
