# Setting Examples

# CSharp
https://www.umayadia.com/Note/Note041TypeScriptReact.htm
https://qiita.com/h0ge/items/5e8343ae16065ae41743
https://zenn.dev/h0ge/articles/cd2f3e75259786

# CSharp React

### パッケージインストール
$ cd .\ClientApp\
$ npm install (念の為)
$ npm install --save-dev babel-plugin-react-html-attrs
$ npm install --save react-chartjs-2 chart.js
$ npm install --save react-bootstrap-table-next
$ npm install swr
$ npm install react-content-loader
$ npm install --save-dev @types/react-content-loader
$ npm install --save-dev styled-components
$ npx sb init
$ npm install --save-dev @testing-library/react
$ npm install --save-dev @types/jest
$ npm install @mui/icons-material @mui/material @emotion/styled @emotion/react

### webpackコマンド
$ webpack --mode development

### Storybook
$ npm run storybook

### Visual Studio Codeから実行
$ dotnet run (.csprojファイルのディレクトリで)
$ npm run wstart

# react
https://qiita.com/TsutomuNakamura/items/72d8cf9f07a5a30be048
https://qiita.com/koedamon/items/8fb75a7c001da40c7bea
https://qiita.com/masafullversion/items/0238b7c069ebf4f1f072
https://qiita.com/banban525/items/b66a439d588858ba3a11

### ディレクトリの作成
$ mkdir js-react
$ cd js-react
$ mkdir -p src/js

### プロジェクトの作成
$ npm init
......
package name: (js-react) 
version: (1.0.0) 
description: 
entry point: (index.js) webpack.config.js    # <- "webpack.config.js" 入力(先にwebpack.config.js 作っておけばデフォルトで選択される)
test command: 
git repository: 
keywords: 
author: Your Name
license: (ISC) 
......

### webpackパッケージインストール
$ npm install --save-dev webpack webpack-cli webpack-dev-server
$ npm install -g webpack webpack-cli
$ npm install --save-dev @babel/core @babel/preset-env @babel/preset-react babel-loader
$ npm install --save-dev react react-dom
$ npm install --save-dev babel-plugin-react-html-attrs
$ npm install --save-dev @babel/compat-data
$ npm install --save-dev react-router react-router-dom
$ npm install --save react-chartjs-2 chart.js
$ npm install --save moment react-moment
$ npm install --save react-bootstrap-table-next
$ npm install --save react-bootstrap-table2-editor
$ npm install --save reactstrap

### グローバルインストールの環境変数設定
$ set NODE_PATH=C:\Users\nando\AppData\Roaming\npm\node_modules

### webpackコマンド
$ webpack --mode development

### Cromeで起動
$ google-chrome-stable ./src/index.html

### webpackサーバ起動
$ npx webpack-dev-server
$ npm start (package.jsonで設定)

# laravel

### ローカルサーバ起動（laravelのアプリルートパスをカレントディレクトリにする）
cd C:\Users\nando\Documents\GitHub\Stocker\src\php\stocker
php -S localhost:8000 -t public

### パッケージリスト更新
sudo yum -y update
### phpインストール
sudo yum install -y php-mbstring php-openssl php-xml unzip
### composerインストール
php -r "copy('https://getcomposer.org/installer', 'composer-setup.php');"
sudo php composer-setup.php --install-dir=/usr/local/bin --filename=composer
composer -V

### phpインストール
ls /usr/bin/php
sudo ln /usr/bin/php
sudo yum -y install http://rpms.famillecollet.com/enterprise/remi-release-7.rpm
sudo yum -y remove php php-pdo php-mbstring
sudo yum -y install php72 php72-mbstring php72-pdo
sudo ln -s /usr/bin/php72 /usr/bin/php

### パスの設定
sudo yum -y install php72-php php72-php-common php72-php-devel php72-php-manual php72-php-pdo php72-php-mbstring php72-php-json php72-php-xml
composer update

### PHPとLaravelのバージョン確認
php -v
laravel -v

### Laravelのアプリ作成
composer create-project <使用するライブラリなどの名前> <ライブラリなどをインストールするディレクトリ名> <バージョン指定などのオプション>
composer create-project --prefer-dist laravel/laravel <アプリ名> "5.8.*"

### 新しく作成したアプリのディレクトリへと移動
cd <アプリ名>

### ルート表示
php artisan route:list

### ローカルサーバーを起動する
php artisan serve --port=8080

### すべてのファイルをステージングする
git add .

### コミットメッセージと共にコミットします
git commit -m "set up bootstrap4"

### SQLiteデータベースの作成
sqlite3 database/database.sqlite
.tables
.exit

### モデルの作成
php artisan make:model <新しく作成するモデル名> 
php artisan make:model -m <モデル名>   (マイグレーションも自動実行)

### Controller の作成
php artisan make:controller <コントローラー名> --resource --model=<モデル名>

### マイグレーションの実行
php artisan migrate

### Tinker(コンソールでのデータ作成) 終了時はexitを入力
php artisan tinker

### シーダー作成
php artisan make:seeder CategoriesTableSeeder
### 作成したシーダーファイルを読み込み
composer dump-autoload

### Font Awesomeのインストール
npm install

### Font Awesomeインストール後にGitでコミット
git add .
git commit -m "add Font Awesome"

### rutorika-sortableをパッケージマネージャでインストール
composer require illuminate/support
composer require rutorika/sortable 7.0.0

### rutorika-sortableのインストール後にコミット
git add .
git commit -m "install rutorika-sortable"

### resources/views/layouts/app.blade.php を編集後にGitでコミット
git add .
git commit -m "change layouts/app.blade.php"

### JavaScriptのライブラリのインストール
npm install

### JavaScript/CSSのビルド
npm run dev

### Laravelのログイン/ログアウト機能を使用
php artisan make:auth

### Heroku CLI
curl -OL https://cli-assets.heroku.com/heroku-linux-x64.tar.gz && tar zxf heroku-linux-x64.tar.gz && rm -f heroku-linux-x64.tar.gz && sudo mv heroku /usr/local && echo 'PATH=/usr/local/heroku/bin:$PATH' >> $HOME/.bash_profile

### Herokuにビルドパックを追加
heroku buildpacks:set heroku/php  -a <作成するアプリ名>
heroku buildpacks:add heroku/nodejs  -a <作成するアプリ名>

### HerokuのデータベースにPostgresqlを使用
heroku addons:create heroku-postgresql:hobby-dev -a <作成するアプリ名>

### Herokuのデータベース設定を確認
heroku config:get DATABASE_URL -a <作成するアプリ名> 

### 確認したデータベース設定を環境変数として設定
heroku config:set DB_CONNECTION=pgsql -a <作成するアプリ名>
heroku config:set DB_DATABASE=<データベース名> -a <作成するアプリ名>
heroku config:set DB_HOST=<ホスト> -a <作成するアプリ名>
heroku config:set DB_PASSWORD=<パスワード> -a <作成するアプリ名>
heroku config:set DB_PORT=<ポート> -a <作成するアプリ名>
heroku config:set DB_USERNAME=<ユーザー> -a <作成するアプリ名>

### Laravelの本番環境用のキーを生成
php artisan key:generate --show

### 生成したキーを環境変数として設定
heroku config:set APP_KEY=<生成されたキー> -a <作成するアプリ名>


