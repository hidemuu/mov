using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace Mov.Accessors
{
    /// <summary>
    /// Jsonファイルのシリアライザー
    /// </summary>
    public class JsonSerializer : ISerializer
    {
        #region フィールド

        private readonly string basePath;
        private string path;
        private Encoding encoding;

        #endregion フィールド

        /// <summary>
        /// コンストラクター
        /// </summary>
        public JsonSerializer(string basePath, string relativePath, string encoding)
        {
            this.basePath = basePath;
            this.path = Path.Combine(basePath, relativePath);
            if (string.IsNullOrEmpty(Path.GetExtension(path))) this.path += DbConstants.PATH_EXTENSION_JSON;
            this.encoding = Encoding.GetEncoding(encoding);
        }

        #region メソッド

        /// <summary>
        /// データをファイルから読み出して指定クラスにデシリアライズ
        /// </summary>
        /// <returns></returns>
        public T Read<T>()
        {
            //Json文字列の取得
            string jsonString = ReadStream();
            //指定オブジェクトにデシリアライズ
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        /// <summary>
        /// データをシリアライズしてファイルに書き込み
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public void Write<T>(T obj)
        {
            //Jsonデータにシリアライズ
            var json = JsonConvert.SerializeObject(obj);
            WriteStream(json, false);
        }

        #endregion メソッド

        #region 内部メソッド

        private string ReadStream()
        {
            using (var stream = new StreamReader(this.path, encoding))
            {
                if (stream != null)
                {
                    return stream.ReadToEnd();
                }
            }
            return "";
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="json"></param>
        /// <param name="isappend">追記モード（falseなら上書き保存）</param>
        private void WriteStream(string json, bool isappend)
        {
            using (var stream = new StreamWriter(this.path, isappend, encoding))
            {
                if (stream != null)
                {
                    stream.Write(json);
                }
            }
        }

        #endregion 内部メソッド
    }
}