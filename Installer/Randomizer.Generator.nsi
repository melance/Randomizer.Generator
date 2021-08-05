!include "MUI2.nsh"

Var StartMenuFolder

; Global config
!define NAME "Randomizer.Generator"
!define REGPATH_UNINSTSUBKEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}"
Name "${NAME}"
XPStyle on

InstallDir "$PROGRAMFILES\Randomizer.Generator\"
InstallDirRegKey HKCU "Software\Randomizer.Generator" ""

!define MUI_ABORTWARNING

!define MUI_ICON "TheRandomizer.ico"
!define MUI_UNICON "TheRandomizer.ico"

!define MUI_PAGE_HEADER_TEXT "Randomizer.Generator"
!define MUI_PAGE_HEADER_SUBTEXT "The Infinitely Customizable Random Content Generator"

; Welcome Page
!define MUI_WELCOMEPAGE_TITLE "Randomizer.Generator"
!define MUI_WELCOMEPAGE_TEXT "This installer will install the Randomizer.Generator application."
!define MUI_WELCOMEFINISHPAGE_BITMAP "Installer Welcome.bmp"

!insertmacro MUI_PAGE_WELCOME

; License Page
!define MUI_LICENSEPAGE_CHECKBOX
!insertmacro MUI_PAGE_LICENSE "License.txt"

; Components Page
!insertmacro MUI_PAGE_COMPONENTS

; Directory Selection Page
!define MUI_DIRECTORYPAGE_VARIABLE $InstDir
!insertmacro MUI_PAGE_DIRECTORY

; Start Menu Page
!define MUI_STARTMENUPAGE_REGISTRY_ROOT "HKCU"
!define MUI_STARTMENUPAGE_REGISTRY_KEY "Software\Randomizer.Generator"
!define MUI_STARTMENUPAGE_REGISTRY_VALUENAME "Randomizer.Generator"

!insertmacro MUI_PAGE_STARTMENU Application $StartMenuFolder

; Installing File Page
!insertmacro MUI_PAGE_INSTFILES

; Finish Page
!define MUI_FINISHPAGE_RUN "rnd.gen.uit.exe"
!insertmacro MUI_PAGE_FINISH

;Uninstall pages

!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES


Section "Program Files (Required)" secRequired
	SectionIn Ro
	
	SetOutPath $InstDir
	WriteUninstaller "$InstDir\Uninstall.exe"
	WriteRegStr HKCU "${REGPATH_UNINSTSUBKEY}" "DisplayName" "${NAME}"
	WriteRegStr HKCU "${REGPATH_UNINSTSUBKEY}" "DisplayIcon" "$InstDir\TheRandomizer.ico"
	WriteRegStr HKCU "${REGPATH_UNINSTSUBKEY}" "UninstallString" "$InstDir\Uninstall.exe"
	WriteRegDWORD HKCU "${REGPATH_UNINSTSUBKEY}" "NoModify" 1
	WriteRegDWORD HKCU "${REGPATH_UNINSTSUBKEY}" "NoRepair" 1
	
	File "un.TheRandomizer.ico"
	File "..\bin\Debug\net5.0\HJson.dll"
	File "..\bin\Debug\net5.0\KeraLua.dll"
	File "..\bin\Debug\net5.0\Microsoft.Extensions.DependencyInjection.Abstractions.dll"
	File "..\bin\Debug\net5.0\JetBrains.Annotations.dll"
	File "..\bin\Debug\net5.0\JsonSubtypes.dll"
	File "..\bin\Debug\net5.0\NCalc.dll"
	File "..\bin\Debug\net5.0\Newtonsoft.Json.dll"
	File "..\bin\Debug\net5.0\NLua.dll"
	File "..\bin\Debug\net5.0\NStack.dll"
	File "..\bin\Debug\net5.0\Rnd.Gen.Conv.dll"
	File "..\bin\Debug\net5.0\Rnd.Gen.dll"
	File "..\bin\Debug\net5.0\Rnd.Gen.UIT.dll"
	File "..\bin\Debug\net5.0\Rnd.Gen.UIT.exe"
	File "..\bin\Debug\net5.0\Rnd.Gen.UIT.runtimeconfig.json"
	File "..\bin\Debug\net5.0\System.CommandLine.dll"
	File "..\bin\Debug\net5.0\System.CommandLine.DragonFruit.dll"
	File "..\bin\Debug\net5.0\System.CommandLine.Rendering.dll"
	File "..\bin\Debug\net5.0\Terminal.Gui.dll"
	File "..\bin\Debug\net5.0\TextCopy.dll"
	File "..\bin\Debug\net5.0\TheRandomizer.Generators.dll"
	File "..\bin\Debug\net5.0\TheRandomizer.Utility.dll"
	File "..\bin\Debug\net5.0\WenceyWang.FIGlet.dll"
	File "..\bin\Debug\net5.0\cs\*.*"
	File "..\bin\Debug\net5.0\de\*.*"
	File "..\bin\Debug\net5.0\es\*.*"
	File "..\bin\Debug\net5.0\fr\*.*"
	File "..\bin\Debug\net5.0\it\*.*"
	File "..\bin\Debug\net5.0\ja\*.*"
	File "..\bin\Debug\net5.0\ko\*.*"
	File "..\bin\Debug\net5.0\pl\*.*"
	File "..\bin\Debug\net5.0\pt-BR\*.*"
	File "..\bin\Debug\net5.0\ru\*.*"
	File "..\bin\Debug\net5.0\tr\*.*"
	File "..\bin\Debug\net5.0\zh-Hans\*.*"
	File "..\bin\Debug\net5.0\zh-Hant\*.*"
	File /r "..\bin\Debug\net5.0\runtimes\"

	!insertmacro MUI_STARTMENU_WRITE_BEGIN Application
		CreateDirectory "$SMPROGRAMS\$StartMenuFolder"
		CreateShortcut "$SMPROGRAMS\$StartMenuFolder\Randomizer Terminal UI.lnk" "$INSTDIR\Rnd.Gen.UIT.exe"
		CreateShortcut "$SMPROGRAMS\$StartMenuFolder\Uninstall Randomizer.Generator.lnk" "$INSTDIR\Uninstall.exe" "" "$INSTDIR\un.TheRandomizer.ico"
	!insertmacro MUI_STARTMENU_WRITE_END
