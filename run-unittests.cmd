@echo off
IF "%1"=="" goto usage

"%~dp0tools\xUnit\xunit.console.exe" "src\TestStack.White.UnitTests\bin\Debug\TestStack.White.UnitTests.dll" /nunit "%1-1.xml"
"%~dp0tools\xUnit\xunit.console.exe" "src\TestStack.White.WebBrowser.UnitTests\bin\Debug\TestStack.White.WebBrowser.UnitTests.dll" /nunit "%1-2.xml"
"%~dp0tools\xUnit\xunit.console.exe" "src\TestStack.White.Modules.UnitTests\bin\Debug\TestStack.White.Modules.UnitTests.dll" /nunit "%1-3.xml"

 goto exit
 
 :usage
 echo Usage: run-unittest [result xml file path without any extension]
 
 :exit