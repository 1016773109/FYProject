@echo off
set CompileType=%1
set SourceDir=%2
set SourcePluginFileName=%3
set ProjectDir=%4
set BatPath=%~dp0
set TargetDir=%BatPath%..\..\Project\Assets\GameFramework\Libraries\
set SourcePluginFilePath=%SourceDir%%SourcePluginFileName%
set TargetPluginFilePath=%TargetDir%%SourcePluginFileName%
set SourcePdbFilePath=%SourceDir%%SourcePluginFileName%.pdb
set TargetPdbFilePath=%TargetDir%%SourcePluginFileName%.pdb

if "%CompileType%"=="Debug" (echo f | xcopy /y "%SourcePdbFilePath%" "%TargetPdbFilePath%" ) else (del /q "%TargetPdbFilePath%")

echo f | xcopy /y "%SourcePluginFilePath%.dll" "%TargetPluginFilePath%.dll"
