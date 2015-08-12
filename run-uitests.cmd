@echo off
IF "%1"=="" goto usage

"%~dp0tools\xUnit\xunit.console.exe" "src\TestStack.White.Modules.Silverlight.UITests\bin\Debug\TestStack.White.Modules.Silverlight.UITests.dll" /nunit "%1-1.xml"
"%~dp0tools\xUnit\xunit.console.exe" "src\TestStack.White.Modules.Win32.UITests\bin\Debug\TestStack.White.Modules.Win32.UITests.dll" /nunit "%1-2.xml"
"%~dp0tools\xUnit\xunit.console.exe" "src\TestStack.White.Modules.WinForm.UITests\bin\Debug\TestStack.White.Modules.WinForm.UITests.dll" /nunit "%1-3.xml"
"%~dp0tools\xUnit\xunit.console.exe" "src\TestStack.White.Modules.Wpf.UITests\bin\Debug\TestStack.White.Modules.Wpf.UITests.dll" /nunit "%1-4.xml"
"%~dp0tools\xUnit\xunit.console.exe" "src\TestStack.White.UITests\bin\Debug\TestStack.White.UITests.dll" /nunit "%1-5.xml"

 goto exit
 
 :usage
 echo Usage: run-uitest [result xml file path without any extension]
 
 :exit