SectionEnd

Section "Command Line Tool" secCmdLine
	File "..\bin\Debug\net5.0\Rnd.Gen.CLI.dll"
	File "..\bin\Debug\net5.0\Rnd.Gen.CLI.exe"
	File "..\bin\Debug\net5.0\Rnd.Gen.CLI.runtimeconfig.json"
	File "..\bin\Debug\net5.0\Spectre.Console.dll"
	File "..\bin\Debug\net5.0\Wcwidth.dll"
SectionEnd

Section "Grammar to Definition CLI Converter Tool" secConverter
	File "..\bin\Debug\net5.0\Rnd.Gen.Conv.exe"
	File "..\bin\Debug\net5.0\Rnd.Gen.Conv.runtimeconfig.json"
SectionEnd

!insertmacro MUI_LANGUAGE "English"
LangString DESC_Required ${LANG_ENGLISH} "The core components and Terminal UI."
LangString DESC_CmdLine ${LANG_ENGLISH} "A command line tool to run a generator."
LangString DESC_Converter ${LANG_ENGLISH} "A command line tool to convert an old Grammar format into the new Definition format."

!insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
	!insertmacro MUI_DESCRIPTION_TEXT ${secRequired} $(DESC_Required)
	!insertmacro MUI_DESCRIPTION_TEXT ${secCmdLine} $(DESC_CmdLine)
	!insertmacro MUI_DESCRIPTION_TEXT ${secConverter} $(DESC_Converter)
!insertmacro MUI_FUNCTION_DESCRIPTION_END

Section "Uninstall"

	Delete "$InstDir\Uninstall.exe"
	
	RMDir "$InstDir"
	
	!insertmacro MUI_STARTMENU_GETFOLDER Application $StartMenuFolder
	
	Delete "$SMPROGRAMS\$StartMenuFolder\Randomizer Terminal UI.lnk"
	Delete "$SMPROGRAMS\$StartMenuFolder\Uninstall Randomizer.Generator.lnk"
	Delete "$SMPROGRAMS\$StartMenuFolder\Open Command Prompt.lnk"
	RMDir "$SMPROGRAMS\$StartMenuFolder"
	
	DeleteRegKey /ifempty HKCU "Software\Randomizer.Generator"

SectionEnd