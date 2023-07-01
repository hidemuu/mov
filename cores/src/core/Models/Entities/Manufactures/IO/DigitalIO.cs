using System;
using System.Text.RegularExpressions;

namespace Mov.Core.Models.Entities.Manufactures.IO
{
    /// <summary>
    /// デジタルI/O　１点分の情報
    /// </summary>
    public class DigitalIO : ICloneable
    {
        #region プロパティ

        /// <summary>
        /// デジタルIO名称
        /// </summary>
        public string Name { get; set; } = "";

        public int Size { get; set; }
        public string Header { get; private set; } = "";
        /// <summary>
        /// デジタルIOアドレス
        /// </summary>
        public int Address { get; set; }
        /// <summary>
        /// デジタルIOデータ型
        /// </summary>
        public DigitalIOType IOType { get; private set; }
        /// <summary>
        /// デジタルIO現在値
        /// </summary>
        public int Status { get; set; } = 0;

        #endregion プロパティ

        #region コンストラクター

        public DigitalIO()
        {

        }

        public DigitalIO(string header, int address, string name)
        {
            Header = header;
            Address = address;
            Name = name;
        }
        public DigitalIO(string headerAddressString, string name)
        {
            var header = Regex.Replace(headerAddressString, @"[0-9]", "");
            var addressString = Regex.Replace(headerAddressString, @"[^0-9]", "");
            if (int.TryParse(addressString, out int res))
            {
                Header = header;
                Address = res;
                Name = name;
            }
        }

        #endregion コンストラクター

        #region メソッド

        public void SetVal(int val)
        {
            Status = val;
        }

        /// <summary>
        /// クローン生成
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new DigitalIO(); //同じものを複製する
        }

        #endregion メソッド
    }
}
