using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Contexts.Structures.Entities
{
    public class Building
    {
        public readonly List<Wall> Walls = new List<Wall>();

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var wall in Walls)
                sb.AppendLine(wall.ToString());
            return sb.ToString();
        }
    }
}
