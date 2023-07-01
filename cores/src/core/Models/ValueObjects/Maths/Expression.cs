namespace Mov.Core.Models.ValueObjects.Maths
{
    /// <summary>
    /// 条件式
    /// </summary>
    public class Expression
    {
        /// <summary>
        /// 左辺
        /// </summary>
        public string LeftSide = string.Empty;

        /// <summary>
        /// 等号・不等号
        /// </summary>
        public string Sign = string.Empty;

        /// <summary>
        /// 右辺
        /// </summary>
        public string RightSide = string.Empty;
    }
}
