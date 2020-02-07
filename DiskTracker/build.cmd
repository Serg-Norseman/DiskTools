@echo off
set MSBDIR=@%WINDIR%\Microsoft.NET\Framework\v4.0.30319
%MSBDIR%\msbuild.exe DiskTracker.sln /p:Configuration=Release /p:Platform="Any CPU" /t:Rebuild

set BUILD_STATUS=%ERRORLEVEL% 
if %BUILD_STATUS%==0 goto test 
if not %BUILD_STATUS%==0 goto fail 
 
:fail 
pause 
exit /b 1 
 
:test 
rem "C:\Program Files (x86)\NUnit 2.6.4\bin\nunit-console-x86.exe" DiskTrackerTests.dll
pause 
exit /b 0
