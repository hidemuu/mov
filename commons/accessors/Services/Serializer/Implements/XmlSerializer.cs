using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Accessors.Services.Serializer.Implements
{
    /// <summary>
    /// XMLシリアライザー
    /// </summary>
    public class XmlSerializer : ISerializer
    {
        #region field

        private readonly IAccessContext context;

        #endregion field

        #region constructor

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="path">ファイルパス</param>
        public XmlSerializer(IAccessContext context)
        {
            this.context = context;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// データをファイルから読み出して指定クラスにデシリアライズ
        /// </summary>
        /// <returns></returns>
        public TResponse Get<TResponse>(string url)
        {
            using (var stream = new StreamReader(Path.Combine(context.FileParameter.FileUnit.Path, url)))
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
            using (var stream = new StreamWriter(Path.Combine(context.FileParameter.FileUnit.Path, url), false, context.FileParameter.Encoding))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(TRequest));
                serializer.Serialize(stream, obj);
                return default;
            }
        }

        #endregion method
    }
}