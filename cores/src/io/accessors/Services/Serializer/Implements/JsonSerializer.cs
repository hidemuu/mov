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
            string jsonString = this.service.Read(url);
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
            this.service.Write(url, json, false);
            return default;
        }

        #endregion method

    }
}