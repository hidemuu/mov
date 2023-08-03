using System.IO;
using System.Xml;
using Mov.Core.Accessors.Services.Clients;
using Mov.Core.Accessors.Services.Clients.Implements;
using Mov.Core.Models.Connections;
using Mov.Core.Models.Texts;

namespace Mov.Core.Accessors.Services.Serializer.Implements
{
    /// <summary>
    /// XMLシリアライザー
    /// </summary>
    public class XmlSerializer : ISerializer
    {
        #region field

        private readonly IAccessClient client;

        #endregion field

        #region property

        public PathValue Endpoint { get; }

        public EncodingValue Encoding { get; }

        #endregion property

        #region constructor

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="path">ファイルパス</param>
        public XmlSerializer(PathValue endpoint, EncodingValue encoding)
        {
            this.Endpoint = endpoint;
            this.Encoding = encoding;
            this.client = new FileAccessClient(endpoint, encoding);
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
            using (var streamReader = this.client.CreateStreamReader(url))
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
            using (var stream = this.client.CreateStreamWriter(url, false))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(TRequest));
                serializer.Serialize(stream, obj);
                return default;
            }
        }

        #endregion method
    }
}