cd ../src/NbSites.Web3x

@REM call dotnet nuget list source
call dotnet restore -r win-x64
call dotnet publish -c Release -r win-x64 --self-contained true --no-restore /p:EnvironmentName=Development

pause