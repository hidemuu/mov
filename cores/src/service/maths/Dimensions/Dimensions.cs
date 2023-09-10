namespace Mov.Core.Models.Dimensions
{
    public static class Dimensions
    {
        public class Two : IDimension
        {
            public int Value => 2;
        }

        public class Three : IDimension
        {
            public int Value => 3;
        }
    }
}
