# mov

# ソリューション構造
```
Mov
| Mov.sln  
|
├─app  
|  | Api                : API
|  |
|  | ConsoleApp         : コンソールアプリ
|  |
|  | ReactApp           : Webアプリ（バックエンドASPNETCore / フロントエンドReact）  
|  |   ├─ClientApp      : フロントエンド処理
|  |   └─Controllers    : バックエンド処理
|  |
|  | WpfApp             : WindowsOS ネイティブアプリ（WPF）
|
└─src  
   ├─analizer
   |  | analizer.Models                 : ドメインモデル
   |  | analizer.Engine                 : ビジネスロジック
   |  | analizer.Service                : アプリケーションサービス
   |  | analizer.Repository             : リポジトリ
   |
   ├─game
   ├─bom
   ├─designer
   ├─drawer

```

# 命名規則

* 名前空間 : Pascal
* クラス : Pascal
* インターフェイス : Pascal
* 構造体 : Pascal
* 列挙型 : Pascal
* 列挙値 : Pascal
* イベント : Pascal
* メソッド : Pascal
* プロパティ : Pascal
* 定数 : すべて大文字
* Publicフィールド : Camel
* Privateフィールド : 先頭にアンダースコア(_) + Camel
* 引数（パラメータ） : Camel
* ローカル変数 : Camel

# アーキテクチャ
  レイヤ化アーキテクチャによるDDD駆動モデルを適用
   (https://qiita.com/takasp/items/f05ef45a6fadd916ffa8 https://qiita.com/mikesorae/items/ff8192fb9cf106262dbf)

# 参照データ
* V-RESAS (https://v-resas.go.jp/)

### Quick start 

- コンソールアプリ  ：XAMPPをインストールし、Apache ポートを81にして起動する
- Webアプリ      　：Kestralをインストールし、dotnetコマンドで起動する
- Visual Studio Codeから実行
  - $ dotnet run (.csprojファイルのディレクトリで)
  - $ npm run wstart
  - $ npm run storybook

#### 環境設定

- ターゲットOS / フレームワーク
  Windows 10
  .Net 7 (アプリケーション)
  .Net Standard 2.0 (ライブラリ)

- 通信チャネル
  Restful Webサービス
  PostgreSQL データベース

- 通信ポート
  REST API ： 8443
  PostgreSQL : 5432
  XAMPP Apache : 81(localhost)

> *Note* 開発環境：Visual Studio 2022


