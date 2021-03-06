; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "AVrBoT Lab"
#define MyAppVersion "4.2"
#define MyAppPublisher "avrbot tehnologies"
#define MyAppURL "http://www.avrbot4.com/"
#define MyAppExeName "AVrBoT 4.0.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{8CD68075-442F-4EAC-802D-A3EBEC8E0EA1}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
LicenseFile=C:\Users\fontome\Desktop\licence.txt
OutputDir=C:\Users\fontome\Desktop
OutputBaseFilename=Setup AVrBoT
SetupIconFile=D:\avrbot4.0\favicon (1).ico
Password=1475963-NHYG-1235987-AQWXSZ
Compression=lzma
SolidCompression=yes
WizardSmallImageFile= C:\Users\fontome\Desktop\robot.bmp
WizardImageFile=C:\Users\fontome\Desktop\utilisateur.bmp

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "brazilianportuguese"; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"
Name: "catalan"; MessagesFile: "compiler:Languages\Catalan.isl"
Name: "corsican"; MessagesFile: "compiler:Languages\Corsican.isl"
Name: "czech"; MessagesFile: "compiler:Languages\Czech.isl"
Name: "danish"; MessagesFile: "compiler:Languages\Danish.isl"
Name: "dutch"; MessagesFile: "compiler:Languages\Dutch.isl"
Name: "finnish"; MessagesFile: "compiler:Languages\Finnish.isl"
Name: "french"; MessagesFile: "compiler:Languages\French.isl"
Name: "german"; MessagesFile: "compiler:Languages\German.isl"
Name: "greek"; MessagesFile: "compiler:Languages\Greek.isl"
Name: "hebrew"; MessagesFile: "compiler:Languages\Hebrew.isl"
Name: "hungarian"; MessagesFile: "compiler:Languages\Hungarian.isl"
Name: "italian"; MessagesFile: "compiler:Languages\Italian.isl"
Name: "japanese"; MessagesFile: "compiler:Languages\Japanese.isl"
Name: "norwegian"; MessagesFile: "compiler:Languages\Norwegian.isl"
Name: "polish"; MessagesFile: "compiler:Languages\Polish.isl"
Name: "portuguese"; MessagesFile: "compiler:Languages\Portuguese.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"
Name: "serbiancyrillic"; MessagesFile: "compiler:Languages\SerbianCyrillic.isl"
Name: "serbianlatin"; MessagesFile: "compiler:Languages\SerbianLatin.isl"
Name: "slovenian"; MessagesFile: "compiler:Languages\Slovenian.isl"
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"
Name: "ukrainian"; MessagesFile: "compiler:Languages\Ukrainian.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Files]
Source: "D:\avrbot4.0\AVrBoT 4.0\AVrBoT 4.0\bin\Debug\AVrBoT 4.0.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\avrbot4.0\AVrBoT 4.0\AVrBoT 4.0\bin\Debug\AVrBoT 4.0.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\avrbot4.0\AVrBoT 4.0\AVrBoT 4.0\bin\Debug\chip.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\avrbot4.0\AVrBoT 4.0\AVrBoT 4.0\bin\Debug\exemple_clignotement_led.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\avrbot4.0\AVrBoT 4.0\AVrBoT 4.0\bin\Debug\exemple_commande_bras_robotique.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\avrbot4.0\AVrBoT 4.0\AVrBoT 4.0\bin\Debug\exemple_commande_moteur_pap_vitesse.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\avrbot4.0\AVrBoT 4.0\AVrBoT 4.0\bin\Debug\exemple_prog_ascenseur.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\avrbot4.0\AVrBoT 4.0\AVrBoT 4.0\bin\Debug\InTheHand.Net.Personal.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\avrbot4.0\AVrBoT 4.0\AVrBoT 4.0\bin\Debug\InTheHand.Net.Personal.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\avrbot4.0\AVrBoT 4.0\AVrBoT 4.0\bin\Debug\programmer.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\avrbot4.0\AVrBoT 4.0\AVrBoT 4.0\bin\Debug\tools\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:ProgramOnTheWeb,{#MyAppName}}"; Filename: "{#MyAppURL}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

