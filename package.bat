@echo off
set version=2.0.%2
set nuget="%ProgramFiles(x86)%\NuGet\Visual Studio 2013\NuGet.exe"
%nuget% pack src\TestStack.White\TestStack.White.nuspec -OutputDirectory "%1" -Version %version%
%nuget% pack src\TestStack.White.WebBrowser\TestStack.White.WebBrowser.nuspec -OutputDirectory "%1" -Version %version%
%nuget% pack src\TestStack.White.ScreenObjects\TestStack.White.ScreenObjects.nuspec -OutputDirectory "%1" -Version %version%
%nuget% pack src\TestStack.White.UnitTests\TestStack.White.UITests.nuspec -OutputDirectory "%1" -Version %version%
%nuget% pack src\TestStack.White.Modules.Win32\TestStack.White.Modules.Win32.nuspec -OutputDirectory "%1" -Version %version%
%nuget% pack src\TestStack.White.Modules.WinForm\TestStack.White.Modules.WinForm.nuspec -OutputDirectory "%1" -Version %version%
%nuget% pack src\TestStack.White.Modules.Wpf\TestStack.White.Modules.Wpf.nuspec -OutputDirectory "%1" -Version %version%
%nuget% pack src\TestStack.White.Modules.Silverlight\TestStack.White.Modules.Silverlight.nuspec -OutputDirectory "%1" -Version %version%
