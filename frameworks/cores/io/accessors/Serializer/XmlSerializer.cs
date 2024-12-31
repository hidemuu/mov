using Mov.Core.Accessors.Models;
using System.IO;
using System.Xml;

namespace Mov.Core.Accessors.Serializer
{
    /// <summary>
    /// XMLシリアライザー
    /// </summary>
    public class XmlSerializer : IFileSerializer
    {

        #region property

        public EncodingValue Encoding { get; }

        #endregion property

        #region constructor

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="path">ファイルパス</param>
        public XmlSerializer(EncodingValue encoding)
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
            var xmlSettings = new XmlReaderSettings() { CheckCharacters = false };
            using (var streamReader = new StreamReader(url, Encoding.Value))
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
        public TResponse Serialize<TRequest, TResponse>(string url, TRequest obj)
        {
            using (var streamWriter = new StreamWriter(url, false, Encoding.Value))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(TRequest));
                serializer.Serialize(streamWriter, obj);
                return default;
            }
        }

        #endregion method
    }
}