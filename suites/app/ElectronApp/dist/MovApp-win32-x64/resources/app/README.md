# 前段取

index.html を変更（./をつける）

<script src="./_framework/blazor.webassembly.js"></script>
<base href="./" />

# 実行方法

下記どちらかをこのカレントディレクトリで実行
npx electron .
npm start

# デスクトップアプリ化

## Windows

npx electron-packager . MovApp --platform=win32 --arch=x64 --out=dist --overwrite

## macOS

npx electron-packager . MovApp --platform=darwin --arch=x64 --out=dist --overwrite
