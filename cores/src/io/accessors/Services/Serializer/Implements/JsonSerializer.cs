using Mov.Core.Accessors.Services.Clients;
using Mov.Core.Accessors.Services.Clients.Implements;
using Mov.Core.Models.Connections;
using Mov.Core.Models.Texts;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace Mov.Core.Accessors.Services.Serializer.Implements
{
    /// <summary>
    /// Jsonファイルのシリアライザー
    /// </summary>
    public class JsonSerializer : ISerializer
    {
        #region property

        public PathValue Endpoint { get; }

        public EncodingValue Encoding { get; }

        #endregion property

        #region constructor

        /// <summary>
        /// コンストラクター
        /// </summary>
        public JsonSerializer(PathValue endpoint, EncodingValue encoding)
        {
            this.Endpoint = endpoint;
            this.Encoding = encoding;
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
            using (var streamReader = new StreamReader(this.Endpoint.Combine(url), this.Encoding.Value))
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
            using (var streamWriter = new StreamWriter(this.Endpoint.Combine(url), false, this.Encoding.Value))
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