using System;

namespace Mov.Schemas.Parameters.Errors
{
    public class Error
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// レベル
        /// </summary>
        public int Lv { get; set; } = 0;

        /// <summary>
        /// 解除可否
        /// </summary>
        public bool Clearable { get; set; } = true;

        /// <summary>
        /// 内容説明
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}
