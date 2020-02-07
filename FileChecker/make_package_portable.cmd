call .\clean.cmd
call .\build.cmd

set BUILD_STATUS=%ERRORLEVEL% 
if %BUILD_STATUS%==0 goto installer
if not %BUILD_STATUS%==0 goto fail 
 
:fail 
pause 
exit /b 1 
 
:installer 
set lstfile=".\listfile.txt"
set out_fn="filechecker_1.0.0_win_portable"
set zip_fn=".\%out_fn%.zip"
set log_fn=".\%out_fn%.log"
del .\*.zip /q
echo ".\bin\Release\FileChecker.exe" > %lstfile%
"c:\Program Files\7-zip\7z.exe" a -tzip -mx9 -scsWIN %zip_fn% @%lstfile%
del %lstfile%
pause 
exit /b 0
