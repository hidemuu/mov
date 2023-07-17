using Mov.Core.Models.Texts;
using System.Text;

namespace Mov.Core.Accessors.Models.Entities
{
    public sealed class FileParameter
    {
        #region property

        /// <summary>
        /// ファイルパス
        /// </summary>
        public FileValue FileUnit { get; }

        /// <summary>
        /// エンコード
        /// </summary>
        public EncodingValue Encoding { get; }

        #endregion property

        #region constructor

        public FileParameter(string path, EncodingValue encodeName)
        {
            FileUnit = new FileValue(path);
            Encoding = encodeName;
        }

        #endregion constructor

    }
}
