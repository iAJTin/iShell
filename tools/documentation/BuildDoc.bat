@ECHO OFF
CLS

rmdir ..\..\documentation /s /q

xmldocmd ..\..\src\extensions\svg\iShell.Svg\bin\Release\net472\iShell.Svg.dll ..\documentation

PAUSE
