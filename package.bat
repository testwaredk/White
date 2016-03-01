@echo off
setlocal

set OUTPUT_DIRECTORY=
set BATCH=false

:loop
if not "%1"=="" (
	if "%1"=="--output-directory" (
		set OUTPUT_DIRECTORY=%2& shift
	)
	if "%1"=="--batch" (
		set BATCH=true
	)
	if "%1"=="--help" (
		goto :usage
	)
	shift
	goto :loop
)

:: check mandatory arguments, if NUGET_PACKAGES not set from arguments, then try fetch it from environment
if "%OUTPUT_DIRECTORY%"=="" set OUTPUT_DIRECTORY=%NUGET_PACKAGES%
if "%OUTPUT_DIRECTORY%"=="" goto usage


set REQUIRED_SHARED_ASSEMBLY_VERSION_CONTENT=AssemblyCompany AssemblyCopyright AssemblyProduct AssemblyVersion
set REQUIRED_ASSEMBLY_INFO_CONTENT=AssemblyTitle AssemblyDescription ComVisible Guid

call :verify_assembly_version_setup || exit /b 1

:: ensure that we have a path to nuget packages
if "%OUTPUT_DIRECTORY%"=="" echo OUTPUT_DIRECTORY was empty & goto usage
if not exist %OUTPUT_DIRECTORY% echo ERROR: Path %OUTPUT_DIRECTORY% did not exists
echo Creating package in %OUTPUT_DIRECTORY%


call :extract_version VERSION
if "%VERSION%"=="" echo VERSION was empty & goto usage
echo Found VERSION %VERSION%

call :create_nuget_packages %VERSION% %OUTPUT_DIRECTORY%

goto :eof


:: extract version from SharedAssemblyProperties.cs
:extract_version
	setlocal
	FOR /f "tokens=2 delims=())" %%i  in ('findstr AssemblyVersion src\SharedAssemblyProperties.cs') do (
		set version=%%~i
	)
	FOR /F "tokens=1,2,3 delims=." %%a IN ("%version%") DO set retval=%%a.%%b.%%c
	endlocal & set "%~1=%retval%"
goto :eof

::Find all nuget specs and create the package
:create_nuget_packages
	setlocal
	set nuget="%ProgramFiles(x86)%\NuGet\Visual Studio 2013\NuGet.exe"
	for /f %%f in ('dir src\*.nuspec /b /s') do %nuget% pack %%f -OutputDirectory "%2" -Version %1 || exit /b 4
	endlocal
goto :eof


:: verify setup of assembly version stuff
:verify_assembly_version_setup
	setlocal

	:: src\SharedAssemblyProperties.cs must exist
	if not exist src\SharedAssemblyProperties.cs echo ERROR: Should exist src\SharedAssemblyProperties.cs || exit /b 1

	for /f %%G in ('dir src\*.nuspec /b /s') do (
		if exist %%~nG.csproj if not exist %%~dpGProperties\AssemblyInfo.cs echo ERROR: Should exist: %%~dpGProperties\AssemblyInfo.cs || exit /b 2
		if exist %%~dpGProperties\SharedAssemblyProperties.cs echo ERROR: Should not exist %%~dpGProperties\SharedAssemblyProperties.cs || exit /b 3
	)

	:: verify that the SharedAssemblyProperties contains
	:: AssemblyCompany AssemblyCopyright AssemblyProduct AssemblyVersion
	echo Verifying SharedAssemblyProperties.cs
	FOR %%G in (%REQUIRED_SHARED_ASSEMBLY_VERSION_CONTENT%) DO (
		findstr %%G src\SharedAssemblyProperties.cs >nul || set FAILED=ERROR: %%G is missing from src\SharedAssemblyProperties.cs
	)

	if not "%FAILED%"=="" (
		echo %FAILED%
		exit /b 4
	)

	for /f %%G in ('dir src\*.nuspec /b /s') do (
		echo Verifying %%~dpGProperties\AssemblyInfo.cs
		call :verify_assembly_info_content %%~dpGProperties\AssemblyInfo.cs
	)

	endlocal
goto :eof

:verify_assembly_info_content
	setlocal
	for %%G in (%REQUIRED_ASSEMBLY_INFO_CONTENT%) do (
		findstr %%G %1 >nul || set FAILED=ERROR: %%G is missing from %1
	)
	if not "%FAILED%"=="" (
		echo %FAILED%
		exit /b 1
	)
	endlocal
goto :eof


:verify_shared_assembly_version_content 
	
goto :eof

:usage
	echo.
	echo   Usage:  package [OPTIONS]
	echo.
	echo      OPTIONS
	echo         --output-directory   : the path to the NuGetPackage directory. Default is ^%NUGET_PACKAGES^%
	echo         --batch              : runs in batch mode, which prevent the script from pause at the endlocal
	echo         --help               : displays this help text
	echo.  
	echo   The package.bat method also ensures that the setup of the assembly version are setup correctly
	exit /b 1
goto :eof


