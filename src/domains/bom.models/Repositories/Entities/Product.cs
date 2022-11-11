using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Bom.Models
{
    /// <summary>
    /// Represents a product.
    /// </summary>
    public class Product : DbObject
    {

        /// <summary>
        /// カテゴリー
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 色
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// 納期
        /// </summary>
        public int DaysToManufacture { get; set; }

        /// <summary>
        /// メーカー
        /// </summary>
        public string Maker { get; set; }

        /// <summary>
        /// 形状
        /// </summary>
        public string Shape { get; set; }

        /// <summary>
        /// 幅
        /// </summary>
        public decimal Width { get; set; }

        /// <summary>
        /// 高さ
        /// </summary>
        public decimal Height { get; set; }

        /// <summary>
        /// 深さ
        /// </summary>
        public decimal Depth { get; set; }

        /// <summary>
        /// 標準価格
        /// </summary>
        public decimal StandardCost { get; set; }

        /// <summary>
        /// 定価
        /// </summary>
        public decimal ListPrice { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Returns the name of the product and the list price.
        /// </summary>
        public override string ToString() => $"{Name} \n{ListPrice}";
    }
}
