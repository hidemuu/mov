;変数
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
;インストールウィザード表示タイトル
AppName        = {#MyAppName}
;アプリケーションバージョン
AppVersion     = {#MyAppVersion}
AppVerName           = {#MyAppName} {#MyAppVersion}
;製作情報
AppPublisher         = {#MyAppPublisher}
;インストールフォルダのデフォルトパス　{pf}はProgram Filesの略
;DefaultDirName = "C:\{#MyAppDirName}"
;DefaultDirName = {pf}\{#MyAppDirName}
DefaultDirName = {userdesktop}\{#MyAppDirName}
;その他
DefaultGroupName     = {#MyAppDirName}
OutputBaseFilename   = setup_{#MyAppName}
;AppMutex             = {#MyAppMutex}
UninstallDisplayIcon = {app}\uninstal_{#MyAppName}
UninstallDisplayName = {app}\uninstal_{#MyAppName}


[Languages]
;未指定の場合英語
Name: "japanese"; MessagesFile: "compiler:Languages\Japanese.isl"

[Dirs]
;Name: "{app}\Database\backup"
;Name: "{#MyDbPath}"; Check: isDbDirExist

[Files]
;インストールファイルの指定
;Source:インストールファイル名、DestDir:インストール先
;{app}指定インストール先フォルダ 標準ではDefaultDirNameで指定した場所
;ignoreversion フラグ：ファイル日付バージョンを無視し上書きインストール
Source: "{#MyAppPath}\*";    DestDir: "{app}"; Flags: ignoreversion


Source: "assets\*";    DestDir: "{app}\assets"; Flags: ignoreversion
Source: "assets\api\*";    DestDir: "{app}\assets\api"; Flags: ignoreversion
Source: "assets\covid\*";    DestDir: "{app}\assets\covid"; Flags: ignoreversion
Source: "dist\*";    DestDir: "{app}\dist"; Flags: ignoreversion
Source: "scripts\*";    DestDir: "{app}\scripts"; Flags: ignoreversion
Source: "scripts\css\*";    DestDir: "{app}\scripts\css"; Flags: ignoreversion
Source: "scripts\js\*";    DestDir: "{app}\scripts\js"; Flags: ignoreversion



[Tasks] 
Name: startmenu; Description:"スタートメニューにショートカットを作成する(&P)"; Flags:
Name: desktopicon; Description: "デスクトップにアイコンを作成する(&D)"; Flags:

[Icons]
Name: "{userdesktop}\CoronaReader"; Filename: "{app}\CoronaReader.exe"; WorkingDir: "{app}"; IconFilename: "{app}\CoronaReader.exe"; IconIndex: 0

[Run]
//Filename: "{app}\SolutionItems\README.md"; Description: "READMEを表示する"; Flags: postinstall shellexec skipifsilent unchecked
//Filename: "{app}\readme.txt"; Description: "READMEを表示する"; Flags: postinstall shellexec skipifsilent unchecked
//Filename: "{app}\CoronaReader.exe"; Description: "インストール完了後起動する"; Flags: postinstall shellexec skipifsilent   