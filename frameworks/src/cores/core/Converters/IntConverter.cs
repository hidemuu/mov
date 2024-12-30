namespace Mov.Core.Converters
{
    public static class IntConverter
    {
        public static string ToHEX(int val)
        {
            return string.Format("0x{0:x8} [HEX]", val);
        }
    }
}
