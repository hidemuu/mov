<p align="center"><a href="https://laravel.com" target="_blank"><img src="https://raw.githubusercontent.com/laravel/art/master/logo-lockup/5%20SVG/2%20CMYK/1%20Full%20Color/laravel-logolockup-cmyk-red.svg" width="400"></a></p>

<p align="center">
<a href="https://travis-ci.org/laravel/framework"><img src="https://travis-ci.org/laravel/framework.svg" alt="Build Status"></a>
<a href="https://packagist.org/packages/laravel/framework"><img src="https://img.shields.io/packagist/dt/laravel/framework" alt="Total Downloads"></a>
<a href="https://packagist.org/packages/laravel/framework"><img src="https://img.shields.io/packagist/v/laravel/framework" alt="Latest Stable Version"></a>
<a href="https://packagist.org/packages/laravel/framework"><img src="https://img.shields.io/packagist/l/laravel/framework" alt="License"></a>
</p>

## About Laravel

Laravel is a web application framework with expressive, elegant syntax. We believe development must be an enjoyable and creative experience to be truly fulfilling. Laravel takes the pain out of development by easing common tasks used in many web projects, such as:

- [Simple, fast routing engine](https://laravel.com/docs/routing).
- [Powerful dependency injection container](https://laravel.com/docs/container).
- Multiple back-ends for [session](https://laravel.com/docs/session) and [cache](https://laravel.com/docs/cache) storage.
- Expressive, intuitive [database ORM](https://laravel.com/docs/eloquent).
- Database agnostic [schema migrations](https://laravel.com/docs/migrations).
- [Robust background job processing](https://laravel.com/docs/queues).
- [Real-time event broadcasting](https://laravel.com/docs/broadcasting).

Laravel is accessible, powerful, and provides tools required for large, robust applications.

## Learning Laravel

Laravel has the most extensive and thorough [documentation](https://laravel.com/docs) and video tutorial library of all modern web application frameworks, making it a breeze to get started with the framework.

If you don't feel like reading, [Laracasts](https://laracasts.com) can help. Laracasts contains over 1500 video tutorials on a range of topics including Laravel, modern PHP, unit testing, and JavaScript. Boost your skills by digging into our comprehensive video library.

## Laravel Sponsors

We would like to extend our thanks to the following sponsors for funding Laravel development. If you are interested in becoming a sponsor, please visit the Laravel [Patreon page](https://patreon.com/taylorotwell).

### Premium Partners

- **[Vehikl](https://vehikl.com/)**
- **[Tighten Co.](https://tighten.co)**
- **[Kirschbaum Development Group](https://kirschbaumdevelopment.com)**
- **[64 Robots](https://64robots.com)**
- **[Cubet Techno Labs](https://cubettech.com)**
- **[Cyber-Duck](https://cyber-duck.co.uk)**
- **[Many](https://www.many.co.uk)**
- **[Webdock, Fast VPS Hosting](https://www.webdock.io/en)**
- **[DevSquad](https://devsquad.com)**
- **[Curotec](https://www.curotec.com/services/technologies/laravel/)**
- **[OP.GG](https://op.gg)**

## Contributing

Thank you for considering contributing to the Laravel framework! The contribution guide can be found in the [Laravel documentation](https://laravel.com/docs/contributions).

## Code of Conduct

In order to ensure that the Laravel community is welcoming to all, please review and abide by the [Code of Conduct](https://laravel.com/docs/contributions#code-of-conduct).

## Security Vulnerabilities

If you discover a security vulnerability within Laravel, please send an e-mail to Taylor Otwell via [taylor@laravel.com](mailto:taylor@laravel.com). All security vulnerabilities will be promptly addressed.

## License

The Laravel framework is open-sourced software licensed under the [MIT license](https://opensource.org/licenses/MIT).


## Memo

# ローカルサーバ起動（laravelのアプリルートパスをカレントディレクトリにする）
cd C:\Users\nando\Documents\GitHub\Stocker\src\php\stocker
php -S localhost:8000 -t public

# パッケージリスト更新
sudo yum -y update
# phpインストール
sudo yum install -y php-mbstring php-openssl php-xml unzip
# composerインストール
php -r "copy('https://getcomposer.org/installer', 'composer-setup.php');"
sudo php composer-setup.php --install-dir=/usr/local/bin --filename=composer
composer -V

# phpインストール
ls /usr/bin/php
sudo ln /usr/bin/php
sudo yum -y install http://rpms.famillecollet.com/enterprise/remi-release-7.rpm
sudo yum -y remove php php-pdo php-mbstring
sudo yum -y install php72 php72-mbstring php72-pdo
sudo ln -s /usr/bin/php72 /usr/bin/php

# パスの設定
sudo yum -y install php72-php php72-php-common php72-php-devel php72-php-manual php72-php-pdo php72-php-mbstring php72-php-json php72-php-xml
composer update

# PHPとLaravelのバージョン確認
php -v
laravel -v

# Laravelのアプリ作成
composer create-project <使用するライブラリなどの名前> <ライブラリなどをインストールするディレクトリ名> <バージョン指定などのオプション>
composer create-project --prefer-dist laravel/laravel <アプリ名> "5.8.*"

# 新しく作成したアプリのディレクトリへと移動
cd <アプリ名>

# ルート表示
php artisan route:list

# ローカルサーバーを起動する
php artisan serve --port=8080

# すべてのファイルをステージングする
git add .

# コミットメッセージと共にコミットします
git commit -m "set up bootstrap4"

# SQLiteデータベースの作成
sqlite3 database/database.sqlite
.tables
.exit

# モデルの作成
php artisan make:model <新しく作成するモデル名> 
php artisan make:model -m <モデル名>   (マイグレーションも自動実行)

# Controller の作成
php artisan make:controller <コントローラー名> --resource --model=<モデル名>

# マイグレーションの実行
php artisan migrate

# Tinker(コンソールでのデータ作成) 終了時はexitを入力
php artisan tinker

# シーダー作成
php artisan make:seeder CategoriesTableSeeder
# 作成したシーダーファイルを読み込み
composer dump-autoload

# Font Awesomeのインストール
npm install

# Font Awesomeインストール後にGitでコミット
git add .
git commit -m "add Font Awesome"

# rutorika-sortableをパッケージマネージャでインストール
composer require illuminate/support
composer require rutorika/sortable 7.0.0

# rutorika-sortableのインストール後にコミット
git add .
git commit -m "install rutorika-sortable"

# resources/views/layouts/app.blade.php を編集後にGitでコミット
git add .
git commit -m "change layouts/app.blade.php"

# JavaScriptのライブラリのインストール
npm install

# JavaScript/CSSのビルド
npm run dev

# Laravelのログイン/ログアウト機能を使用
php artisan make:auth

# Heroku CLI
curl -OL https://cli-assets.heroku.com/heroku-linux-x64.tar.gz && tar zxf heroku-linux-x64.tar.gz && rm -f heroku-linux-x64.tar.gz && sudo mv heroku /usr/local && echo 'PATH=/usr/local/heroku/bin:$PATH' >> $HOME/.bash_profile

# Herokuにビルドパックを追加
heroku buildpacks:set heroku/php  -a <作成するアプリ名>
heroku buildpacks:add heroku/nodejs  -a <作成するアプリ名>

# HerokuのデータベースにPostgresqlを使用
heroku addons:create heroku-postgresql:hobby-dev -a <作成するアプリ名>

# Herokuのデータベース設定を確認
heroku config:get DATABASE_URL -a <作成するアプリ名> 

# 確認したデータベース設定を環境変数として設定
heroku config:set DB_CONNECTION=pgsql -a <作成するアプリ名>
heroku config:set DB_DATABASE=<データベース名> -a <作成するアプリ名>
heroku config:set DB_HOST=<ホスト> -a <作成するアプリ名>
heroku config:set DB_PASSWORD=<パスワード> -a <作成するアプリ名>
heroku config:set DB_PORT=<ポート> -a <作成するアプリ名>
heroku config:set DB_USERNAME=<ユーザー> -a <作成するアプリ名>

# Laravelの本番環境用のキーを生成
php artisan key:generate --show

# 生成したキーを環境変数として設定
heroku config:set APP_KEY=<生成されたキー> -a <作成するアプリ名>