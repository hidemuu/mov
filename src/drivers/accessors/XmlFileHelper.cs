using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Accessors
{
    public class XmlFileHelper : IFileHelper
    {
        private const string EXTENSION = ".xml";
        private string path;
        private Encoding encoding;
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="path">ファイルパス</param>
        public XmlFileHelper(string path, string encoding)
        {
            this.path = path;
            if (string.IsNullOrEmpty(Path.GetExtension(path))) this.path += EXTENSION;
            this.encoding = Encoding.GetEncoding(encoding);
        }

        /// <summary>
        /// データをファイルから読み出して指定クラスにデシリアライズ
        /// </summary>
        /// <returns></returns>
        public T Read<T>()
        {
            using (var stream = new StreamReader(path))
            {
                var serializer = new XmlSerializer(typeof(T));
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
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stream, obj);
            }
        }
    }
}
