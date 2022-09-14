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
        private string path;
        private Encoding encoding;

        #endregion フィールド

        #region コンストラクター

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="path">ファイルパス</param>
        public XmlSerializer(string endpoint, string path, string encoding)
        {
            this.endpoint = endpoint;
            this.path = Path.Combine(endpoint, path);
            if (string.IsNullOrEmpty(Path.GetExtension(path))) this.path += DbConstants.PATH_EXTENSION_XML;
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
            using (var stream = new StreamReader(path))
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
            using (var stream = new StreamWriter(path, false, encoding))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                serializer.Serialize(stream, obj);
            }
        }

        #endregion メソッド
    }
}