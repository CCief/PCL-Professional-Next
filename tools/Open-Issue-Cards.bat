@echo off
rem One-click launcher: open Edge with the Issue card extension loaded.
rem No installation needed. All paths are resolved relative to this file.
setlocal
set "EXT=%~dp0issue-cards-extension"
set "PROFILE=%LOCALAPPDATA%\Microsoft\Edge\User Data\PCLIssueCards"
set "URL=https://github.com/CCief/PCL-Professional-Next/issues"
set "EDGE=C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe"
if not exist "%EDGE%" set "EDGE=C:\Program Files\Microsoft\Edge\Application\msedge.exe"
if not exist "%EDGE%" (
  echo Microsoft Edge not found.
  echo Please install the extension manually, see issue-cards-extension\README.md
  pause
  exit /b 1
)
start "" "%EDGE%" --disable-extensions-except="%EXT%" --load-extension="%EXT%" --user-data-dir="%PROFILE%" "%URL%"
endlocal
