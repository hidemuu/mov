using Newtonsoft.Json;
using System.IO;

namespace Mov.Core.Accessors.Services.Serializer.Implements
{
    /// <summary>
    /// Jsonファイルのシリアライザー
    /// </summary>
    public class JsonSerializer : ISerializer
    {
        #region field

        private readonly IFileService service;

        #endregion field

        #region constructor

        /// <summary>
        /// コンストラクター
        /// </summary>
        public JsonSerializer(IFileService service)
        {
            this.service = service;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// データをファイルから読み出して指定クラスにデシリアライズ
        /// </summary>
        /// <returns></returns>
        public TResponse Get<TResponse>(string url)
        {
            //Json文字列の取得
            string jsonString = ReadStream(url);
            //指定オブジェクトにデシリアライズ
            return JsonConvert.DeserializeObject<TResponse>(jsonString);
        }

        /// <summary>
        /// データをシリアライズしてファイルに書き込み
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public TResponse Post<TRequest, TResponse>(string url, TRequest obj)
        {
            //Jsonデータにシリアライズ
            var json = JsonConvert.SerializeObject(obj);
            WriteStream(url, json, false);
            return default;
        }

        #endregion method

        #region private method

        private string ReadStream(string url)
        {
            using (var stream = new StreamReader(Path.Combine(service.FileValue.Path, url), service.Encoding.Value))
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
            using (var stream = new StreamWriter(Path.Combine(service.FileValue.Path, url), isappend, service.Encoding.Value))
            {
                if (stream != null)
                {
                    stream.Write(json);
                }
            }
        }

        #endregion private method
    }
}