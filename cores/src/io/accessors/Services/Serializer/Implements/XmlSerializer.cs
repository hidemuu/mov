using System.IO;
using System.Xml;

namespace Mov.Core.Accessors.Services.Serializer.Implements
{
    /// <summary>
    /// XMLシリアライザー
    /// </summary>
    public class XmlSerializer : ISerializer
    {
        #region field

        private readonly IFileService service;

        #endregion field

        #region constructor

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="path">ファイルパス</param>
        public XmlSerializer(IFileService service)
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
            var xmlSettings = new XmlReaderSettings() { CheckCharacters = false };
            using (var streamReader = new StreamReader(Path.Combine(service.FileValue.Path, url)))
            using (var xmlReader = XmlReader.Create(streamReader, xmlSettings))
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(TResponse));
                return (TResponse)serializer.Deserialize(xmlReader);
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