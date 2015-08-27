@echo off
setlocal
if "%1" == "" goto usage

for /f %%i in (NextVersion.txt) DO set version=%%i

if "%version%" == "" goto usage

set nuget="%ProgramFiles(x86)%\NuGet\Visual Studio 2013\NuGet.exe"
for /f %%f in ('dir src\*.nuspec /b /s') do %nuget% pack %%f -OutputDirectory "%1" -Version %version%

goto exit


:usage
echo Usage: package [path]
echo        path         : the path to the NuGetPackage directory
echo Example: package ..\NuGetPackage
:exit	