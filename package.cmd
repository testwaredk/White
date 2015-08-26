@echo off
set nuget=%ProgramFiles(x86)%\NuGet\Visual Studio 2013\NuGet.exe
"%nuget%" pack src\TestStack.White.nuspec -OutputDirectory "%1" -Version 2.0.%2
"%nuget%" pack src\TestStack.White.WebBrowser\TestStack.White.WebBrowser.nuspec -OutputDirectory "%1" -Version 2.0.%2