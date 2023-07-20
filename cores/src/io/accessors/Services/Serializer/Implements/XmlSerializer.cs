using System.IO;

namespace Mov.Core.Accessors.Services.Serializer.Implements
{
    /// <summary>
    /// XMLシリアライザー
    /// </summary>
    public class XmlSerializer : ISerializer
    {
        #region field

        private readonly IAccessService service;

        #endregion field

        #region constructor

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="path">ファイルパス</param>
        public XmlSerializer(IAccessService service)
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
            using (var stream = new StreamReader(Path.Combine(service.FileValue.Path, url)))
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(TResponse));
                return (TResponse)serializer.Deserialize(stream);
            }
        }

        /// <summary>
        /// シリアライズしてファイルに書き込み
        /// </summary>
        /// <param name="obj"></param>
        public TResponse Post<TRequest, TResponse>(string url, TRequest obj)
        {
            using (var stream = new StreamWriter(Path.Combine(service.FileValue.Path, url), false, service.Encoding.Value))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(TRequest));
                serializer.Serialize(stream, obj);
                return default;
            }
        }

        #endregion method
    }
}