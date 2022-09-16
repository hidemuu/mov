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

        private readonly string endpoint;
        private readonly Encoding encoding;

        #endregion フィールド

        /// <summary>
        /// コンストラクター
        /// </summary>
        public JsonSerializer(string endpoint, string encoding)
        {
            this.endpoint = endpoint;
            if (string.IsNullOrEmpty(Path.GetExtension(endpoint))) this.endpoint += DbConstants.PATH_EXTENSION_JSON;
            this.encoding = Encoding.GetEncoding(encoding);
        }

        #region メソッド

        /// <summary>
        /// データをファイルから読み出して指定クラスにデシリアライズ
        /// </summary>
        /// <returns></returns>
        public T Read<T>(string url)
        {
            //Json文字列の取得
            string jsonString = ReadStream(url);
            //指定オブジェクトにデシリアライズ
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        /// <summary>
        /// データをシリアライズしてファイルに書き込み
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public void Write<T>(string url, T obj)
        {
            //Jsonデータにシリアライズ
            var json = JsonConvert.SerializeObject(obj);
            WriteStream(url, json, false);
        }

        #endregion メソッド

        #region 内部メソッド

        private string ReadStream(string url)
        {
            using (var stream = new StreamReader(Path.Combine(this.endpoint, url), this.encoding))
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
        private void WriteStream(string url, string json, bool isappend)
        {
            using (var stream = new StreamWriter(Path.Combine(this.endpoint, url), isappend, this.encoding))
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