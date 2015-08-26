@echo off
set nuget="%ProgramFiles(x86)%\NuGet\Visual Studio 2013\NuGet.exe"
%nuget% pack src\TestStack.White\TestStack.White.nuspec -OutputDirectory "%1" -Version 2.0.%2
%nuget% pack src\TestStack.White.WebBrowser\TestStack.White.WebBrowser.nuspec -OutputDirectory "%1" -Version 2.0.%2
%nuget% pack src\TestStack.White.ScreenObjects\TestStack.White.ScreenObjects.nuspec -OutputDirectory "%1" -Version 2.0.%2
%nuget% pack src\TestStack.White.Modules.Win32\TestStack.White.Modules.Win32.nuspec -OutputDirectory "%1" -Version 2.0.%2
%nuget% pack src\TestStack.White.Modules.WinForm\TestStack.White.Modules.WinForm.nuspec -OutputDirectory "%1" -Version 2.0.%2
%nuget% pack src\TestStack.White.Modules.Silverlight\TestStack.White.Modules.Silverlight.nuspec -OutputDirectory "%1" -Version 2.0.%2