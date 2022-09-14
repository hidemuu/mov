;�ϐ�
#define MyAppName    "CoronaReader"
#define MyAppVersion "1.0.0.0"
#define MyAppPublisher "p-hidemitsu-miura"
#define MyAppExeName   "CoronaReader.exe"
#define MyAppDirName "CoronaReader"
#define MyAppPath "src\csharp\App\CoronaReader\bin\Release\net5.0"
#define MyDbPath "assets\api"
#define MyDbName "corona_reader.sqlite"
;#define MyAppMutex     "https://misw.jp/sampleapp"

[Setup]
;�C���X�g�[���E�B�U�[�h�\���^�C�g��
AppName        = {#MyAppName}
;�A�v���P�[�V�����o�[�W����
AppVersion     = {#MyAppVersion}
AppVerName           = {#MyAppName} {#MyAppVersion}
;������
AppPublisher         = {#MyAppPublisher}
;�C���X�g�[���t�H���_�̃f�t�H���g�p�X�@{pf}��Program Files�̗�
;DefaultDirName = "C:\{#MyAppDirName}"
;DefaultDirName = {pf}\{#MyAppDirName}
DefaultDirName = {userdesktop}\{#MyAppDirName}
;���̑�
DefaultGroupName     = {#MyAppDirName}
OutputBaseFilename   = setup_{#MyAppName}
;AppMutex             = {#MyAppMutex}
UninstallDisplayIcon = {app}\uninstal_{#MyAppName}
UninstallDisplayName = {app}\uninstal_{#MyAppName}


[Languages]
;���w��̏ꍇ�p��
Name: "japanese"; MessagesFile: "compiler:Languages\Japanese.isl"

[Dirs]
;Name: "{app}\Database\backup"
;Name: "{#MyDbPath}"; Check: isDbDirExist

[Files]
;�C���X�g�[���t�@�C���̎w��
;Source:�C���X�g�[���t�@�C�����ADestDir:�C���X�g�[����
;{app}�w��C���X�g�[����t�H���_ �W���ł�DefaultDirName�Ŏw�肵���ꏊ
;ignoreversion �t���O�F�t�@�C�����t�o�[�W�����𖳎����㏑���C���X�g�[��
Source: "{#MyAppPath}\*";    DestDir: "{app}"; Flags: ignoreversion


Source: "assets\*";    DestDir: "{app}\assets"; Flags: ignoreversion
Source: "assets\api\*";    DestDir: "{app}\assets\api"; Flags: ignoreversion
Source: "assets\covid\*";    DestDir: "{app}\assets\covid"; Flags: ignoreversion
Source: "dist\*";    DestDir: "{app}\dist"; Flags: ignoreversion
Source: "scripts\*";    DestDir: "{app}\scripts"; Flags: ignoreversion
Source: "scripts\css\*";    DestDir: "{app}\scripts\css"; Flags: ignoreversion
Source: "scripts\js\*";    DestDir: "{app}\scripts\js"; Flags: ignoreversion



[Tasks] 
Name: startmenu; Description:"�X�^�[�g���j���[�ɃV���[�g�J�b�g���쐬����(&P)"; Flags:
Name: desktopicon; Description: "�f�X�N�g�b�v�ɃA�C�R�����쐬����(&D)"; Flags:

[Icons]
Name: "{userdesktop}\CoronaReader"; Filename: "{app}\CoronaReader.exe"; WorkingDir: "{app}"; IconFilename: "{app}\CoronaReader.exe"; IconIndex: 0

[Run]
//Filename: "{app}\SolutionItems\README.md"; Description: "README��\������"; Flags: postinstall shellexec skipifsilent unchecked
//Filename: "{app}\readme.txt"; Description: "README��\������"; Flags: postinstall shellexec skipifsilent unchecked
//Filename: "{app}\CoronaReader.exe"; Description: "�C���X�g�[��������N������"; Flags: postinstall shellexec skipifsilent   