using System.Text;

namespace Mov.Core.Converters
{
    public static class ByteConverter
    {
        /// <summary>
        /// バイト型配列を文字列に変換
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns>変換結果文字列</returns>
        public static string ToString(byte[] buffer)
        {
            string msg = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
            return msg;
        }
    }
}
