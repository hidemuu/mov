using Mov.Schemas.DesignPatterns.Structuals.Bridges.Renderers;
using Mov.Schemas.Units.Shapes;
using Mov.Utilities.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Graphics
{
    public class GraphicObject : ValueObjectBase<GraphicObject>
    {
        #region フィールド

        private readonly IRenderer renderer;

        #endregion フィールド

        #region プロパティ

        public virtual string Name { get; } = "Group";

        public IShape Shape { get; }

        public string Color { get; }

        private Lazy<List<GraphicObject>> children = new Lazy<List<GraphicObject>>();
        public List<GraphicObject> Children => children.Value;


        #endregion プロパティ

        #region コンストラクタ

        public GraphicObject(IShape shape, string color, IRenderer renderer)
        {
            this.Shape = shape;
            this.Color = color;
            this.renderer = renderer;
        }


        #endregion コンストラクタ

        #region メソッド

        public override string ToString()
        {
            var sb = new StringBuilder();
            Print(sb, 0);
            return sb.ToString();
        }

        #endregion メソッド

        #region 内部メソッド

        protected override bool EqualCore(GraphicObject other)
        {
            return this.Name.Equals(other.Name) && this.Color.Equals(other.Color);
        }

        protected override int GetHashCodeCore()
        {
            return this.Name.GetHashCode() ^ this.Color.GetHashCode();
        }


        private void Print(StringBuilder sb, int depth)
        {
            sb.Append(new string('*', depth))
              .Append(string.IsNullOrWhiteSpace(Color) ? string.Empty : $"{Color} ")
              .AppendLine($"{Name}");
            foreach (var child in Children)
                child.Print(sb, depth + 1);
        }

        #endregion 内部メソッド

    }
}
