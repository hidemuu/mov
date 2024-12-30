using Mov.Core.Graphicers.Services.Renderers;
using Mov.Core.Graphicers.Services.Shapes;
using Mov.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Graphicers.Models.ValueObjects
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
            Shape = shape;
            Color = color;
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
            return Name.Equals(other.Name) && Color.Equals(other.Color);
        }

        protected override int GetHashCodeCore()
        {
            return Name.GetHashCode() ^ Color.GetHashCode();
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