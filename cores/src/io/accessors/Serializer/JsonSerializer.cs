using Mov.Core.Accessors.Models;
using Newtonsoft.Json;
using System.IO;

namespace Mov.Core.Accessors.Serializer
{
    /// <summary>
    /// Jsonファイルのシリアライザー
    /// </summary>
    public class JsonSerializer : IFileSerializer
    {
        #region property

        public EncodingValue Encoding { get; }

        #endregion property

        #region constructor

        /// <summary>
        /// コンストラクター
        /// </summary>
        public JsonSerializer(EncodingValue encoding)
        {
            Encoding = encoding;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// データをファイルから読み出して指定クラスにデシリアライズ
        /// </summary>
        /// <returns></returns>
        public TResponse Deserialize<TRequest, TResponse>(string url)
        {
            //Json文字列の取得
            string jsonString = string.Empty;
            using (var streamReader = new StreamReader(url, Encoding.Value))
            {
                if (streamReader != null)
                {
                    jsonString = streamReader.ReadToEnd();
                }
            }
            //指定オブジェクトにデシリアライズ
            return JsonConvert.DeserializeObject<TResponse>(jsonString);
        }

        /// <summary>
        /// データをシリアライズしてファイルに書き込み
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public TResponse Serialize<TRequest, TResponse>(string url, TRequest obj)
        {
            //Jsonデータにシリアライズ
            var json = JsonConvert.SerializeObject(obj);
            using (var streamWriter = new StreamWriter(url, false, Encoding.Value))
            {
                if (streamWriter != null)
                {
                    streamWriter.Write(json);
                }
            }
            return default;
        }

        #endregion method

    }
}