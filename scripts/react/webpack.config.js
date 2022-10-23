var path    = require('path');
const outputPath = path.resolve(__dirname, 'public');

module.exports = {
  devtool: 'source-map',
    context: path.join(__dirname, "src"),
    entry: './index.jsx',
    //entry: './index.tsx',
  mode: 'development',
  output: {
    path: outputPath,
    filename: 'index.min.js',
    libraryTarget: 'commonjs2',
  },
  devServer: {
    contentBase: outputPath,
    open: true,
    historyApiFallback: true
  },
  resolve: {
      extensions: ['.webpack.js', '.web.js', '.ts', '.js', '.jsx', '.tsx']
  },
  devtool: "source-map",
  module: {
      rules: [
          {
              //test: /\.js[x]?$/,
              test: /\.tsx?$/,
              exclude: /(node_modules|bower_components)/,
              use: {
                  //loader: 'babel-loader',
                  loader: "ts-loader",
                  options: {
                    transpileOnly: true,
                    presets: [
                      '@babel/preset-env',
                      '@babel/preset-react' //ReactのPresetを追加
                    ],
                    plugins: [
                      'react-html-attrs',
                      '@babel/plugin-syntax-jsx'
                    ] //JSXパース用
                  }
              }
          }
      ]
  }
}