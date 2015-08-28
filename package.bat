@echo off
setlocal
if "%1" == "" goto usage

for /f %%i in (NextVersion.txt) DO set version=%%i

if "%version%" == "" goto usage

if not "%2" == "" set version=%version%.%2

set nuget="%ProgramFiles(x86)%\NuGet\Visual Studio 2013\NuGet.exe"
for /f %%f in ('dir src\*.nuspec /b /s') do %nuget% pack %%f -OutputDirectory "%1" -Version %version%

goto exit


:usage
echo #
echo # Usage: package [path] ^<build^>
echo #        path         : the path to the NuGetPackage directory
echo #        build        : optional build number
echo # 
echo # Example packaging to directory ..\NuGetPackage with build 256
echo #        package ..\NuGetPackage 256
echo #
:exit	