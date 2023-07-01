using Mov.Core.Models.ValueObjects.Units;
using System.Text;

namespace Mov.Core.Accessors.Models.Entities
{
    public sealed class FileParameter
    {
        #region property

        /// <summary>
        /// ファイルパス
        /// </summary>
        public FileUnit FileUnit { get; }

        /// <summary>
        /// エンコード
        /// </summary>
        public Encoding Encoding { get; }

        #endregion property

        #region constructor

        public FileParameter(string path, string encodeName = AccessConstants.ENCODE_NAME_UTF8)
        {
            FileUnit = new FileUnit(path);
            Encoding = Encoding.GetEncoding(encodeName);
        }

        #endregion constructor

    }
}
