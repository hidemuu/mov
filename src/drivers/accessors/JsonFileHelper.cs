using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Accessors
{
    public class JsonFileHelper : IFileHelper
    {
        private const string EXTENSION = ".json";
        private string path;
        private Encoding encoding;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <param name="encode">エンコード</param>
        public JsonFileHelper(string path, string encoding)
        {
            this.path = path;
            if (string.IsNullOrEmpty(Path.GetExtension(path))) this.path += EXTENSION;
            this.encoding = Encoding.GetEncoding(encoding);
        }

        /// <summary>
        /// データをファイルから読み出して指定クラスにデシリアライズ
        /// </summary>
        /// <typeparam name="T"></typeparam>
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
    }
}
