using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Accessors
{
    /// <summary>
    /// XMLシリアライザー
    /// </summary>
    public class XmlSerializer : ISerializer
    {
        #region フィールド

        private readonly string endpoint;
        private  readonly Encoding encoding;

        #endregion フィールド

        #region コンストラクター

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="path">ファイルパス</param>
        public XmlSerializer(string endpoint, string encoding)
        {
            this.endpoint = endpoint;
            if (string.IsNullOrEmpty(Path.GetExtension(endpoint))) this.endpoint += DbConstants.PATH_EXTENSION_XML;
            this.encoding = Encoding.GetEncoding(encoding);
        }

        #endregion コンストラクター

        #region メソッド

        /// <summary>
        /// データをファイルから読み出して指定クラスにデシリアライズ
        /// </summary>
        /// <returns></returns>
        public T Read<T>()
        {
            using (var stream = new StreamReader(this.endpoint))
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stream);
            }
        }

        /// <summary>
        /// シリアライズしてファイルに書き込み
        /// </summary>
        /// <param name="obj"></param>
        public void Write<T>(T obj)
        {
            using (var stream = new StreamWriter(this.endpoint, false, this.encoding))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                serializer.Serialize(stream, obj);
            }
        }

        #endregion メソッド
    }
}