namespace Mov.Core.Models.ValueObjects.Shapes
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
